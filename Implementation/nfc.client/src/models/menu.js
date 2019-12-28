export const MENU = 'menu'
export const SUBMENU = 'submenu'

export default {
    initStorage: function() {
        return {
            menus: []
        }
    },
    initGeneral: function() {
        return {
            menu: MENU,
            submenu: SUBMENU
        }
    }
}