<template>
  <section>
    <slider/>
    <product-item/>
  </section>
</template>

<script>
export default {
  components: {
    'slider': () => import("@/components/external/slider"),
    'product-item': () => import("@/components/external/product-item"),
  }
}
</script>

<style></style>
