import "@/assets/vendor/nucleo/css/nucleo.css";
import "@/assets/scss/main.scss";
import globalComponents from "./globalComponents";
import globalDirectives from "./globalDirectives";
import SidebarPlugin from "@/components/shared/SidebarPlugin/index"
import NotificationPlugin from "@/components/shared/NotificationPlugin/index"

export default {
  install(Vue) {
    Vue.use(globalComponents);
    Vue.use(globalDirectives);
    Vue.use(SidebarPlugin);
    Vue.use(NotificationPlugin);
  }
};
