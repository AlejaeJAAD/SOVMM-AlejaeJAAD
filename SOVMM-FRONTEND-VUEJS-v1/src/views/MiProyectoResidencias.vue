<template>
  <v-container class="nomar">
    <v-row>
      <v-col cols="12">
        <v-btn fixed color="white" elevation="5" fab @click="nr=true"
               large style="margin-left: -15px">
          <v-icon>mdi-text-box-plus</v-icon>
        </v-btn>
        <v-dialog persistent :width="width" v-model="nr">
          <NuevoPresidencias v-if="nr" @onClose="nr=false" @createdP="createdP"/>
        </v-dialog>
      </v-col>
      <v-col cols="11" md="11" v-for="(proyecto, i) in myPresidencias"
             :key="proyecto.id+proyecto.liked_by">
        <ListPRCard :proyecto="proyecto" :index="i" mios/>
      </v-col>
    </v-row>
    <v-card shaped elevation="3" class="colores" style="position: absolute;">
      <div class="elementos filter">
        Rechazado: <v-avatar size="25" color="red darken-2"></v-avatar>
        <br>
        <br>
        En Proceso: <v-avatar size="25" color="orange darken-2"></v-avatar>
        <br>
        <br>
        Aceptado: <v-avatar size="25" color="light-green darken-2"></v-avatar>
        <br>
        <br>
        Sin estatus: <v-avatar size="25" color="grey lighten-5"></v-avatar>
      </div>
    </v-card>
  </v-container>
</template>

<script>
import ListPRCard from '@/views/ListPRCard';
import NuevoPresidencias from '@/components/NuevoPresidencias';

export default {
  name: 'ProyectosResidencias',
  components: {
    NuevoPresidencias,
    ListPRCard,
  },
  data() {
    return {
      nr: false,
    };
  },
  mounted() {
    this.$nextTick(() => {
      this.$store.dispatch('fetchMyPresidencias');
      this.$store.dispatch('fetchPresidencias');
      this.$store.dispatch('fetchProyectos');
      this.$store.dispatch('fetchMyUsuarios');
      this.$store.dispatch('fetchUsuarios');
    });
  },
  computed: {
    // eslint-disable-next-line consistent-return,vue/return-in-computed-property
    width() {
      // eslint-disable-next-line default-case
      switch (this.$vuetify.breakpoint.name) {
        case 'xs':
          return '100%';
        case 'sm':
          return '90%';
        case 'md':
          return '85%';
        case 'lg':
          return '80%';
        case 'xl':
          return '80%';
      }
    },
    myPresidencias() {
      return this.$store.getters.getMyPresidencias || [];
    },
  },
  methods: {
    createdP() {
      this.$store.dispatch('fetchPresidencias');
      this.$store.dispatch('fetchMyPresidencias');
      this.nr = false;
    },
  },
};
</script>

<style scoped>
.colores{
  position: fixed;
  top: 10%;
  right: 1%;
  padding: 20px;
}
.elementos{
  position: relative;
  text-align: right;
}
.nomar {
  margin-top: -0.5rem;
  padding-top: 2.5rem;
}
</style>
