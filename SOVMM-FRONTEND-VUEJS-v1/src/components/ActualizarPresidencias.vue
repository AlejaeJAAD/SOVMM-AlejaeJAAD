<template>
  <div>
    <v-card v-if="!isLoading" elevation="5" >
      <v-card-title>Nuevo Proyecto</v-card-title>
      <v-card-text>
        <v-row ref="place">
          <v-col cols="12">
            <v-text-field solo shaped
                          placeholder="Nombre de proyecto:" v-model="nproyecto"
            ></v-text-field>
            <v-row>
              <v-col cols="4">
                <v-autocomplete solo
                                placeholder="Periodo:" v-model="periodo"
                                :items="['Enero - Junio', 'Agosto - Diciembre']"
                ></v-autocomplete>
              </v-col>
              <v-col cols="4">
                <v-autocomplete solo
                                placeholder="Opcion elegida:" v-model="opcionElegida"
                                :items="['Banco de proyectos', 'Propuesta propia', 'Trabajador']"
                ></v-autocomplete>
              </v-col>
              <v-col cols="4">
                <v-autocomplete solo
                                placeholder="Categoria:" v-model="categoria"
                                :items="['Base de datos', 'Web', 'Aplicacion Android', 'Redes']"
                ></v-autocomplete>
              </v-col>
              <v-col cols="12">
                <v-autocomplete solo
                                placeholder="Departamento:" v-model="departamento"
                                :items="[
                            'Departamento de Metal-Mecanica',
                            'Departamento de Sistemas y Computacion']"
                ></v-autocomplete>
              </v-col>
            </v-row>
            <v-textarea no-resize :rows="3" solo
                        placeholder="Objetivo de proyecto."
                        counter maxlength="2000" v-model="objetivo">
            </v-textarea>
            <v-textarea no-resize :rows="3" solo
                        placeholder="Justificacion de proyecto"
                        counter maxlength="2000" v-model="justificacion">
            </v-textarea>
            <br>
            <v-chip style="margin-bottom: 5px">Datos empresa</v-chip>
            <v-divider></v-divider>
            <image-handler style="margin-top: 20px" v-model="image_s"></image-handler>
            <v-row>
              <v-col cols="8">
                <v-autocomplete solo
                                placeholder="Giro, Ramo o Sector:" v-model="giroEmpresa"
                                :items="['Industrial', 'Servicios', 'Publico', 'Privado', 'Otro']"
                ></v-autocomplete>
              </v-col>
              <v-col cols="4">
                <v-text-field solo shaped
                              placeholder="RFC:" v-model="RFC"
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Domicilio (Calle, Numero, Colonia):" v-model="domicilio"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Colonia:" v-model="Colonia"
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="C.P.:" v-model="CP"
                ></v-text-field>
              </v-col>
              <v-col cols="3">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Fax:" v-model="Fax"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Ciudad:" v-model="Ciudad"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Estado:" v-model="Estado"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Telefono:" v-model="Telefono"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Ext.:" v-model="Ext"
                ></v-text-field>
              </v-col>
              <v-col cols="8">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Nombre del(la) Titular de la empresa:"
                              v-model="NTEmpresa"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Puesto:" v-model="puestoNTE"
                ></v-text-field>
              </v-col>
              <v-col cols="8">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Nombre de la persona que firmará el acuerdo de trabajo."
                              v-model="NFA"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Puesto:" v-model="puestoNFA"
                ></v-text-field>
              </v-col>
              <v-col cols="8">
                <v-text-field
                  solo shaped style="margin-top: -30px"
                  placeholder="Asesor(a) Externo(a) (persona quién los supervisará en la empresa):"
                  v-model="AsesorExterno"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field solo shaped style="margin-top: -30px"
                              placeholder="Puesto:" v-model="puestoAE"
                ></v-text-field>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-btn shaped color="red" @click="$emit('onClose')">Cerrar</v-btn>
        <v-spacer></v-spacer>
        <v-btn shaped color="success"
               @click="postPresidencias">Crear proyecto</v-btn>
      </v-card-actions>
    </v-card>
    <v-card height="40vh" v-if="isLoading">
      <v-card-actions>
        <v-progress-circular
          style="margin:10% auto"
          size="90"
          indeterminate
          color="purple"
        ></v-progress-circular>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script>
