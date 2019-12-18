export const TOKEN = 'accessToken'
const USER = 'user'
export default {
    setAuthStorage(info) {
        let self = this;
        self.setToken(info.token);
        localStorage.setItem(USER, JSON.stringify(info.user));
    },
    getUser() {
        return localStorage.getItem(USER);
    },
    getToken() {
        return localStorage.getItem(TOKEN);
    },
    removeAuthStorage() {
        let self = this;
        self.removeToken()
        localStorage.removeItem(USER);
    },
    removeToken() {
        localStorage.removeItem(TOKEN);
    },
    setToken(token) {
        localStorage.setItem(TOKEN, token);
    }
}