<template>
  <v-card flat style="margin-bottom: -0.5rem">
    <v-form>
      <v-row>
        <v-col cols="12">
          <a @click="styleButton" style="color: inherit; text-decoration: none;" href="https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf" target="_blank">
            <v-btn large dark @click="styleButton" :outlined="!clicked" :color="!clicked ? 'grey darken-3' : 'black'" :class="!clicked ? 'white--text' : ''">
              Descarga el formato de tercer seguimiento
              <v-icon class="ml-2">mdi-download</v-icon>
            </v-btn>
          </a>
          <form action="https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf" method="get"></form>
        </v-col>
        <v-col cols="12">
          <v-card-subtitle>
            Agrega tu tercer seguimiento
            <v-icon>mdi-arrow-down-bold</v-icon>
          </v-card-subtitle>
          <document-handler single v-model="tercerSeguimientoEv"></document-handler>
        </v-col>
      </v-row>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="postDocument" color="success" class="text-center" dark>Subir documento</v-btn>
        <v-spacer></v-spacer>
      </v-card-actions>
      <v-card flat style="background-color: #333333" class="text-center white--text mt-5">
        EL DOCUMENTO MOSTRADO DEBAJO ES EL FORMATO DE TERCER SEGUIMIENTO EN BLANCO <br />
        NECESITAS CARGAR TU TERCER SEGUIMIENTO DE RESIDENCIAS PROFESIONALES CORRESPONDIENTE PARA SU ACTUALIZACION
      </v-card>
      <v-row>
        <v-col cols="12" class="d-flex align-center justify-center">
          <v-card
            flat
            v-for="document in selectedProyecto.tercerSeguimientoEv"
            :key="document"
            style="width: 100%;
                "
          >
            <pdf :src="document" :page="currentPage" @num-pages="pageCount = $event" @page-loaded="currentPage = $event"> </pdf>
          </v-card>
        </v-col>
        <v-col cols="12" class="d-flex align-center justify-center">
          <v-card flat style="margin-bottom: -2.5rem; margin-top: -3rem">
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
        <v-col cols="12">
          <v-card flat style="background-color: #333333; padding-top: -3rem; margin-bottom: -2rem" class="text-center white--text mt-5">
            SI AUN NO ES AGREGADO TU DOCUMENTO DE TERCER SEGUIMIENTO <br />
            EL BOTON DE ABAJO SOLO DESCARGARA EL FORMATO EN BLANCO DE TERCER SEGUIMIENTO HASTA QUE SEA AGREGADO EL NUEVO DOCUMENTO
          </v-card>
        </v-col>
        <v-col cols="12" v-for="document in selectedProyecto.tercerSeguimientoEv" :key="document">
          <a @click="styleButton" style="color: inherit; text-decoration: none;" :href="document" target="_blank">
            <v-btn style="margin-bottom: -4.5rem" dark @click="styleButton" :outlined="!clicked" :color="!clicked ? 'grey darken-3' : 'black'" :class="!clicked ? 'white--text' : ''">
              Descargar documento actualizado
              <v-icon class="ml-2">mdi-download</v-icon>
            </v-btn>
          </a>
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
  name: "TercerSeguimiento",
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
      tercerSeguimientoEv: []
    };
  },
  mounted() {
    Axios.get(`proyectos/${this.proyecto.proyectoId}`, {
      headers: this.$store.getters.getAuth
    }).then(response => {
      this.info = response.data;
      // eslint-disable-next-line prefer-destructuring
    });
    this.$nextTick(() => {
      setTimeout(() => {
        if (this.$route.fullPath.includes(`#${this.proyecto.id}`)) {
          this.expand = true;
          this.$refs[this.proyecto.id].scrollIntoView();
        }
      }, 1000);
    });
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
      if (this.tercerSeguimientoEv.length !== 0) {
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
          resolutionDate: new Date().toISOString()
        };

        this.isLoading = true;
        const fD = new FormData();
        for (let i = 0; i < this.tercerSeguimientoEv.length; i += 1) {
          fD.append(`document${i}`, this.tercerSeguimientoEv[i]);
        }
        Axios.post("documents", fD, {
          headers: this.$store.getters.getAuth
        }).then(res => {
          const proyect = this.info;
          proyect.tercerSeguimientoEv = res.data.docs;
          proyect.status = true;
          Axios.put(`proyectos/${proyect.id}`, proyect, {
            headers: this.$store.getters.getAuth
          });
          Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
            headers: this.$store.getters.getAuth
          }).then(() => {
            console.log(proyect);
          });
        });
      }
    }
  }
};
</script>

<style scoped></style>
