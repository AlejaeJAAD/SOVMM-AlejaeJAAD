<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <!-- <v-card hover @click="getUserInfo(presidencia.id)" v-model="presidencia.id" :color="color" class="borde-carta">
          <v-row>
            <v-col>
              <v-card class="borde-carta2">
                <h3>{{ presidencia.id }}</h3>
                <br />
                <hr />
                <h3>{{ presidencia.createdBy }}</h3>
              </v-card>
            </v-col>
          </v-row>
        </v-card> -->
        <v-card class="card" hover @click="getUserInfo(presidencia.id)" v-model="presidencia.id" :color="color">
          <v-menu v-model="menu" :close-on-content-click="false" open-on-hover transition="scroll-x-reverse-transition" min-width="auto"
            ><template v-slot:activator="{ on, attrs }">
              <v-card class="cardAC" v-bind="attrs" v-on="on">
                <div class="card-inner">
                  <h5 class="card-title">
                    {{ presidencia.id }}<br /><br />
                    Categoria: <span style="opacity: 0.8">{{ presidencia.categoria }}</span>

                    <v-divider></v-divider>
                  </h5>
                  <br />
                  <h5>
                    Nombre de proyecto: <br /><span style="opacity: 0.8">{{ presidencia.nProyecto }}</span>
                  </h5>
                  <h5>
                    Creador por: <br /><span style="opacity: 0.8">{{ getUserInfoC.firstName }} {{ getUserInfoC.lastName }}</span>
                  </h5>
                  <h5>
                    Correo institucional: <br /><span style="opacity: 0.8">{{ getUserInfoC.email }}</span>
                  </h5>
                </div>
              </v-card>
            </template>
            <v-card>
              <v-list>
                <v-list-item>
                  <v-list-item-avatar>
                    <img :src="getUserInfoC.image" alt="image" />
                  </v-list-item-avatar>

                  <v-list-item-content>
                    <v-list-item-title>{{ getUserInfoC.firstName }} {{ getUserInfoC.lastName }}</v-list-item-title>
                    <v-list-item-subtitle>Founder of Vuetify</v-list-item-subtitle>
                  </v-list-item-content>

                  <v-list-item-action>
                    <v-btn :class="fav ? 'red--text' : ''" icon @click="fav = !fav">
                      <v-icon>mdi-heart</v-icon>
                    </v-btn>
                  </v-list-item-action>
                </v-list-item>
              </v-list>

              <v-divider></v-divider>
              <v-card-actions>
                <v-spacer></v-spacer>

                <v-btn text @click="menu = false">
                  Cerrar
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-menu>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  props: ["presidencia"],
  data() {
    return {
      userId: "",
      color: "white",
      proyecto: "",
      menu: false,
      fav: true
    };
  },
  mounted() {
    setTimeout(() => {
      this.proyecto = this.presidencia;
      if (this.proyecto.status === 0) {
        this.color = "grey lighten-5";
      }
      if (this.proyecto.status === 1) {
        this.color = "light-green darken-2";
      }
      if (this.proyecto.status === 2) {
        this.color = "orange darken-2";
      }
      if (this.proyecto.status === 3) {
        this.color = "red darken-3";
      }
    }, 1000);
    document.body.style.background = "#ccc";
  },
  methods: {
    getUserInfo(id) {
      console.log(id);
      this.$router.push(`/proyectos-alumnos/${id}`);
    }
  },
  computed: {
    getUserInfoC() {
      return this.$store.getters.getUserInfo || [];
    }
  }
};
</script>

<style lang="scss" scoped>
/* .borde-carta {
  padding: 6px 0 1px 6px;
}
.borde-carta2 {
  padding: 1rem;
} */

.card {
  color: white;
  font-size: 16px;
  width: 400px;
  margin: auto;
  font-family: Arial;
  padding: 1px 0 0 0;
}
.cardAC {
  margin: 5px 0 0 5px;
}
.card-inner {
  padding: 2rem;
  border-radius: 4px;
  box-shadow: 0 4px 8px 0 rgb(0 0 0 / 20%);
}
</style>
