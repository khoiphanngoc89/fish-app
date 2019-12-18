<template>
    <b-loading :is-full-page="true" :active.sync="loading" :can-cancel="true">
        <b-icon
            pack="fas"
            icon="sync-alt"
            size="is-large"
            custom-class="fa-spin">
        </b-icon>
    </b-loading>
</template>

<script>
import EventBus from '@/plugins/event-bus';
import { BUSY_INDICATOR_EVENT } from '@/utils/constants/event-bus.constant';
    export default {
        name: "loading",
        data() {
            return {
                loading: false
            }
        },
        mounted() {
            EventBus.$on(BUSY_INDICATOR_EVENT, data => {
                this.loading = data
            })
        },
        beforeDestroy() {
            EventBus.$off(BUSY_INDICATOR_EVENT)
        }
    }
</script>