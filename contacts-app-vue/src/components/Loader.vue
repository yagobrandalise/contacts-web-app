<template>
  <v-container fluid fill-height>
    <v-row align-content="center" justify="center">
      <v-progress-circular
        :rotate="180"
        :size="150"
        :width="7"
        indeterminate
      >
      </v-progress-circular>
    </v-row>
  </v-container>
</template>

<style scoped>
.v-container {
  height: 100vh;
  max-width: 100%;
  z-index: 9999;
  position: fixed;
  background: rgba(255, 255, 255, 0.5);
}

.v-progress-circular {
  padding-top: 50%;
}

</style>