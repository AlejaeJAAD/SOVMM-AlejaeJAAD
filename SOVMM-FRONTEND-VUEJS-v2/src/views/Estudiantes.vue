<template>
  <v-lazy
    v-model="isActive"
    :options="{
      threshold: 0.5
    }"
    style="width: auto;"
    min-height="auto"
    transition="fade-transition"
  >
    <v-container>
      <v-row>
        <v-col>
          <div>
            <v-col cols="12">
              <download-excel :data="getEstudiantes" :fields="info_fields">
                <v-btn color="green" block small class="white--text" @click="imprimir"> Descargar Excel<v-icon>mdi-microsoft-excel</v-icon> </v-btn>
              </download-excel>
            </v-col>
            <v-col cols="12" sm="4" md="2" lg="4" style="margin-bottom: -2rem">
              <v-btn block color="blue darken-1" small class="white--text" @click="edit()">
                Nuevo Estudiante
              </v-btn>
            </v-col>
          </div>
        </v-col>
        <v-col cols="12">
          <EstudiantesTable />
        </v-col>
        <v-col cols="auto" sm="8" md="10" lg="8"></v-col>
        <v-col>
          <v-row justify="center">
            <v-dialog v-model="confirmar" persistent max-width="800px">
              <v-card>
                <v-card-title>
                  <span class="text-h5">Nuevo Estudiante</span>
                </v-card-title>
                <v-divider></v-divider>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12">
                        <v-alert v-if="camposVacios" border="right" prominent type="error">
                          Por favor llenar todos los campos.
                        </v-alert>
                      </v-col>
                      <v-col cols="12">
                        <v-alert v-if="errorAlpha" border="right" prominent type="info">
                          Solo se permiten caracteres alfabeticos.
                        </v-alert>
                      </v-col>
                    </v-row>

                    <v-row>
                      <v-col cols="4">
                        <label>Correo institucional</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled id="Correoinstitucional" ref="inpCorreoinstitucional" v-model="correoinstitucional" label="Correo electronico" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Contraseña</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field
                          :disabled="toUpdate"
                          filled
                          maxlength="10"
                          counter
                          id="Contraseña"
                          ref="inpContraseña"
                          :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                          :type="show1 ? 'text' : 'password'"
                          @click:append="show1 = !show1"
                          v-model="contraseña"
                          label="Contraseña"
                          color="cyan darken"
                        ></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Nombres:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="30" @keypress="checkAlpha($event)" id="Nombres" ref="inpNombres" v-model="nombres" label="Nombre(s)" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Apellido(s):</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="30" @keypress="checkAlpha($event)" id="Apellidos" ref="inpApellidos" v-model="apellidos" label="Apellido(s)" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Ciudad:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="15" @keypress="checkAlpha($event)" id="Ciudad" ref="inpCiudad" v-model="ciudad" label="Ciudad" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Estado:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="15" @keypress="checkAlpha($event)" id="Estado" ref="inpEstado" v-model="estado" label="Estado" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Curp:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled counter maxlength="18" id="Curp" ref="inpCurp" v-model="curp" label="Curp" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Telefono:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="10" counter id="Telefono" ref="inpTelefono" @keypress="checkNumber($event)" v-model="telefono" label="Telefono" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Direccion:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled maxlength="30" id="Direccion" ref="inpDireccion" v-model="direccion" label="Direccion" color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Carrera:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-select :disabled="toUpdate" filled @keypress="checkAlpha($event)" id="Carrera" ref="inpCarrera" v-model="carrera" label="Carrera" color="cyan darken" :items="carreras" :rules="rules.carrera"></v-select>
                      </v-col>
                      <v-col cols="4">
                        <label>Numero de control:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-text-field :disabled="toUpdate" filled counter maxlength="8" id="Numerodecontrol" @keypress="checkNumber($event)" ref="inpNumerodecontrol" v-model="numerodecontrol" label="Numero de control" outlined color="cyan darken"></v-text-field>
                      </v-col>
                      <v-col cols="4">
                        <label>Departamento:</label>
                      </v-col>
                      <v-col cols="8">
                        <v-select :disabled="toUpdate" filled @keypress="checkAlpha($event)" id="Departamento" ref="inpDepartamento" v-model="departamento" label="Departamento" outlined color="cyan darken" :items="departamentos" :rules="rules.departamento"> </v-select>
                      </v-col>
                      <v-col cols="12">
                        <v-alert prominent v-if="noMayor" border="right" type="error">
                          El nuevo estudiante debe de ser mayor de edad.
                        </v-alert>
                      </v-col>
                      <v-col cols="4">
                        <label>Fecha nacimiento(s):</label>
                      </v-col>
                      <v-col cols="8">
                        <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :return-value.sync="fechaNacimiento" transition="scale-transition" offset-y min-width="auto">
                          <template v-slot:activator="{ on, attrs }">
                            <v-text-field v-model="fechaNacimiento" label="Selecciona fecha de nacimiento de alumno" prepend-icon="mdi-calendar" readonly v-bind="attrs" v-on="on"></v-text-field>
                          </template>
                          <v-date-picker :disabled="toUpdate" type="date" ref="inpfNacimiento" v-model="fechaNacimiento" elevation="5" year-icon="mdi-calendar-blank" prev-icon="mdi-skip-previous" next-icon="mdi-skip-next" no-title scrollable>
                            <v-spacer></v-spacer>
                            <v-btn text color="primary" @click="menu = false">
                              Cancel
                            </v-btn>
                            <v-btn text color="primary" @click="$refs.menu.save(fechaNacimiento)">
                              OK
                            </v-btn>
                          </v-date-picker>
                        </v-menu>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn outlined color="red" text @click="cerrar">
                    Cerrar
                  </v-btn>
                  <v-btn outlined color="blue darken-1" text @click="cr">
                    Aceptar
                  </v-btn>
                </v-card-actions>
                <v-dialog v-model="confirmarRegistro" width="700px">
                  <v-card>
                    <v-card-title class="text-h5 justify-center">
                      ¿Registrar nuevo alumno?
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn color="red" outlined @click="cancelar">
                        Cancelar
                      </v-btn>
                      <v-spacer></v-spacer>
                      <v-btn color="green darken-1" outlined @click="registrar">
                        Aceptar
                      </v-btn>
                      <v-spacer></v-spacer>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
              </v-card>
            </v-dialog>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
  </v-lazy>
