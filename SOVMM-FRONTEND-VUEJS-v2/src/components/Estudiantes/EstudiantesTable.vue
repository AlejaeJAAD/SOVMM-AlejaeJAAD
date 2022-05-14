<template>
    <v-lazy>
        <v-container>
            <v-row>
                <v-col cols="12" sm=12 md=12 lg=12>
                    <v-alert color="red" v-if="!eliminado">
                      No se pudo eliminar, favor de modificar
                      el proyecto de residencias perteneciente al estudiante
                    </v-alert>
                    <v-card width="100%" height="100%" elevation="-20">
                      <v-card-title>
                        Estudiantes
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
                          :items="getEstudiantes"
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
                                     outlined @click.prevent="detalleEstudiante(item.id)">
                                <v-icon>
                                  mdi-account-details
                                </v-icon>
                              </v-btn>
                            </template>
                            <template v-slot:[`item.edit`]="{ item }">
                              <v-btn color="orange accent-4"
                                     outlined @click.prevent="editarEstudiante(item.id)">
                                <v-icon>
                                  mdi-account-edit
                                </v-icon>
                              </v-btn>
                            </template>
                            <template v-slot:[`item.delete`]="{ item }">
                              <v-btn color="red accent-3"
                                     outlined @click.prevent="eliminarEstudiante(item.id)">
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
                    <v-dialog persistent v-model="detalle" width="unset" class="dm">
                      <v-card flat>
                        <v-btn block @click.prevent="cerrar">Cerrar</v-btn>
                        <EstudianteDetail v-bind:currentStudent="currentStudent"/>
                      </v-card>
                    </v-dialog>
                    <v-dialog v-model="modificar" width="500px">
                      <v-card>Hola</v-card>
                    </v-dialog>
                    <v-dialog v-model="eliminar" width="750px">
                      <EstudianteDelete v-bind:currentStudent="currentStudent"
                      :eliminar.sync="eliminar"/>
                    </v-dialog>
                </v-col>
            </v-row>
        </v-container>
    </v-lazy>
</template>

<script>
import EstudianteDetail from './EstudianteDetail.vue';
import EstudianteDelete from './EstudianteDelete.vue';

export default {
  name: 'Estudiantes',
  components: {
    EstudianteDetail,
    EstudianteDelete,
  },
  data() {
    return {
      isActive: false,
      headers: [
        // { text: 'ID', align: 'start', value: 'id' },
        { text: 'NUMERO DE CONTROL', align: 'start', value: 'enrollment' },
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
      estudiantes: [],
      currentStudent: '',
    };
  },
  created() {
    this.$store.dispatch('fetchEstudiantes');
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
  },
  computed: {
    getEstudiantes() {
      return this.$store.getters.getEstudiantes;
    },
  },
  methods: {
    clean() {
      Object.assign(this.$data, this.$options.data());
    },
    detalleEstudiante(id) {
      console.log(id, 'ID DET');
      this.$store.dispatch('getStudent', id).then((res) => {
        this.currentStudent = res;
        console.log(this.currentStudent.id, 'DETALLE');
        this.detalle = true;
        return this.currentStudent;
      });
    },
    eliminarEstudiante(id) {
      console.log(id, 'ID DEL');
      this.$store.dispatch('getStudent', id).then((res) => {
        this.currentStudent = res;
        console.log(this.currentStudent.id, 'ELIMINAR');
        this.eliminar = true;
        return this.currentStudent || {};
      });
    },
    editarEstudiante(id) {
      console.log(id, 'ID EDIT');
      this.modificar = true;
    },
    totalPaginas() {
      return Math.cell(this.info.length / this.elementosPorPagina);
    },
    cerrar() {
      this.detalle = false;
    },
  },
};
</script>

<style scoped>
</style>
