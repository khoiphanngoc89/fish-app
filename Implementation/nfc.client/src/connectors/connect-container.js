import productConnector from './product-connector';
import menuConnector from './menu-connector';
import homeConnector, { HomeInterface } from './home-connector';
import { PRODUCT, HOME, MENU } from './connect-types';

const ConnectorInterface = {
    getAllAsync() {},
    getByIdAsync() {},
    addAsync() {},
    updateAsync() {},
    deleteAsync() {},
  };

const connectors = { product: productConnector, menu: menuConnector, home: homeConnector };

function bind(repositoryName, Interface) {
  return {
    ...Object.keys(Interface).reduce((prev, method) => {
      const resolveableMethod = async(...args) => {
        const connector = await connectors[repositoryName];
        return connector[method](...args);
      };
      return { ...prev, [method]: resolveableMethod };
    }, {})
  };
}

// This is the place where you set up all
// of your dependencies. You can switch
// repositories or change the implementation
// details of a repository without having to
// touch all of the components which use it.
export default {
    productConnector: bind(PRODUCT, ConnectorInterface),
    menuConnector: bind(MENU, ConnectorInterface),
    homeConnector: bind(HOME, HomeInterface)
  };