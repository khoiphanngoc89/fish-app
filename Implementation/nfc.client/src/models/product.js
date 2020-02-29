export default {
    initModel: function() {
        return {
            id: 0,
            name: null,
            description: null,
            price: 0,
            promotionPrice: 0,
            iamge1: null,
            image2: null,
            image3: null,
            image4: null
        }
    },
    initGeneral: function() {
        return {
            total: 200,
            number: 1,
            size: 30,
            getLatest: false,
            order: ''
        }
    },
    initStorage: function() {
        return {
            products: []
        }
    }
}