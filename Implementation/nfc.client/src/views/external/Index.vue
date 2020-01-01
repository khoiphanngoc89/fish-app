<template>
  <section>
    <slider/>
    <product-item/>
  </section>
</template>

<script>
export default {
  components: {
    'slider': () => import("@/components/external/SliderBar"),
    'product-item': () => import("@/components/external/ProductItem"),
  }
}
</script>

<style></style>
