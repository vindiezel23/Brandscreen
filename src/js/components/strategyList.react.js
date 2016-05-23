var ListCreator = require('./ListCreator');
var BSAPIUtils = require('../utils/BSAPIUtils');

module.exports = ListCreator.create({
    store: require('../stores/StrategyListStore'),
    listItemComponent: require('./StrategyListItem.react'),
    modelId: 'StrategyUuid',
    emptyMessage: 'No strategies',
    getFunc: BSAPIUtils.getStrategies,
    headers: ['Strategy Name', 'Media Type', 'Flight Type']
});