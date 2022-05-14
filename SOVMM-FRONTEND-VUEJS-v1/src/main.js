import Vue from "vue";
import JsonExcel from "vue-json-excel";
import Axios from "axios";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";

Vue.component("downloadExcel", JsonExcel);

Vue.config.productionTip = false;
// eslint-disable-next-line import/prefer-default-export
export const testEnv = false;

Axios.defaults.baseURL = "http://localhost:5000";
// Axios.defaults.baseURL = 'https://sovmm.azurewebsites.net';

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