</template>

<script>
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
      isActive: false,
      noMayor: false,
      camposVacios: false,
      errorAlpha: false,
      confirmar: false,
      confirmacion: false,
      show1: false,
      toUpdate: false,
      correoinstitucional: "",
      contraseña: "",
      nombres: "",
      apellidos: "",
      ciudad: "",
      estado: "",
      curp: "",
      telefono: "",
      direccion: "",
      carrera: "",
      numerodecontrol: "",
      departamento: "",
      fechaNacimiento: new Date(Date.now() - new Date().getTimezoneOffset() * 60000).toISOString().substr(0, 10),
      confirmarRegistro: false,
      menu: false,
      modal: false,
      menu2: false,
      date: new Date(Date.now() - new Date().getTimezoneOffset() * 60000).toISOString().substr(0, 10),
      rules: {
        carrera: [val => (val || "").length > 0 || "Este campo es requerido"],
        departamento: [val => (val || "").length > 0 || "Este campo es requerido"]
      },
      carreras: ["Ingenieria Mecanica", "Ingenieria Mecatronica"],
      departamentos: ["Departamento de Metal-Mecanica"]
    };
  },
  components: {
    EstudiantesTable
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
    fechaNacimiento(val) {
      const dates = new Date(val);
      const date2 = new Date(dates.getFullYear() + 18, dates.getMonth(), dates.getDate());
      if (date2 <= new Date()) {
        this.noMayor = false;
      } else {
        // eslint-disable-next-line no-unused-expressions
        this.fechaNacimiento = "";
        this.noMayor = true;
        setTimeout(() => {
          this.noMayor = false;
        }, 2000);
      }
    }
  },
  methods: {
    imprimir() {
      console.log(this.info_fields.email);
    },
    cancelar() {
      this.confirmarRegistro = false;
    },
    edit() {
      this.confirmar = true;
    },
    cerrar() {
      this.confirmar = false;
    },
    clean() {
      Object.assign(this.$data, this.$options.data());
    },
    cr() {
      this.confirmarRegistro = true;
    },
    registrar() {
      if (this.checaCamposVacio()) {
        this.camposVacios = true;
        setTimeout(() => {
          this.camposVacios = false;
        }, 7000);
      } else {
        const estudiante = {
          image: "",
          email: this.correoinstitucional,
          password: this.contraseña,
          firstName: this.nombres,
          lastName: this.apellidos,
          city: this.ciudad,
          state: this.estado,
          curp: this.curp,
          phone: this.telefono,
          address: this.direccion,
          career: this.carrera,
          enrollment: this.numerodecontrol,
          department: this.departamento,
          birthDate: new Date(this.fechaNacimiento).toISOString(),
          userSince: new Date().toISOString(),
          status: true,
          accessLevel: 3
          // eslint-disable-next-line semi
        };
        this.$store.dispatch("insertStudent", estudiante);
      }
      if (this.camposVacios) {
        this.confirmarRegistro = false;
      } else {
        this.clean();
      }
      this.isActive = true;
    },
    /* eslint no-else-return: "error" */
    checaCamposVacio() {
      if (!this.correoinstitucional) {
        this.$refs.inpCorreoinstitucional.focus();
        return true;
      } else if (!this.contraseña) {
        this.$refs.inpContraseña.focus();
        return true;
      } else if (!this.nombres) {
        this.$refs.inpNombres.focus();
        return true;
      } else if (!this.apellidos) {
        this.$refs.inpApellidos.focus();
        return true;
      } else if (!this.ciudad) {
        this.$refs.inpCiudad.focus();
        return true;
      } else if (!this.estado) {
        this.$refs.inpEstado.focus();
        return true;
      } else if (!this.curp) {
        this.$refs.inpCurp.focus();
        return true;
      } else if (!this.telefono) {
        this.$refs.inpTelefono.focus();
        return true;
      } else if (!this.direccion) {
        this.$refs.inpDireccion.focus();
        return true;
      } else if (!this.carrera) {
        this.$refs.inpCarrera.focus();
        return true;
      } else if (!this.numerodecontrol) {
        this.$refs.inpNumerodecontrol.focus();
        return true;
      } else if (!this.departamento) {
        this.$refs.inpDepartamento.focus();
        return true;
      } else if (!this.fechaNacimiento) {
        this.$refs.inpfNacimiento.focus();
        return true;
        // eslint-disable-next-line no-else-return
      } else {
        return false;
      }
    },
    checkNumber(evt) {
      if (evt.keyCode > 31 && (evt.keyCode < 48 || evt.keyCode > 57) && evt.keyCode !== 46) {
        evt.preventDefault();
      }
      return true;
    },
    checkAlpha(evt) {
      // eslint-disable-next-line no-mixed-operators
      if (
        !(
          (evt.keyCode >= 65 && evt.keyCode <= 90) ||
          // eslint-disable-next-line no-mixed-operators
          (evt.keyCode >= 97 && evt.keyCode <= 122) ||
          evt.keyCode === 32
        )
      ) {
        evt.preventDefault();
        if (!this.errorAlpha) {
          this.errorAlpha = true;
          setTimeout(() => {
            this.errorAlpha = false;
          }, 5000);
        }
      }
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

<style scoped></style>
