import Axios from 'axios';

Axios.defaults.baseUrl = 'http://localhost:5000/';

const state = {
  students: [],
};

/* eslint no-shadow: ["error", { "allow": ["state"] }] */

const mutations = {
  setEstudiantes(state, students) {
    state.students = students;
  },
};

const actions = {
  fetchEstudiantes(context) {
    Axios.get('users').then((res) => {
      const info = res.data.filter((al) => al.accessLevel === 3);
      context.commit('setEstudiantes', info);
    });
  },
  insertStudent(context, nuevoStudent) {
    Axios.post('/users', nuevoStudent).then(() => {
      context.dispatch('fetchEstudiantes');
    });
  },
  deleteStudent(context, id) {
    return new Promise((resolve) => {
      Axios.delete(`/users/${id}`).then((res) => resolve(res.data));
    });
  },
  updateStudent(context, student) {
    Axios.put(`/users/${student.id}`, student).then(() => {
      context.dispatch('fetchEstudiantes');
    });
  },
  getStudent(context, student) {
    return new Promise((resolve) => {
      Axios.get(`/users/${student}`).then((res) => resolve(res.data));
    });
  },
};
const getters = {
  getEstudiantes() {
    return state.students;
  },
};
export default {
  state,
  mutations,
  actions,
  getters,
};
