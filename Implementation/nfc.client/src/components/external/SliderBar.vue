<template>
  <b-carousel id="slider" :indicator-inside="false">
    <b-carousel-item v-for="(item, i) in 6" :key="i">
      <section>
        <div class="hero-body" :style="setupBackground(i)">
          <b-button class="shopping-btn">Shop now</b-button>
          <div class="des-container"><span>Description</span></div>
        </div>
      </section>
    </b-carousel-item>
    <template slot="indicators" slot-scope="props">
      <span class="al image">
        <img :src="getImgUrl(props.i)" :title="props.i" />
      </span>
    </template>
  </b-carousel>
</template>

<script>
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
    loadDataAsync: async function() {
      let self = this;
      self.storage.products = await self.productConnector.getHighlightAsync();
    },
    getImgUrl: function(value) {
      return `https://picsum.photos/id/43${value}/1230/500`;
    },
    setupBackground: function(value) {
      return `background-image: url(${this.getImgUrl(value)}); background-repeat: no-repeat; background-size: cover;`;
    }
  }
}
</script>
<style lang="scss">
#slider {
  .hero-body {
    height: 60vh;
  }
}
</style>
<style lang="scss" scoped>
@mixin element-position() {
  position: absolute;
  bottom: 3rem;
}
.is-active {
  .al {
    img {
      filter: grayscale(0%);
    }
  }
}
.al {
  img {
    filter: grayscale(100%);
  }
}
.shopping-btn {
  @include element-position();
  left: 3rem;
}
.des-container {
  @include element-position();
  right: 3rem;
  color: #fff;
  background-color: #111;
  background: rgba(0, 0, 0, 0.6);
  padding: 10px;
  border-radius: 4px;
}
</style>
