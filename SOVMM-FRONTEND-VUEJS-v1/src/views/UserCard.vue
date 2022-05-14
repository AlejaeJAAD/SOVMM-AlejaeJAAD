<template>
  <v-container class="nomar">
    <v-row>
      <v-col
             cols="12" md="12" v-bind="(proyecto) in myAlumnos">
        <v-card height="100%"
                style="position: relative"
                class="d-flex justify-center align-center">
          <v-card-text class="text-center">
            <v-avatar size="100">
              <v-img :src="myAlumnos.image" class="justify-center align-center text-center"></v-img>
            </v-avatar>
            <h3 class="text-h5 mb-2">
              {{ myAlumnos.firstName}} {{ myAlumnos.lastName }}
            </h3>
            <div class="blue--text mb-2">
              {{ myAlumnos.email }}
            </div>
          </v-card-text>
          <v-divider></v-divider>
          <v-card-subtitle>
            <v-row tag="v-card-text">
              <v-col cols="12">
                <v-row>
                  <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                    Estado:
                  </v-col>
                  <v-col cols="6" class="text-right">{{ myAlumnos.state }}</v-col>

                  <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                    Ciudad:
                  </v-col>
                  <v-col cols="6" class="text-right">{{ myAlumnos.city }}</v-col>

                  <v-col class="text-left ml-1 mr-5 mb-1" tag="strong" cols="4">
                    Curp:
                  </v-col>
                  <v-col cols="6" class="text-right">{{ myAlumnos.curp }}</v-col>

                  <v-col class="text-left ml-1 mr-2 mb-1" tag="strong" cols="4">
                    Telefono:
                  </v-col>
                  <v-col cols="6" class="text-right">{{ myAlumnos.phone }}</v-col>
                </v-row>
              </v-col>
            </v-row>
          </v-card-subtitle>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>

export default {
  name: 'UserCard',
  components: {
  },
  props: {
    proyecto: Object,
    index: Number,
  },
  data() {
    return {
      proy: {},
      image: '',
      isActive: false,
      color: 'white',
      textColor: '',
      status: '',
      info: [],
    };
  },
  computed: {
    myAlumnos() {
      return this.$store.getters.getUsuario || [];
    },
  },
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch('fetchMyUsuarios');
    });
  },
};
</script>

<style scoped>
</style>
