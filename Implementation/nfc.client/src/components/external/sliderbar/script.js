import { PRODUCT_CONNECTOR } from '@/connectors/connect-types.js'
import vm from '@/models/product.js';
export default {
    inject: [PRODUCT_CONNECTOR],
    data() {
        return {
            storage: vm.initStorage()
        }
    },
    async created() {
        let self = this;
        await self.loadDataAsync()
    },
    methods: {
        loadDataAsync: async function () {
            let self = this;
            self.storage.products = await self.productConnector.getHighlightAsync();
        },
        getImgUrl: function (value) {
            return `https://picsum.photos/id/43${value}/1230/500`;
        },
        setupBackground: function (value) {
            return `background-image: url(${this.getImgUrl(value)}); background-repeat: no-repeat; background-size: cover;`;
        }
    }
}