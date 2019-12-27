import Connector from './connector-base.js';
const endpoint = '/product'
export const ProductInterface = {
    getHighlightAsync() {},
    getAllAsync() {},
    getByIdAsync() {},
    addAsync() {},
    updateAsync() {},
    deleteAsync() {}
  };

export default {
    async getHighlightAsync() {
        return await Connector.get(`${endpoint}/highlight`);
    },
    async getAllAsync({pageNumber, pageSize, getLatest}) {
        return await Connector.post(`${endpoint}/all/home`, this.buildParams(pageNumber, pageSize, getLatest));
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
