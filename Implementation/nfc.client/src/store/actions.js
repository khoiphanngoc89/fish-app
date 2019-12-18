
import util from '@/utils/shared.util';
import storageUtil from '@/utils/localStorage.util';
import axios from '@/plugins/axios';
import { 
    AUTHEN_REQUEST,
    AUTHEN_SUCCESS,
    AUTHEN_ERROR,
    LOGOUT
} from './mutation-types';
import {
    SIGNIN_URL,
    REGISTER_URL
} from '@/utils/constants/url.constant'
const AUTHORIZATION = 'Authorization';

export default {
    login({ commit }, context) {
        return new Promise((resolve, reject) => {
            commit(AUTHEN_REQUEST);
            axios.post(SIGNIN_URL, context)
                .then(({data}) => {
                    let info = util.getAuthenAPIInfo(data);
                    storageUtil.setAuthStorage(info);
                    axios.defaults.headers.common[AUTHORIZATION] = `Bearer ${info.token}`;
                    commit(AUTHEN_SUCCESS, info);
                    resolve(data);
                })
                .catch(err => {
                    commit(AUTHEN_ERROR);
                    storageUtil.removeAuthStorage();
                    reject(err);
                })
        })
    },
    logout({ commit }) {
        commit(LOGOUT);
        storageUtil.removeToken();
        delete axios.defaults.headers.common[AUTHORIZATION];
    },
    register({ commit }, user) {
        return new Promise((resolve, reject) => {
            commit(AUTHEN_REQUEST);
            axios.post(REGISTER_URL, user)
                .then(({ data }) => {
                    let info = util.getAPIData(data);
                    storageUtil.setToken(info.token);
                    axios.defaults.headers.common[AUTHORIZATION] = info.token;
                    commit(AUTHEN_SUCCESS, info);
                    resolve(data);
                })
                .catch(err => {
                    commit(AUTHEN_ERROR, err)
                    storageUtil.removeToken();
                    reject(err)
                })
        })
    },
    refreshToken() {
        return new Promise((resolve, reject) => {
            let parmas = {
                ...storageUtil.getUser(),
                token: localStorage.getToken()
            }
            axios.post('auth/refresh', parmas)
                 .then(({data}) => {
                     let token = util.getAPIData(data);
                     storageUtil.setToken(token);
                     resolve(data);
                 })
                 .catch(error => {
                     reject(error)
                 })
        })
    }
}