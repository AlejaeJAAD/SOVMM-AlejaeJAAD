<template>
  <div>
    <v-card v-for="(file,index) in docArray"
            :key="index"
            elevation="3"
            rounded
            style="position: relative;display: block;
                    margin-left: auto;
                    margin-right: auto;">
      <v-avatar
        tile
        class="mt-15"
        size="300">
        <v-img :src="file"></v-img>
      </v-avatar>
    </v-card>
    <v-file-input
      :disabled="disabled"
      prepend-inner-icon="mdi-file-document"
      placeholder="Presiona aquí"
      prepend-icon=""
      :loading="uploading"
      solo-inverted
      :multiple="!single"
      v-model="files"
      accept="application/pdf"
      chips
      persistent-hint
      :error-messages="errors"
      :style="iStyles"
    />
  </div>
</template>

<script>

export default {
  props: {
    single: Boolean,
    iStyles: Array,
    disabled: Boolean,
    uploading: Boolean,
  },
  name: 'DocumentHandler',
  data() {
    return {
      files: null,
      errors: [],
      docArray: [],
      icon_outer: 'mdi-cloud-upload',
    };
  },
  watch: {
    files() {
      const finalArray = [];
      if (this.files.length > 1) {
        this.files = this.files.slice(0, 1);
        this.errors.push(`Se elimino el documento ${this.files.length - 1}. Solo se permite 1 documento!`);
        setTimeout(() => {
          this.errors = [];
        }, 1000);
      }
      if (!this.single) {
        for (let i = 0; i < this.files.length; i += 1) {
          const file = this.files[i];
          try {
            const document = file;
            const lector = new FileReader();
            lector.readAsDataURL(document);
            let result;
            lector.onload = (event) => {
              result = event.target.result;
              finalArray.push(result);
            };
          } catch (e) {
            console.log(e);
          }
        }
        this.docArray = finalArray;
      }
      setTimeout(() => {
        this.errors = [];
      }, 5000);
      this.filesChanged();
    },
  },
  methods: {
    filesChanged() {
      this.$emit('input', this.files);
    },
  },
  created() {
  },
};
</script>

<style scoped>

</style>
