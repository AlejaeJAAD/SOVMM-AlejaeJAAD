<template>
  <v-lazy
    :ref="proyecto.id"
    v-model="isActive"
    :options="{
    threshold: 0.5
    }"
    style="width: auto;"
    min-height="auto"
    transition="fade-transition"
  >
    <v-card v-if="isActive" elevation="5" :color="color" style="padding: 1px">
      <v-card style="padding: 25px; margin-top: 10px;"
              elevation="'3'" shaped  tile
              :disabled="proyecto.status === 4"
              :color="'white'"
      >
        <v-chip class="ma-1 float-right"  color="white">
          <span :class="textColor" class="font-weight-bold">{{status}}</span>
        </v-chip>
        <v-row>
          <v-col cols="12">
            <v-card-title style="margin-top: -20px">
              ID: {{ proyecto.id }} <br>
              Creado por: {{ proyecto.createdBy }}
            </v-card-title>
            <v-card-text class="text-right">
              Categoria: {{ proyecto.categoria }}</v-card-text>
            <v-divider></v-divider>
            <v-card-title>Nombre de proyecto:</v-card-title>
            <v-card-subtitle>{{proyecto.nProyecto}}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Fecha de proyecto:</v-card-title>
            <v-card-subtitle>{{ proyecto.createdDate}}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Periodo:</v-card-title>
            <v-card-subtitle>{{ proyecto.periodo}}</v-card-subtitle>
            <v-card-title style="margin-top: -25px">Tipo de proyecto:</v-card-title>
            <v-card-subtitle>{{ proyecto.opcElegida}}</v-card-subtitle>
            <v-divider></v-divider>
            <v-card-title>Objetivo:</v-card-title>
            <v-card-subtitle>{{proyecto.objetivo}}</v-card-subtitle>
            <v-divider></v-divider>
            <v-card-title>Justificacion:</v-card-title>
            <v-card-subtitle>{{proyecto.justificacion}}</v-card-subtitle>
          </v-col>
          <v-col cols="12">
            <v-expansion-panels popout>
              <v-expansion-panel>
                <v-expansion-panel-header>Detalle alumno</v-expansion-panel-header>
                <v-expansion-panel-content height="100%"
                                           style="position: relative;
                                           margin-top: 50px">
                  <v-col cols="12" v-for="(alumno) in alumnosCard"
                         :key="alumno.id">
                    <v-alert
                      border="left"
                      colored-border
                      color="deep-purple accent-4"
                      elevation="2"
                    >
                      <v-card height="100%"
                              flat
                              style="position: relative"
                              class="d-flex justify-center align-center">
                        <v-card-text class="text-center">
                          <v-avatar size="100">
                            <v-img :src="alumno.image"
                                   class="justify-center align-center text-center"></v-img>
                          </v-avatar>
                          <h3 class="text-h5 mb-2">
                            {{ alumno.firstName}} {{ alumno.lastName }}
                          </h3>
                          <div class="blue--text mb-2">
                            {{ alumno.email }}
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
                                <v-col cols="6" class="text-right">{{ alumno.state }}</v-col>

                                <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                                  Ciudad:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ alumno.city }}</v-col>

                                <v-col class="text-left ml-1 mr-5 mb-1" tag="strong" cols="4">
                                  Curp:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ alumno.curp }}</v-col>

                                <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                                  Telefono:
                                </v-col>
                                <v-col cols="6" class="text-right">{{ alumno.phone }}</v-col>
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
                <v-expansion-panel-content height="100%"
                                           style="position: relative;
                                           margin-top: 50px">
                  <v-card-title>
                    <v-col cols="8">
                      <h4>Logotipo de empresa</h4>
                    </v-col>
                    <v-col cols="4">
                      <v-avatar size="150" v-for="image in proy.repImages" :key="image">
                        <v-img class="justify-center align-center text-center" :src="image"></v-img>
                      </v-avatar>
                    </v-col>
                    <v-col cols="6" class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px">
                      <h4>Giro, Ramo, Sector:</h4>
                      <v-card-subtitle>
                        <span>{{ proyecto.giroEmpresa }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px"
                           cols="12">
                      <h4>RFC:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-card-account-details</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.rfc }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Domicilio:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-map-marker</v-icon>
                        </v-list-item-action>
                        <span>
                          {{ proyecto.ciudad }},{{ proyecto.estado }}
                          {{ proyecto.domicilio }} Col.{{ proyecto.colonia }} C.P.{{ proyecto.cp }}
                          <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>FAX:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-fax</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.fax }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Telefono:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-phone</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.telefono }} <br></span>
                      </v-card-subtitle>
                      <h4>EXT:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-puzzle</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.ext }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre del(la) Titular de la empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.ntEmpresa }} <br></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.puestoNTE }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Nombre de la persona que firmará el acuerdo de trabajo.
                        Estudiante - Escuela-Empresa:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.nfa }} <br></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.puestoNFA }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                    <v-col class="text-left ml-1 mr-2 mb-2" style="margin-top: -20px" cols="12">
                      <h4>Asesor(a) Externo(a) (persona quién los supervisará en la empresa):</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.asesorExterno }} <br></span>
                      </v-card-subtitle>
                      <h4>Puesto:</h4>
                      <v-card-subtitle>
                        <v-list-item-action>
                          <v-icon>mdi-domain</v-icon>
                        </v-list-item-action>
                        <span>{{ proyecto.puestoAE }} <br></span>
                      </v-card-subtitle>
                      <v-divider></v-divider>
                    </v-col>
                  </v-card-title>
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>
          <v-col cols="12">
            <v-expansion-panels popout :disabled="statusProy">
              <v-expansion-panel>
                <v-expansion-panel-header>Documentacion</v-expansion-panel-header>
                <v-expansion-panel-content height="100%"
                                           style="position: relative;">
                  <v-row>
                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px;"
                      >
                        SOLICITUD DE RESIDENCIAS PROFESIONALES
                      </v-card>
                    </v-col>
                    <v-col cols="12">
                      <v-card height="auto" style="z-index:20001;">
                        <v-dialog :retain-focus="false" v-model="dialogSolicitudRes"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue accent-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI SOLICITUD DE RESIDENCIAS
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              SOLICITUD DE RESIDENCIAS
                            </v-card-title>
                            <SolicitudResidencias :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogSolicitudRes = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px"
                      >
                        CARTA PRESENTACION Y CARTA ACEPTACION
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogPresentacion"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue accent-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI CARTA DE PRESENTACION
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              CARTA PRESENTACION
                            </v-card-title>
                            <CartaPresentacion :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogPresentacion = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogAceptacion"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue accent-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI CARTA DE ACEPTACION
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              CARTA ACEPTACION
                            </v-card-title>
                            <CartaAceptacion :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                color="primary"
                                text
                                right
                                @click="dialogAceptacion = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px"
                      >
                        ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                      </v-card>
                    </v-col>
                    <v-col cols="12">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogAntePro"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue accent-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              ANTEPROYECTO DE RESIDENCIAS PROFESIONALES
                            </v-card-title>
                            <Anteproyecto :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogAntePro = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px"
                      >
                        PRIMER SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogPrimerAsesoria"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue darken-2"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 1
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              PRIMER ASESORIA
                            </v-card-title>
                            <PrimerAsesoria :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogPrimerAsesoria = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogPrimerSeguimiento"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              :outlined="isOutlined01"
                              block
                              color="blue darken-2"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 1
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 1
                            </v-card-title>
                            <PrimerSeguimiento :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogPrimerSeguimiento = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px"
                      >
                        SEGUNDO SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogSegundaAsesoria"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue darken-3"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 2
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              SEGUNDA ASESORIA
                            </v-card-title>
                            <SegundaAsesoria :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogSegundaAsesoria = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogSegundoSeguimiento"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              :outlined="isOutlined02"
                              block
                              color="blue darken-3"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 2
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 2
                            </v-card-title>
                            <SegundoSeguimiento :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogSegundoSeguimiento = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>

                    <v-col cols="12">
                      <v-card
                        color="dark"
                        label
                        outlined
                        block
                        flat
                        class="text-center pa-1"
                        style="margin-bottom: -15px"
                      >
                        TERCER SEGUIMIENTO
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogTerceraAsesoria"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              outlined
                              block
                              color="blue darken-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI FORMATO PARA EL REGISTRO DE ASESORIAS 3
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              TERCER ASESORIA
                            </v-card-title>
                            <TercerAsesoria :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogTerceraAsesoria = false"
                              >
                                Cerrar
                              </v-btn>
                            </v-card-actions>
                          </v-card>
                        </v-dialog>
                      </v-card>
                    </v-col>
                    <v-col cols="6">
                      <v-card height="auto">
                        <v-dialog :retain-focus="false" v-model="dialogTercerSeguimiento"
                                  fullscreen
                                  hide-overlay
                                  transition="dialog-bottom-transition">
                          <template v-slot:activator="{ on, attrs }">
                            <v-btn
                              :outlined="isOutlined03"
                              block
                              color="blue darken-4"
                              v-bind="attrs"
                              v-on="on"
                              large
                              width="100%"
                            >
                              SUBE AQUI EVALUACION Y SEGUIMIENTO 3
                            </v-btn>
                          </template>
                          <v-card>
                            <v-card-title class="text-h5 grey lighten-2 pa-10">
                              EVALUACION Y SEGUIMIENTO 3
                            </v-card-title>
                            <TercerSeguimiento :proyecto="proyecto"/>
                            <v-divider></v-divider>
                            <v-card-actions>
                              <v-spacer></v-spacer>
                              <v-btn
                                right
                                color="primary"
                                text
                                @click="dialogTercerSeguimiento = false"
                              >
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
          <v-col cols="12" v-show="proyecto.status === 0">
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="green" class="white--text"
                     v-if="!editable"
                     @click="aceptar">Aceptar proyecto
              </v-btn>
              <v-btn color="red" class="white--text"
                     v-if="!editable"
                     @click="rechazar">Rechazar proyecto
              </v-btn>
            </v-card-actions>
            <v-dialog
              v-model="dialog" max-width="290">
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
import Axios from 'axios';
import CartaPresentacion from '@/components/EDocu/CartaPresentacion';
import CartaAceptacion from '@/components/EDocu/CartaAceptacion';
import SolicitudResidencias from '@/components/EDocu/SolicitudResidencias';
// import DocumentHandler from '@/components/Global/DocumentHandler';
// import Perfil from '@/assets/Perfil.png';
// import UserCard from '@/views/UserCard';
import Anteproyecto from '@/components/EDocu/Anteproyecto';
import PrimerAsesoria from '@/components/EDocu/PrimerAsesoria';
import PrimerSeguimiento from '@/components/EDocu/PrimerSeguimiento';
import SegundaAsesoria from '@/components/EDocu/SegundaAsesoria';
import SegundoSeguimiento from '@/components/EDocu/SegundoSeguimiento';
import TercerAsesoria from '@/components/EDocu/TercerAsesoria';
import TercerSeguimiento from '@/components/EDocu/TercerSeguimiento';
// import NuevoPresidencias from '@/components/NuevoPresidencias';
// import pdf from 'vue-pdf';

