<template>
  <v-container>
    <v-row>
      <v-col cols="12" lg="8" md="12" sm="12" xs="12">
        <v-card class="cardCount">
          <h3>
            Conteo de proyectos de residencias:
            <h2 style="padding: 1px 0 0 0.1rem">{{ getPresidenciasLength }}</h2>
          </h3>
          <v-sheet>El conteo se realiza en base a los filtros que sean seleccionados.</v-sheet>
          <v-row>
            <v-col>
              <v-sheet class="cardCount2">
                <v-card-subtitle style="font-weight: bold">
                  Al momento de descargar el archivo Excel, dependiendo del estatus que haya sido seleccionado seran los proyectos que contenga dicho archivo Excel.
                </v-card-subtitle>
              </v-sheet>
            </v-col>
            <v-col cols="12">
              <download-excel :data="getPresidencias" :fields="info_fields">
                <v-btn type="button" class="white--text" style="background-color: rgba(1, 114, 58, 1)" block outlined> Generar Excel <v-icon>mdi-microsoft-excel</v-icon> </v-btn>
              </download-excel>
            </v-col>
          </v-row>
        </v-card>
      </v-col>
      <v-col cols="12" lg="4" md="4" sm="12" xs="12">
        <v-card min-heigth="90%">
          <v-col cols="12"><h3>Filtrar proyectos por estatus</h3></v-col>
          <v-col cols="12">
            <v-btn small color="white" block @click="setFilter((filter = 0))">Sin estatus <v-icon>mdi-filter</v-icon></v-btn>
          </v-col>
          <v-col cols="12">
            <v-btn small color="green" block @click="setFilter((filter = 1))">Aceptado <v-icon>mdi-filter</v-icon></v-btn>
          </v-col>
          <v-col cols="12">
            <v-btn small color="orange" block @click="setFilter((filter = 2))">En proceso <v-icon>mdi-filter</v-icon></v-btn>
          </v-col>
          <v-col cols="12">
            <v-btn small color="red" block @click="setFilter((filter = 3))">Rechazado <v-icon>mdi-filter</v-icon></v-btn>
          </v-col>
          <v-col cols="12">
            <v-btn outlined small color="black" block @click="noFilter()">Sin filtro <v-icon>mdi-filter</v-icon></v-btn>
          </v-col>
        </v-card>
      </v-col>
      <v-col>
        <v-row>
          <v-col cols="12">
            <v-card class="cardCount2">
              <v-card-subtitle style="font-weight: bold">
                Para poder visualizar mas informacion de los proyectos de residencias basta con pulsar una de las cartas que se encuentra debajo. <br />
                Esta accion lo redirigira a otra pagina en la cual apareceran los detalles del proyecto seleccionado.
              </v-card-subtitle>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  props: ["getPresidenciasLength", "getPresidencias"],
  data() {
    return {
      filter: "",
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
        "Puesto AE": "puestoAE"
      }
    };
  },
  methods: {
    setFilter(filter) {
      console.log(filter);
      this.$store.dispatch("fetchPresidenciasFilter", filter);
    },
    noFilter() {
      this.$store.dispatch("fetchPresidencias");
    }
  }
};
</script>

<style lang="scss" scoped>
.spaceB {
  justify-content: space-around;
}
.cardCount {
  padding: 1rem;
  border-width: 1px;
  border-style: solid;
  border-color: rgba(0, 0, 0, 0.289);
}
.cardCount2 {
  border-width: 1px;
  border-style: solid;
  border-color: rgba(0, 0, 0, 0.289);
}
</style>
