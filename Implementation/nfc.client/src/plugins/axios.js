import axios from 'axios';
//import store from '@/store/index';

// You can use your own logic to set your local or production domain
// The base URL is empty this time due we are using the jsonplaceholder API
const baseURL = process.env.VUE_APP_BASE_URL;

const instance = axios.create({
  baseURL: `${baseURL}api`,
  withCredentials: false,
})

instance.defaults.headers.common['Access-Control-Allow-Origin'] = '*';

// let isRefreshing = false;
// instance.interceptors.response.use(
//   response => {
//     response;
//   }, 
//   error => {
//     debugger
//     const {status} = error.request;
    
//     if(status === 401) {
//       if(!isRefreshing) {
//         isRefreshing = true;
//         store.dispatch('refreshToken');
//         if(status === 200 || status === 204) {
//           isRefreshing = false;
//         }
//       }
//     }
//     return error
//   }
// )
export default instance;