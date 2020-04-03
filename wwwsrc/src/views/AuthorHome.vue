<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 col-md-6">
        <authors />
      </div>
      <div class="col-12 col-md-6">
        <ul id="example-1">
          <li v-for="item in activeBook" :key="item.id">Book: {{ item.title }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import Authors from "@/components/Authors";
export default {
  name: "authorhome",
  mounted() {
    this.$store.dispatch("getAuthors");
  },
  components: {
    Authors
  },
  computed: {
    activeBook() {
      return this.$store.state.activeBook;
    }
  }
};
</script>
