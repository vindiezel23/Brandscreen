var ListItemCreator = require('./ListItemCreator');

module.exports = ListItemCreator.create({
    modelId: 'CreativeUuid',
    path: 'creative',
    columns: ['CreativeName', 'CreativeTypeId']
});