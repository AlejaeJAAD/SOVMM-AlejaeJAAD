/** @format */

import Vue from "vue";
import VueRouter from "vue-router";
import store from "../store";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Landing",
    component: () => import("@/views/Landing"),
    meta: { requiresAuth: false }
  },
  {
    path: "/error",
    name: "error",
    component: Error
  },
  {
    path: "/login",
    name: "Login",
    component: () => import("@/views/Login.vue"),
    meta: { requiresAuth: false }
  },
  {
    path: "/inicio",
    name: "Inicio",
    components: {
      default: () => import("@/views/Inicio.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/cuenta",
    name: "cuenta",
    components: {
      default: () => import("@/views/Cuenta.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/mi-proyecto",
    name: "Mi-proyecto",
    components: {
      default: () => import("@/views/MiProyecto.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/proyectos-alumnos",
    name: "ProyectosAlumnos",
    components: {
      default: () => import("@/views/ProyectosAlumnos.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/proyectos-alumnos/:id",
    name: "proyectoSeleccionado",
    components: {
      default: () => import("@/components/ProyectosAlumnos/PAInfo.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    props: true
  },
  {
    path: "/estudiantes",
    name: "Estudiantes",
    components: {
      default: () => import("@/views/Estudiantes.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  },
  {
    path: "/maestros",
    name: "Maestros",
    components: {
      default: () => import("@/views/Maestros.vue"),
      nav: () => import("@/components/Global/Nav.vue")
    },
    meta: { requiresAuth: true }
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
