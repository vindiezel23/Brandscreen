var keyMirror = require('keymirror');
var models = require('../models/models.js');

var actionTypes = keyMirror({
    LOGIN: null,
    LOGIN_SUCCESS: null,
    LOGIN_FAILURE: null,
    LOGIN_EXPIRED: null,
    RECEIVE_CAMPAIGN_LIST: null,
    RECEIVE_STRATEGY_LIST: null,
    RECEIVE_CREATIVE_LIST: null
});

for (var key in models) {
    actionTypes['RECEIVE_' + key] = 'RECEIVE_' + key;
    actionTypes['PATCH_' + key] = 'PATCH_' + key;
}

module.exports = {

    url: 'http://stage-api.brandscreen.net/',

    ActionTypes: actionTypes

};