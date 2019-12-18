import Badge from "../components/shared/Badge";
import BaseAlert from "../components/shared/BaseAlert";
import BaseButton from "../components/shared/BaseButton";
import BaseCheckbox from "../components/shared/BaseCheckbox";
import BaseInput from "../components/shared/BaseInput";
import BaseDropdown from "../components/shared/BaseDropdown";
import BaseNav from "../components/shared/BaseNav";
import BasePagination from "../components/shared/BasePagination";
import BaseProgress from "../components/shared/BaseProgress";
import BaseRadio from "../components/shared/BaseRadio";
import BaseSlider from "../components/shared/BaseSlider";
import BaseSwitch from "../components/shared/BaseSwitch";
import BaseTable from "../components/shared/BaseTable";
import BaseHeader from "../components/shared/BaseHeader";
import Card from "../components/shared/Card";
import StatsCard from "../components/shared/StatsCard";
import Modal from "../components/shared/Modal";
import TabPane from "../components/shared/Tabs/TabPane";
import Tabs from "../components/shared/Tabs/Tabs";
import Loading from "../components/shared/Loading";

export default {
  install(Vue) {
    Vue.component(Badge.name, Badge);
    Vue.component(BaseAlert.name, BaseAlert);
    Vue.component(BaseButton.name, BaseButton);
    Vue.component(BaseInput.name, BaseInput);
    Vue.component(BaseNav.name, BaseNav);
    Vue.component(BaseDropdown.name, BaseDropdown);
    Vue.component(BaseCheckbox.name, BaseCheckbox);
    Vue.component(BasePagination.name, BasePagination);
    Vue.component(BaseProgress.name, BaseProgress);
    Vue.component(BaseRadio.name, BaseRadio);
    Vue.component(BaseSlider.name, BaseSlider);
    Vue.component(BaseSwitch.name, BaseSwitch);
    Vue.component(BaseTable.name, BaseTable);
    Vue.component(BaseHeader.name, BaseHeader);
    Vue.component(Card.name, Card);
    Vue.component(StatsCard.name, StatsCard);
    Vue.component(Modal.name, Modal);
    Vue.component(TabPane.name, TabPane);
    Vue.component(Tabs.name, Tabs);
    Vue.component(Loading.name, Loading);
  }
};
