<template>
  <v-stepper v-model="e1">
    <v-stepper-header>
      <v-stepper-step
        :complete="e1 > 1"
        step="1"
      >
        Datos.
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step
        :complete="e1 > 2"
        step="2"
      >
        Verificación.
      </v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step step="3">
        Finalizacion de Registro.
      </v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <v-card shaped :loading="f1load" style="margin-bottom: 10px" >
          <v-row style="padding: 10px">
            <v-col cols="6" sm="6">
              <v-text-field dense solo label="Nombre(s)" v-model="firstName"></v-text-field>
            </v-col>
            <v-col cols="6" sm="6">
              <v-text-field dense solo label="Apellido(s)" v-model="lastName"></v-text-field>
            </v-col>
            <v-col cols="6" sm="3" md="3">
              <v-text-field label="Ciudad" dense solo v-model="city"></v-text-field>
            </v-col>
            <v-col cols="6" sm="3" md="3">
              <v-text-field label="Estado" dense solo v-model="state"></v-text-field>
            </v-col>
            <v-col cols="6" sm="3" >
              <v-text-field label="Telefono"
                            prefix="+52"
                            class="num"
                            maxlength="10"
                            @keypress="isNumber"
                            dense solo v-model.number="phone"></v-text-field>
            </v-col>
            <v-col cols="6" sm="3" md="3">
              <v-menu
                ref="menu"
                v-model="menu"
                :close-on-content-click="false"
                :return-value.sync="fNacimiento"
                transition="scale-transition"
                offset-y
                min-width="290px"
                @click="telefono=123"
              >
                <template v-slot:activator="{ on }">
                  <v-text-field
                    v-model="fNacimiento"
                    label="Nacimiento"
                    solo
                    readonly
                    dense
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
                  >Ok</v-btn
                  >
                </v-date-picker>
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field label="Email" dense solo v-model="email"></v-text-field>
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field label="CURP" dense solo v-model="curp"></v-text-field>
            </v-col>
            <v-chip style="margin: 5px"> Su telefono y curp serán verificados.</v-chip>
          </v-row>
        </v-card>

        <v-btn
          color="primary"
          @click="checkCurp"
        >
          Continuar
        </v-btn>

        <v-btn text @click="$emit('cancelar')">
          Cancelar
        </v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <v-card
          class="mb-12"
          color="white darken-1"
          elevation="0"
        >
          <v-card-title>Se envió un codigo a tu telefono!</v-card-title>
          <v-card-subtitle>Introducelo a continuación: </v-card-subtitle>
          <v-card-subtitle v-if="testEnv">
            Pruebas, no se puede enviar codigo
            <br> inserte el codigo a continuación:
            <br> {{rCode}} </v-card-subtitle>
          <v-card-actions>
            <v-spacer></v-spacer>
            <div>
              <v-text-field
                autocomplete="off"
                ref="tf1"
                @keypress="isNumber"
                maxlength="1"
                @keyup="code[0] >= 0 ? $refs.tf2.focus() : '';"
                dense solo v-model.number="code[0]" class="tf"></v-text-field>
              <v-text-field
                autocomplete="off"
                ref="tf2"
                maxlength="1"
                @keypress="isNumber"
                @keyup="code[1] >= 0 ? $refs.tf3.focus() : ''"
                @keydown.delete="()=>{
                code=[null,null,null,null,null,null];
                $refs.tf1.focus();
              }"
                dense solo v-model.number="code[1]" class="tf"></v-text-field>
              <v-text-field
                autocomplete="off"
                ref="tf3"
                @keypress="isNumber"
                maxlength="1"
                @keyup="code[2] >= 0 ? $refs.tf4.focus() : ''"
                @keydown.delete="()=>{
                code=[null,null,null,null,null,null];
                $refs.tf1.focus();
              }"
                dense solo v-model.number="code[2]" class="tf"></v-text-field>
              <v-text-field
                autocomplete="off"
                ref="tf4"
                @keypress="isNumber"
                maxlength="1"
                @keyup="code[3] >= 0 ? $refs.tf5.focus() : ''"
                @keydown.delete="()=>{
                code=[null,null,null,null,null,null];
                $refs.tf1.focus();
              }"
                dense solo v-model.number="code[3]" class="tf"></v-text-field>
              <v-text-field
                autocomplete="off"
                ref="tf5"
                @keypress="isNumber"
                maxlength="1"
                @keyup="code[4] >= 0 ? $refs.tf6.focus() : ''"
                @keydown.delete="()=>{
                code=[null,null,null,null,null,null];
                $refs.tf1.focus();
              }"
                dense solo v-model.number="code[4]" class="tf"></v-text-field>
              <v-text-field
                autocomplete="off"
                ref="tf6"
                @keypress="isNumber"
                maxlength="1"
                @keydown.delete="()=>{
                code=[null,null,null,null,null,null];
                $refs.tf1.focus();
              }"
                @keyup="checkCode"
                dense solo v-model.number="code[5]" class="tf"></v-text-field>
            </div>
            <v-spacer></v-spacer>
          </v-card-actions>
          <v-alert
            dense
            text
            type="error"
            :value="cdWrong"
            transition="scale-transition"
          >
            Codigo incorrecto intente nuevamente!
          </v-alert>
          <v-alert
            dense
            text
            type="success"
            :value="cdRight"
            transition="scale-transition"
          >
            Codigo correcto!
          </v-alert>
        </v-card>
      </v-stepper-content>

      <v-stepper-content step="3">
        <v-card
          class="mb-12"
          color="grey lighten-1"
          height="200px"
        >
          <v-card-title>Ya casi.</v-card-title>
          <v-card-subtitle>Solo introduce tu contraseña:</v-card-subtitle>
          <v-text-field
            :append-icon="shPassword ? 'mdi-eye-open' : 'mdi-eye'"
            @click:append="shPassword=!shPassword"
            :type="shPassword ? 'text' : 'password'"
            solo dense v-model="password">
          </v-text-field>
          <v-text-field type="password" solo dense>
          </v-text-field>
        </v-card>

        <v-btn
          color="primary"
          @click="registrar"
        >
          Continuar
        </v-btn>

      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script>
