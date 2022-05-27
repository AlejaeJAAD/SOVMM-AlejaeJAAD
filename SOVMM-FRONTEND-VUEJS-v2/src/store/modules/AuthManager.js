/** @format */

import Axios from "axios";

const state = {
  token: localStorage.x_jwt_string ?? "",
  expiration: localStorage.x_jwt_exp ?? new Date(),
  userId: localStorage.x_sovmm_userId ?? "",
  accessLvl: localStorage.x_ulvl ?? 0,
  user: [],
  auth: { Authorization: `Bearer ${localStorage.x_jwt_string}` },
  usuarios: [],
  myUsuarios: []
};
const getters = {
  getToken(state) {
    return state.token;
  },
  getUserId(state) {
    return state.userId;
  },
  getUser(state) {
    return state.user;
  },
  getAuth(state) {
    return state.auth;
  },
  getAccessLevel(state) {
    return state.user.accessLevel;
  },
  isLogged(state) {
    return state.token !== "";
  }
};
const mutations = {
  authUser(state, userData) {
    state.token = userData.credentials.token;
    state.userId = userData.id;
    state.accessLvl = userData.accessLevel;
    state.user = userData;
  },
  clearAuthData(state) {
    state.token = "";
    state.userId = "";
    state.expiration = "";
    state.user = {};
  },
  setMyUsuario(state, usuarios) {
    state.myUsuarios = usuarios;
  },
  setUsuarios(state, usuarios) {
    state.usuarios = usuarios;
  }
};
const actions = {
  logIn(context, loginForm) {
    return new Promise((response, error) => {
      Axios.post("users/auth", loginForm)
        .then(res => {
          if (res.data.error) {
            error(res.data.error);
            return;
          }
          const now = new Date();
          const expiration = new Date().setDate(now.getDate() + res.data.credentials.expirationInDays);
          localStorage.setItem("x_jwt_exp", new Date(expiration).toISOString());
          localStorage.setItem("x_jwt_string", res.data.credentials.token);
          localStorage.setItem("x_sovmm_userId", res.data.id);
          localStorage.setItem("x_ulvl", res.data.accessLevel);
          context.commit("authUser", res.data);
          response(res.data);
        })
        .catch(() => error(new Error("Algo salió mal!")));
    });
  },
  logOut(context) {
    context.commit("clearAuthData");
    localStorage.removeItem("x_jwt_string");
    localStorage.removeItem("x_jwt_exp");
    localStorage.removeItem("x_sovmm_userId");
    localStorage.removeItem("x_ulvl");
  },
  setExpiration() {},
  fetchSession(context) {
    return new Promise((resolve, error) => {
      const token = localStorage.x_jwt_string;
      if (!token) {
        context.dispatch("logOut");
        error(new Error("Necesitas inciar sesion"));
        return;
      }
      const { expiration } = localStorage.x_jwt_exp;
      const now = new Date();
      if (now >= expiration) {
        context.dispatch("logOut");
        error(new Error("Tiempo de sesion finalizado, por favor inicie sesión nuevamente."));
        return;
      }
      const { userId } = context.state;
      Axios.get(`users/${userId}`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      })
        .then(res => {
          const user = res.data;
          user.credentials.token = token;
          context.commit("authUser", user);
          resolve(res.data);
        })
        .catch(err => error(new Error(`CATCHERR: Algo salió mal! ${err}`)));
    });
  },
  register(context, data) {
    Axios.post("users", data);
  },
  updateUser(context, newUserData) {
    return new Promise((resolve, error) => {
      Axios.put(`users/${newUserData.id}`, newUserData, {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      })
        .then(() => {
          context.dispatch("fetchSession");
          resolve(true);
        })
        .catch(() => {
          error(new Error());
        });
    });
  },
  updatePassword(context, pwModel) {
    return new Promise((resolve, error) => {
      Axios.put(`users/password/${context.getters.getUserId}`, pwModel, {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      })
        .then(res => resolve(res))
        .catch(err => error(err));
    });
  },
  fetchMyUsuarios(context) {
    Axios.get(`users/${context.getters.getUserId}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`
      }
    }).then(res => {
      context.commit("setMyUsuario", res.data);
    });
  },
  fetchUsuarios(context) {
    return new Promise(resolve => {
      Axios.get("users", {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(res => {
        resolve(true);
        context.commit("setUsuarios", res.data);
      });
    });
  }
};
export default {
  state,
  getters,
  mutations,
  actions
};
