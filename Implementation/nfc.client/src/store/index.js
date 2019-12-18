import states from './states';
import actions from './actions';
import getters from './getters';
import mutations from './mutations';
// https://scotch.io/tutorials/handling-authentication-in-vue-using-vuex?fbclid=IwAR3kJtr6Gk0S4Vs1IxsJWnJgvMxDNQ8lcz4KchZ079-wl1tjoBuqiR9pN8U

import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const store = new Vuex.Store({
  state: states,
  mutations: mutations,
  actions: actions,
  getters: getters,
});

export default store;