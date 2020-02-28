<template>
  <section>
    <loading/>
    <section class="always-top">
      <top-nav/>
    </section>
    <section class="container">
      <fade-transition :duration="200" origin="center top" mode="out-in">
        <!-- your content here -->
        <router-view></router-view>
      </fade-transition>
      <footer-bar />
    </section>
  </section>
</template>

<script>
import { FadeTransition } from "vue2-transitions";
export default {
  components: {
    "top-nav": () => import("@/components/external/topnav/Index.vue"),
    "footer-bar": () => import("@/components/external/footerbar/Index.vue"),
    FadeTransition
  }
};

</script>

<style>
</style>