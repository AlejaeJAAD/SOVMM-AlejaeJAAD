<!-- @format -->

<template>
  <v-app>
    <v-main>
      <router-view name="nav" />
      <div style="margin-top: 3rem">
        <transition name="fade" mode="out-in">
          <router-view />
        </transition>
      </div>
      <v-snackbar color="red" centered style="margin-top: -15%" transition="fade-in" :timeout="3000" @mouseenter="snackbar = false" shaped v-model="snackbar">{{ snckTxt }}</v-snackbar>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: "App",

  components: {},
  data() {
    return {
      snackbar: false,
      snckTxt: ""
    };
  },
  created() {
    console.log("k", this.$store.getters.getToken);
    this.$nextTick(() => {
      console.log("m", this.$store.getters.getToken);
      this.$store.dispatch("fetchSession").catch(err => {
        console.log(err);
        this.$router.replace("/login");
        this.snackbar = true;
        this.snckTxt = err.message;
      });
    });
  }
};
</script>
<style>
.xxl {
  font-size: 4rem;
}
</style>
