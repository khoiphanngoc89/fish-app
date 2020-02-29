import axios from 'axios';
import store from '@/store/index';
import { REFRESH_AUTHEN } from '@/utils/constants/shared.constant'

// You can use your own logic to set your local or production domain
// The base URL is empty this time due we are using the jsonplaceholder API
const baseURL = process.env.VUE_APP_BASE_URL;

const $axios = axios.create({
  baseURL: `${baseURL}api`,
  withCredentials: false,
})

$axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';



$axios.interceptors.request.use(function (config) {
  // Do something before request is sent
  return config;
}, function (error) {
  const code = parseInt(error.response && error.response.status);
  if(code === 401) {
    store.dispatch(REFRESH_AUTHEN)
    return Promise.reject(error);
  }
  // Do something with request error
  return Promise.resolve(error);
});

export default $axios;