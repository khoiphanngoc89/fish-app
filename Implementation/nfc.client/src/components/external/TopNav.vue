<template>
  <div class="container">
    <b-navbar id="top-nav">
      <template slot="brand">
        <b-navbar-item tag="router-link" :to="{ path: '/' }">
          <img
            src="@/assets/img/logo.png"
            alt="Lightweight UI components for Vue.js based on Bulma"
          />
        </b-navbar-item>
      </template>
      <template slot="start">
        <b-navbar-item href="#">
          <b-icon icon="home" />
          <embed/>
          <span class="home-nav">Home</span>
        </b-navbar-item>
        <b-navbar-dropdown label="Fish">
          <b-navbar-item href="#">About</b-navbar-item>
          <b-navbar-item href="#">Contact</b-navbar-item>
        </b-navbar-dropdown>
        <b-navbar-dropdown label="Policy">
          <b-navbar-item href="#">About</b-navbar-item>
          <b-navbar-item href="#">Contact</b-navbar-item>
        </b-navbar-dropdown>
        <b-navbar-item href="#">Contact Us</b-navbar-item>
      </template>

      <template slot="end">
        <b-navbar-item tag="div">
          <div class="buttons">
            <b-button class="is-light none-btn">
               <b-icon icon="magnify" />
            </b-button>
            <b-button class="is-light none-btn">
              <div>
                <b-icon icon="cart" />
               <span class="badge badge-pill badge-danger center-position">7</span>
              </div>
               
            </b-button>
             <b-button class="is-light none-btn">
               <b-icon icon="login" />
               
            </b-button> 
          </div>
        </b-navbar-item>
      </template>
    </b-navbar>
  </div>
</template>

<script>
import { MENU_CONNECTOR } from '@/connectors/connect-types.js';
import vm from '@/models/menu';
export default {
  inject: [MENU_CONNECTOR],
  data() {
    return {
      storage: vm.initStorage()
    }
  },
  async created() {
    let self = this;
    await self.loadDataAsync();
  },
  methods: {
    loadDataAsync: async function() {
      let self = this;
      self.storage.menus = await self.menuConnector.getAllAsync();
    }
  }
  
}
</script>

<style lang="scss" scoped>
.center-position {
  vertical-align: super;
}
.none-btn {
  border: none;
  background-color: transparent;
}
.home-nav {
  display: none;
}

@media screen and (max-width: 1021px){
  .home-nav {
    display: inline;
  }
}
</style>
