<template>
  <!-- eslint-disable max-len -->
  <v-container class="nomar">
    <v-row>
      <v-col cols="12">
        <v-btn fixed color="white" elevation="5" fab @click="nr = true" :disabled="shoun">
          <v-icon>mdi-text-box-plus</v-icon>
        </v-btn>
        <v-dialog persistent :width="width" v-model="nr">
          <nuevo-proyecto v-if="nr" @onClose="nr = false" @created="created" />
        </v-dialog>
      </v-col>
      <v-col cols="12" class="centrar">
        <v-chip>El archivo Excel se descargara solo cuando un filtro haya sido seleccionado, en caso de no haber proyectos con el estatus seleccionado no se descargara nada.</v-chip>
      </v-col>
      <v-col cols="12">
        <download-excel :data="proresidencias" :fields="info_fields">
          <v-btn type="button" class="btn" style="background-color: rgba(1, 114, 58, 1)" block outlined> Generar Excel <v-icon>mdi-microsoft-excel</v-icon> </v-btn>
        </download-excel>
      </v-col>
      <v-col cols="12" class="centrar">
        <v-chip>Los proyectos se mostraran hasta que el estatus deseado sea seleccionado</v-chip>
      </v-col>
      <v-col cols="12">
        <v-row>
          <v-col cols="12">
            <v-btn type="button" class="btn btn-success white--text" block color="black" dark style="float: left" @click="filterTodo"> Todos<v-icon>mdi-filter</v-icon> </v-btn>
          </v-col>
          <v-col cols="3">
            <v-btn type="button" class="btn btn-success black--text" block color="grey lighten-5" dark style="float: left" @click="filter0">
              <v-icon>mdi-filter</v-icon>
            </v-btn>
          </v-col>
          <v-col cols="3">
            <v-btn type="button" class="btn btn-success black--text" block color="light-green darken-2" dark style="float: left" @click="filter1">
              <v-icon>mdi-filter</v-icon>
            </v-btn>
          </v-col>
          <v-col cols="3">
            <v-btn type="button" class="btn btn-success black--text" block color="orange darken-2" dark style="float: left" @click="filter2">
              <v-icon>mdi-filter</v-icon>
            </v-btn>
          </v-col>
          <v-col cols="3">
            <v-btn type="button" class="btn btn-success black--text" block color="red darken-2" dark style="float: left" @click="filter3">
              <v-icon>mdi-filter</v-icon>
            </v-btn>
          </v-col>
        </v-row>
      </v-col>

      <v-col cols="12" md="12" v-for="(proyecto, i) in muestraPresidencias" :key="proyecto.id">
        <ListProyectosCard :proyecto="proyecto" mios :index="i" />
      </v-col>
      <v-col cols="12" class="pagination">
        <v-pagination v-model="page" :length="Math.ceil(proresidencias.length / totalElem)" prev-icon="mdi-menu-left" next-icon="mdi-menu-right" :page="page" :total-visible="7"></v-pagination>
      </v-col>
    </v-row>
    <v-card
      shaped
      elevation="3"
      class="colores"
      style="display: fixed; z-index:20001;
      margin-right: -1px"
    >
      <div class="elementos">
        Rechazado: <v-avatar size="15" color="red darken-2"></v-avatar>
        <br />
        <br />
        En Proceso: <v-avatar size="15" color="orange darken-2"></v-avatar>
        <br />
        <br />
        Aceptado: <v-avatar size="15" color="light-green darken-2"></v-avatar>
        <br />
        <br />
        Sin estatus: <v-avatar size="15" color="grey lighten-5"></v-avatar>
      </div>
    </v-card>
  </v-container>
</template>

<script>
import ListProyectosCard from "@/views/ListProyectosCard";
import NuevoProyecto from "@/components/NuevoPresidencias";

export default {
  name: "ProyectosResidencias",
  components: {
    NuevoProyecto,
    ListProyectosCard,
  },
  data() {
    return {
      page: 1,
      totalElem: 3,
      nr: false,
      user: this.$store.getters.getUser,
      proresidencias: [],
      Proyecto: [],
      pRes: [],
      type: "",
      search1: "",
      search2: "",
      inputTask: "",
      selected: null,
      info: [this.proresidencias],
      info_fields: {
        CreadoPor: "createdBy",
        Departamento: "departamento",
        Categoria: "categoria",
        "Nombre de proyecto": "nProyecto",
        "Opcion elegida": "opcElegida",
        Periodo: "periodo",
        "Giro de empresa": "giroEmpresa",
        RFC: "rfc",
        "Domicilio (Calle, Numero, Colonia)": "domicilio",
        Colonia: "colonia",
        CP: "cp",
        FAX: "fax",
        Ciudad: "ciudad",
        Estado: "estado",
        Telefono: "telefono",
        Ext: "ext",
        "Nombre del titular de empresa": "ntEmpresa",
        "Puesto NTE": "puestoNTE",
        "Nombre de la persona que firmara el acuerdo": "nfa",
        "Puesto NFA": "puestoNFA",
        "Asesor externo": "asesorExterno",
        "Puesto AE": "puestoAE",
      },
      filter: [],
    };
  },
  /* eslint-disable consistent-return */
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch("fetchPresidencias");
      this.$store.dispatch("fetchMyPresidencias");
    });
  },
  methods: {
    onchange() {
      this.info = this.proresidencias;
    },
    filterTodo() {
      console.log("Hola");
      console.log(this.proresidencias, "PROS");
      this.proresidencias = this.$store.getters.getPresidenciasFilterTodo;
    },
    filter0() {
      this.proresidencias = this.$store.getters.getPresidenciasFilter0;
    },
    filter1() {
      this.proresidencias = this.$store.getters.getPresidenciasFilter1;
    },
    filter2() {
      this.proresidencias = this.$store.getters.getPresidenciasFilter2;
    },
    filter3() {
      this.proresidencias = this.$store.getters.getPresidenciasFilter3;
    },
    created() {
      this.$store.dispatch("fetchPresidencias");
      this.$store.dispatch("fetchMyPresidencias");
      this.nr = false;
    },
  },
  computed: {
    shoun() {
      if (this.$store.getters.getUser.accessLevel === 2) {
        return true;
      }
      return false;
    },
    muestraPresidencias() {
      return this.proresidencias.slice((this.page - 1)
      * this.totalElem, this.page * this.totalElem);
    },
    presidencias() {
      return this.$store.getters.getPresidencias;
    },
    // eslint-disable-next-line consistent-return,vue/return-in-computed-property
    width() {
      // eslint-disable-next-line default-case
      switch (this.$vuetify.breakpoint.name) {
        case "xs":
          return "100%";
        case "sm":
          return "90%";
        case "md":
          return "80%";
        case "lg":
          return "70%";
        case "xl":
          return "70%";
      }
    },
    // vue/no-side-effects-in-computed-properties
    getUser() {
      return this.usuario;
    },
  },
};
</script>

<style scoped>
.colores {
  position: fixed;
  top: 10%;
  right: 1%;
  padding: 20px;
}
.elementos {
  position: relative;
  text-align: right;
}
.nomar {
  margin-top: -0.5rem;
  padding-top: 2.5rem;
}
.centrar {
  display: flex;
  justify-content: center;
}
</style>
