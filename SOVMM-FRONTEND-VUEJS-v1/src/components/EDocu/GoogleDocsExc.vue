<template>
  <v-row>
    <v-col cols="12">
      <iframe :src="`https://docs.google.com/viewer?url=${this.info.cartPres[0]}&embedded=true`"
              style="position:fixed; top:0; left:0; bottom:0; right:0; width:100%;
                  height:100%; border:none; margin:0; padding:0; overflow:hidden; z-index:999999;"
              name="myiFrame" scrolling="yes"
              frameborder="1" marginheight="0px" marginwidth="0px"
              allowfullscreen></iframe>
    </v-col>
  </v-row>
</template>

<script>
export default {
  name: 'GoogleDocsExc',
};
</script>

<style scoped>

</style>
