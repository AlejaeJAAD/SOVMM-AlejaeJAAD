/** @format */

import Vue from "vue";
import Vuex from "vuex";
import AuthManager from "@/store/modules/AuthManager";
import ResidenciasManager from "@/store/modules/ResidenciasManager";
import Estudiantes from "@/store/modules/Estudiantes";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    AuthManager,
    ResidenciasManager,
    Estudiantes
  }
});
