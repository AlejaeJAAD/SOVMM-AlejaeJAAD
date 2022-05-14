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
                    <v-col cols=12>
                      <download-excel :data="getMaestros" :fields="info_fields">
                        <v-btn color="green" block small class="white--text">
                          Descargar Excel<v-icon>mdi-microsoft-excel</v-icon>
                        </v-btn>
                      </download-excel>
                    </v-col>
                    <v-col cols=12 sm=4 md=2 lg=4 style="margin-bottom: -2rem">
                      <v-btn  block color="blue darken-1" small class="white--text"
                              @click="edit()"
                      >
                              Nuevo Maestro
                      </v-btn>
                    </v-col>
                  </div>
                </v-col>
                <v-col cols=12>
                  <MaestrosTable/>
                </v-col>
                <v-col cols=auto sm=8 md=10 lg=8></v-col>
                <v-col>
                  <v-row justify="center">
                    <v-dialog
                    v-model="confirmar"
                    persistent
                    max-width="600px"
                    >
                      <v-card>
                        <v-card-title>
                          <span class="text-h5">Nuevo Maestro</span>
                        </v-card-title>
                        <v-divider></v-divider>
                        <v-card-text>
                          <v-container>
                            <v-row>
                              <v-col cols=12>
                                <div v-if="camposVacios" class="alert alert-warning"
                                      role="alert">
                                      Por favor llenar todos los campos.
                                </div>
                              </v-col>
                              <v-col cols=12>
                                <div  v-if="errorAlpha" class="alert alert-warning"
                                      role="alert">
                                      Solo se permiten caracteres alfabeticos.
                                </div>
                              </v-col>
                            </v-row>

                            <v-row>
                              <v-col cols=4>
                                <label>Correo institucional</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  counter
                                  id="Correoinstitucional"
                                  ref="inpCorreoinstitucional"
                                  v-model="correoinstitucional"
                                  label="Correo electronico"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Contraseña</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  id="Contraseña"
                                  ref="inpContraseña"
                                  :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                                  :type="show1 ? 'text' : 'password'"
                                  @click:append="show1 = !show1"
                                  v-model="contraseña"
                                  label="Contraseña"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Nombres:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Nombres"
                                  ref="inpNombres"
                                  v-model="nombres"
                                  label="Nombre(s)"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Apellido(s):</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Apellidos"
                                  ref="inpApellidos"
                                  v-model="apellidos"
                                  label="Apellido(s)"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Ciudad:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Ciudad"
                                  ref="inpCiudad"
                                  v-model="ciudad"
                                  label="Ciudad"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Estado:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Estado"
                                  ref="inpEstado"
                                  v-model="estado"
                                  label="Estado"
                                  placeholder="Sinaloa"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Curp:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  id="Curp"
                                  ref="inpCurp"
                                  v-model="curp"
                                  label="Curp"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Telefono:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  id="Telefono"
                                  ref="inpTelefono"
                                  v-model="telefono"
                                  label="Telefono"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Direccion:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  id="Direccion"
                                  ref="inpDireccion"
                                  v-model="direccion"
                                  label="Direccion"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Carrera:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Carrera"
                                  ref="inpCarrera"
                                  v-model="carrera"
                                  label="Carrera"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Numero de matricula:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  id="Numerodematricula"
                                  ref="inpNumerodematricula"
                                  v-model="numerodematricula"
                                  label="Numero de matricula"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <v-col cols=4>
                                <label>Departamento:</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <v-text-field
                                  :disabled="toUpdate"
                                  filled
                                  shaped
                                  maxlength="30"
                                  @keypress="checkAlpha($event)"
                                  id="Departamento"
                                  ref="inpDepartamento"
                                  v-model="departamento"
                                  label="Departamento"
                                  outlined color="cyan darken"
                                ></v-text-field>
                              </v-col>
                              <div v-if="noMayor" class="alert alert-warning" role="alert">
                                El nuevo maestro debe de ser mayor de edad.
                              </div>
                              <v-col cols=4>
                                <label>Fecha nacimiento(s):</label>
                              </v-col>
                              <v-col
                                cols="8"
                              >
                                <input  :disabled="toUpdate" type="date" ref="inpfNacimiento"
                                        v-model="fNacimiento"
                                >
                              </v-col>
                            </v-row>
                          </v-container>
                        </v-card-text>
                        <v-card-actions>
                          <v-spacer></v-spacer>
                          <v-btn
                            color="blue darken-1"
                            text
                            @click="cerrar"
                          >
                            Cerrar
                          </v-btn>
                          <v-btn
                            color="blue darken-1"
                            text
                            @click="registrar"
                          >
                            Aceptar
                          </v-btn>
                        </v-card-actions>
                      </v-card>
                    </v-dialog>
                  </v-row>
                </v-col>
            </v-row>
        </v-container>
    </v-lazy>
