var BSAPIModelStoreCreator = require('./BSAPIModelStoreCreator');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = BSAPIModelStoreCreator.create({
    getFunc: BSAPIUtils.getAccount,
    receiveActionType: ActionTypes.RECEIVE_ACCOUNT,
    modelId: 'BuyerAccountUuid'
});