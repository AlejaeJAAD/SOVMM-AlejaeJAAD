<template>
  <div class="nomar">
    <div class="header" style="height: 130vh; z-index: 1">
      <v-container>
        <v-row>
          <v-col cols="10" offset="1" lg="4" offset-lg="4" style="margin-top: 30px">
            <v-card elevation="5" class="grey lighten-4 center ma-15"
            outlined>
              <v-progress-circular
                v-if="loading"
                :size="75"
                color="grey"
                indeterminate
                style="margin-top: 40%; margin-bottom: 40%"
              >
              </v-progress-circular>
              <v-card v-else style="margin-top: -80px">
                <v-img height="100%" contain :src="img ? img : ''" />
                <v-alert v-model="alert" type="error" color="red" outlined text
                         transition="fade-in"
                         class="text-center">
                  {{errorMsg}}
                </v-alert>
                <v-card-title />
                <v-divider></v-divider>
                <v-form
                  ref="form"
                  v-model="validLogin"
                  @submit.prevent="login"
                  lazy-validation
                  class="input-form mt-2">
                  <v-text-field
                    solo placeholder="Correo Institucional"
                    :rules="[rules.novacio, rules.formato]"
                    v-model="email" />
                  <v-text-field
                    solo placeholder="Contraseña"
                    :append-icon="mPW ? 'mdi-eye' : 'mdi-eye-off'"
                    :rules="[rules.novacio]"
                    :type="mPW ? 'text' : 'password'"
                    v-model="password"
                    @click:append="mPW = !mPW"/>
                  <v-checkbox
                    class="align-end"
                    label="Mantener sesión iniciada." />
                  <v-divider></v-divider>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                      color="grey lighten-3"
                      type="submit"
                      x-large
                      style="margin-bottom: 20px; margin-top: 15px"
                    >Iniciar Sesión
                    </v-btn>
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-form>
              </v-card>
            </v-card>
          </v-col>
          <v-col cols="12" class="text-center" style="margin-top: 60px">
            <v-card flat outlined elevation="10" color=indigo
            style="position: relative">
              <v-divider></v-divider>
              <v-card-subtitle class="white--text">
                Instituto Tecnológico de Culiacán <br>
                Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe. Culiacán, Sinaloa. C.P. 80220 <br>
                Teléfono: +52 (667) 713 -17-96, 713-38-04 <br>
                Tecnológico Nacional de México <br>
              </v-card-subtitle>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </div>
  </div>
</template>

<script>
import LogoTec from '@/assets/LogoTec.png';
import MetalMecanica from '@/assets/MetalMecanica.jpg';

export default {
  name: 'Login',
  data() {
    return {
      loading: false,
      img: LogoTec,
      MetalMecanica,
      email: '',
      password: '',
      validLogin: true,
      keepLogin: false,
      alert: false,
      alertTxt: '',
      rules: {
        formato: (v) => /.+@.+\..+/.test(v) || 'E-mail debe ser formato valido.',
        novacio: (v) => !!v || 'No se permiten campos vacios',
      },
      errorMsg: '',
      mPW: false,
    };
  },
  methods: {
    login() {
      this.$refs.form.validate();
      if (this.validLogin) {
        this.loading = true;
        const authModel = { email: this.email, password: this.password };
        console.log(authModel, 'AUTH');
        this.$store.dispatch('logIn', authModel)
          .then(() => this.$router.replace('/inicio'))
          .catch((err) => {
            if (err.data) {
              console.log('login catch');
              console.log(err);
              this.alertTxt = err;
              this.alert = true;
              setTimeout(() => {
                this.alert = false;
              }, 10000);
              this.loading = false;
            } else {
              this.alert = true;
              this.errorMsg = 'Ha ocurrido un problema';
              this.loading = false;
              setTimeout(() => {
                this.alert = false;
              }, 10000);
            }
          });
        console.log(authModel);
      } else {
        this.$refs.form.reset();
      }
    },
  },
};
</script>

<style scoped>
.input-form {
  width: 80%;
  margin: 0 auto;
}
.center {
  margin: 15vh auto 0 auto !important;
}
.nomar {
  margin-top: -3rem;
  margin-bottom: -1rem;
  position: relative;
}
.nomar2 {
  margin-top: -16.3rem;
}
template {
  overflow: hidden;
}
.header {
  position:relative;
  text-align:center;
  background: linear-gradient(60deg, rgba(84,58,183,1) 0%, rgba(0,172,193,1) 100%);
  color:white;
  margin-top: -3rem;
}
</style>
