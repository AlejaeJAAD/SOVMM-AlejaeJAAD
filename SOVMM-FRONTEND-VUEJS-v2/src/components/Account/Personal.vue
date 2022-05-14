<template>
  <v-form>
    <v-card style="padding: 10px" elevation="3">
      <v-row class="bgImg">
        <v-col cols="6">
          <v-img class="mx-auto" :src="imagen" height="300" width="55%" style="border-radius: 15px;"></v-img>
        </v-col>
        <v-col cols="8">
          <image-handler single :disabled="!editable" v-model="image"></image-handler>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-row style="margin-top: 5px">
        <v-col cols="12"><h3>Datos personales</h3></v-col>
        <v-col cols="12" md="6">
          <v-text-field label="Nombre(s)" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="firstName" append-icon="mdi-rename-box"></v-text-field>
        </v-col>
        <v-col cols="12" md="6">
          <v-text-field label="Apellido(s)" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="lastName" append-icon="mdi-rename-box"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Correo Institucional" solo readonly :disabled="myUser.accessLevel === 3" type="email" v-model="email" append-icon="mdi-email"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Correo Personal" solo :readonly="!editable" v-model="personalEmail" append-icon="mdi-email"> </v-text-field>
        </v-col>
        <v-col cols="12" md="2" offset-md="2">
          <v-text-field label="Telefono" solo type="number" :readonly="!editable" v-model.number="phone" append-icon="mdi-cellphone"></v-text-field>
        </v-col>
        <v-col cols="12" md="5">
          <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :return-value.sync="fNacimiento" transition="scale-transition" offset-y disabled min-width="290px">
            <template v-slot:activator="{ on }">
              <v-text-field v-model="fNacimiento" label="Fecha De Nacimiento" readonly solo-inverted v-on="on"> </v-text-field>
            </template>
            <v-date-picker v-model="fNacimiento" no-title scrollable locale="es" append-icon="mdi-calendar">
              <v-spacer></v-spacer>
              <v-btn text color="red" @click="menu = false">Cancelar</v-btn>
              <v-btn text color="green" @click="$refs.menu.save(fNacimiento)">Ok </v-btn>
            </v-date-picker>
          </v-menu>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="CURP" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="curp" append-icon="mdi-account"> </v-text-field>
        </v-col>
        <v-col cols="12" md="2">
          <v-select label="Genero" v-model="gender" :readonly="!editable" solo :items="['Masculino', 'Femenino', 'Otro']"></v-select>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-row style="margin-top: 5px">
        <v-col cols="12">
          <h3>Datos domiciliarios</h3>
        </v-col>
        <v-col cols="12" md="3" offset="9">
          <v-text-field @click:append="verificarCP" type="number" solo :readonly="!editable" label="Codigo Postal" :append-icon="icono" v-model.number="cp" hint="Podras editar tu domicilio al verficiar el codigo postal!" persistent-hint :color="color"></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Estado" solo :readonly="sinCP" v-model="state" append-icon="mdi-sign-real-estate"> </v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-text-field label="Ciudad" solo :readonly="sinCP" v-model="city" append-icon="mdi-city"> </v-text-field>
        </v-col>

        <v-col cols="12" md="4">
          <v-select solo :readonly="sinCP" :items="suburbs" :value="suburb" label="Suburb" v-model="suburb" append-icon="mdi-home-group"></v-select>
        </v-col>
        <v-col cols="12" md="12">
          <v-text-field label="Direccion" solo :readonly="sinCP" v-model="dir" append-icon="mdi-map-marker"> </v-text-field>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-row style="margin-top: 5px">
        <v-col cols="12">
          <h3>Datos institucionales</h3>
        </v-col>
        <v-col cols="5" md="5">
          <v-text-field label="Carrera" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="career"> </v-text-field>
        </v-col>
        <v-col cols="7" md="7">
          <v-text-field label="Departamento" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="department"> </v-text-field>
        </v-col>
        <v-col cols="3" md="3">
          <v-text-field label="Numero de control" solo :readonly="!editable" :disabled="myUser.accessLevel === 3" v-model="enrollment"> </v-text-field>
        </v-col>
      </v-row>
      <v-divider></v-divider>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="orange" v-if="!editable" class="white--text" @click="editable = !editable">Editar </v-btn>
        <v-btn color="red" class="white--text" v-if="editable" @click="cancelar">Cancelar </v-btn>
        <v-btn color="green" class="white--text" v-if="editable" @click="actualizar">Actualizar </v-btn>
      </v-card-actions>
      <v-dialog v-model="dialog" max-width="290">
        <v-card>
          <v-card-title class="text-h5">
            <v-icon>mdi-alert-circle</v-icon>
          </v-card-title>
          <v-card-text>
            La informacion del usuario ha sido actualizada.
          </v-card-text>
        </v-card>
      </v-dialog>
    </v-card>
  </v-form>
