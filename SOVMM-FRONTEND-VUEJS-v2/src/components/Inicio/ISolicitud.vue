<!-- @format -->
<template>
  <div>
    <v-row>
      <v-col cols="12">
        <v-row>
          <v-col cols="4">
            <v-card class="" height="69.5vh">Hola</v-card>
          </v-col>
          <v-col cols="8">
            <iframe
              :src="
                `
                  https://docs.google.com/viewer?url=https://sovmm-bucket-01.s3.us-east-2.amazonaws.com/FORMATO-SOLICITUD+DE+RESIDENCIAS+PROFESIONALES.pdf&embedded=true`
              "
              style="
                position: relative;
                top: 0;
                left: 0;
                bottom: 0;
                right: 0;
                width: 100%;
                height: 100%;
                border: none;
                margin: 0;
                padding: 20px;
              "
              scrolling="no"
              frameborder="1"
              marginheight="0px"
              marginwidth="0px"
            ></iframe>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
.hero {
  background: url("../../assets/1200px-Tecnologico_Nacional_de_Mexico.svg.png");
  background-size: cover;
  width: 100%;
  max-width: 100%;
  height: auto;
}
.row {
  justify-content: space-between;
}
</style>
