<template>
  <div class="authors row">
    <!-- NOTE Props are data passed from parent to child component -->
    <author v-for="(authorObj) in authors" :key="authorObj.id" :authorData="authorObj" />
  </div>
</template>

<script>
import Author from "./Author";

export default {
  name: "Authors",
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
    authors() {
      return this.$store.state.authors;
    }
  },
  components: {
    Author
  }
};
</script>

<style></style>
