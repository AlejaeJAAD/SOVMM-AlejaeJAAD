import Axios from "axios";

Axios.defaults.baseUrl = "http://localhost:5000/";

const state = {
  maestros: []
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */

const mutations = {
  setMaestros(state, maestros) {
    state.maestros = maestros;
  }
};

const actions = {
  fetchMaestros(context) {
    Axios.get("users").then(res => {
      const info = res.data.filter(al => al.accessLevel === 2);
      context.commit("setMaestros", info);
    });
  },
  insertTeacher(context, nuevoTeacher) {
    console.log(nuevoTeacher);
    Axios.post("/users", nuevoTeacher).then(() => {
      context.dispatch("fetchMaestros");
    });
  },
  deleteTeacher(context, id) {
    return new Promise(resolve => {
      Axios.delete(`/users/${id}`).then(res => resolve(res.data));
    });
  },
  updateTeacher(context, teacher) {
    Axios.put(`/users/${teacher.id}`, teacher).then(() => {
      context.dispatch("fetchMaestros");
    });
  },
  getTeacher(context, teacher) {
    return new Promise(resolve => {
      Axios.get(`/users/${teacher}`).then(res => resolve(res.data));
    });
  }
};
const getters = {
  getMaestros() {
    return state.maestros;
  }
};
export default {
  state,
  mutations,
  actions,
  getters
};