import Axios from 'axios';
import { testEnv } from '@/main';

export default {
  name: 'RegisterCmp',
  data() {
    return {
      testEnv,
      e1: 1,
      phone: '',
      email: '',
      password: '',
      f1load: false,
      shPassword: false,
      code: [null, null, null, null, null, null],
      ronly: false,
      fNacimiento: '',
      firstName: '',
      lastName: '',
      city: '',
      state: '',
      curp: '',
      menu: false,
      cdWrong: false,
      cdRight: false,
      rCode: 928349,
      reqId: '',
    };
  },
  methods: {
    isNumber(evt) {
      const charCode = (evt.which) ? evt.which : evt.keyCode;
      if ((charCode > 31 && (charCode < 48 || charCode > 57))) {
        evt.preventDefault();
      } else {
        return true;
      }
      return true;
    },
    checkCode() {
      const currCode = this.code.join('');
      if (testEnv) {
        if (parseInt(currCode, 10) === this.rCode) {
          this.cdRight = true;
          setTimeout(() => {
            this.cdRight = false;
            this.e1 += 1;
          }, 1500);
        }
      } else {
        Axios.get(`https://api.nexmo.com/verify/check/json?&api_key=da68c4f1&api_secret=arfqeucehAI4gfJX&request_id=${this.reqId}&code=${currCode}`).then((res) => {
          if (res.data.status === '0') {
            this.cdRight = true;
            setTimeout(() => {
              this.cdRight = false;
              this.e1 += 1;
            }, 1500);
          } else {
            this.cdWrong = true;
            setTimeout(() => {
              this.cdWrong = false;
            }, 4000);
          }
        });
      }
    },
    registrar() {
      const newuser = {
        email: this.email,
        password: this.password,
        image: 'https://cdn0.iconfinder.com/data/icons/set-ui-app-android/32/8-512.png',
        firstName: this.firstName,
        lastName: this.lastName,
        city: this.city,
        state: this.state,
        curp: this.curp,
        phone: this.phone.toString(),
        accessLevel: 1,
        birthDate: new Date(this.fNacimiento).toISOString(),
        userSince: new Date().toISOString(),
        status: true,
      };
      Axios.post('/users', newuser).then(() => {
        this.$router.push('/login');
      });
    },
    checkCurp() {
      if (this.curp !== '' && this.curp.length === 18) {
        this.f1load = true;
        Axios.get(`https://us-central1-arsus-production.cloudfunctions.net/curp?curp=${this.curp}&apiKey=hxHekQa1MXS7kNBtBH9WABstlf33`)
          .then((response) => {
            const birthDate = new Date(response.data.birthday);
            if (birthDate.toISOString() === new Date(this.fNacimiento).toISOString()) {
              const number = parseInt(`52${this.phone}`, 10);
              Axios.get(`https://api.nexmo.com/verify/json?api_key=da68c4f1&api_secret=arfqeucehAI4gfJX&number=${number}&brand=Sinba&code_length=6`).then((res) => {
                this.reqId = res.data.request_id;
                this.f1load = false;
                this.e1 += 1;
              });
            } else {
              this.f1load = false;
            }
          }).catch((error) => Error(error));
      }
    },
  },
  watch: {
    curp() {
      this.curp = this.curp.toUpperCase();
    },
  },
};
</script>

<style scoped>
.tf{
  display: inline-block;
  font-size: xx-large;
  height: 60px !important;
  width: 40px !important;
  margin: 0 10px;
  text-align: center;
  background-color: rgba(0,0,0,0.06);

}
.text {
  padding-left: 15px;
  letter-spacing: 42px;
  border: 0;
  outline: none;
  background-image: linear-gradient(to left, black 70%, rgba(255, 255, 255, 0) 0%);
  background-position: bottom;
  background-size: 50px 1px;
  background-repeat: repeat-x;
  background-position-x: 35px;
  width: 300px;
}
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none !important;
  margin: 0 !important;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield !important;
}
</style>
