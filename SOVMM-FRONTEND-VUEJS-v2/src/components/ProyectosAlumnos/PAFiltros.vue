<template>
  <v-container>
    <v-row>
      <v-col cols="3">
        <v-btn small color="white" block>Sin estatus</v-btn>
      </v-col>
      <v-col cols="3">
        <v-btn small color="green" block>Aceptado</v-btn>
      </v-col>
      <v-col cols="3">
        <v-btn small color="orange" block>En proceso</v-btn>
      </v-col>
      <v-col cols="3">
        <v-btn small color="red" block>Rechazado</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
.spaceB {
  justify-content: space-around;
}
</style>
