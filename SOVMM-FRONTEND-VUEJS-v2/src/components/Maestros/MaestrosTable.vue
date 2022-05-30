<template>
  <v-lazy>
    <v-container>
      <v-row>
        <v-col cols="12" sm="12" md="12" lg="12">
          <v-alert color="red" v-if="!eliminado">
            No se pudo eliminar, favor de modificar el proyecto de residencias perteneciente al estudiante
          </v-alert>
          <v-card width="100%" height="100%" elevation="-20">
            <v-card-title>
              Estudiantes
              <v-spacer></v-spacer>
              <v-text-field v-model="busqueda" append-icon="mdi-magnify" label="Buscar" single-line hide-details> </v-text-field>
            </v-card-title>
            <v-divider></v-divider>
            <v-data-table locale="es" item-key="id" :headers="headers" :items="getMaestros" :items-per-page="10" :page.sync="page" @page-count="pageCount = $event" class="elevation-1" :search="busqueda" hide-default-footer>
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
                <v-btn color="indigo accent-2" outlined @click.prevent="detalleEstudiante(item.id)">
                  <v-icon>
                    mdi-account-details
                  </v-icon>
                </v-btn>
              </template>
              <template v-slot:[`item.edit`]="{ item }">
                <v-btn color="orange accent-4" outlined @click.prevent="editarEstudiante(item.id)">
                  <v-icon>
                    mdi-account-edit
                  </v-icon>
                </v-btn>
              </template>
              <template v-slot:[`item.delete`]="{ item }">
                <v-btn color="red accent-3" outlined @click.prevent="eliminarEstudiante(item.id)">
                  <v-icon>
                    mdi-account-remove
                  </v-icon>
                </v-btn>
              </template>
            </v-data-table>

            <v-pagination v-model="page" :length="Math.ceil(getMaestrosLength / totalElem)" prev-icon="mdi-menu-left" next-icon="mdi-menu-right" :page="page" :total-visible="7"></v-pagination>
          </v-card>
          <v-dialog persistent v-model="detalle" width="80%" class="dm">
            <v-card flat>
              <v-btn block @click.prevent="cerrar">Cerrar</v-btn>
              <MaestroDetail v-bind:currentStudent="currentStudent" />
            </v-card>
          </v-dialog>
          <v-dialog persistent v-model="modificar" width="80%" class="dm">
            <v-card flat>
              <v-btn block @click.prevent="cerrar">Cerrar</v-btn>
              <MaestroEdit v-bind:currentStudent="currentStudent" />
            </v-card>
          </v-dialog>
          <v-dialog persistent v-model="eliminar" width="750px">
            <v-row>
              <v-col cols="12">
                <v-card>
                  <v-card-title class="text-h6 justify-center">
                    Desea eliminar a {{ currentStudent.firstName }} {{ currentStudent.lastName }}
                    de sus alumnos?
                    <v-avatar>
                      <v-img :src="currentStudent.image"> </v-img>
                    </v-avatar>
                  </v-card-title>
                  <v-divider></v-divider>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="red" outlined @click="cancelar">
                      Cancelar
                    </v-btn>
                    <v-spacer></v-spacer>
                    <v-btn color="green darken-1" outlined @click="eliminarEstudianteC(currentStudent.id)">
                      Aceptar
                    </v-btn>
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>
          </v-dialog>
        </v-col>
      </v-row>
    </v-container>
  </v-lazy>
</template>

<script>
import MaestroDetail from "./MaestroDetail.vue";
import MaestroEdit from "./MaestroEdit.vue";

export default {
  name: "Estudiantes",
  components: {
    MaestroDetail,
    MaestroEdit
  },
  data() {
    return {
      isActive: false,
      headers: [
        // { text: 'ID', align: 'start', value: 'id' },
        { text: "NUMERO DE CONTROL", align: "start", value: "enrollment" },
        { text: "NOMBRE(S)", align: "start", value: "firstName" },
        { text: "APELLIDO(S)", value: "lastName" },
        { text: "CORREO INSTITUCIONAL", value: "email" },
        { text: "TELEFONO", value: "phone" },
        { text: "DETALLE", value: "detail", sortable: false },
        { text: "EDITAR", value: "edit", sortable: false },
        { text: "ELIMINAR", value: "delete", sortable: false }
      ],
      eliminado: true,
      tabla: false,
      user: "",
      active: [],
      search: "",
      avatar: null,
      open: [],
      detalle: false,
      modificar: false,
      eliminar: false,
      busqueda: "",
      page: 1,
      totalElem: 10,
      pageCount: 0,
      info: [],
      idAEliminar: "",
      estudiantes: [],
      currentStudent: ""
    };
  },
  created() {
    this.$store.dispatch("fetchEstudiantes");
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    }
  },
  computed: {
    getMaestros() {
      return this.$store.getters.getMaestros.slice((this.page - 1) * this.totalElem, this.page * this.totalElem);
    },
    getMaestrosLength() {
      return this.$store.getters.getMaestros.length;
    }
  },
  methods: {
    clean() {
      Object.assign(this.$data, this.$options.data());
    },
    detalleEstudiante(id) {
      this.$store.dispatch("getTeacher", id).then(res => {
        this.currentStudent = res;
        this.detalle = true;
        return this.currentStudent;
      });
    },
    eliminarEstudiante(id) {
      this.$store.dispatch("getTeacher", id).then(res => {
        this.currentStudent = res;
        this.eliminar = true;
        return this.currentStudent || {};
      });
    },
    editarEstudiante(id) {
      this.$store.dispatch("getTeacher", id).then(res => {
        this.currentStudent = res;
        this.modificar = true;
        return this.currentStudent;
      });
    },
    totalPaginas() {
      return Math.cell(this.info.length / this.elementosPorPagina);
    },
    cerrar() {
      this.detalle = false;
      this.modificar = false;
    },
    cancelar() {
      // this.eliminar = false;
      this.eliminar = false;
    },
    eliminarEstudianteC(id) {
      this.$store.dispatch("deleteTeacher", id).then(res => {
        this.eliminado = res;
        setTimeout(() => {
          this.eliminado = true;
        }, 5000);
        if (res) {
          this.eliminar = false;
        }
      });
      this.$router.go();
    }
  }
};
</script>

<style scoped></style>
