export default {
    isAuthenticated: state => !!state.authorization.token,
    authStatus: state => state.authorization.status
}