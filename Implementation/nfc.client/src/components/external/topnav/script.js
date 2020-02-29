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