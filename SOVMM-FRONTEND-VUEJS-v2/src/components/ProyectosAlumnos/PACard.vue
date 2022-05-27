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
          <v-card class="cardAC">
            <div class="card-inner">
              <h3 class="card-title">
                {{ presidencia.id }}
                <v-card>
                  <v-img :src="getUserInfoC.image"></v-img>
                </v-card>
              </h3>
            </div>
          </v-card>
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
      proyecto: ""
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
  position: relative;
  width: 400px;
  margin: auto;
  font-family: Arial;
  padding: 1px 0 0 0;
}

.card-inner {
  background: linear-gradient(45deg, #ffffff4b, #00000000);
  position: relative;
  padding: 2rem;
  border-radius: 4px;
  box-shadow: 0 4px 8px 0 rgb(0 0 0 / 20%);
}
.cardAC {
  margin: 5px 0 0 5px;
}
</style>
