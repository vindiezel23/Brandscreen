var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = {

    receive: function(response) {
        BSAPIAppDispatcher.dispatch({
            type: ActionTypes.RECEIVE_CAMPAIGN,
            response: response
        });
    }

};