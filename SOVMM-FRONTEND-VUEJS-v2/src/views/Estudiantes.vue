<template>
  <v-container>
    <v-row>
      <v-col>
        <div>
          <v-col cols="12">
            <download-excel :data="getEstudiantes" :fields="info_fields">
              <v-btn color="green" block small class="white--text" @click="imprimir()"> Descargar Excel<v-icon>mdi-microsoft-excel</v-icon> </v-btn>
            </download-excel>
          </v-col>
          <v-col cols="12" sm="4" md="2" lg="4" style="margin-bottom: -2rem">
            <v-btn color="blue darken-1" small class="white--text " @click="creacionEstudiante = true">
              Nuevo Estudiante
              <CrearEstudiante :creacionEstudiante="creacionEstudiante" @update="crearEstudianteMethod" />
            </v-btn>
          </v-col>
        </div>
      </v-col>
      <v-col cols="12">
        <EstudiantesTable />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import CrearEstudiante from "../components/Estudiantes/CrearEstudiante";
import EstudiantesTable from "../components/Estudiantes/EstudiantesTable";
export default {
  name: "Estudiantes",
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
      creacionEstudiante: false
    };
  },
  components: {
    CrearEstudiante,
    EstudiantesTable
  },

  methods: {
    imprimir() {
      console.log(this.info_fields.email);
    },
    crearEstudianteMethod(value) {
      console.log(value);
      this.creacionEstudiante = value;
    }
  },
  created() {
    this.$store.dispatch("fetchEstudiantes");
  },
  computed: {
    getEstudiantes() {
      return this.$store.getters.getEstudiantes;
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
