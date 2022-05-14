<template>
    <v-card>
    <v-card-title class="text-h5 justify-center">
        <v-avatar>
          <v-img>
            {{ currentStudent.image }}
          </v-img>
        </v-avatar>
        Desea eliminar a {{ currentStudent.firstName }} {{ currentStudent.lastName }}
        de sus alumnosss?
    </v-card-title>
        <v-divider></v-divider>
        <v-card-actions>
            <v-spacer></v-spacer>
                <v-btn color="red" outlined @click="cancelar">
                    Cancelar
                </v-btn>
            <v-spacer></v-spacer>
                <v-btn color="green darken-1" outlined
                @click="eliminarEstudiante(currentStudent.id)">
                    Aceptar
                </v-btn>
            <v-spacer></v-spacer>
        </v-card-actions>
    </v-card>
</template>
<script>

export default {
  props: ['currentStudent'],
  name: 'EstudianteDelete',
  data() {
    return {
    };
  },
  methods: {
    cancelar() {
      // this.eliminar = false;
      this.$emit('update:eliminar');
    },
    eliminarEstudiante(id) {
      console.log(this.eliminar, 'EL');
      console.log(id, 'ID DEL');
      this.$store.dispatch('deleteStudent', id).then((res) => {
        this.eliminado = res;
        setTimeout(() => {
          this.eliminado = true;
        }, 5000);
        if (res) {
          this.$router.go();
        }
      });
    },
  },
};
</script>

<style scoped>
.centered {
    text-align: center
}
</style>
