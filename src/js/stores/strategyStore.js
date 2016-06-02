var BSAPIModelStoreCreator = require('./BSAPIModelStoreCreator');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = BSAPIModelStoreCreator.create({
    getFunc: BSAPIUtils.getStrategy,
    receiveActionType: ActionTypes.RECEIVE_STRATEGY,
    patchActionType: ActionTypes.PATCH_STRATEGY,
    modelId: 'StrategyUuid'
});