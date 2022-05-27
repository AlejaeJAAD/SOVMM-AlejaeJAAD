<!-- @format -->

<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <PAFiltros :error="error" :getPresidenciasLength="getPresidenciasLength" :getPresidencias="getPresidencias" />
      </v-col>
      <v-col cols="12" v-if="proyectosCargados">
        <v-card style="margin: 1rem">
          Cargando proyectos...
        </v-card>
      </v-col>
      <v-col cols="12" lg="4" md="4" sm="6" xs="12" v-for="presidencia in getPresidencias" :key="presidencia.id" v-else>
        <PACard :presidencia="presidencia" v-if="!error" />
      </v-col>
      <v-col cols="12" class="pagination">
        <v-pagination v-model="page" :length="Math.ceil(getPresidenciasLength / totalElem)" prev-icon="mdi-menu-left" next-icon="mdi-menu-right" :page="page" :total-visible="7"></v-pagination>
      </v-col>
      <!-- <v-col>
        <v-card
          justify="right"
          elevation="1"
          class="colores"
          style="display: fixed; z-index:1;
      "
        >
          <div class="elementos">
            Sin estatus: <v-avatar size="15" color="grey lighten-5"></v-avatar>
            <br />
            <br />
            Aceptado: <v-avatar size="15" color="light-green darken-2"></v-avatar>
            <br />
            <br />
            En Proceso: <v-avatar size="15" color="orange darken-2"></v-avatar>
            <br />
            <br />
            Rechazado: <v-avatar size="15" color="red darken-2"></v-avatar>
            <br />
            <br />
          </div>
        </v-card>
      </v-col> -->
    </v-row>
  </v-container>
</template>

<script>
import PAFiltros from "@/components/ProyectosAlumnos/PAFiltros.vue";
import PACard from "@/components/ProyectosAlumnos/PACard.vue";
export default {
  components: {
    PAFiltros,
    PACard
  },
  data() {
    return {
      proyectosCargados: true,
      error: false,
      page: 1,
      totalElem: 6
    };
  },
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch("fetchPresidencias");
      setTimeout(() => {
        this.proyectosCargados = false;
      }, 2000);
    });
  },
  computed: {
    getPresidencias() {
      return this.$store.getters.getPresidencias.slice((this.page - 1) * this.totalElem, this.page * this.totalElem);
    },
    getPresidenciasLength() {
      return this.$store.getters.getPresidencias.length;
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
</style>
