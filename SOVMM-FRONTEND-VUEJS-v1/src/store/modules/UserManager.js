import Axios from 'axios';
import AuthManager from './AuthManager';

/* eslint no-shadow: ["error", { "allow": ["state"] }] */

const state = {
  usuarios: [],
  myUsuarios: [],
};

const getters = {
  getUsuario(state) {
    return state.myUsuarios;
  },
  getUsuarios(state) {
    console.log(state, 'ew');
    const useer = AuthManager.state.user;
    return state.usuarios.filter((alum) => useer.departamento === alum.departamento);
  },
  /* eslint-disable consistent-return */
};
const mutations = {
  setMyUsuario(state, usuarios) {
    state.myUsuarios = usuarios;
  },
  setUsuarios(state, usuarios) {
    state.usuarios = usuarios;
  },
};
const actions = {
  fetchMyUsuarios(context) {
    Axios.get(`users/${context.getters.getUserId}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`,
      },
    }).then((res) => {
      context.commit('setMyUsuario', res.data);
      // console.log(res.data, 'hello');
    });
  },
  fetchUsuarios(context) {
    return new Promise(((resolve) => {
      Axios.get('users', {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`,
        },
      }).then((res) => {
        resolve(true);
        context.commit('setUsuarios', res.data);
      });
    }));
  },
};

export default {
  state, getters, mutations, actions,
};
