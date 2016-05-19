var keyMirror = require('keymirror');

module.exports = {

    url: 'http://stage-api.brandscreen.net/',

    ActionTypes: keyMirror({
        LOGIN: null,
        LOGIN_SUCCESS: null,
        LOGIN_FAILURE: null,
        LOGIN_EXPIRED: null,
        RECEIVE_CAMPAIGN_LIST: null,
        RECEIVE_CAMPAIGN: null,
        RECEIVE_BRAND: null,
        RECEIVE_ACCOUNT: null
    })

};