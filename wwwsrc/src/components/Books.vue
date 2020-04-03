<template>
  <div class="books row">
    <!-- NOTE Props are data passed from parent to child component -->
    <book v-for="(bookObj) in books" :key="bookObj.id" :bookData="bookObj" />
  </div>
</template>

<script>
import Book from "./Book";

export default {
  name: "Books",
  mounted() {
    //NOTE mounted is fired when the component is 'mounted' to the page
    //NOTE '$' is a reference to the Root instance (main.js)
  },
  data() {
    return {};
  },
  //NOTE Computed's are watching the store for changes (observers) and are reactive to change
  //NOTE Computeds can be treated like getters (variable properties) and should always be used when getting data from the state
  computed: {
    //NOTE Computeds must always return a value
    books() {
      return this.$store.state.books;
    }
  },
  components: {
    Book
  }
};
</script>

<style></style>
