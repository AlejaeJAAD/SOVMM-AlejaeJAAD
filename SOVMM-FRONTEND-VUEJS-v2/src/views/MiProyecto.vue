<!-- @format -->

<template>
  <v-container class="nomar">
    <v-row>
      <v-col cols="12">
        <v-btn fixed color="white" elevation="5" fab @click="nr = true" large style="margin-left: -15px">
          <v-icon>mdi-text-box-plus</v-icon>
        </v-btn>
        <v-dialog persistent :width="width" v-model="nr">
          <CrearProyectoResidencias v-if="nr" @onClose="nr = false" @createdP="createdP" />
        </v-dialog>
      </v-col>
      <v-col cols="12" v-if="proyectosCargados">
        <v-card style="margin: 1rem">
          Cargando proyecto...
        </v-card>
      </v-col>
      <v-col cols="12" lg="12" md="12" sm="12" xs="12" v-for="presidencia in getPresidencias" :key="presidencia.id" v-else>
        <ListPRCard :presidencia="presidencia" />
      </v-col>
    </v-row>
    <v-card shaped elevation="3" class="colores" style="position: absolute;" color="white">
      <div class="elementos filter">
        Rechazado: <v-avatar size="25" color="red darken-2"></v-avatar>
        <br />
        <br />
        En Proceso: <v-avatar size="25" color="orange darken-2"></v-avatar>
        <br />
        <br />
        Aceptado: <v-avatar size="25" color="light-green darken-2"></v-avatar>
        <br />
        <br />
        Sin estatus: <v-avatar size="25" color="grey lighten-5"></v-avatar>
      </div>
    </v-card>
  </v-container>
</template>

<script>
import CrearProyectoResidencias from "@/components/Global/CrearProyectoResidencias";
import ListPRCard from "@/components/MiProyectoAlumno/ListPRCard";
export default {
  components: {
    CrearProyectoResidencias,
    ListPRCard
  },
  data() {
    return {
      nr: false,
      proyectosCargados: true
    };
  },
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch("fetchMiPresidencias");
      setTimeout(() => {
        this.proyectosCargados = false;
      }, 2000);
    });
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
    getPresidencias() {
      return this.$store.getters.getMiProyectoResidencias;
    }
  },
  methods: {
    createdP() {
      this.$store.dispatch("fetchPresidencias");
      this.$store.dispatch("fetchMiPresidencias");
      this.nr = false;
    }
  }
};
</script>

<style lang="scss" scoped>
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
</style>
