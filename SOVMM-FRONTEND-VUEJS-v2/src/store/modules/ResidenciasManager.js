import Axios from "axios";

const state = {
  proyectosResidencias: [],
  proyectosResidenciasInmutable: [],
  proyectos: [],
  miProyectoResidencias: [],
  longMiProyectoResidencias: [],
  longProyectosResidencias: [],
  selectedPresidencia: [],
  selectedProyecto: [],
  selectedUsuario: [],
  filter: [],
  error: "",
  counterFilter: "",
  userInfo: []
};

const getters = {
  getPresidencias(state) {
    return state.proyectosResidencias;
  },
  getPresidenciasInmutable(state) {
    return state.proyectosResidenciasInmutable;
  },
  getMiProyectoResidencias(state) {
    return state.miProyectoResidencias;
  },
  getSelectedPresidencia(state) {
    return state.selectedPresidencia;
  },
  getSelectedProyecto(state) {
    return state.selectedProyecto;
  },
  getSelectedUsuario(state) {
    console.log(state.selectedUsuario);
    return state.selectedUsuario;
  },
  getProyectos(state) {
    return state.proyectos;
  },
  getFilter(state) {
    return state.filter;
  },
  getCounterFilter(state) {
    return state.counterFilter;
  },
  getUserInfo(state) {
    return state.userInfo;
  }
};

const mutations = {
  setPresidencias(state, presidencias) {
    state.proyectosResidencias = presidencias;
  },
  setPresidenciasInmutable(state, presidencias) {
    state.proyectosResidenciasInmutable = presidencias;
  },
  setMiProyectoResidencias(state, miPresidencia) {
    state.miProyectoResidencias = miPresidencia;
  },
  setSelectedPresidencia(state, selectedPresidencia) {
    state.selectedPresidencia = selectedPresidencia;
  },
  setSelectedProyecto(state, selectedProyecto) {
    state.selectedProyecto = selectedProyecto;
  },
  setSelectedUsuario(state, selectedUsuario) {
    state.selectedUsuario = selectedUsuario;
  },
  setProyectos(state, proyectos) {
    state.proyectos = proyectos;
  },
  setFilter(state, filters) {
    state.filter = filters;
  },
  setCounterFilter(state, counter) {
    state.counterFilter = counter;
  },
  POST_ERROR: (state, payload) => {
    state.error = payload;
  },
  setUserInfo(state, userInfo) {
    state.userInfo = userInfo;
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
        context.commit("setPresidenciasInmutable", res.data);

        res.data.forEach(pr => {
          console.log(pr.createdBy);
          Axios.get(`users/${pr.createdBy}`, {
            headers: {
              Authorization: `Bearer ${context.getters.getToken}`
            }
          }).then(resp => {
            resolve(true);
            context.commit("setUserInfo", resp.data);
          });
          state.longProyectosResidencias.push(pr);
        });
      });
    });
  },
  fetchPresidenciasFilter(context, filterSelected) {
    return new Promise(resolve => {
      Axios.get("presidencias", {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(res => {
        resolve(true);
        // let contador = 0;
        // for (var i in res.data) {
        //   if (res.data[i].status == filter) {
        //     contador++;
        //     console.log(contador);
        //   }
        //   console.log(contador);
        // }

        // context.commit("setCounterFilter", contador);

        // res.data.forEach(filteredData => {
        //   let contador = 0;
        //   let arrayPresidencias = [];
        //   if (filteredData.status == filter) {
        //     contador = contador + 1;
        //     // console.log(`Hay ${contador} proyectos con estatus ${filter}`);
        //     arrayPresidencias.push(filteredData);
        //     context.commit("setPresidencias", arrayPresidencias);
        //   }
        // });
        var filteredNumbers = res.data.filter(function(e) {
          return e.status == filterSelected;
        });

        if (filteredNumbers.length == 0) {
          console.log("Hola");
        }

        console.log(filteredNumbers);
        context.commit("setPresidencias", filteredNumbers);
      });
    });
  },
  fetchPresidenciasCategoria(context, categoriaSelected) {
    return new Promise(resolve => {
      Axios.get("presidencias", {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(res => {
        resolve(true);
        // let contador = 0;
        // for (var i in res.data) {
        //   if (res.data[i].status == filter) {
        //     contador++;
        //     console.log(contador);
        //   }
        //   console.log(contador);
        // }

        // context.commit("setCounterFilter", contador);

        // res.data.forEach(filteredData => {
        //   let contador = 0;
        //   let arrayPresidencias = [];
        //   if (filteredData.status == filter) {
        //     contador = contador + 1;
        //     // console.log(`Hay ${contador} proyectos con estatus ${filter}`);
        //     arrayPresidencias.push(filteredData);
        //     context.commit("setPresidencias", arrayPresidencias);
        //   }
        // });
        var filteredCategorias = res.data.filter(function(e) {
          console.log(e.categoria, categoriaSelected);
          const upperCat = categoriaSelected.charAt(0).toUpperCase() + categoriaSelected.slice(1);

          console.log(upperCat);
          return e.categoria == upperCat;
        });

        if (filteredCategorias.length == 0) {
          console.log("Hola");
        }

        console.log(filteredCategorias);
        context.commit("setPresidencias", filteredCategorias);
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
    });
  },
  fetchSelectedPresidencia(context, id) {
    Axios.get(`presidencias/${id}`, {
      headers: {
        Authorization: `Bearer ${context.getters.getToken}`
      }
    }).then(res => {
      context.commit("setSelectedPresidencia", res.data);
      console.log(res.data.createdBy);
      Axios.get(`users/${res.data.createdBy}`, {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(resu => {
        context.commit("setSelectedUsuario", resu.data);
        console.log(resu.data);
      });
      Axios.get(`proyectos/${res.data.proyectoId}`, {
        headers: {
          Authorization: `Bearer ${context.getters.getToken}`
        }
      }).then(resp => {
        context.commit("setSelectedProyecto", resp.data);
      });
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
  SET_ERROR: (context, errorMsg) => {
    console.log(errorMsg);
    context.commit("POST_ERROR", errorMsg);
  }
};

export default {
  state,
  getters,
  mutations,
  actions
};
