import Axios from "axios";

const state = {
  proyectosResidencias: [],
  proyectos: [],
  miProyectoResidencias: [],
  miProyectos: [],
  longMiProyectoResidencias: []
};

const getters = {
  getPresidencias(state) {
    return state.presidencias;
  },
  getProyectos(state) {
    return state.proyectos;
  },
  getMiProyectoResidencias(state) {
    return state.miProyectoResidencias;
  },
  getMiProyectos(state) {
    return state.miProyectos;
  },
  getMiProyectoID(state) {
    return state.getMiProyectoResidencias.proyectoId;
  }
};

const mutations = {
  setPresidencias(state, presidencias) {
    state.proyectosResidencias = presidencias;
  },
  setMiProyectoResidencias(state, miPresidencia) {
    state.miProyectoResidencias = miPresidencia;
  },
  setProyectos(state, proyectos) {
    state.proyectos = proyectos;
  },
  setMiProyectos(state, proyectos) {
    state.miProyectos = proyectos;
  }
};

const actions = {
  fetchPresidencias(context) {
    return new Promise(resolve => {
      Axios.get("presidencias", {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(res => {
        resolve(true);
        context.commit("setPresidencias", res.data);
      });
    });
  },
  fetchMiPresidencias(context) {
    Axios.get(`presidencias/user/${context.getters.getUserId}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`
      }
    }).then(res => {
      context.commit("setMiProyectoResidencias", res.data);
      state.longMiProyectoResidencias.push(res.data);
      console.log(state.longMiProyectoResidencias.length, "HJola");
    });
  },
  fetchProyectos(context) {
    Axios.get("proyectos", {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`
      }
    }).then(res => {
      context.commit("setProyectos", res.data);
    });
  },
  fetchMiProyectos(context) {
    Axios.get(`proyectos/presidencias/${context.getters.getMyProyectoID}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`
      }
    }).then(res => {
      context.commit("setMiProyectos", res.data);
    });
  }
};

export default {
  state,
  getters,
  mutations,
  actions
};
