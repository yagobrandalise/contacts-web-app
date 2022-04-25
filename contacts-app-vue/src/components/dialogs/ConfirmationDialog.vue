<template>
  <v-dialog v-model="dialog">
    <v-card>
      <v-card-title>
        <b>
          <span>{{ title }}</span>
        </b>
      </v-card-title>
      <span class="pa-5">{{ message }}</span>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="confirm"> Yes </v-btn>
        <v-btn @click="cancel"> Cancel </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
export default {
  props: {
    title: String,
    message: String,
  },
  data: () => ({
    dialog: false,
  }),
  methods: {
    confirm() {
      this.dialog = false;
      this.$emit("on-confirm");
    },
    cancel() {
      this.dialog = false;
      this.$emit("on-cancel");
    },
  },
};
</script>

<style scoped>
.v-card {
  width: 300px;
  height: 150;
}
</style>