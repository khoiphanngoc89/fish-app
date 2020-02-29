import {
    STATUS_ERROR,
    STATUS_LOADING,
    STATUS_SUCCESS,
    AUTHEN_REQUEST,
    AUTHEN_SUCCESS,
    AUTHEN_ERROR,
    AUTHEN_LOGOUT
} from './mutation-types'

export default {
    [AUTHEN_REQUEST](state) {
        state.authorization.status = STATUS_LOADING;
        state.authorization.token = '';
        state.authorization.user = {};
    },
    [AUTHEN_SUCCESS](state, info) {
        state.authorization.status = STATUS_SUCCESS;
        state.authorization.token = info.token;
        state.authorization.user = info.user;
    },
    [AUTHEN_ERROR](state) {
        state.authorization.status = STATUS_ERROR;
        state.authorization.token = '';
        state.authorization.user = {};
    },
    [AUTHEN_LOGOUT](state) {
        state.authorization.status = '';
        state.authorization.token = '';
        state.authorization.user = {};
    }
}