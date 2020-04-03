<template>
  <div class="author col-6">
    <ul>
      <li>
        <h5 class="point" @click="getBook">{{ authorData.name }}</h5>
      </li>
    </ul>
  </div>
</template>


<script>
export default {
  name: "author",
  props: ["authorData", "authorIndex"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    getBook() {
      this.$store.dispatch("getCurrentBook", this.authorData.id);
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