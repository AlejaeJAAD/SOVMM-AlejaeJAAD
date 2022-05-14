<!-- @format -->

<template>
  <v-app>
    <v-main style="background-color: #f7f7f7">
      <v-container>
        <IPortada />
        <v-row justify="center">
          <v-col cols="12">
            <v-expansion-panels inset>
              <v-expansion-panel style="background-color: #50858b">
                <v-expansion-panel-header>
                  Anteproyecto
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-1-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <IAnteProyecto />
                </v-expansion-panel-content>
              </v-expansion-panel>
              <v-expansion-panel style="background-color: #5497a2">
                <v-expansion-panel-header>
                  Carta de presentacion
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-2-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <ICartaPresentacion />
                </v-expansion-panel-content>
              </v-expansion-panel>
              <v-expansion-panel style="background-color: #62a8ac">
                <v-expansion-panel-header>
                  Carta de aceptacion
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-3-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <ICartaAceptacion />
                </v-expansion-panel-content>
              </v-expansion-panel>
              <v-expansion-panel style="background-color: #78cad2">
                <v-expansion-panel-header>
                  Formato de solicitud de residencia profesional
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-4-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <ISolicitud />
                </v-expansion-panel-content>
              </v-expansion-panel>
              <v-expansion-panel style="background-color: #a1d2ce">
                <v-expansion-panel-header>
                  Formato de evaluacion y seguimiento de residencia profesional
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-5-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <IEvaluacionSeguimiento />
                </v-expansion-panel-content>
              </v-expansion-panel>
              <v-expansion-panel style="background-color: #c7edea">
                <v-expansion-panel-header>
                  Formato de registro de asesoria de residencia profesional
                  <template v-slot:actions>
                    <v-icon color="white">mdi-numeric-6-box-multiple-outline</v-icon>
                  </template>
                </v-expansion-panel-header>
                <v-expansion-panel-content eager>
                  <IRegistroAsesoria />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import IPortada from "@/components/Inicio/IPortada.vue";
import IAnteProyecto from "@/components/Inicio/IAnteProyecto.vue";
import ICartaPresentacion from "@/components/Inicio/ICartaPresentacion.vue";
import ICartaAceptacion from "@/components/Inicio/ICartaAceptacion.vue";
import ISolicitud from "@/components/Inicio/ISolicitud.vue";
import IEvaluacionSeguimiento from "@/components/Inicio/IEvaluacionSeguimiento.vue";
import IRegistroAsesoria from "@/components/Inicio/IRegistroAsesoria.vue";
export default {
  components: {
    IPortada,
    IAnteProyecto,
    ICartaPresentacion,
    ICartaAceptacion,
    ISolicitud,
    IEvaluacionSeguimiento,
    IRegistroAsesoria
  },
  data() {
    return {};
  }
};
</script>

<style lang="scss" scoped>
.backg {
  background-color: #c7edea;
}
</style>
