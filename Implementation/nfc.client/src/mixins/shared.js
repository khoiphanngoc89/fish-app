import { DOT, REQUIRE } from '@/utils/constants/shared.constant';
import { SHOW_ERROR, SHOW_SUCCESS, SHOW_WARNING } from '@/plugins/vue-toasted';
import EventBus from '@/plugins/event-bus';
import { BUSY_INDICATOR_EVENT } from '@/utils/constants/event-bus.constant';
export default {
    data() {
        return {
            root: null,
        }
    },
    methods: {
        getLabel: function(key, isRequired = false) {
            let self = this;
            let msg = key.includes(DOT) ? self.$t(key) : self.$t(`${self.root}${key}`);
            return isRequired ? msg + REQUIRE : msg;
        },
        showSuccess(msg) {
            this.show(SHOW_SUCCESS, msg)
        },
        showError(msg) {
            this.show(SHOW_ERROR, msg)
        },
        showWarning(msg) {
            this.show(SHOW_WARNING, msg)
        },
        show(type, msg) {
            this.$toasted.global[type]({
                message: msg
            });
        },
        onBusyIndicator() {
            EventBus.$emit(BUSY_INDICATOR_EVENT, true)
        },
        offBusyIndicator() {
            EventBus.$emit(BUSY_INDICATOR_EVENT, false)
        }
    }
}