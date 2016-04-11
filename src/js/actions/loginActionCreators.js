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

    success: function(response) {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN_SUCCESS,
            response: response
        });
    },

    failure: function() {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.LOGIN_FAILURE
        });
    }

};