</template>

<script>
import MaestrosTable from '../components/Maestros/MaestrosTable';

export default {
  name: 'Maestros',
  data() {
    return {
      info_fields: {
        'Correo institucional': 'email',
        'Correo Personal': 'personalEmail',
        'Numero de matricula': 'enrollment',
        'Nombre(s)': 'firstName',
        'Apellido(s)': 'lastName',
        Ciudad: 'city',
        Estado: 'state',
        CURP: 'curp',
        Carrera: 'career',
        Departamento: 'department',
        Telefono: 'phone',
        Direccion: 'address',
      },
      isActive: false,
      noMayor: false,
      camposVacios: false,
      errorAlpha: false,
      confirmar: false,
      confirmacion: false,
      show1: false,
      toUpdate: false,
      correoinstitucional: '',
      contraseña: '',
      nombres: '',
      apellidos: '',
      ciudad: '',
      estado: '',
      curp: '',
      telefono: '',
      direccion: '',
      carrera: '',
      numerodematricula: '',
      departamento: '',
      fNacimiento: '',
    };
  },
  components: {
    MaestrosTable,
  },
  watch: {
    isActive() {
      console.log(this.isActive);
    },
    fechaNacimiento(val) {
      const date = new Date(val);
      const date2 = new Date(date.getFullYear() + 18, date.getMonth(), date.getDate());
      if (date2 <= new Date()) {
        this.noMayor = false;
      } else {
        // eslint-disable-next-line no-unused-expressions
        this.fechaNacimiento = '';
        this.noMayor = true;
        setTimeout(() => {
          this.noMayor = false;
        }, 2000);
      }
    },
  },
  methods: {
    edit() {
      this.confirmar = true;
    },
    cerrar() {
      this.confirmar = false;
    },
    clean() {
      Object.assign(this.$data, this.$options.data());
    },
    registrar() {
      if (this.checaCamposVacio()) {
        this.camposVacios = true;
        setTimeout(() => {
          this.camposVacios = false;
        }, 7000);
      } else {
        const maestro = {
          image: '',
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
          enrollment: this.numerodematricula,
          department: this.departamento,
          birthDate: new Date(this.fNacimiento).toISOString(),
          userSince: new Date().toISOString(),
          status: true,
          accessLevel: 2,
        // eslint-disable-next-line semi
        }
        this.$store.dispatch('insertTeacher', maestro);
      }
      this.clean();
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
      } else if (!this.numerodematricula) {
        this.$refs.inpNumerodematricula.focus();
        return true;
      } else if (!this.departamento) {
        this.$refs.inpDepartamento.focus();
        return true;
      } else if (!this.fNacimiento) {
        this.$refs.inpfNacimiento.focus();
        return true;
      // eslint-disable-next-line no-else-return
      } else {
        return false;
      }
    },
    checkAlpha(evt) {
      // eslint-disable-next-line no-mixed-operators
      if (!(evt.keyCode >= 65 && evt.keyCode <= 90
          // eslint-disable-next-line no-mixed-operators
          || evt.keyCode >= 97 && evt.keyCode <= 122
          || evt.keyCode === 32)) {
        evt.preventDefault();
        if (!this.errorAlpha) {
          this.errorAlpha = true;
          setTimeout(() => {
            this.errorAlpha = false;
          }, 5000);
        }
      }
    },
  },
  created() {
    this.$store.dispatch('fetchMaestros');
  },
  computed: {
    getMaestros() {
      return this.$store.getters.getMaestros;
    },
  },
};
</script>

<style scoped>

</style>
