// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'

// Импорт компонентов страниц
import App from '../views/App.vue'
import Registration from '../views/Registration.vue'
import Login from '../views/Login.vue'
import PasswordReset from '../views/PasswordReset.vue'
import PatientHome from '../views/PatientHome.vue'
import SickLeave from '../views/SickLeave.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: App,
    meta: { requiresAuth: false }
  },
  {
    path: '/about',
    name: 'About',
    component: Registration,
    meta: { requiresAuth: false }
  },
  {
    path: '/login',
    name: 'login',
    component: Login,
    meta: { 
      requiresAuth: false,
      preventIfAuthenticated: true // Дополнительный флаг для страницы логина
    }
  },
  {
    path: '/forgot-password',
    name: 'forgot-password',
    component: PasswordReset,
    meta: { requiresAuth: false }
  },
  {
    path: '/PatientHome',
    name: 'PatientHome',
    component: PatientHome,
    meta: { requiresAuth: true }
  },
  {
    path: '/SickLeaves',
    name: 'SickLeave',
    component: SickLeave,
    meta: { requiresAuth: true }
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})
43
export default router