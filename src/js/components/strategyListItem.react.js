var ListItemCreator = require('./ListItemCreator');

module.exports = ListItemCreator.create({
    modelId: 'StrategyUuid',
    path: 'strategy',
    columns: ['StrategyName', 'MediaType', 'FlightType']
});
