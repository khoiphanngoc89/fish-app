import Connector from './connector-base.js';
const endpoint = '/product'

export default {
    async getHighlightAsync() {
        return await Connector.get(`${endpoint}/highlight`);
    },
    async getAllAsync({number, size, getLatest}) {
        return await Connector.post(`${endpoint}/all/home`, this.buildParams(number, size, getLatest));
    },
    async getByIdAsync(id) {
        return await Connector.get(`${endpoint}/${id}`);
    },
    async addAsync(model) {
        return await Connector.post(`${endpoint}/add`, model);
    },
    async updateAsync(model) {
        return await Connector.put(`${endpoint}/update`, model);
    },
    async deleteAsync(id) {
        return await Connector.delete(`${endpoint}/delete`, id);
    },
    buildParams(pageNumber, pageSize, getLatest) {
        return {
            pageNumber: pageNumber,
            pageSize: pageSize,
            getLatest: getLatest
        }
    }
}
