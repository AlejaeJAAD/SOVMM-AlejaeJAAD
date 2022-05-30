<template>
  <v-container>
    <v-row>
      <v-col>
        <div>
          <v-col cols="12">
            <download-excel :data="getMaestros" :fields="info_fields">
              <v-btn color="green" block small class="white--text" @click="imprimir()"> Descargar Excel<v-icon>mdi-microsoft-excel</v-icon> </v-btn>
            </download-excel>
          </v-col>
          <v-col cols="12" sm="4" md="2" lg="4" style="margin-bottom: -2rem">
            <v-btn color="blue darken-1" small class="white--text " @click="creacionMaestro = true">
              Nuevo Maestro
              <CrearMaestro :creacionMaestro="creacionMaestro" @update="crearMaestroMethod" />
            </v-btn>
          </v-col>
        </div>
      </v-col>
      <v-col cols="12">
        <MaestrosTable />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CrearMaestro from "../components/Maestros/CrearMaestro";
import MaestrosTable from "../components/Maestros/MaestrosTable";
export default {
  name: "Maestros",
  data() {
    return {
      info_fields: {
        "Correo institucional": "email",
        "Correo Personal": "personalEmail",
        "Numero de control": "enrollment",
        "Nombre(s)": "firstName",
        "Apellido(s)": "lastName",
        Ciudad: "city",
        Estado: "state",
        CURP: "curp",
        Carrera: "career",
        Departamento: "department",
        Telefono: "phone",
        Direccion: "address"
      },
      creacionMaestro: false
    };
  },
  components: {
    CrearMaestro,
    MaestrosTable
  },

  methods: {
    imprimir() {
      console.log(this.info_fields.email);
    },
    crearMaestroMethod(value) {
      console.log(value);
      this.creacionMaestro = value;
    }
  },
  created() {
    this.$store.dispatch("fetchMaestros");
  },
  computed: {
    getMaestros() {
      return this.$store.getters.getMaestros;
    }
  }
};
</script>

<style lang="scss">
.disenoBoton {
  text-align: center;
  align-content: center;
  align-items: center;
  justify-content: center;
}
</style>
