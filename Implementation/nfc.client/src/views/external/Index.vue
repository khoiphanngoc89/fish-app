<template>
  <section>
    <slider/>
    <product-item/>
  </section>
</template>

<script>
export default {
  components: {
    'slider': () => import("@/components/external/sliderbar/Index.vue"),
    'product-item': () => import("@/components/external/product/Index.vue"),
  }
}
</script>

<style></style>
