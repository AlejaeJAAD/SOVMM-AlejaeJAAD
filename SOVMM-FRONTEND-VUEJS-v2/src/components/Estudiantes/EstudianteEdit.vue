<template>
  <v-container>
    <v-card flat>
      <v-card style="padding: 20px">
        <v-row class="marginsin">
          <v-col sm="4" md="4" lg="4">
            <v-card color="grey lighten-3" size="300">
              <v-img :src="currentStudent.image"></v-img>
            </v-card>
          </v-col>
          <v-col sm="8" md="8" lg="8">
            <v-row>
              <v-col cols="12">
                <p class="fuente" align="center">INFORMACION PERSONAL</p>
              </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-row>
              <v-col class="mt-5; negrita">
                <v-icon>mdi-rename-box</v-icon> Nombre(s):
                <v-text-field :readonly="!editable" v-model="currentStudent.firstName"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col class="mt-5; negrita">
                <v-icon>mdi-rename-box</v-icon> Apellido(s):
                <v-text-field :readonly="!editable" v-model="currentStudent.lastName"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="4" class="mt-5; negrita"> <v-icon>mdi-city</v-icon> Ciudad, Estado </v-col>
              <v-col cols="8">
                <v-row class="marginsino">
                  <v-col cols="6">
                    <v-text-field :readonly="!editable" v-model="currentStudent.city"></v-text-field>
                  </v-col>
                  <v-col cols="6">
                    <v-text-field :readonly="!editable" v-model="currentStudent.state"></v-text-field>
                  </v-col>
                </v-row>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="3" class="mt-5; negrita"> <v-icon>mdi-cellphone</v-icon> Telefono: </v-col>
              <v-col cols="3" class="marginsin">
                <v-text-field v-model="currentStudent.phone" :readonly="!editable"></v-text-field>
              </v-col>
              <v-col cols="2" class="mt-5; negrita"> <v-icon>mdi-curp</v-icon> Curp: </v-col>
              <v-col cols="4" class="marginsin">
                <v-text-field v-model="currentStudent.curp" :readonly="!editable"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsine">
              <v-col cols="5" class="mt-5; negrita"> <v-icon>mdi-calendar-range</v-icon> Fecha de nacimiento: </v-col>
              <v-col cols="7" class="marginsin">
                <v-menu ref="menu" v-model="menu" :close-on-content-click="false" :return-value.sync="currentStudent.birthdate" transition="scale-transition" offset-y disabled min-width="290px">
                  <template v-slot:activator="{ on }">
                    <v-text-field v-model="currentStudent.birthdate" :readonly="!editable" label="Fecha De Nacimiento" readonly solo-inverted v-on="on"> </v-text-field>
                  </template>
                  <v-date-picker v-model="currentStudent.birthdate" no-title scrollable locale="es">
                    <v-spacer></v-spacer>
                    <v-btn text color="red" @click="menu = false">Cancelar</v-btn>
                    <v-btn text color="green" @click="$refs.menu.save(currentStudent.birthdate)">Ok </v-btn>
                  </v-date-picker>
                </v-menu>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="3" class="mt-5; negrita"> <v-icon>mdi-map-marker</v-icon> Direccion: </v-col>
              <v-col cols="9" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.address"></v-text-field>
              </v-col>
            </v-row>
            <v-spacer></v-spacer>
            <v-spacer></v-spacer>
            <v-row>
              <v-col cols="12">
                <p class="fuente" align="center">INFORMACION ESCOLAR</p>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="6" class="mt-5; negrita"> <v-icon>mdi-school</v-icon> Carrera: </v-col>
              <v-col cols="6" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.career"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="6" class="mt-5; negrita"> <v-icon>mdi-school</v-icon> Departamento: </v-col>
              <v-col cols="6" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.department"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="4" class="mt-5; negrita"> <v-icon>mdi-card-account-details</v-icon> Numero de control: </v-col>
              <v-col cols="8" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.enrollment"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="5" class="mt-5; negrita"> <v-icon>mdi-email</v-icon> Correo institucional: </v-col>
              <v-col cols="7" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.email"></v-text-field>
              </v-col>
            </v-row>
            <v-row class="marginsin">
              <v-col cols="6" class="mt-5; negrita"> <v-icon>mdi-email</v-icon> Correo electronico personal: </v-col>
              <v-col cols="6" class="marginsin">
                <v-text-field :readonly="!editable" v-model="currentStudent.personalEmail"></v-text-field>
              </v-col>
            </v-row>
          </v-col>
        </v-row>
      </v-card>
    </v-card>
  </v-container>
</template>

<script>
import ImageHandler from "@/components/Global/ImageHandler";

export default {
  components: { ImageHandler },
  props: ["currentStudent"],
  name: "EstudianteEdit",
  data() {
    return {
      image: [],
      menu: false,
      editable: false
    };
  },
  watch: {
    image() {
      if (this.image.length <= 1) {
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
  methods: {
    close() {
      console.log("hOLA");
    }
  }
};
</script>

<style scoped>
.marginsin {
  margin-top: -20px;
}
.marginsine {
  margin-top: -5px;
  margin-bottom: -20px;
}
.marginsino {
  margin-top: -30px;
}
/* Hide scrollbar for Chrome, Safari and Opera */
template::-webkit-scrollbar {
  display: none;
}

/* Hide scrollbar for IE, Edge and Firefox */
template {
  -ms-overflow-style: none; /* IE and Edge */
  scrollbar-width: none; /* Firefox */
}
.fuente {
  font-size: 1.5rem;
  font-weight: bolder;
}
.image-handler {
  margin-top: -60px;
}
</style>
