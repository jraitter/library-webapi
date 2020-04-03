<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 col-md-6">
        <books />
      </div>
      <div class="col-12 col-md-6">
        <ul id="example-1">
          <li v-for="item in activeAuthor" :key="item.id">Auhtor: {{ item.name }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import Books from "@/components/Books";
export default {
  name: "bookhome",
  mounted() {
    this.$store.dispatch("getBooks");
  },
  components: {
    Books
  },
  computed: {
    activeAuthor() {
      return this.$store.state.activeAuthor;
    }
  }
};
</script>
