import { TOKEN } from '@/utils/localStorage.util'
export default {
    authorization: {
        status: '',
        token: localStorage.getItem(TOKEN) || '',
        user: {}
    }
}
