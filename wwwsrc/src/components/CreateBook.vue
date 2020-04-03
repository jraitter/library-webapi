<template>
  <div class="create-book">
    <form @submit.prevent="createBook">
      <input type="text" name="title" placeholder="Title..." v-model="newBook.title" required />
      <input type="text" name="author" placeholder="Author..." v-model="newBook.author" required />
      <input
        type="text"
        name="publication"
        placeholder="Publishing Company..."
        v-model="newBook.publication"
      />
      <!-- need a drop down in put for which library has book -->
      <button type="submit" class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "CreateBook",
  data() {
    return {
      newBook: {
        title: "",
        author: "",
        name: "",
        publication: "",
        libId: 1
      }
    };
  },
  methods: {
    createBook() {
      this.newBook.name = this.newBook.author;
      this.$store.dispatch("createBook", this.newBook);
    }
  }
};
</script>

<style></style>
