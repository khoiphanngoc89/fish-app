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
            pageNumber: 1,
            pageSize: 30,
            getLatest: false
        }
    },
    initStorage: function() {
        return {
            products: []
        }
    }

}