import productConnector, {ProductInterface} from './product-connector';
import menuConnector from './menu-connector';
import { PRODUCT, MENU } from './connect-types';

const ConnectorInterface = {
    getAllAsync() {},
    getByIdAsync() {},
    addAsync() {},
    updateAsync() {},
    deleteAsync() {},
  };

const connectors = { product: productConnector, menu: menuConnector };

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
    productConnector: bind(PRODUCT, ProductInterface),
    menuConnector: bind(MENU, ConnectorInterface),
  };