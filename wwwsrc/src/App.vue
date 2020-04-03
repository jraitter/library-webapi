<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  name: "App",
  async beforeCreate() {
    try {
      await onAuth();
      if (this.$auth.isAuthenticated) {
        this.$store.dispatch("setBearer", this.$auth.bearer);
      }
    } catch (error) {
      console.error("authentication failed");
    }
    // this.$store.dispatch("getBooks");
    // this.$store.dispatch("getAuthors");
  },
  components: {
    Navbar
  }
};
</script>

<style></style>
