<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 text-right">
        <button v-if="!bookForm" @click="bookForm = true" class="btn btn-success">Add-Car</button>
        <button v-else @click="bookForm = false" class="btn btn-danger">cancel</button>
      </div>
      <div class="col-12">
        <create-book v-if="bookForm" />
      </div>
    </div>
  </div>
</template>

<script>
import CreateBook from "@/components/CreateBook";
export default {
  name: "home",
  data() {
    return {
      bookForm: false
    };
  },
  components: {
    CreateBook
  },
  computed: {}
};
</script>
