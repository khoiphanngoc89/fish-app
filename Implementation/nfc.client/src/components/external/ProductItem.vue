<template>
  <section>
    <div v-if="storage.products.length" class="row">
      <div v-for="product in storage.products" :key="product.id" class="col-lg-4 col-md-6 mb-4">
        <div class="card h-100">
          <a href="#">
            <img class="card-img-top" :src="product.image1" alt=""/></a>
          <div class="card-body">
            <h4 class="card-title">
              <a href="#">{{ product.name }}</a>
            </h4>
            <h5>{{ product.price }}</h5>
            <p class="card-text">
              {{ product.description }}
            </p>
          </div>
          <div class="card-footer">
            <small class="text-muted"
              >&#9733; &#9733; &#9733; &#9733; &#9734;</small
            >
          </div>
        </div>
      </div>
    </div>
    <hr>
    <b-pagination
            :total="general.total"
            :current.sync="general.number"
            :rounded="true"
            :per-page="general.size"
            :icon-prev="constant.table.prevIcon"
            :icon-next="constant.table.nextIcon"
            :aria-next-constant="constant.table.nextPage"
            :aria-previous-label="constant.table.previousPage"
            :aria-page-label="constant.table.page"
            :aria-current-label="constant.table.currentPage">
    </b-pagination>
  </section>
</template>

<script>
import vm from '@/models/product';
import * as constvm from '@/models/constant';
import { PRODUCT_CONNECTOR } from '@/connectors/connect-types';
import { HOME_PAGE_SIZE } from '@/utils/constants/external.constant';
import { SPLASH } from '@/utils/constants/shared.constant'

export default {
  inject: [PRODUCT_CONNECTOR],
  data: () => {
    return {
      model: vm.initModel(),
      storage: vm.initStorage(),
      general: vm.initGeneral(),
      constant: constvm.constant
    } 
  },
  async mounted() {
    let self = this;
    if(self.isHome) self.general.pageSize = HOME_PAGE_SIZE;
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
};
</script>

<style></style>
