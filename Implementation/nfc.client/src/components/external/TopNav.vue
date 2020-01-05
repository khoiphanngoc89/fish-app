<template>
  <div class="container">
    <b-navbar id="top-nav">
      <template slot="brand">
        <template v-for="menu in storage.menus">
          <b-navbar-item v-if="menu.menuType == 0"  :key="menu.id" tag="router-link" :to="{ path: menu.url }">
            <img
              :src="`@/${menu.image}`"
              alt="Lightweight UI components for Vue.js based on Bulma"
            />
          </b-navbar-item>
        </template>
      </template>
      <template slot="start">
        <template v-for="menu in storage.menus">
          <b-navbar-item v-if="isVisible(general.menu, menu.menuType, menu.hasSub)" :key="menu.id" tag="router-link" :to="{ path: menu.url }">
            <template v-if="menu.icon">
              <b-icon :icon="menu.icon" />
              <embed/>
            </template>
            <span :class="{'home-nav': isVisibleIcon(menu.name) }">{{ menu.name }}</span>
          </b-navbar-item>
          
          <b-navbar-dropdown :label="menu.name" :key="menu.id" v-if="isVisible(general.submenu, menu.menuType, menu.hasSub)" >
            <b-navbar-item  v-for="submenu in menu.subMenus" :key="submenu.id" :href="submenu.url"> {{ submenu.name }}</b-navbar-item>
          </b-navbar-dropdown>
        </template>
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
import vm, { MENU, SUBMENU } from '@/models/menu';
export default {
  inject: [MENU_CONNECTOR],
  data() {
    return {
      storage: vm.initStorage(),
      general: vm.initGeneral()
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
    },
    isVisible: function(type, menuType, hasSubMenu) {
      let result = menuType > 0;
      switch(type) {
        case MENU:
          return result && !hasSubMenu;
        case SUBMENU:
          return result && hasSubMenu;
      }
    },
    isVisibleIcon: function(name) {
      return name.toLowerCase() == 'home';
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
