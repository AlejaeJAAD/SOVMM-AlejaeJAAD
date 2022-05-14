<template>
  <v-form v-model="valido"  @submit.prevent="guardar">
    <v-card elevation="3" style="padding: 3px">
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-alert :value="alerta2"
                 colored-border
                 border="top"
                 color="red"
                 transition="scale-transition">{{estatusMensaje}}
          <v-btn @click="alerta2=false"
                 icon
                 color="red">
            <v-icon>mdi-close-circle</v-icon>
          </v-btn>
          <v-btn style="margin-left: 15px"
                 icon
                 color="green">
            <v-icon>mdi-check-bold</v-icon>
          </v-btn>
        </v-alert>
        <v-spacer></v-spacer>

      </v-card-actions>
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field
            outlined
            :append-icon="mPW1 ? 'mdi-eye' : 'mdi-eye-off'"
            v-model="passwordAct"
            :type="mPW1 ? 'text' : 'password'"
            :rules="[rules.novacio, rules.longitudPW]"
            @click:append="mPW1 = !mPW1"
            label="Contraseña Actual:"
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" md="4">
          <v-text-field
            outlined
            :append-icon="mPW2 ? 'mdi-eye' : 'mdi-eye-off'"
            v-model="passwordNvo"
            :type="mPW2 ? 'text' : 'password'"
            :rules="[rules.novacio, rules.longitudPW]"
            @click:append="mPW2 = !mPW2"
            label="Nueva Contraseña:"
          ></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field
            outlined
            v-model="passwordConf"
            type="password"
            :rules="[rules.novacio, rules.longitudPW, rules.match]"
            label="Confirmar Contraseña:"
          ></v-text-field>
        </v-col>
      </v-row>
      <v-alert :value="alerta"
               :type="alertType"
               transition="scale-transition"
               :color="msgColor">{{mensaje}}</v-alert>
      <v-divider></v-divider>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="red" class="white--text">Cancelar</v-btn>
        <v-btn color="green" class="white--text"
               :disabled="!valido"
               type="submit"
        >Actualizar</v-btn>
      </v-card-actions>
    </v-card>
    <v-snackbar v-model="snackbar"
                timeout="3000"
                top="top"
                centered
                right="right"
                vertical
                multi-line

    ><span
      style="font-size: large; "
    >{{snackbarMsg}}</span></v-snackbar>
  </v-form>
</template>

<script>
export default {
  props: ['estatus'],
  name: 'Seguridad',
  data() {
    return {
      valido: false,
      mPW1: false,
      passwordAct: '',
      mPW2: false,
      passwordNvo: '',
      passwordConf: '',
      rules: {
        novacio: (v) => !!v || 'No se permiten campos vacios',
        longitudPW: (v) => v.length >= 8 || 'Minimo 8 caracteres',
        match: (v) => v === this.passwordNvo || 'Contraseñas no son iguales',
      },
      alerta: false,
      msgColor: 'blue',
      mensaje: '',
      alertType: 'info',
      estatusMensaje: '',
      alerta2: false,
      snackbar: false,
      snackbarMsg: '',
    };
  },
  methods: {
    guardar() {
      const data = {
        currPassword: this.passwordAct,
        newPassword: this.passwordNvo,
      };
      this.$store.dispatch('updatePassword', data).then((res) => {
        if (!res.data) {
          this.mensaje = 'Algo pasó, intenta nuevamente';
          this.msgColor = 'red';
          this.alerta = true;
          this.alertType = 'error';
          this.passwordAct = '';
          this.passwordNvo = '';
          this.passwordConf = '';
          setTimeout(() => {
            this.alerta = false;
          }, 3000);
        } else {
          this.mensaje = 'Se cambió la contraseña, deberá iniciar sesion nuevamente.';
          this.msgColor = 'green';
          this.alertType = 'success';
          this.alerta = true;
          setTimeout(() => {
            this.$store.dispatch('logOut');
            this.$router.replace('/login');
          }, 5000);
        }
      }).catch((err) => Error(err));
    },
  },
};
</script>

<style scoped></style>
