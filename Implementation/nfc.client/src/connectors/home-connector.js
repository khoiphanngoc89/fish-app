import Connector from './connector-base.js';
const endpoint = '/product'
export const HomeInterface = {
    getHighlightAsync() {},
    getAllAsync() {},
  };

export default {
    async getHighlightAsync() {
        return await Connector.get(`${endpoint}/highlight`);
    },
    async getAllAsync() {
        return await Connector.get(`${endpoint}/all/home`);
    }
}
