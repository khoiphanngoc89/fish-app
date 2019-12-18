const routes = [
  {
    path: '*',
    redirect: '/',
  },
  {
    path: '/',
    component: () => import(/* webpackChunkName: "demo" */ '@/layouts/external/index'),
    redirect: '/home',
    children: [
      {
        path: '/',
        name: 'home',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/external/index'),
      },
    ]
  },
  {
    path: '/admin/login',
    component: () => import(/* webpackChunkName: "demo" */ '@/layouts/internal/AuthLayout'),
    redirect: '/admin/login',
    children: [
      {
        path: '/admin/login',
        name: 'login',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/Login.vue'),
        meta: {
          requiresAuth: true
        }
      },
    ]
  },
  {
    path: '/admin',
    redirect: '/admin/dashboard',
    component: () => import(/* webpackChunkName: "demo" */ '@/layouts/internal/DashboardLayout'),
    children: [
      {
        path: '/admin/dashboard',
        name: 'dashboard',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/Dashboard.vue'),
        meta: {
          requiresAuth: true
        }
      },
      {
        path: '/admin/icons',
        name: 'icons',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/Icons.vue'),
        meta: {
          requiresAuth: true
        }
      },
      {
        path: '/admin/profile',
        name: 'profile',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/UserProfile.vue'),
        meta: {
          requiresAuth: true
        }
      },
      {
        path: '/admin/maps',
        name: 'maps',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/Maps.vue'),
        meta: {
          requiresAuth: true
        }
      },
      {
        path: '/admin/tables',
        name: 'tables',
        component: () => import(/* webpackChunkName: "demo" */ '@/views/internal/Tables.vue'),
        meta: {
          requiresAuth: true
        }
      }
    ]
  }, 
]

export default routes