export default {
  components: {
    // NuevoPresidencias,
    TercerSeguimiento,
    TercerAsesoria,
    SegundoSeguimiento,
    SegundaAsesoria,
    PrimerSeguimiento,
    PrimerAsesoria,
    Anteproyecto,
    SolicitudResidencias,
    CartaPresentacion,
    CartaAceptacion,
    // DocumentHandler,
    // pdf,
    // UserCard,
  },
  props: {
    proyecto: Object,
    index: Number,
    mios: Boolean,
  },
  name: 'ListProyectosCard',
  data() {
    return {
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
      proresidencias: [],
      usuarios: [],
      usuario: '',
      alumnos: [],
      dialogPresentacion: false,
      dialogAceptacion: false,
      colortxt: 'black',
      clicked: false,
      currentPage: 1,
      pageCount: 0,
      page: '1',
      numPages: 0,
      placeChangedOnce: false,
      documents: [],
      isLoading: false,
      proyect: {},
      document: '',
      expand: false,
      cartPres: [],
      proy: {},
      image: '',
      isActive: false,
      color: 'white',
      textColor: '',
      status: '',
      info: [],
      infoProAlu: '',
      infoAluPro: '',
    };
  },
  /* eslint-disable consistent-return */
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch('fetchMyUsuarios');
      this.$store.dispatch('fetchUsuarios');
      this.$store.dispatch('fetchMyPresidencias');
      this.$store.dispatch('fetchPresidencias');
      this.$store.dispatch('fetchProyectos');
    });
    if (this.mios) {
      if (this.proyecto.status === 0) {
        this.color = 'grey lighten-5';
      }
      if (this.proyecto.status === 1) {
        this.color = 'light-green darken-2';
      }
      if (this.proyecto.status === 2) {
        this.color = 'orange darken-2';
      }
      if (this.proyecto.status === 3) {
        this.color = 'red darken-3';
      }
    }
    Axios.get(`proyectos/${this.proyecto.proyectoId}`, {
      headers: this.$store.getters.getAuth,
    })
      .then((response) => {
        this.proy = response.data;
        this.image = this.proyecto.repImages;
      });
    this.$nextTick(() => {
      setTimeout(() => {
        if (this.$route.fullPath.includes(`#${this.proyecto.id}`)) {
          this.expand = true;
          this.$refs[this.proyecto.id].scrollIntoView();
        }
      }, 1000);
    });
    Axios.get('users')
      .then((response) => {
        this.usuarios = response.data.filter((b) => b.accessLevel === 3);
      });
    Axios.get('presidencias')
      .then((response) => {
        this.proresidencias = response.data;
      });
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
  },
  computed: {
    isOutlined01() {
      console.log(this.proy, 'INFO');
      if (this.proy.primerSeguimientoEv[0] !== 'https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf') {
        return false;
      }
      return true;
    },
    isOutlined02() {
      if (this.proy.segundaSeguimientoEv[0] !== 'https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf') {
        return false;
      }
      return true;
    },
    isOutlined03() {
      if (this.proy.tercerSeguimientoEv[0] !== 'https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-EVALUACION+Y+SEGUIMIENTO+DE+RESIDENCIA+PROFESIONAL.pdf') {
        return false;
      }
      return true;
    },
    statusProy() {
      return this.proyecto.status !== 1 && this.proyecto.status !== 2;
    },
    auth() {
      return this.$store.getters.getAuth || {};
    },
    noPrevPage() {
      return this.currentPage <= 1;
    },
    noNextPage() {
      return this.currentPage === this.pageCount;
    },
    alumnosCard() {
      return this.usuarios.filter((user) => user.id === this.proyecto.createdBy);
    },
  },
  methods: {
    rechazar() {
      console.log('ENTRO');
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
        likedBy: this.proyecto.likedBy,
      };

      this.isLoading = true;
      Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
        headers: this.$store.getters.getAuth,
      }).then(() => {
        this.$store.dispatch('fetchMyPresidencias');
        this.$store.dispatch('fetchPresidencias');
        console.log('SALIO');
        this.$router.push('/inicio');
      });
    },
    aceptar() {
      console.log('ENTRO');
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
        status: 1,
        createdDate: this.proyecto.createdDate,
        resolutionDate: new Date().toISOString(),
        likedBy: this.proyecto.likedBy,
      };

      this.isLoading = true;
      Axios.put(`presidencias/${presidenciasActualizado.id}`, presidenciasActualizado, {
        headers: this.$store.getters.getAuth,
      }).then(() => {
        this.$store.dispatch('fetchMyPresidencias');
        this.$store.dispatch('fetchPresidencias');
        console.log('SALIO');
        this.$router.push('/inicio');
      });
    },
  },
};
</script>

<style scoped>
</style>
