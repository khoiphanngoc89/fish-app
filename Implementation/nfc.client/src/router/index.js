import Vue from 'vue';
import Router from 'vue-router';
import routes from './route';

Vue.use(Router);

 const router = new Router({
  linkExactActiveClass: 'active',
  routes: routes,
  mode: 'history'
})

export default router;
