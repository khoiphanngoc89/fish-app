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
            :current.sync="general.current"
            :order="general.order"
            :size="general.size"
            :simple="general.isSimple"
            :rounded="general.isRounded"
            :per-page="general.perPage"
            :icon-prev="general.prevIcon"
            :icon-next="general.nextIcon"
            aria-next-label="Next page"
            aria-previous-label="Previous page"
            aria-page-label="Page"
            aria-current-label="Current page"
            @change="onChange">
    </b-pagination>
  </section>
</template>

<script>
import vm from '@/models/product.js';
import { PRODUCT_CONNECTOR } from '@/connectors/connect-types.js'

export default {
  inject: [PRODUCT_CONNECTOR],
  data: () => {
    return {
      model: vm.initModel(),
      storage: vm.initStorage(),
      general: vm.initGeneral()
    } 
  },
  computed: {
    isHome: function() {
      return window.location.pathname == '/';
    }
  },
  async mounted() {
    let self = this;
    if(self.isHome) self.general.size = 6;
    await self.loadDataAsync();
  },
  methods: {
    loadDataAsync: async function() {
      let self = this;
      await self.onConnect();
        
    },
    onChange: async function(number) {
      let self = this;
      self.general.current = number;
      await self.onConnect();
    },
    onConnect: async function() {
      let self = this;
      self.storage.products =
        await self.productConnector.getAllAsync(self.general);
    }
  }
};
</script>

<style>
</style>
