<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-card height="60vh"
                class="align-content-center hero">
        </v-card>
        <v-card>
          <v-card-title>
            Residencias profesionales
          </v-card-title>
          <v-card-subtitle>
            Se concibe la residencia profesional como una estrategia educativa,
            con carácter curricular, que permite al estudiante, aun estando en proceso de formación,
            incorporarse profesionalmente a los sectores productivos de bienes y servicios,
            a través del desarrollo de un proyecto, asesorado por instancias
            académicas e instancias externas. <br>
            El desarrollo de la residencia profesional puede representar una forma de
            transitar entre la teoría y la práctica.
          </v-card-subtitle>
        </v-card>
      </v-col>
      <v-col cols="12">
        <v-row>
          <v-col cols="12">
            <v-card height="auto"
                    class="align-content-center hero1">
              <v-app-bar
                dense
                flat
              >Requisitos para Residencias Profesionales</v-app-bar>
              <v-card-subtitle>
                El alumno que ha cubierto el 75% del total de sus créditos puede solicitar
                la realización de susResidencias Profesionales mediante los siguientes mecanismos:
              </v-card-subtitle>
              <v-card-text>
                A través de su selección en el banco de proyectos de la coordinación respectiva.
                <br>
                Proponiendo su propio tema directamente a la División de Estudios Profesionales,
                la que turnara al Departamento Académico para su análisis,
                Presentando a la División de Estudios Profesionales su situación
                como trabajador de alguna empresa,
                para que se dictamine la correspondencia entre las actividades que
                realiza y las de un proyecto de Residencias Profesionales.
                En los casos en que el alumno propone su propio proyecto o somete a consideración
                su situación como trabajador es conveniente que su propuesta de
                proyecto de Residencias Profesionales
                con tenga la siguiente información: <br> <br>

                Nombre y objetivo del proyecto. <br>
                Cronograma preliminar de actividades. <br>
                Descripción detallada de las actividades. <br>
                Lugar donde se realizará el proyecto. <br>
                Información de la empresa o institución donde se desarrollara el trabajo. <br>
              </v-card-text>
              <v-row>
                <v-col cols="6">
                  <iframe :src="`
                  https://docs.google.com/viewer?url=https://sovmm-01.s3.us-east-2.amazonaws.com/FORMATO-CARTA+DE+PRESENTACIÓN.pdf&embedded=true`"
                          style="position:relative; top:0; left:0; bottom:0; right:0; width:100%;
                  height:112vh; border:none; margin:0; padding:20px;"
                          scrolling="no"
                          frameborder="1" marginheight="0px" marginwidth="0px"></iframe>
                </v-col>
                <v-col cols="6">
                  <v-card-title>
                    Carta Presentacion
                  </v-card-title>
                </v-col>
              </v-row>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import axios from 'axios';
import Fondo from '@/assets/1200px-Tecnologico_Nacional_de_Mexico.svg.png';

export default {
  name: 'Inicio',
  components: { },
  data() {
    return {
      img: Fondo,
      info: [],
      person: [],
    };
  },
  watch: {
    $route(to) {
      this.filter(to.query.s);
      this.$router.go();
    },
  },
  mounted() {
    axios.get('users')
      .then((response) => {
        this.info = response.data;
        this.person = this.info.filter((person) => (
          person.accessLevel === 3
        ));
        console.log(this.person, '49494');
      });
  },
};
</script>

<style scoped>
.hero {
  background: url('../assets/1200px-Tecnologico_Nacional_de_Mexico.svg.png');
  background-size: cover;
  width: 100%;
  max-width: 100%;
  height: auto;
  margin-top: 25px;
}
.hero1 {
  width: 100%;
  max-width: 100%;
  height: auto;
  margin-bottom: 5px;
}
</style>