</template>

<script>
import Axios from "axios";
import ImageHandler from "@/components/Global/ImageHandler";

export default {
  components: { ImageHandler },
  props: ["myUser"],
  name: "Personal",
  data() {
    return {
      prevUser: "",
      editable: false,
      imagen: "",
      image: [],
      fNacimiento: "",
      firstName: "",
      department: "",
      lastName: "",
      phone: "",
      email: "",
      personalEmail: "",
      curp: "",
      state: "",
      city: "",
      suburb: "",
      career: "",
      enrollment: "",
      gender: "",
      dir: "",
      menu: false,
      dialog: false,
      suburbs: [],
      cp: "",
      color: "primmary",
      icono: "mdi-check",
      sinCP: true
    };
  },
  methods: {
    castUser() {
      if (this.myUser.image != null) {
        this.imagen = this.myUser.image;
      } else {
        this.imagen = "";
        this.image = [];
      }
      this.firstName = this.myUser.firstName;
      this.lastName = this.myUser.lastName;
      if (this.myUser.birthDate) {
        this.fNacimiento = new Date(this.myUser.birthDate).toISOString().substring(0, 10);
      }
      this.phone = this.myUser.phone;
      this.email = this.myUser.email;
      this.personalEmail = this.myUser.personalEmail;
      this.curp = this.myUser.curp;
      this.state = this.myUser.state;
      this.city = this.myUser.city;
      this.suburb = this.myUser.suburb;
      this.career = this.myUser.career;
      this.department = this.myUser.department;
      this.enrollment = this.myUser.enrollment;
      this.gender = this.myUser.gender;
      this.dir = this.myUser.address;
      console.log("Hola", this.myUser);
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
        personalEmail: this.personalEmail,
        image: this.myUser.image,
        firstName: this.firstName,
        lastName: this.lastName,
        city: this.city,
        suburb: this.suburb,
        state: this.state,
        curp: this.myUser.curp,
        phone: this.phone.toString(),
        career: this.career,
        department: this.department,
        enrollment: this.enrollment,
        gender: this.gender,
        address: this.dir,
        password: "nopassword",
        accessLevel: this.myUser.accessLevel,
        birthDate: this.myUser.birthDate,
        userSince: this.myUser.userSince,
        status: this.myUser.status,
        credentials: {
          token: null,
          expirationInDays: 0
        }
      };
      if (this.image.length > 0) {
        const formData = new FormData();
        formData.append("image", this.image[0]);
        Axios.post("images", formData, {
          headers: this.$store.getters.getAuth
        }).then(res => {
          UpdatedUserData.image = res.data.imgs[0];
          this.$store.dispatch("updateUser", UpdatedUserData).then(result => {
            if (result) {
              this.$router.push("/inicio");
            }
          });
        });
      } else {
        this.$store.dispatch("updateUser", UpdatedUserData).then(res => {
          if (res) {
            this.$router.push("/inicio");
          }
        });
      }
    },
    verificarCP() {
      console.log("Hola");
      return Axios.post("https://api.copomex.com/query/info_cp/" + this.cp + "?token=47b8b142-c0dc-4767-b207-662d6e6064fa").then(res => {
        console.log(res.data);
        this.suburbs = [];
        for (let i = 0; i < res.data.length; i++) {
          const info = res.data[i].response;
          this.city = info.ciudad;
          this.state = info.estado;
          this.suburb = res.data[0].response.asentamiento;
          this.suburbs.push(info.asentamiento);
        }
        this.sinCP = false;
        this.suburb = this.myUser.suburb;
      });
    }
  },
  watch: {
    myUser: {
      handler() {
        this.castUser();
      },
      deep: true
    },
    image() {
      if (this.image.length <= 1) {
        console.log(this.image);
        try {
          const image = this.image[0];
          const lector = new FileReader();
          lector.readAsDataURL(image);
          lector.onload = event => {
            this.imagen = event.target.result;
          };
        } catch (e) {
          Error(e);
        }
      }
    }
  },
  mounted() {
    this.castUser();
  }
};
</script>

<style scoped>
.bgImg {
  justify-content: space-around;
}
</style>
