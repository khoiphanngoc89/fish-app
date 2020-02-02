import router from '@/router/index.js';
import store from '@/store/index.js';
import { LOGIN_URL, ADMIN_ROOT_URL, DASHBOARD_URL } from '@/utils/constants/url.constant.js';
const isAuthenticated = store.getters.isAuthenticated;

function notLogin (to) {
    return !to.fullPath.includes(LOGIN_URL);
}

function redirectToLogin(to, next) {
  next({
    path: LOGIN_URL,
    query: { redirect: to.fullPath }
  });
}

function redirectToDashboard(to, next) {
  next({
    path: DASHBOARD_URL,
  });
}

function isAdminArea(to) {
  return to.path.includes(ADMIN_ROOT_URL) && notLogin(to);
}

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {
      // this route requires auth, check if logged in
      // if not, redirect to login page.
      if (!isAuthenticated && notLogin(to)) {
        redirectToLogin(to, next);
      }
      else {
        next();
      }
    } else if(isAuthenticated && isAdminArea(to)) { // users -> /admin then will check authen and redirect to 
      redirectToDashboard(to, next);
    } else if(!isAuthenticated && isAdminArea(to)) {
      redirectToLogin(to, next);
    }
    else next(); // make sure to always call next()!
  })

export default router;