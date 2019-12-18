import Toasted from 'vue-toasted';
import Vue from 'vue'

const options = {
    position: 'top-right',
    theme: 'toasted-primary'
}


Vue.use(Toasted, options);

export const SHOW_ERROR = 'ShowError';
export const SHOW_SUCCESS = 'ShowSuccess';
export const SHOW_WARNING = 'ShowWarning';

const op_error = {
    type: 'error',
    iconPack: 'mdi',
    icon: 'alert-circle',
    duration: 3000
  };

const op_success = {
    type: 'success',
    iconPack: 'mdi',
    icon: 'check',
    duration: 3000
  };

const op_warn = {
    iconPack: 'mdi',
    icon: 'alert',
    duration: 3000,
    className: '.bg-warning'
  };

// register the toast with the custom message
Vue.toasted.register(SHOW_ERROR,
  (payload) => {
    return payload.message;
  },
  op_error
)

Vue.toasted.register(SHOW_SUCCESS,
  (payload) => {
    return payload.message;
  },
  op_success
)

Vue.toasted.register(SHOW_WARNING,
  (payload) => {
    return payload.message;
  },
  op_warn
)
