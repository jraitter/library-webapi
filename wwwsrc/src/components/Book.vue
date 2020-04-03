<template>
  <div class="book col-6">
    <ul>
      <li>
        <h5 class="point" @click="getAuthor">{{ bookData.title }}</h5>
      </li>
    </ul>
  </div>
</template>


<script>
export default {
  name: "book",
  props: ["bookData", "bookIndex"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    getAuthor() {
      this.$store.dispatch("getCurrentAuthor", this.bookData.id);
    }
  },
  components: {}
};
</script>


<style scoped>
.point {
  cursor: pointer;
}
</style>