import context from '@/models/product';
import * as constContext from '@/models/constant';
import { PRODUCT_CONNECTOR } from '@/connectors/connect-types';
import { HOME_PAGE_SIZE } from '@/utils/constants/external.constant';
import { SPLASH } from '@/utils/constants/shared.constant'

export default {
    inject: [PRODUCT_CONNECTOR],
    data: () => {
        return {
            model: context.initModel(),
            storage: context.initStorage(),
            general: context.initGeneral(),
            constant: constContext.constant
        }
    },
    async mounted() {
        let self = this;
        if (self.isHome) self.general.pageSize = HOME_PAGE_SIZE;
        await self.loadDataAsync();
    },
    computed: {
        isHome() {
            return window.location.pathname === SPLASH;
        }
    },
    methods: {
        async loadDataAsync() {
            let self = this;
            self.storage.products =
                await self.productConnector.getAllAsync(self.general);
        }
    }
}