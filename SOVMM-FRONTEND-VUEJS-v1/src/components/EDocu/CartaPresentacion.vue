<template>
  <v-card flat style="margin-bottom: -0.5rem">
    <v-form>
      <v-row>
        <v-col cols="12">
          <a @click="styleButton" style="color: inherit; text-decoration: none;"
             href="https://sovmm-03.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+PRESENTACI%C3%93N.pdf"
             target="_blank">
            <v-btn
              large
              dark
              @click="styleButton"
              :outlined="!clicked"
              :color="!clicked ? 'grey darken-3' : 'black'"
              :class="!clicked ? 'white--text':''"
            >
              Descarga el formato de la carta de presentacion
              <v-icon class="ml-2">mdi-download</v-icon>
            </v-btn>
          </a>
          <form action="https://sovmm-03.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+PRESENTACI%C3%93N.pdf"
                method="get">
          </form>
        </v-col>
        <v-col cols="12">
          <v-card-subtitle>
            Agrega tu carta de presentacion
            <v-icon>mdi-arrow-down-bold</v-icon>
          </v-card-subtitle>
          <document-handler single v-model="cartPres"></document-handler>
        </v-col>
      </v-row>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="postDocument" color="success"
               class="text-center" dark>Subir documento</v-btn>
        <v-spacer></v-spacer>
      </v-card-actions>
      <v-card flat style="background-color: #333333"
              class="text-center white--text mt-5">
        EL DOCUMENTO MOSTRADO DEBAJO ES POR DEFECTO <br>
        CARGAR CARTA DE PRESENTACION CORRESPONDIENTE PARA SU ACTUALIZACION
      </v-card>
      <v-row>
        <v-col cols="12">
          <v-card flat
                  v-for="document in this.info.cartPres" :key="document">
            <pdf :src="document"
                 :page="currentPage"
                 @num-pages="pageCount = $event"
                 @page-loaded="currentPage = $event"
                 style="display: inline-block; width: 100%;
                 position:relative;"
            >
            </pdf>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn class="primary" @click="prevPage">
                Pagina anterior
              </v-btn>
              <v-spacer></v-spacer>
              <v-btn class="ma-10">{{ currentPage }} / {{ pageCount }}</v-btn>
              <v-spacer></v-spacer>
              <v-btn class="primary" @click="nextPage">
                Pagina siguiente
              </v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-form>
  </v-card>
</template>

<script>
import DocumentHandler from '@/components/Global/DocumentHandler';
import pdf from 'vue-pdf';
import Axios from 'axios';
import Perfil from '@/assets/Perfil.png';

export default {
  props: {
    proyecto: Object,
    index: Number,
    mios: Boolean,
  },
  name: 'CartaPresentacion',
  components: {
    DocumentHandler,
    pdf,
  },
  data() {
    return {
      colortxt: 'black',
      clicked: false,
      currentPage: 1,
      pageCount: 0,
      page: '1',
      numPages: 0,
      img: Perfil,
      isActive: false,
      color: 'white',
      proy: {},
      image: '',
      textColor: '',
      status: '',
      info: [],
      placeChangedOnce: false,
      documents: [],
      isLoading: false,
      proyect: {},
      document: '',
      expand: false,
      cartPres: [],
    };
  },
  mounted() {
    Axios.get(`proyectos/${this.proyecto.proyectoId}`, {
      headers: this.$store.getters.getAuth,
    })
      .then((response) => {
        this.info = response.data;
        console.log(response, '8749');
        console.log(this.info, '3939393');
        // eslint-disable-next-line prefer-destructuring
      });
    this.$nextTick(() => {
      setTimeout(() => {
        if (this.$route.fullPath.includes(`#${this.proyecto.id}`)) {
          this.expand = true;
          this.$refs[this.report.id].scrollIntoView();
        }
      }, 1000);
    });
    console.log(this.proyecto, 'uyuyuyuy');
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
  },
  computed: {
    auth() {
      return this.$store.getters.getAuth || {};
    },
    noPrevPage() {
      return this.currentPage <= 1;
    },
    noNextPage() {
      return this.currentPage === this.pageCount;
    },
  },
  methods: {
    styleButton() {
      this.clicked = true;
      setTimeout(() => {
        this.clicked = false;
      }, 3000);
    },
    prevPage() {
      /* eslint-disable no-plusplus */
      this.currentPage--;
    },
    nextPage() {
      /* eslint-disable no-plusplus */
      this.currentPage++;
    },
    postDocument() {
      console.log(this.cartPres, 'ih');
      console.log(this.proy.cartPres, '49494');
      /*
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
            'Media-Type': 'application/pdf',
            Authorization: `Bearer ${this.$store.getters.getToken}`,
          },
        })
          .then((res) => {
            console.log('pw0w0w¿', res);
            // eslint-disable-next-line prefer-destructuring
            data.document = res.data.docs[0];

            console.log('put', data);
          });
      } else {
        console.log('puto', data);
      }
      */
      if (this.cartPres.length !== 0) {
        console.log('entro0');
        console.log(this.info, 'metodo');
        const presidenciasActualizado = {
          id: this.proyecto.id,
          createdBy: this.proyecto.createdBy,
          nProyecto: this.proyecto.nProyecto,
          opcElegida: this.proyecto.opcElegida,
          periodo: this.proyecto.periodo,
          objetivo: this.proyecto.objetivo,
          justificacion: this.proyecto.justificacion,
          giroEmpresa: this.proyecto.giroEmpresa,
          RFC: this.proyecto.rfc,
          domicilio: this.proyecto.domicilio,
          Colonia: this.proyecto.colonia,
          Categoria: this.proyecto.categoria,
          Departamento: this.proyecto.departamento,
          CP: this.proyecto.cp,
          Fax: this.proyecto.fax,
          Ciudad: this.proyecto.ciudad,
          Estado: this.proyecto.estado,
          Telefono: this.proyecto.telefono,
          Ext: this.proyecto.ext,
          NTEmpresa: this.proyecto.ntEmpresa,
          puestoNTE: this.proyecto.puestoNTE,
          NFA: this.proyecto.nfa,
          puestoNFA: this.proyecto.puestoNFA,
          AsesorExterno: this.proyecto.asesorExterno,
          puestoAE: this.proyecto.puestoAE,
          proyectoId: this.proyecto.proyectoId,
          status: 2,
          createdDate: this.proyecto.createdDate,
          resolutionDate: new Date().toISOString(),
        };

        this.isLoading = true;
        const fD = new FormData();
        for (let i = 0; i < this.cartPres.length; i += 1) {
          fD.append(`document${i}`, this.cartPres[i]);
        }
        Axios.post('documents', fD, {
          headers: this.$store.getters.getAuth,
        }).then((res) => {
          const proyect = this.info;
          console.log(res.data.docs, 'tutut');
          console.log(proyect, 'utyt');
          proyect.cartPres = res.data.docs;
          proyect.status = true;
          Axios.put(`proyectos/${proyect.id}`, proyect, {
            headers: this.$store.getters.getAuth,
          });
          Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
            headers: this.$store.getters.getAuth,
          }).then(() => {
            this.$store.dispatch('fetchMyPresidencias');
            this.$store.dispatch('fetchPresidencias');
            console.log(proyect, 'oororor');
          });
        });
      }
    },
  },
};
</script>

<style scoped>

</style>
