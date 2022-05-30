<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="12">
        <v-dialog v-model="creacionMaestro" persistent max-width="600px">
          <v-card>
            <v-card-title>
              <v-spacer />
              <div class="text-center">
                <span class="text-h5">CREAR MAESTRO</span>
              </div>
              <v-spacer />
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

                <v-row style="justify-content: space-around">
                  <v-col cols="12" style="margin: -2rem 0 -2rem 0">
                    <v-text-field dense label="Nombre(s)" single-line outlined :disabled="toUpdate" maxlength="30" @keypress="checkAlpha($event)" id="Nombres" ref="inpNombres" v-model="nombres"></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field dense label="Apellido(s)" single-line outlined :disabled="toUpdate" maxlength="30" @keypress="checkAlpha($event)" id="Apellidos" ref="inpApellidos" v-model="apellidos"></v-text-field>
                  </v-col>
                  <v-col cols="12" style="margin: -2rem 0 0 0">
                    <v-text-field dense label="Curp" single-line outlined :disabled="toUpdate" counter maxlength="18" id="Curp" ref="inpCurp" v-model="curp"></v-text-field>
                  </v-col>
                  <v-col cols="12" style="margin: -2rem 0 0 0">
                    <v-text-field dense label="Numero de telefono" single-line outlined :disabled="toUpdate" maxlength="10" counter id="Telefono" ref="inpTelefono" @keypress="checkNumber($event)" v-model="telefono"></v-text-field>
                  </v-col>
                  <v-col cols="12" style="margin: -2rem 0 -2rem 0">
                    <v-text-field dense label="Numero de matricula" single-line outlined :disabled="toUpdate" counter maxlength="8" id="Numerodecontrol" @keypress="checkNumber($event)" ref="inpNumerodecontrol" v-model="numerodecontrol"></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field dense label="Correo institucional" :suffix="correoinstitucionalSuffix" single-line outlined :disabled="toUpdate" counter maxlength="8" id="Correoinstitucional" ref="inpCorreoinstitucional" v-model="correoinstitucional"></v-text-field>
                  </v-col>
                  <v-col cols="12" style="margin: -2rem 0 -2rem 0">
                    <v-text-field
                      dense
                      single-line
                      outlined
                      :disabled="toUpdate"
                      maxlength="10"
                      counter
                      id="Contraseña"
                      ref="inpContraseña"
                      :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                      :type="show1 ? 'text' : 'password'"
                      @click:append="show1 = !show1"
                      v-model="contraseña"
                      label="Contraseña"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-select dense label="Carrera" single-line outlined :disabled="toUpdate" @keypress="checkAlpha($event)" id="Carrera" ref="inpCarrera" v-model="carrera" :items="carreras" :rules="rules.carrera"></v-select>
                  </v-col>
                  <v-col cols="12" style="margin: -2rem 0 -2rem 0">
                    <v-select dense label="Departamento" single-line outlined :disabled="toUpdate" @keypress="checkAlpha($event)" id="Departamento" ref="inpDepartamento" v-model="departamento" :items="departamentos" :rules="rules.departamento"> </v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-alert prominent v-if="noMayor" border="right" type="error">
                      El nuevo estudiante debe de ser mayor de edad.
                    </v-alert>
                  </v-col>
                  <v-col cols="12">
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
                  ¿Registrar nuevo maestro?
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
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  props: ["creacionMaestro"],
  data() {
    return {
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
      departamentos: ["Departamento de Metal-Mecanica"],
      correoinstitucionalSuffix: "@culiacan.tecnm.mx"
    };
  },
  created() {
    console.log(this.creacionMaestro);
  },
  watch: {
    // numerodecontrol(val) {
    //   const nControl = val;
    //   this.correoinstitucional = nControl;
    // },
    fechaNacimiento(val) {
      const dates = new Date(val);
      const date2 = new Date(dates.getFullYear() + 18, dates.getMonth(), dates.getDate());
      console.log(date2, new Date(), "fechas");
      if (date2 <= new Date()) {
        console.log("Hola");
        this.noMayor = false;
      } else {
        // eslint-disable-next-line no-unused-expressions
        console.log("Hola2");
        this.fechaNacimiento = "";
        this.noMayor = true;
        setTimeout(() => {
          this.noMayor = false;
        }, 2000);
      }
    }
  },
  methods: {
    cancelar() {
      this.confirmarRegistro = false;
    },
    cerrar() {
      this.$emit("update", false);
    },
    clean() {
      Object.assign(this.$data, this.$options.data());
    },
    cr() {
      this.confirmarRegistro = true;
    },
    registrar() {
      console.log(this.checaCamposVacio());
      if (this.checaCamposVacio()) {
        this.camposVacios = true;
        setTimeout(() => {
          this.camposVacios = false;
        }, 7000);
      } else {
        console.log(this.correoinstitucional + this.correoinstitucionalSuffix);
        const maestro = {
          image: "https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/LogotipoTec.png",
          email: this.correoinstitucional + this.correoinstitucionalSuffix,
          password: this.contraseña,
          firstName: this.nombres,
          lastName: this.apellidos,
          city: this.ciudad,
          state: this.estado,
          suburb: "",
          gender: "",
          curp: this.curp,
          phone: this.telefono,
          address: this.direccion,
          career: this.carrera,
          enrollment: this.numerodecontrol,
          department: this.departamento,
          personalEmail: "",
          birthDate: new Date(this.fechaNacimiento).toISOString(),
          userSince: new Date().toISOString(),
          status: true,
          accessLevel: 2
          // eslint-disable-next-line semi
        };
        console.log(maestro.birthDate, maestro.userSince, maestro);
        this.$store.dispatch("insertTeacher", maestro);
      }
      console.log(this.camposVacios);
      if (this.camposVacios) {
        this.$emit("update", false);
        this.confirmarRegistro = false;
      } else {
        this.$emit("update", false);
        this.clean();
      }
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
        // } else if (!this.ciudad) {
        //   this.$refs.inpCiudad.focus();
        //   return true;
        // } else if (!this.estado) {
        //   this.$refs.inpEstado.focus();
        //   return true;
        // } else if (!this.curp) {
        //   this.$refs.inpCurp.focus();
        //   return true;
      } else if (!this.telefono) {
        this.$refs.inpTelefono.focus();
        return true;
        // } else if (!this.direccion) {
        //   this.$refs.inpDireccion.focus();
        //   return true;
        // } else if (!this.carrera) {
        //   this.$refs.inpCarrera.focus();
        //   return true;
      } else if (!this.numerodecontrol) {
        this.$refs.inpNumerodecontrol.focus();
        return true;
      } else if (!this.departamento) {
        this.$refs.inpDepartamento.focus();
        return true;
        // } else if (!this.fechaNacimiento) {
        //   this.$refs.inpfNacimiento.focus();
        //   return true;
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
  }
};
</script>

<style lang="scss" scoped></style>
