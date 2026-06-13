import { createRouter, createWebHistory } from 'vue-router'

import NuevaCompra from '../views/NuevaCompra.vue'
import HistorialMovimientos from '../views/HistorialMovimientos.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/compra'
    },
    {
      path: '/compra',
      component: NuevaCompra
    },
    {
      path: '/historial',
      component: HistorialMovimientos
    }
  ]
})

export default router