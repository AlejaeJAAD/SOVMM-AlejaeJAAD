<!-- @format -->

<template>
  <v-app class="header">
    <v-main style="z-index: 1">
      <v-container>
        <v-row justify="center">
          <v-col cols="12" style="padding: 9rem">
            <v-card class="center" width="340px" color="transparent">
              <v-card
                color="transparent"
                flat
                v-if="loading"
                style="
                  padding-top: 100px;
                  padding-bottom: 100px;
                  margin-top: -100px;
                "
              >
                <v-progress-circular :size="75" color="grey" indeterminate></v-progress-circular>
              </v-card>

              <v-card v-else elevation="10" color="transparent" style="margin-top: -200px">
                <v-alert v-model="alert" type="error" color="rgb(161, 210, 206)" outlined text transition="fade-in" class="text-center">
                  {{ errorMsg }}
                </v-alert>
                <v-card-title />
                <v-img max-height="110px" contain :src="img ? img : ''" />
                <v-form ref="form" v-model="validLogin" @submit.prevent="login" lazy-validation class="input-form mt-2">
                  <v-card-text>
                    <v-row>
                      <v-col cols="12">
                        <v-text-field placeholder="Correo Institucional" :rules="[rules.novacio, rules.formato]" v-model="email" required class="form-input" />
                      </v-col>
                      <v-col cols="12">
                        <v-text-field placeholder="Contraseña" :append-icon="mPW ? 'mdi-eye' : 'mdi-eye-off'" :rules="[rules.novacio]" :type="mPW ? 'text' : 'password'" v-model="password" @click:append="mPW = !mPW" required class="form-input" />
                      </v-col>
                    </v-row>
                  </v-card-text>
                  <v-divider></v-divider>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="transparent" type="submit" large>Iniciar Sesión </v-btn>
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-form>
              </v-card>
            </v-card>
          </v-col>
          <v-col cols="12" class="text-center" style="margin-top: -120px">
            <v-card flat outlined color="transparent" style="position: relative">
              <v-divider></v-divider>
              <v-card-subtitle class="white--text">
                Instituto Tecnológico de Culiacán <br />
                Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe. Culiacán, Sinaloa. C.P. 80220 <br />
                Teléfono: +52 (667) 713 -17-96, 713-38-04 <br />
                Tecnológico Nacional de México <br />
              </v-card-subtitle>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import LogoTec from "@/assets/LogoTec.png";
import MetalMecanica from "@/assets/MetalMecanica.jpg";

export default {
  name: "Login",
  data() {
    return {
      loading: false,
      img: LogoTec,
      MetalMecanica,
      email: "",
      password: "",
      validLogin: true,
      keepLogin: false,
      alert: false,
      alertTxt: "",
      rules: {
        formato: v => /.+@.+\..+/.test(v) || "El correo institucional debe ser formato valido.",
        novacio: v => !!v || "No se permiten campos vacios"
        // long: (v) =>
        //   (v || '').length < 27 ||
        //   'El correo institucional debe de ser de 26 caracteres maximo',
      },
      errorMsg: "",
      mPW: false
    };
  },
  methods: {
    login() {
      this.$refs.form.validate();
      if (this.validLogin) {
        this.loading = true;
        setTimeout(() => {
          const authModel = { email: this.email, password: this.password };
          this.$store
            .dispatch("logIn", authModel)
            .then(() => this.$router.replace("/inicio"))
            .catch(err => {
              if (err.data) {
                this.alertTxt = err;
                this.alert = true;
                setTimeout(() => {
                  this.alert = false;
                }, 10000);
                this.loading = false;
              } else {
                this.alert = true;
                this.errorMsg = "Ha ocurrido un problema";
                this.loading = false;
                setTimeout(() => {
                  this.alert = false;
                }, 10000);
              }
            });
        }, 3000);
      } else {
        this.$refs.form.reset();
      }
    }
  }
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
.header {
  position: relative;
  text-align: center;
  background: linear-gradient(60deg, rgba(84, 58, 183, 1) 0%, rgba(0, 172, 193, 1) 100%);
  color: white;
  margin-top: -3rem;
}
.row {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
.form-input >>> .v-input__slot::after {
  border-color: rgb(161, 210, 206) !important;
}

.form-input >>> .v-input__slot::before {
  border-color: rgb(161, 210, 206) !important;
}
.form-input >>> .error--text {
  color: rgb(161, 210, 206) !important;
}
.form-input >>> input {
  color: rgb(161, 210, 206) !important;
}
.form-input >>> .counter_slot::before {
  color: rgb(161, 210, 206) !important;
}
</style>
