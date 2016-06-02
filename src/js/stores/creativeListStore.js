var BSAPIListStoreCreator = require('./BSAPIListStoreCreator');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = BSAPIListStoreCreator.create({
    getFunc: BSAPIUtils.getCreatives,
    receiveActionType: ActionTypes.RECEIVE_CREATIVE_LIST
});