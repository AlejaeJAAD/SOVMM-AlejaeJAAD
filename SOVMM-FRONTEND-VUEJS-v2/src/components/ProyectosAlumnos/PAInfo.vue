<template>
  <v-container>
    <v-card v-if="this.proyecto" elevation="5" :color="color" style="padding: 5px">
      <v-card style="padding: 25px; margin-top: 10px;" elevation="'3'" shaped tile :disabled="this.proyecto.status === 4" :color="'white'">
        <v-chip class="ma-1 float-right" color="white">
          <span :class="textColor" class="font-weight-bold">{{ status }}</span>
        </v-chip>
        <v-row>
          <v-col cols="12">
            <v-card-title style="margin-top: -20px">
              ID: {{ this.proyecto.id }} <br />
              Creado por: {{ this.proyecto.createdBy }}
            </v-card-title>
            <v-card-text class="text-right"> Categoria: {{ this.proyecto.categoria }}</v-card-text>
            <v-divider></v-divider>
            <v-card-title>Nombre de proyecto:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.nProyecto }}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Fecha de proyecto:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.createdDate }}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Periodo:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.periodo }}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Tipo de proyecto:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.opcElegida }}</v-card-subtitle>
            <v-divider></v-divider>
            <v-card-title>Objetivo:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.objetivo }}</v-card-subtitle>
            <v-divider></v-divider>
            <v-card-title>Justificacion:</v-card-title>
            <v-card-subtitle>{{ this.proyecto.justificacion }}</v-card-subtitle>
          </v-col>
          <v-col cols="12">
            <v-expansion-panels popout>
              <v-expansion-panel>
                <v-expansion-panel-header>Detalle alumno</v-expansion-panel-header>
                <v-expansion-panel-content
                  height="100%"
                  style="position: relative;
                                           margin-top: 50px"
                >
                  <v-col cols="12">
                    <v-alert border="left" colored-border color="deep-purple accent-4" elevation="2">
                      <v-card height="100%" flat style="position: relative" class="d-flex justify-center align-center">
                        <v-card-text class="text-center">
                          <v-avatar size="100">
                            <v-img :src="selectedUsuario.image" class="justify-center align-center text-center"></v-img>
                          </v-avatar>
                          <h3 class="text-h5 mb-2">{{ selectedUsuario.firstName }} {{ selectedUsuario.lastName }}</h3>
                          <div class="blue--text mb-2">
                            {{ selectedUsuario.email }}
                          </div>
                        </v-card-text>
                        <v-divider></v-divider>
                        <v-card-subtitle>
                          <v-row tag="v-card-text">
                            <v-col cols="12">
                              <v-row>
                                <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                                  Estado:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ selectedUsuario.state }}</v-col>

                                <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                                  Ciudad:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ selectedUsuario.city }}</v-col>

                                <v-col class="text-left ml-1 mr-5 mb-1" tag="strong" cols="4">
                                  Curp:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ selectedUsuario.curp }}</v-col>

                                <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                                  Telefono:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ selectedUsuario.phone }}</v-col>
                              </v-row>
                            </v-col>
                          </v-row>
                        </v-card-subtitle>
                      </v-card>
                    </v-alert>
                  </v-col>
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>
          <v-col cols="12">
            <v-expansion-panels popout>
              <v-expansion-panel>
                <v-expansion-panel-header>Detalle empresa</v-expansion-panel-header>
                <v-expansion-panel-content
                  height="100%"
                  style="position: relative;
                                           margin-top: 50px"
                >
                  <v-card-title>
                    <v-col cols="8">
                      <h4>Logotipo de empresa</h4>
                    </v-col>
                    <v-col cols="4">
                      <v-card v-for="image in selectedProyecto.repImages" :key="image">
                        <v-img max-height="100%" max-width="100%" class="mx-auto" :src="image"></v-img>
                      </v-card>
                    </v-col>
                    <v-col cols="6" class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px">
                      <h4>Giro, Ramo, Sector:</h4>
                      <v-card-subtitle>
                        <span>{{ this.proyecto.giroEmpresa }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>RFC:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-card-account-details</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.rfc }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Domicilio:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-map-marker</v-icon>
                        </v-list-item-action>
                        <span> {{ this.proyecto.ciudad }},{{ this.proyecto.estado }} {{ this.proyecto.domicilio }} Col.{{ this.proyecto.colonia }} C.P.{{ this.proyecto.cp }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>FAX:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-fax</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.fax }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Telefono:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-phone</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.telefono }} <br /></span>
                      </v-card-subtitle>
                      <h4>EXT:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-puzzle</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.ext }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre del(la) Titular de la empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.ntEmpresa }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.puestoNTE }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre de la persona que firmará el acuerdo de trabajo. Estudiante - Escuela-Empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.nfa }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.puestoNFA }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Asesor(a) Externo(a) (persona quién los supervisará en la empresa):</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.asesorExterno }} <br /></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ this.proyecto.puestoAE }} <br /></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                  </v-card-title>
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>

          <v-col cols="12">
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
                            <SolicitudResidencias :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <CartaPresentacion :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <CartaAceptacion :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <Anteproyecto :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <PrimerAsesoria :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <v-btn small :outlined="isOutlinedPrimerSeg" block color="blue darken-2" v-bind="attrs" v-on="on" width="100%" style="margin-bottom: -15px">
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 1
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 1
                            </v-card-title>
                            <PrimerSeguimiento :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <SegundaAsesoria :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <SegundoSeguimiento :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <TercerAsesoria :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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
                            <TercerSeguimiento :selectedProyecto="selectedProyecto" :selectedPresidencia="selectedPresidencia" />
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

          <v-col cols="12" v-show="this.proyecto.status === 0">
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="green" class="white--text" v-if="!editable" @click="aceptar">Aceptar proyecto </v-btn>
              <v-btn color="red" class="white--text" v-if="!editable" @click="rechazar">Rechazar proyecto </v-btn>
            </v-card-actions>
            <v-dialog v-model="dialog" max-width="290">
              <v-card>
                <v-card-title class="text-h5">
                  <v-icon>mdi-alert-circle</v-icon>
                </v-card-title>
                <v-card-text>
                  El estatus del proyecto ha sido actualizado.
                </v-card-text>
              </v-card>
            </v-dialog>
          </v-col>
        </v-row>
      </v-card>
    </v-card>
    <v-card v-else>
      La informacion aun no carga, favor de esperar...
    </v-card>
    <v-row style="margin: 0 -0.5rem 0 0">
      <v-col cols="12" align="right">
        <v-card flat>
          <v-card-actions>
            <v-container>
              <v-row dense>
                <v-col
                  ><v-btn color="black" outlined to="/proyectos-alumnos"><v-icon></v-icon>Volver a proyectos</v-btn></v-col
                >
              </v-row>
            </v-container>
          </v-card-actions>
        </v-card>
        <!-- <router-link class="" :to="{ name: 'ProyectosAlumnos' }">
          Go back
        </router-link> -->
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Axios from "axios";
import CartaPresentacion from "@/components/EDocu/CartaPresentacion";
import CartaAceptacion from "@/components/EDocu/CartaAceptacion";
import SolicitudResidencias from "@/components/EDocu/SolicitudResidencias";
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
  data() {
    return {
      id: "",
      dialog: false,
      editable: false,
      color: "white",
      isActive: true,
      isLoading: false,
      textColor: "",
      status: "",
      image: "",
      proyecto: "",
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
      cartAceptacion: ["https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+ACEPTACION.pdf"]
    };
  },
  mounted() {
    setTimeout(() => {
      this.proyecto = this.selectedPresidencia;
      if (this.proyecto.status === 0) {
        this.color = "grey lighten-5";
      }
      if (this.proyecto.status === 1) {
        this.color = "light-green darken-2";
      }
      if (this.proyecto.status === 2) {
        this.color = "orange darken-2";
      }
      if (this.proyecto.status === 3) {
        this.color = "red darken-3";
      }
    }, 3000);
  },
  created() {
    this.id = this.$route.params.id;
    this.$store.dispatch("fetchSelectedPresidencia", this.id);
  },
  computed: {
    selectedPresidencia() {
      return this.$store.getters.getSelectedPresidencia || [];
    },
    selectedProyecto() {
      return this.$store.getters.getSelectedProyecto || [];
    },
    selectedUsuario() {
      return this.$store.getters.getSelectedUsuario || [];
    },
    isOutlinedPrimerSeg() {
      console.log(this.selectedProyecto.primerSeguimientoEv[0], this.primerSeguimientoEv[0]);
      if (this.selectedProyecto.primerSeguimientoEv[0] !== this.primerSeguimientoEv) {
        return true;
      }
      return false;
    }
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    }
  },
  methods: {
    rechazar() {
      console.log("ENTRO");
      const presidenciasActualizado = {
        id: this.proyecto.id,
        createdBy: this.proyecto.createdBy,
        nProyecto: this.proyecto.nProyecto,
        opcElegida: this.proyecto.opcElegida,
        periodo: this.proyecto.periodo,
        objetivo: this.proyecto.objetivo,
        justificacion: this.proyecto.justificacion,
        giroEmpresa: this.proyecto.giroEmpresa,
        rfc: this.proyecto.rfc,
        domicilio: this.proyecto.domicilio,
        colonia: this.proyecto.colonia,
        categoria: this.proyecto.categoria,
        departamento: this.proyecto.departamento,
        cp: this.proyecto.cp,
        fax: this.proyecto.fax,
        ciudad: this.proyecto.ciudad,
        estado: this.proyecto.estado,
        telefono: this.proyecto.telefono,
        ext: this.proyecto.ext,
        ntEmpresa: this.proyecto.ntEmpresa,
        puestoNTE: this.proyecto.puestoNTE,
        nfa: this.proyecto.nfa,
        puestoNFA: this.proyecto.puestoNFA,
        asesorExterno: this.proyecto.asesorExterno,
        puestoAE: this.proyecto.puestoAE,
        proyectoId: this.proyecto.proyectoId,
        status: 3,
        createdDate: this.proyecto.createdDate,
        resolutionDate: new Date().toISOString(),
        likedBy: this.proyecto.likedBy
      };

      this.dialog = true;
      Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
        headers: this.$store.getters.getAuth
      }).then(() => {
        this.$router.push("/proyectos-alumnos");
      });
    },
    aceptar() {
      console.log("ENTRO");
      const presidenciasActualizado = {
        id: this.proyecto.id,
        createdBy: this.proyecto.createdBy,
        nProyecto: this.proyecto.nProyecto,
        opcElegida: this.proyecto.opcElegida,
        periodo: this.proyecto.periodo,
        objetivo: this.proyecto.objetivo,
        justificacion: this.proyecto.justificacion,
        giroEmpresa: this.proyecto.giroEmpresa,
        rfc: this.proyecto.rfc,
        domicilio: this.proyecto.domicilio,
        colonia: this.proyecto.colonia,
        categoria: this.proyecto.categoria,
        departamento: this.proyecto.departamento,
        cp: this.proyecto.cp,
        fax: this.proyecto.fax,
        ciudad: this.proyecto.ciudad,
        estado: this.proyecto.estado,
        telefono: this.this.proyecto.telefono,
        ext: this.proyecto.ext,
        ntEmpresa: this.proyecto.ntEmpresa,
        puestoNTE: this.proyecto.puestoNTE,
        nfa: this.proyecto.nfa,
        puestoNFA: this.proyecto.puestoNFA,
        asesorExterno: this.proyecto.asesorExterno,
        puestoAE: this.proyecto.puestoAE,
        proyectoId: this.proyecto.proyectoId,
        status: 3,
        createdDate: this.proyecto.createdDate,
        resolutionDate: new Date().toISOString(),
        likedBy: this.proyecto.likedBy
      };

      this.dialog = true;
      Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
        headers: this.$store.getters.getAuth
      }).then(() => {
        console.log("SALIO");
        this.$router.push("/proyectos-alumnos");
      });
    }
  }
};
</script>

<style lang="scss" scoped></style>
