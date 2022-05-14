import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Landing',
    component: () => import('../views/Landing.vue'),
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../views/Login.vue'),
  },
  {
    path: '/inicio',
    name: 'Inicio',
    components: {
      default: () => import('../views/Inicio.vue'),
      nav: () => import('../components/Global/Nav.vue'),
    },
  },
  {
    path: '/proyectos-residencias',
    name: 'Proyectos-Residencias,',
    components: {
      default: () => import('@/views/ProyectosResidencias.vue'),
      nav: () => import('../components/Global/Nav'),
    },
  },
  {
    path: '/mi-proyecto-residencias',
    name: 'Proyecto-Residencias',
    components: {
      default: () => import('@/views/MiProyectoResidencias.vue'),
      nav: () => import('../components/Global/Nav'),
    },
  },
  {
    path: '/estudiantes',
    name: 'Estudiantes',
    components: {
      default: () => import('../views/Estudiantes.vue'),
      nav: () => import('../components/Global/Nav.vue'),
    },
  },
  {
    path: '/maestros',
    name: 'Maestros',
    components: {
      default: () => import('../views/Maestros.vue'),
      nav: () => import('../components/Global/Nav.vue'),
    },
  },
  {
    path: '/cuenta',
    name: 'cuenta',
    components: {
      default: () => import('@/views/Cuenta.vue'),
      nav: () => import('@/components/Global/Nav.vue'),
    },
  },
  {
    path: '*',
    redirect: 'login',
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

export default router;
