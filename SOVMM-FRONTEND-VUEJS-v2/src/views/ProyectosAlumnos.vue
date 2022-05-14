<!-- @format -->

<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <h3>Filtrar proyectos por estatus</h3>
        <br />
        <PAFiltros />
        <PACard />
      </v-col>
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
    return {};
  }
};
</script>

<style lang="scss" scoped></style>
