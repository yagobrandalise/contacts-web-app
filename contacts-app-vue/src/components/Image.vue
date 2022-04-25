<template>
  <div>
    <div>
      <v-img
        transition="fade-transition"
        class="image-display"
        height="200"
        width="200"
        cover=""
        :src="'data:image/png;base64, ' + modelValue"
      >
        <div class="add-image-text" v-if="!modelValue">
          <a class="image-link" @click="addfile"> Add Picture </a>
        </div>
      </v-img>
      <input
        style="display: none"
        type="file"
        ref="image"
        @change="onFilePicked"
        accept="image/*"
      />
    </div>
    <div width="160px" class="pa-2 text-center">
      <p class="font-weight-medium">
        <span class="image-link" style="margin-left: 20px" v-if="modelValue" @click="removeFile">
          Remove Picture</span
        >
      </p>
    </div>
  </div>
</template>
<script>
import { toBase64 } from "@/helpers/image-helper.js";
import imageCompression from "browser-image-compression";

export default {
  props: ["modelValue"],
  data: () => ({
    localImage: "",
  }),
  computed: {
    image: {
      get() {
        return this.modelValue;
      },
      set(val) {
        this.localImage = val;
        this.$emit('update:modelValue', val);
      },
    },
  },
  methods: {
    addfile() {
      this.$refs.image.value = null;
      this.$refs.image.click();
    },
    removeFile() {
      this.$refs.image.value = null;
      this.image = null;
    },
    async onFilePicked(e) {
      if (e.target.files.length > 0) {
        const compressedFile = await imageCompression(e.target.files[0], {
          maxSizeMB: 1,
          maxWidthOrHeight: 500,
          useWebWorker: true,
        });

        this.image = await toBase64(compressedFile, this.asText);
      }
    },
  },
};
</script>
<style scoped>

.v-card {
  border-radius: 50%;
}

.image-link {
    cursor: pointer;
  }
  
.image-display {
  margin-left: 140px;
  border-radius: 50%;
}

.add-image-text {
  margin-top: 90px;
  margin-left: 60px;

}
</style>