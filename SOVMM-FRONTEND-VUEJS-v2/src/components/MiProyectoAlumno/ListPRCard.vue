<template>
  <v-lazy
    v-model="isActive"
    :options="{
      threshold: 0.5
    }"
    style="width: auto;"
    min-height="auto"
    transition="fade-transition"
  >
    <v-card elevation="" :color="color" style="padding: 3px;">
      <v-card v-if="isActive" style="padding: 25px; margin-top: 10px;" elevation="3" shaped tile>
        <v-row justify="center">
          <v-col cols="12">
            <v-card-title style="margin-top: -20px"> ID: {{ presidencia.id }} </v-card-title>
            <v-card-subtitle>
              <h3 class="text-right">Categoria: {{ presidencia.categoria }}</h3>
              <h3>Creado por:</h3>
              <h4>{{ infoUser.firstName }} {{ infoUser.lastName }}</h4>
              <v-divider></v-divider>
              <br />
              <h3>Nombre de proyecto:</h3>
              <h4>{{ presidencia.nProyecto }}</h4>
              <br />
              <h3>Fecha de proyecto:</h3>
              <h4>{{ presidencia.createdDate }}</h4>
              <br />
              <h3>Periodo:</h3>
              <h4>{{ presidencia.periodo }}</h4>
              <br />
              <h3>Tipo de proyecto:</h3>
              <h4>{{ presidencia.opcElegida }}</h4>
              <br />
              <v-divider></v-divider>
              <br />
              <h3>Objetivo:</h3>
              <br />
              <h4>{{ presidencia.objetivo }}</h4>
              <br />
              <br />
              <v-divider></v-divider>
              <br />
              <h3>Justificacion:</h3>
              <br />
              <h4>{{ presidencia.justificacion }}</h4>
              <br />
            </v-card-subtitle>
          </v-col>
          <v-col cols="12">
            <v-expansion-panels popout>
              <v-expansion-panel>
                <v-expansion-panel-header>Detalle empresa</v-expansion-panel-header>
                <v-expansion-panel-content height="100%" style="position: relative;">
                  <v-card-title>
                    <v-col cols="8">
                      <h4>Logotipo de empresa</h4>
                    </v-col>
                    <v-col cols="4">
                      <v-avatar size="150" v-for="image in info.repImages" :key="image">
                        <v-img class="justify-center align-center text-center" :src="image"></v-img>
                      </v-avatar>
                    </v-col>
                    <v-col cols="6" class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px">
                      <h4>Giro, Ramo, Sector:</h4>
                      <v-card-subtitle>
                        <span>{{ presidencia.giroEmpresa }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>RFC:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-card-account-details</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.rfc }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Domicilio:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-map-marker</v-icon>
                        </v-list-item-action>
                        <span> {{ presidencia.ciudad }},{{ presidencia.estado }} {{ presidencia.domicilio }} Col.{{ presidencia.colonia }} C.P.{{ presidencia.cp }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>FAX:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-fax</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.fax }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Telefono:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-phone</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.telefono }} <br /></span>
                      </v-card-subtitle>
                      <h4>EXT:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-puzzle</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.ext }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre del(la) Titular de la empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.ntEmpresa }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.puestoNTE }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre de la persona que firmará el acuerdo de trabajo. Estudiante - Escuela-Empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.nfa }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.puestoNFA }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Asesor(a) Externo(a) (persona quién los supervisará en la empresa):</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.asesorExterno }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ presidencia.puestoAE }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                  </v-card-title>
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>

          <v-col cols="12" v-bind="selectedProyecto in selectedProyecto" :key="selectedProyecto.id">
            <v-expansion-panels popout>
              <v-expansion-panel>
                <v-expansion-panel-header>Documentacion</v-expansion-panel-header>
                <v-expansion-panel-content height="100%" style="position: relative;">
                  <v-row>
                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px;">
                        SOLICITUD DE RESIDENCIAS PROFESIONALES
                      </v-card>
                    </v-col>
                    <v-col cols="12">
                      <v-card height="auto" style="z-index:20001;">
                        <v-dialog :retain-focus="false" v-model="dialogSolicitudRes" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue accent-4" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI SOLICITUD DE RESIDENCIAS
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              SOLICITUD DE RESIDENCIAS
                            </v-card-title>
                            <SolicitudResidencias :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogSolicitudRes = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px">
                        CARTA PRESENTACION Y CARTA ACEPTACION
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto" style="z-index:20001;">
                        <v-dialog :retain-focus="false" v-model="dialogPresentacion" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue accent-4" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI CARTA DE PRESENTACION
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              CARTA PRESENTACION
                            </v-card-title>
                            <CartaPresentacion :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogPresentacion = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogAceptacion" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue accent-4" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI CARTA DE ACEPTACION
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              CARTA ACEPTACION
                            </v-card-title>
                            <CartaAceptacion :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn color="primary" text right @click="dialogAceptacion = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px">
                        ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                      </v-card>
                    </v-col>
                    <v-col cols="12">
                      <v-card height="auto" style="z-index:20001;">
                        <v-dialog :retain-focus="false" v-model="dialogAntePro" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue accent-4" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                            </v-card-title>
                            <Anteproyecto :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogAntePro = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px">
                        PRIMER SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogPrimerAsesoria" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-2" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 1
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              PRIMER ASESORIA
                            </v-card-title>
                            <PrimerAsesoria :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogPrimerAsesoria = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogPrimerSeguimiento" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-2" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 1
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 1
                            </v-card-title>
                            <PrimerSeguimiento :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn outlined right color="primary" text @click="dialogPrimerSeguimiento = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px">
                        SEGUNDO SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogSegundaAsesoria" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-3" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 2
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              SEGUNDA ASESORIA
                            </v-card-title>
                            <SegundaAsesoria :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogSegundaAsesoria = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogSegundoSeguimiento" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-3" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 2
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 2
                            </v-card-title>
                            <SegundoSeguimiento :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogSegundoSeguimiento = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card color="dark" label block flat class="text-center pa-1" style="margin-bottom: -15px">
                        TERCER SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogTerceraAsesoria" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-4" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 3
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              TERCER ASESORIA
                            </v-card-title>
                            <TercerAsesoria :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogTerceraAsesoria = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogTercerSeguimiento" width="700px" hide-overlay transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn small outlined block color="blue darken-4" v-bind="attrs" v-on="on" width="100%">
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 3
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 3
                            </v-card-title>
                            <TercerSeguimiento :selectedProyecto="selectedProyecto" />
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn right color="primary" text @click="dialogTercerSeguimiento = false">
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                  </v-row>
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>
          <v-col cols="12" v-show="this.user.accessLevel === 3">
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="orange" class="white--text" v-if="!editable" @click="aceptar">Editar proyecto </v-btn>
            </v-card-actions>
            <v-dialog v-model="dialog" max-width="290">
              <v-card>
                <v-card-title class="text-h5">
                  <v-icon>mdi-alert-circle</v-icon>
                </v-card-title>
                <v-card-text>
                  La informacion del usuario ha sido actualizada.
                </v-card-text>
              </v-card>
            </v-dialog>
          </v-col>
        </v-row>
      </v-card>
    </v-card>
  </v-lazy>
