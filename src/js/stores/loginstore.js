var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var EventEmitter = require('events').EventEmitter;
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIAuthUtils = require('../utils/BSAPIAuthUtils');
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var LOGIN_EVENT = 'login';

var _accessToken = null;

var LoginStore = assign({}, EventEmitter.prototype, {

    emitLogin: function() {
        this.emit(LOGIN_EVENT);
    },

    addLoginListener: function(callback) {
        this.on(LOGIN_EVENT, callback);
    },

    removeLoginListener: function(callback) {
        this.removeListener(LOGIN_EVENT, callback);
    },

    getAccessToken: function() {
        if (_accessToken === null) {
            return '';
        }
        return _accessToken;
    }

});

LoginStore.dispatchToken = BSAPIAppDispatcher.register(function(action) {

    switch(action.type) {

        case ActionTypes.LOGIN:
            BSAPIAuthUtils.authenticate(action.username, action.password);
            break;

        case ActionTypes.LOGIN_SUCCESS:
            _accessToken = action.response.access_token;
            LoginStore.emitLogin();
            break;

        default:
        // do nothing
    }

});

module.exports = LoginStore;