import ImageHandler from '@/components/Global/ImageHandler';
import Axios from 'axios';

export default {
  name: 'ActualizarPresidencias',
  components: { ImageHandler },
  data() {
    return {
      pRes: '',
      place: {
      },
      placeChangedOnce: false,
      image_s: [],
      isLoading: false,
      nproyecto: '',
      departamento: '',
      objetivo: '',
      justificacion: '',
      opcionElegida: '',
      periodo: '',
      giroEmpresa: '',
      RFC: '',
      domicilio: '',
      Colonia: '',
      categoria: '',
      CP: '',
      Fax: '',
      Ciudad: '',
      Estado: '',
      Telefono: '',
      Ext: '',
      NTEmpresa: '',
      puestoNTE: '',
      NFA: '',
      puestoNFA: '',
      AsesorExterno: '',
      puestoAE: '',
    };
  },
  computed: {
    auth() {
      return this.$store.getters.getAuth || {};
    },
  },
  methods: {
    putPresidencias() {
      console.log(JSON.stringify(this.auth));
      if (this.image_s.length !== 0) {
        this.isLoading = true;
        const fD = new FormData();
        for (let i = 0; i < this.image_s.length; i += 1) {
          fD.append(`image${i}`, this.image_s[i]);
        }
        Axios.post('images', fD, {
          headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${this.$store.getters.getToken}`,
          },
        })
          .then((res) => {
            this.uploading = false;
            const newProyecto = {
              type: 'RESIDENCIAS',
              repImages: res.data.imgs,
              primerAsesoria: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf'],
              primerSeguimientoEv: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf'],
              segundaAsesoria: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf'],
              segundaSeguimientoEv: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf'],
              tercerAsesoria: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf'],
              tercerSeguimientoEv: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf'],
              anteProy: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-ANTEPROYECTO+DE+RESIDENCIAS+PROFESIONALES.pdf'],
              solicitudRes: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-SOLICITUD+DE+RESIDENCIAS+PROFESIONALES.pdf'],
              cartPres: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+PRESENTACI%C3%93N.pdf'],
              cartAceptacion: ['https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+ACEPTACION.pdf'],
              status: false,
            };
            console.log(newProyecto, 'uyuyuy');
            Axios.post('proyectos/new', newProyecto, { headers: this.auth })
              .then((proyecto) => {
                const newPresidencias = {
                  createdBy: this.$store.getters.getUser.id,
                  nProyecto: this.nproyecto,
                  departamento: this.departamento,
                  opcElegida: this.opcionElegida,
                  periodo: this.periodo,
                  objetivo: this.objetivo,
                  justificacion: this.justificacion,
                  giroEmpresa: this.giroEmpresa,
                  RFC: this.RFC,
                  domicilio: this.domicilio,
                  Colonia: this.Colonia,
                  Categoria: this.categoria,
                  CP: this.CP,
                  Fax: this.Fax,
                  Ciudad: this.Ciudad,
                  Estado: this.Estado,
                  Telefono: this.Telefono,
                  Ext: this.Ext,
                  NTEmpresa: this.NTEmpresa,
                  puestoNTE: this.puestoNTE,
                  NFA: this.NFA,
                  puestoNFA: this.puestoNFA,
                  AsesorExterno: this.AsesorExterno,
                  puestoAE: this.puestoAE,
                  proyectoId: proyecto.data.id,
                  status: 0,
                  createdDate: new Date().toISOString(),
                  likedBy: [],
                };
                console.log(newPresidencias, 'ailso');
                Axios.post('presidencias/new', newPresidencias, { headers: this.auth }).then(() => {
                  this.isLoading = false;
                  this.$emit('created', true);
                  this.$router.push('/inicio');
                });
              });
          });
      }
    },
  },
  mounted() {
    this.pRes = this.$store.getters.getMyPresidencias;
    console.log(this.pRes, 'PAP');
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