</template>

<script>
import Axios from "axios";
import SolicitudResidencias from "@/components/EDocu/SolicitudResidencias";
import CartaPresentacion from "@/components/EDocu/CartaPresentacion";
import CartaAceptacion from "@/components/EDocu/CartaAceptacion";
import Anteproyecto from "@/components/EDocu/Anteproyecto";
import PrimerAsesoria from "@/components/EDocu/PrimerAsesoria";
import PrimerSeguimiento from "@/components/EDocu/PrimerSeguimiento";
import SegundaAsesoria from "@/components/EDocu/SegundaAsesoria";
import SegundoSeguimiento from "@/components/EDocu/SegundoSeguimiento";
import TercerAsesoria from "@/components/EDocu/TercerAsesoria";
import TercerSeguimiento from "@/components/EDocu/TercerSeguimiento";

export default {
  components: {
    TercerSeguimiento,
    TercerAsesoria,
    SegundoSeguimiento,
    SegundaAsesoria,
    PrimerSeguimiento,
    PrimerAsesoria,
    Anteproyecto,
    SolicitudResidencias,
    CartaPresentacion,
    CartaAceptacion
  },
  props: ["presidencia"],
  name: "ListPRCard",
  data() {
    return {
      user: "",
      nr: false,
      dialog: false,
      editable: false,
      myUser: [],
      myProy: [],
      dialogPrimerSeguimiento: false,
      dialogSegundoSeguimiento: false,
      dialogTercerSeguimiento: false,
      dialogPrimerAsesoria: false,
      dialogSegundaAsesoria: false,
      dialogTerceraAsesoria: false,
      dialogAntePro: false,
      dialogSolicitudRes: false,
      dialogPresentacion: false,
      dialogAceptacion: false,
      primerAsesoria: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf"],
      primerSeguimientoEv: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf"],
      segundaAsesoria: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf"],
      segundaSeguimientoEv: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf"],
      tercerAsesoria: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-REGISTRO+DE+ASESORIA.pdf"],
      tercerSeguimientoEv: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdff"],
      anteProy: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-ANTEPROYECTO+DE+RESIDENCIAS+PROFESIONALES.pdf"],
      solicitudRes: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-SOLICITUD+DE+RESIDENCIAS+PROFESIONALES.pdf"],
      cartPres: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+PRESENTACIÓN.pdf"],
      cartAceptacion: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+ACEPTACION.pdf"],
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
      cartPres: [],
      tool: false
    };
  },
  mounted() {
    this.user = this.$store.getters.getUser;
    this.$nextTick(() => {
      if (this.presidencia) {
        if (this.presidencia.status === 0) {
          this.color = "grey lighten-5";
        }
        if (this.presidencia.status === 1) {
          this.color = "light-green darken-2";
        }
        if (this.presidencia.status === 2) {
          this.color = "orange darken-2";
        }
        if (this.presidencia.status === 3) {
          this.color = "red darken-3";
        }
      }
      this.$store.dispatch("fetchMiPresidencias");
      this.$store.dispatch("fetchMyUsuarios");
      this.$store.dispatch("fetchMiProyectos", this.presidencia.proyectoId);
    });

    Axios.get(`proyectos/${this.presidencia.proyectoId}`, {
      headers: this.$store.getters.getAuth
    }).then(response => {
      this.info = response.data;
      // eslint-disable-next-line prefer-destructuring
    });
    this.$nextTick(() => {
      setTimeout(() => {
        if (this.$route.fullPath.includes(`#${this.presidencia.id}`)) {
          this.expand = true;
          this.$refs[this.presidencia.id].scrollIntoView();
        }
      }, 1000);
    });
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
    image() {
      if (this.image.length <= 1) {
        try {
          const image = this.image[0];
          const lector = new FileReader();
          lector.readAsDataURL(image);
          lector.onload = event => {
            this.imagen = event.target.result;
          };
        } catch (e) {
          Error(e);
        }
      }
    }
  },
  computed: {
    // eslint-disable-next-line consistent-return,vue/return-in-computed-property
    width() {
      // eslint-disable-next-line default-case
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          return "100%";
        case "sm":
          return "90%";
        case "md":
          return "85%";
        case "lg":
          return "80%";
        case "xl":
          return "80%";
      }
    },
    statusProy() {
      if (this.presidencia.status === 1) {
        return true;
      }
      if (this.presidencia.status === 3) {
        return true;
      }
      return false;
    },
    infoUser() {
      return this.$store.getters.getUsuario || [];
    },
    selectedProyecto() {
      console.log(this.$store.getters.getMiProyecto);
      return this.$store.getters.getMiProyecto[0] || [];
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
    aceptar() {
      this.editable = false;
    },
    actualizar() {
      console.log("olo");
    }
  }
};
</script>

<style scoped>
.n {
  font-weight: bold;
  font-size: large;
}
</style>
