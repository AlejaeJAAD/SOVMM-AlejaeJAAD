<template>
  <v-form>
    <v-card style="padding: 10px" elevation="3">
      <v-row style="margin-bottom: 5px">
        <v-col cols="4" offset="4" offset-md="0" md="2">
          <v-avatar color="grey lighten-3" size="150">
            <v-img :src="imagen"></v-img>
          </v-avatar>
        </v-col>
        <v-col cols="12" offset-md="1" md="4">
          <image-handler single :disabled="!editable"
                         style="margin-top: 15%" v-model="image"></image-handler>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-row style="margin-top: 5px">
        <v-col cols="12" md="4">
          <v-text-field label="Nombre(s)"
                        solo
                        :readonly="!editable"
                        v-model="firstName"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Apellido(s)"
                        solo
                        :readonly="!editable"
                        v-model="lastName"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-menu
            ref="menu"
            v-model="menu"
            :close-on-content-click="false"
            :return-value.sync="fNacimiento"
            transition="scale-transition"
            offset-y
            disabled
            min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="fNacimiento"
                label="Fecha De Nacimiento"
                readonly
                solo-inverted
                v-on="on"
              >
              </v-text-field>
            </template>
            <v-date-picker
              v-model="fNacimiento"
              no-title
              scrollable
              locale="es"
            >
              <v-spacer></v-spacer>
              <v-btn text color="red" @click="menu = false">Cancelar</v-btn>
              <v-btn text color="green" @click="$refs.menu.save(fNacimiento)"
              >Ok
              </v-btn
              >
            </v-date-picker>
          </v-menu>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field label="Telefono"
                        solo
                        type="number"
                        :readonly="!editable"
                        v-model.number="phone"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Correo Institucional"
                        solo
                        readonly
                        :disabled="myUser.accessLevel === 1 || myUser.accessLevel === 2
                         || myUser.accessLevel === 3"
                        type="email" v-model="email"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field
            label="Correo Personal"
            solo
            :readonly="!editable"
            :disabled="myUser.accessLevel === 1 || myUser.accessLevel === 2"
            v-model="emailPersonal">
          </v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field
            label="Estado"
            solo
            :readonly="!editable"
            v-model="state">
          </v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field
            label="Ciudad"
            solo
            :readonly="!editable"
            v-model="city">
          </v-text-field>
        </v-col>
        <v-col cols="5" md="5">
          <v-autocomplete solo
                          placeholder="Departamento:" v-model="departamento"
                          :readonly="!editable"
                          :items="['Departamento de Metal-Mecanica',
                            'Departamento de Sistemas y Computacion']"
          ></v-autocomplete>
        </v-col>
        <v-col cols="5" md="5">
          <v-text-field
            label="Numero de matricula"
            solo
            :readonly="!editable"
            :disabled="myUser.accessLevel === 1 || myUser.accessLevel === 2 ||
            myUser.accessLevel === 3"
            v-model="nm">
          </v-text-field>
        </v-col>
        <v-col cols="12" md="12">
          <v-text-field
            label="Direccion"
            solo
            :readonly="!editable"
            :disabled="myUser.accessLevel === 1 || myUser.accessLevel === 2"
            v-model="dir">
          </v-text-field>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="orange"
               v-if="!editable"
               class="white--text"
               @click="editable = !editable">Editar
        </v-btn>
        <v-btn color="red" class="white--text"
               v-if="editable"
               @click="cancelar">Cancelar
        </v-btn>
        <v-btn color="green" class="white--text"
               v-if="editable"
               @click="actualizar">Actualizar
        </v-btn>
      </v-card-actions>
      <v-dialog
        v-model="dialog" max-width="290">
        <v-card>
          <v-card-title class="text-h5">
            <v-icon>mdi-alert-circle</v-icon>
          </v-card-title>
          <v-card-text>
            La informacion del usuario ha sido actualizada.
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="green darken-1"
              text
              @click="dialog = false"
            >
              Aceptar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-card>
  </v-form>
</template>

<script>
import Axios from 'axios';
import ImageHandler from '@/components/Global/ImageHandler';

export default {
  components: { ImageHandler },
  props: ['myUser'],
  name: 'PersonalLvl2',
  data() {
    return {
      prevUser: '',
      editable: false,
      imagen: '',
      image: [],
      fNacimiento: '',
      firstName: '',
      lastName: '',
      phone: '',
      email: '',
      emailPersonal: '',
      curp: '',
      state: '',
      city: '',
      departamento: '',
      nm: '',
      dir: '',
      menu: false,
      dialog: false,
    };
  },
  methods: {
    castUser() {
      if (this.myUser.image != null) {
        this.imagen = this.myUser.image;
      } else {
        this.imagen = '';
        this.image = [];
      }
      this.firstName = this.myUser.firstName;
      this.lastName = this.myUser.lastName;
      if (this.myUser.birthDate) {
        this.fNacimiento = new Date(this.myUser.birthDate).toISOString().substring(0, 10);
      }
      this.phone = this.myUser.phone;
      this.email = this.myUser.email;
      this.emailPersonal = this.myUser.emailPersonal;
      this.curp = this.myUser.curp;
      this.state = this.myUser.state;
      this.city = this.myUser.city;
      this.departamento = this.myUser.departamento;
      this.nm = this.myUser.numeroMatricula;
      this.dir = this.myUser.direccion;
      console.log('Hola', this.myUser);
    },
    cancelar() {
      this.castUser();
      this.editable = false;
    },
    actualizar() {
      this.dialog = true;
      const UpdatedUserData = {
        id: this.myUser.id,
        email: this.myUser.email,
        emailPersonal: this.emailPersonal,
        image: this.myUser.image,
        firstName: this.firstName,
        lastName: this.lastName,
        city: this.city,
        state: this.state,
        curp: this.myUser.curp,
        phone: this.phone.toString(),
        departamento: this.departamento,
        numeroControl: this.nm,
        direccion: this.dir,
        password: 'nopassword',
        accessLevel: this.myUser.accessLevel,
        birthDate: this.myUser.birthDate,
        userSince: this.myUser.userSince,
        status: this.myUser.status,
        credentials: {
          token: null,
          expirationInDays: 0,
        },
      };
      if (this.image.length > 0) {
        const formData = new FormData();
        formData.append('image', this.image[0]);
        Axios.post('images', formData, {
          headers: this.$store.getters.getAuth,
        }).then((res) => {
          // eslint-disable-next-line prefer-destructuring
          UpdatedUserData.image = res.data.imgs[0];
          this.$store.dispatch('updateUser', UpdatedUserData).then((result) => {
            if (result) {
              this.$router.push('/inicio');
            }
          });
        });
      } else {
        this.$store.dispatch('updateUser', UpdatedUserData).then((res) => {
          if (res) {
            this.$router.push('/inicio');
          }
        });
      }
    },
  },
  watch: {
    myUser: {
      handler() {
        this.castUser();
      },
      deep: true,
    },
    image() {
      if (this.image.length <= 1) {
        try {
          const image = this.image[0];
          const lector = new FileReader();
          lector.readAsDataURL(image);
          lector.onload = (event) => {
            this.imagen = event.target.result;
          };
        } catch (e) {
          Error(e);
        }
      }
    },
  },
  mounted() {
    this.castUser();
  },
};
</script>

<style scoped></style>
