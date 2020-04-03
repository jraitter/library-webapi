<template>
  <div class="about text-center">{{ authors }}</div>
</template>

<script>
export default {
  name: "Profile",
  mounted() {
    this.$store.dispatch("getAuthors");
  },
  computed: {
    authors() {
      return this.$store.state.authors;
    }
  }
};
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
