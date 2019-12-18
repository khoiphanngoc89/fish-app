import Chart from 'chart.js';
import { initGlobalOptions } from "@/components/shared/Charts/config";
export default {
  mounted() {
    initGlobalOptions(Chart);
  }
}
