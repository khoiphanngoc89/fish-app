import Connector from './connector-base.js';
const endpoint = '/menu'
export default {
    async getAllAsync() {
        debugger
        return await Connector.get(`${endpoint}/all`)
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
    }
}
