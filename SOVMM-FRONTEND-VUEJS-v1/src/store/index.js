import Vue from 'vue';
import Vuex from 'vuex';
import ResidenciasManager from '@/store/modules/ResidenciasManager';
import UserManager from '@/store/modules/UserManager';
import AuthManager from '@/store/modules/AuthManager';
import Maestros from '@/store/modules/Maestros';
import Estudiantes from '@/store/modules/Estudiantes';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    AuthManager,
    ResidenciasManager,
    UserManager,
    Maestros,
    Estudiantes,
  },
});
