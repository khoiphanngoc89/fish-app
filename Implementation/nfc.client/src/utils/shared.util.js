export default {
    deepClone(obj) {
        return JSON.parse(JSON.stringify(obj));
    },
    shallowClone(obj) {
        return Object.assign({}, obj)
    }, 
    getAuthenAPIInfo: function (data) {
        if (data.hasError)
            throw Error(data.Errors[0]);

        let info = data.result;
        return {
            token: info.token,
            user: {
                id: info.id,
                firstName: info.firstName,
                lastName: info.lastName,
                email: info.email
            }
        };
    },
    getAPIData: function(data) {
        if (data.hasError)
            throw Error(data.Errors[0]);
        return data.result;
    },
    resolveImg: function(imagePath) {
        return imagePath ? imagePath : 'http://placehold.it/700x400';
    },
    hasChanged(nowObj, cachedObj) {
        return JSON.stringify(nowObj) !== JSON.stringify(cachedObj);
    }
}