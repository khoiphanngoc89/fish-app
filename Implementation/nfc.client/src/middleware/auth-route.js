import router from '@/router/index.js';
import store from '@/store/index.js';
import { LOGIN_URL, ADMIN_ROOT_URL, DASHBOARD_URL } from '@/utils/constants/url.constant.js';
const isAuthenticated = store.getters.isAuthenticated;
//import storageUtil from '@/utils/localStorage.util';

function toLoginPage(to) {
  return to.fullPath.includes(LOGIN_URL);
}

function toRequiredAuthPage (to) {
    return !toLoginPage(to);
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
  return to.path.includes(ADMIN_ROOT_URL) && toRequiredAuthPage(to);
}

router.beforeEach((to, from, next) => {
    // this route requires auth, check if logged in
    // if not, redirect to login page.
    if (to.matched.some(record => record.meta.requiresAuth)) {
      // route: access to admin/login but already authen -> redirect to dashboard
      if(isAuthenticated && toLoginPage(to)) {
        redirectToDashboard(to, next);
      }
      else if (!isAuthenticated && toRequiredAuthPage(to)) { // route: access to authen request page but not yet authen -> redirect to login
        redirectToLogin(to, next);
      } else { // process redirect to target page
        next();
      }
    } else if(isAuthenticated && isAdminArea(to)) { // route: access to  /admin and has authen -> direct doashboard
      redirectToDashboard(to, next);
    } else if(!isAuthenticated && isAdminArea(to)) { // route: access to /admin but not authen -> direct to login
      redirectToLogin(to, next);
    }
    else next(); // make sure to always call next()!
  })

export default router;