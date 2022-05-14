<template>
    <v-lazy>
        <v-container>
            <v-row>
                <v-col cols="12" sm=12 md=12 lg=12>
                    <v-alert color="red" v-if="!eliminado">
                      No se pudo eliminar, favor de modificar
                      el proyecto de residencias perteneciente al maestro
                    </v-alert>
                    <v-card width="100%" height="100%" elevation="-20">
                      <v-card-title>
                        Maestros
                        <v-spacer></v-spacer>
                        <v-text-field
                          v-model="busqueda"
                          append-icon="mdi-magnify"
                          label="Buscar"
                          single-line
                          hide-details
                        >
                        </v-text-field>
                      </v-card-title>
                        <v-divider></v-divider>
                          <v-data-table
                          locale="es"
                          :headers="headers"
                          :items="getMaestros"
                          :items-per-page="10"
                          :page.sync="page"
                          @page-count="pageCount = $event"
                          class="elevation-1"
                          :search="busqueda"
                          hide-default-footer
                          >
                          <!--
                            <template slot="items" slot-scope="props">
                              <td>{{ props.item.id }}</td>
                              <td>{{ props.item.controlnumber }}</td>
                              <td>{{ props.item.firstName }}</td>
                              <td>{{ props.item.lastName }}</td>
                              <td>{{ props.item.email }}</td>
                              <td>{{ props.item.phone }}</td>
                              <td>{{ props.item.career }}</td>
                            </template>
                          -->
                            <template v-slot:[`item.detail`]="{ item }">
                              <v-btn color="indigo accent-2"
                                     outlined @click="detalleMaestro(item.id)">
                                <v-icon>
                                  mdi-account-details
                                </v-icon>
                              </v-btn>
                            </template>
                            <template v-slot:[`item.edit`]="{ item }">
                              <v-btn color="orange accent-4"
                                     outlined @click="editarMaestro(item.id)">
                                <v-icon>
                                  mdi-account-edit
                                </v-icon>
                              </v-btn>
                            </template>
                            <template v-slot:[`item.delete`]="{ item }">
                              <v-btn color="red accent-3"
                                     outlined @click="eliminarMaestro(item.id)">
                                <v-icon>
                                  mdi-account-remove
                                </v-icon>
                              </v-btn>
                            </template>
                          </v-data-table>
                          <v-pagination
                            v-model="page"
                            :length="pageCount"
                          ></v-pagination>
                    </v-card>
                    <v-dialog v-model="detalle" width="unset">
                      <v-card>
                        Detalle usuario
                      </v-card>
                    </v-dialog>
                    <v-dialog v-model="modificar" width="unset">
                      <v-card>
                        Modificar usuario
                      </v-card>
                    </v-dialog>
                    <v-dialog v-model="eliminar" width="unset">
                        <v-card>
                        <v-card-title class="text-h5" style="word-break: break-word"
                        >Desea dar de baja a este usuario de sus maestros?</v-card-title
                        >
                        <v-divider></v-divider>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="red" outlined>
                            Cancelar
                            </v-btn>
                            <v-spacer></v-spacer>
                            <v-btn color="green darken-1" outlined @click="el()">
                            Aceptar
                            </v-btn>
                            <v-spacer></v-spacer>
                        </v-card-actions>
                        </v-card>
                    </v-dialog>
                </v-col>
            </v-row>
            <v-row>
              <v-col cols=12>
                <!--
                <div v-if="currentTeacher" class="edit-form py-3">
                  <p class="text-h5">Editar Maestro</p>
                  {{currentTeacher.firstName}}
                </div>
                -->
                <MaestroDetail v-bind:currentTeacher="currentTeacher"/>
              </v-col>
            </v-row>
        </v-container>
    </v-lazy>
</template>

<script>
import MaestroDetail from './MaestroDetail.vue';

export default {
  name: 'MaestrosTable',
  components: {
    MaestroDetail,
  },
  data() {
    return {
      isActive: false,
      headers: [
        // { text: 'ID', align: 'start', value: 'id' },
        { text: 'NUMERO DE MATRICULA', align: 'start', value: 'enrollment' },
        { text: 'NOMBRE(S)', align: 'start', value: 'firstName' },
        { text: 'APELLIDO(S)', value: 'lastName' },
        { text: 'CORREO INSTITUCIONAL', value: 'email' },
        { text: 'TELEFONO', value: 'phone' },
        { text: 'DETALLE', value: 'detail', sortable: false },
        { text: 'EDITAR', value: 'edit', sortable: false },
        { text: 'ELIMINAR', value: 'delete', sortable: false },
      ],
      eliminado: true,
      tabla: false,
      user: '',
      active: [],
      search: '',
      avatar: null,
      open: [],
      detalle: false,
      modificar: false,
      eliminar: false,
      busqueda: '',
      page: 1,
      totalElem: 6,
      pageCount: 0,
      info: [],
      idAEliminar: '',
      maestros: [],
      currentTeacher: '',
    };
  },
  created() {
    this.$store.dispatch('fetchMaestros');
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
  },
  computed: {
    getMaestros() {
      return this.$store.getters.getMaestros;
    },
  },
  methods: {
    detalleMaestro(id) {
      console.log(id, 'ID DET');
      this.$store.dispatch('getTeacher', id).then((res) => {
        this.currentTeacher = res;
        console.log(this.currentTeacher, 'CURRENT');
        return this.currentTeacher || {};
      });
    },
    eliminarMaestro(id) {
      console.log(id, 'ID DEL');
      this.$store.dispatch('deleteTeacher', id).then((res) => {
        this.eliminado = res;
        setTimeout(() => {
          this.eliminado = true;
        }, 5000);
        if (res) {
          this.$router.go();
        }
      });
    },
    editarMaestro(id) {
      console.log(id, 'ID EDIT');
    },
    totalPaginas() {
      return Math.cell(this.info.length / this.elementosPorPagina);
    },
  },
};
</script>
