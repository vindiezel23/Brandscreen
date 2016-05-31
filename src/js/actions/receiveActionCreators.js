var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');

module.exports = {

    receive: function(response, actionType) {
        BSAPIAppDispatcher.dispatch({type: actionType, response: response});
    },

    patchedField: function(actionType, name) {
        BSAPIAppDispatcher.dispatch({type: actionType, name: name});
    }

};