export const IConnector = {
    getAllAsync() {},
    getByIdAsync() {},
    addAsync() {},
    updateAsync() {},
    deleteAsync() {},
};

export const IProductConnector = {
    getHighlightAsync() {},
    ...IConnector
};