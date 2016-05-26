var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = {

    createLogin: function(username, password) {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN,
            username: username,
            password: password
        });
    },

    success: function(accessToken) {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN_SUCCESS,
            accessToken: accessToken
        });
    },

    failure: function() {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN_FAILURE
        });
    },

    expired: function() {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN_EXPIRED
        });
    }

};