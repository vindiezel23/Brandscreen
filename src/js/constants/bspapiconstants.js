var keyMirror = require('keymirror');

module.exports = {

    url: 'http://stage-api.brandscreen.net/',

    ActionTypes: keyMirror({
        LOGIN: null,
        LOGIN_SUCCESS: null,
        RECEIVE_CAMPAIGN_LIST: null
    })

};