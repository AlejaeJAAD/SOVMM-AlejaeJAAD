<template>
  <div>
    <v-card v-for="(file, index) in imgArray" :key="index" elevation="16" rounded style="display: inline-block;margin: 5px">
      <v-avatar tile size="124">
        <v-img :src="file"></v-img>
      </v-avatar>
    </v-card>
    <v-file-input :disabled="disabled" prepend-inner-icon="mdi-camera" prepend-icon="" :loading="uploading" solo-inverted :multiple="!single" v-model="files" accept="image/png, image/jpeg, image/bmp" chips persistent-hint :error-messages="errors" :style="iStyles" />
  </div>
</template>

<script>
export default {
  props: {
    single: Boolean,
    iStyles: Array,
    disabled: Boolean,
    uploading: Boolean
  },
  name: "ImageHandler",
  data() {
    return {
      files: null,
      errors: [],
      imgArray: [],
      icon_outer: "mdi-cloud-upload"
    };
  },
  watch: {
    files() {
      const finalArray = [];
      if (this.files.length > 1) {
        this.files = this.files.slice(0, 1);
        this.errors.push(`Se elimino la imagen ${this.files.length - 1}. Solo se permite 1 imagen!`);
        setTimeout(() => {
          this.errors = [];
        }, 1000);
      }
      if (!this.single) {
        for (let i = 0; i < this.files.length; i += 1) {
          const file = this.files[i];
          try {
            const imagen = file;
            const lector = new FileReader();
            lector.readAsDataURL(imagen);
            let result;
            lector.onload = event => {
              result = event.target.result;
              finalArray.push(result);
            };
          } catch (e) {
            console.log(e);
          }
        }
        this.imgArray = finalArray;
      }
      setTimeout(() => {
        this.errors = [];
      }, 5000);
      this.filesChanged();
    }
  },
  methods: {
    filesChanged() {
      this.$emit("input", this.files);
    }
  },
  created() {}
};
</script>

<style scoped></style>
