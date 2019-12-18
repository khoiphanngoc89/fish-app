export default {
    isLoggedIn: state => !!state.authorization.token,
    authStatus: state => state.authorization.status
}