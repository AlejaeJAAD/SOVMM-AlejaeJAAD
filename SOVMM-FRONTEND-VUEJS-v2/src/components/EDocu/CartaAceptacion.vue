<template>
  <v-card flat style="margin-bottom: -0.5rem">
    <v-form>
      <v-row>
        <v-col cols="12">
          <a @click="styleButton" style="color: inherit; text-decoration: none;" href="https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+ACEPTACION.pdf" target="_blank">
            <v-btn large dark @click="styleButton" :outlined="!clicked" :color="!clicked ? 'grey darken-3' : 'black'" :class="!clicked ? 'white--text' : ''">
              Descarga el formato de la carta de presentacion
              <v-icon class="ml-2">mdi-download</v-icon>
            </v-btn>
          </a>
          <form action="https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+ACEPTACION.pdf" method="get"></form>
        </v-col>
        <v-col cols="12">
          <v-card-subtitle>
            Agrega tu carta de aceptacion
            <v-icon>mdi-arrow-down-bold</v-icon>
          </v-card-subtitle>
          <document-handler single v-model="cartAceptacion"></document-handler>
        </v-col>
      </v-row>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="postDocument" color="success" class="text-center" dark>Subir documento</v-btn>
        <v-spacer></v-spacer>
      </v-card-actions>
      <v-card flat style="background-color: #333333" class="text-center white--text mt-5">
        EL DOCUMENTO MOSTRADO DEBAJO ES UN EJEMPLO DE CARTA DE ACEPTACION <br />
        CARGAR CARTA DE ACEPTACION CORRESPONDIENTE PARA SU ACTUALIZACION
      </v-card>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-center">
          <v-card
            v-for="document in selectedProyecto.cartAceptacion"
            :key="document"
            style="width: 100%; margin: 1rem; margin-bottom: -1rem
                "
          >
            <pdf :src="document" :page="currentPage" @num-pages="pageCount = $event" @page-loaded="currentPage = $event"> </pdf>
          </v-card>
        </v-col>
        <v-col cols="12" class="d-flex align-center justify-center">
          <v-card flat style="margin-bottom: -3.2rem;">
            <v-card-actions>
              <v-container>
                <v-row dense>
                  <v-col
                    ><v-btn outlined @click="prevPage"><v-icon>mdi-arrow-left-drop-circle-outline</v-icon></v-btn></v-col
                  >
                  <v-col
                    ><v-btn outlined>{{ currentPage }} / {{ pageCount }}</v-btn></v-col
                  >
                  <v-col
                    ><v-btn outlined @click="nextPage"><v-icon>mdi-arrow-right-drop-circle-outline</v-icon></v-btn></v-col
                  >
                </v-row>
              </v-container>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-form>
  </v-card>
</template>

<script>
import DocumentHandler from "@/components/Global/DocumentHandler";
import pdf from "vue-pdf";
import Axios from "axios";

export default {
  props: ["selectedProyecto", "selectedPresidencia"],
  name: "CartaAceptacion",
  components: {
    DocumentHandler,
    pdf
  },
  data() {
    return {
      colortxt: "black",
      clicked: false,
      currentPage: 1,
      pageCount: 0,
      page: "1",
      numPages: 0,
      isActive: false,
      color: "white",
      proy: {},
      image: "",
      textColor: "",
      status: "",
      info: [],
      placeChangedOnce: false,
      documents: [],
      isLoading: false,
      proyect: {},
      document: "",
      expand: false,
      cartAceptacion: []
    };
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    }
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
    }
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

            console.log(data);
          });
      } else {
        console.log(data);
      }
      */
      if (this.cartAceptacion.length !== 0) {
        const presidenciasActualizado = {
          id: this.selectedPresidencia.id,
          createdBy: this.selectedPresidencia.createdBy,
          nProyecto: this.selectedPresidencia.nProyecto,
          opcElegida: this.selectedPresidencia.opcElegida,
          periodo: this.selectedPresidencia.periodo,
          objetivo: this.selectedPresidencia.objetivo,
          justificacion: this.selectedPresidencia.justificacion,
          giroEmpresa: this.selectedPresidencia.giroEmpresa,
          RFC: this.selectedPresidencia.rfc,
          domicilio: this.selectedPresidencia.domicilio,
          Colonia: this.selectedPresidencia.colonia,
          Categoria: this.selectedPresidencia.categoria,
          Departamento: this.selectedPresidencia.departamento,
          CP: this.selectedPresidencia.cp,
          Fax: this.selectedPresidencia.fax,
          Ciudad: this.selectedPresidencia.ciudad,
          Estado: this.selectedPresidencia.estado,
          Telefono: this.selectedPresidencia.telefono,
          Ext: this.selectedPresidencia.ext,
          NTEmpresa: this.selectedPresidencia.ntEmpresa,
          puestoNTE: this.selectedPresidencia.puestoNTE,
          NFA: this.selectedPresidencia.nfa,
          puestoNFA: this.selectedPresidencia.puestoNFA,
          AsesorExterno: this.selectedPresidencia.asesorExterno,
          puestoAE: this.selectedPresidencia.puestoAE,
          proyectoId: this.selectedPresidencia.proyectoId,
          status: 2,
          createdDate: this.selectedPresidencia.createdDate,
          resolutionDate: new Date().toISOString()
        };

        this.isLoading = true;
        const fD = new FormData();
        for (let i = 0; i < this.cartAceptacion.length; i += 1) {
          fD.append(`document${i}`, this.cartAceptacion[i]);
        }
        Axios.post("documents", fD, {
          headers: this.$store.getters.getAuth
        }).then(res => {
          const proyect = this.info;
          proyect.cartAceptacion = res.data.docs;
          proyect.status = true;
          Axios.put(`proyectos/${proyect.id}`, proyect, {
            headers: this.$store.getters.getAuth
          });
          Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
            headers: this.$store.getters.getAuth
          }).then(() => {
            console.log(proyect, "Proyecto");
          });
        });
      }
    }
  }
};
</script>

<style scoped></style>
