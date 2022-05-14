<template>
  <v-container>
    <v-card class="pa-4" elevation="5" shaped style="margin-bottom: 10px; margin-top: 20px">
      <v-form>
        <v-row style="padding: 10px">
          <v-col cols="12">
            <v-avatar  v-if="document" tile size="180">
              <v-img :src="document"></v-img>
            </v-avatar>
            <document-handler single v-model="documents"></document-handler>
          </v-col>
        </v-row>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn to="/" dark color="red">Cancelar</v-btn>
          <v-spacer></v-spacer>
          <v-btn @click="postDocument" color="success" dark>Aceptar</v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-form>
    </v-card>
  </v-container>
</template>

<script>
import DocumentHandler from '@/components/Global/DocumentHandler';
import Axios from 'axios';

export default {
  name: 'Document',
  components: { DocumentHandler },
  data() {
    return {
      placeChangedOnce: false,
      documents: [],
      document: null,
      isLoading: false,
    };
  },
  computed: {
    auth() {
      return this.$store.getters.getAuth || {};
    },
  },
  methods: {
    postDocument() {
      const data = {
        document: '',
      };
      if (this.documents.length > 0) {
        const fD = new FormData();
        for (let i = 0; i < this.documents.length; i += 1) {
          fD.append(`document${i}`, this.documents[i]);
        }
        Axios.post('documents', fD, {
          headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${this.$store.getters.getToken}`,
          },
        })
          .then((res) => {
            console.log(res);
            // eslint-disable-next-line prefer-destructuring
            data.document = res.data.docs[0];
            this.$store.dispatch('updateProyectos', data);
            this.$router.push('/inicio');
          });
      } else {
        this.$store.dispatch('updateProyectos', data);
        this.$router.push('/inicio');
      }
    },
  },
  watch: {
    documents() {
      console.log('e');
      try {
        const document = this.documents[0];
        const lector = new FileReader();
        lector.readAsDataURL(document);
        lector.onload = (event) => {
          this.document = event.target.result;
        };
      } catch (e) {
        console.log(e);
      }
    },
  },
  mounted() {
    this.$nextTick(() => {
      this.$refs.input.$el.focus();
    }, 100);
  },
};
</script>

<style scoped>
.tf{
  border: 0px !important;
}
</style>
