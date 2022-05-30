/** @format */

import Vue from "vue";
import Vuex from "vuex";
import AuthManager from "@/store/modules/AuthManager";
import ResidenciasManager from "@/store/modules/ResidenciasManager";
import Estudiantes from "@/store/modules/Estudiantes";
import Maestros from "@/store/modules/Maestros";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    AuthManager,
    ResidenciasManager,
    Estudiantes,
    Maestros
  }
});
