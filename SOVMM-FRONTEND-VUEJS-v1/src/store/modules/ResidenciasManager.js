import Axios from 'axios';

/* eslint no-shadow: ["error", { "allow": ["state"] }] */

const state = {
  presidencias: [],
  proyectos: [],
  myPresidencias: [],
  myProyectos: [],
};
const getters = {
  getPresidencias(state) {
    return state.presidencias;
  },
  /* eslint-disable consistent-return */
  getPresidenciasFilterTodo(state) {
    return state.presidencias;
  },
  getPresidenciasFilter0(state) {
    return state.presidencias.filter((val) => val.status === 0);
  },
  getPresidenciasFilter1(state) {
    return state.presidencias.filter((val) => val.status === 1);
  },
  getPresidenciasFilter2(state) {
    return state.presidencias.filter((val) => val.status === 2);
  },
  getPresidenciasFilter3(state) {
    return state.presidencias.filter((val) => val.status === 3);
  },
  getMyPresidencias(state) {
    return state.myPresidencias;
  },
  getProyectos(state) {
    return state.proyectos;
  },
  getMyProyectos(state) {
    return state.myProyectos;
  },
  getMyProyectoID(state) {
    console.log(state.myPresidencias.id, 'IDDD');
    return state.myPresidencias.proyectoId;
  },
  getPresidenciasUnfiltered(state) {
    return state.presidencias;
  },
  getPresidenciasFiltered(state, filter) {
    return state.presidencias.filter(((value) => value === filter));
  },
};
const mutations = {
  setPresidencias(state, presidencias) {
    state.presidencias = presidencias;
  },
  setMyPresidencias(state, presidencias) {
    state.myPresidencias = presidencias;
  },
  setProyectos(state, proyectos) {
    state.proyectos = proyectos;
  },
  setMyProyectos(state, proyectos) {
    state.myProyectos = proyectos;
  },
};
const actions = {
  fetchPresidencias(context) {
    return new Promise(((resolve) => {
      Axios.get('presidencias', {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`,
        },
      }).then((res) => {
        resolve(true);
        context.commit('setPresidencias', res.data);
      });
    }));
  },
  fetchMyPresidencias(context) {
    Axios.get(`presidencias/user/${context.getters.getUserId}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then((res) => {
      context.commit('setMyPresidencias', res.data);
      // console.log(res.data, 'hola');
    });
  },
  fetchProyectos(context) {
    Axios.get('proyectos', {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then((res) => {
      context.commit('setProyectos', res.data);
      // console.log(res.data, 'hola2');
    });
  },
  fetchMyProyectos(context) {
    Axios.get(`proyectos/presidencias/${context.getters.getMyProyectoID}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then((res) => {
      context.commit('setMyProyectos', res.data);
      // console.log(res.data, 'hola');
    });
  },
  updatePresidencias(context, updatedPresidencias) {
    Axios.put(`presidencias/${updatedPresidencias.id}`, updatedPresidencias, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then(() => {
      context.dispatch('fetchPresidencias');
    });
  },
  updateProyectos(context, updatedProyectos) {
    Axios.put(`proyectos/${updatedProyectos.id}`, updatedProyectos, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then(() => {
      context.dispatch('fetchProyectos');
    });
  },
};

export default {
  state, getters, mutations, actions,
};
