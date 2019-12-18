
import util from '@/utils/shared.util';
import axios from '@/plugins/axios'
export default {
    async get(url) {
        return await axios.get(url)
            .then(({ data }) => {
                return util.getAPIData(data)
            })
            .catch(error => {
                throw error;
            })
    },
    async post(url, params) {
        return await axios.post(url, params)
            .then(({ data }) => {
                return util.getAPIData(data)
            })
            .catch(error => {
                throw error;
            })
    },
    async put(url, parmas) {
        return await axios.put(url, parmas)
            .then(({ data }) => {
                return util.getAPIData(data)
            })
            .catch(error => {
                throw error;
            })
    },
    async delete(url, id) {
        return await axios.delete(`${url}/${id}`)
            .then(({ data }) => {
                return this.getAPIData(data)
            })
            .catch(error => {
                throw error;
            })
    },
}
