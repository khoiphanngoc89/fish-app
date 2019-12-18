/*!

=========================================================
* Vue Argon Dashboard - v1.0.0
=========================================================

* Product Page: https://www.creative-tim.com/product/argon-dashboard
* Copyright 2019 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/argon-dashboard/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import Vue from 'vue'
import App from './App.vue'
import router from "@/middleware/auth-route";
import './registerServiceWorker'

import store from './store/index';

// apply IoC inject for Vue + repository pattern
// https://medium.com/canariasjs/vue-api-calls-in-a-smart-way-8d521812c322
// https://markus.oberlehner.net/blog/the-ioc-container-pattern-with-vue/
import connectContainer from '@/connectors/connect-container.js';

Vue.config.productionTip = false

/* Register the buefy */
import '@mdi/font/css/materialdesignicons.css';
import Buefy from 'buefy'
import 'buefy/dist/buefy.css'
Vue.use(Buefy)

/* Register the vue-meta */
import VueMeta from 'vue-meta'
Vue.use(VueMeta, {
  // optional pluginOptions
  refreshOnceOnNavigation: true
})

/* Setup axios for Vue use as default */
import axios from '@/plugins/axios'
Vue.prototype.$http = axios;

/* Register the global mixin */
import shared from '@/mixins/shared';
Vue.mixin(shared);

/* Register i18n */
// https://www.codeandweb.com/babeledit/tutorials/how-to-translate-your-vue-app-with-vue-i18n
import i18n from '@/plugins/i18n';

/* Set doashboard */
import ArgonDashboard from './plugins/argon-dashboard';
Vue.use(ArgonDashboard);

import '@/plugins/vue-toasted';


new Vue({
  i18n,
  router,
  store,
  provide: connectContainer,
  render: h => h(App)
}).$mount('#app')
