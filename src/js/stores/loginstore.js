var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var EventEmitter = require('events').EventEmitter;
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIAuthUtils = require('../utils/BSAPIAuthUtils');
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var LOGIN_EVENT = 'login';
var EXPIRED_EVENT = 'expired';

var _accessToken = '';
var _username = '';

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

    emitExpired: function() {
        this.emit(EXPIRED_EVENT);
    },
    addExpiredListener: function(callback) {
        this.on(EXPIRED_EVENT, callback);
    },
    removeExpiredListener: function(callback) {
        this.removeListener(EXPIRED_EVENT, callback);
    },

    getAccessToken: function() {
        if (_accessToken === null) {
            return '';
        }
        return _accessToken;
    },
    getUsername: function() {
        return _username;
    }

});

LoginStore.dispatchToken = BSAPIAppDispatcher.register(function(action) {

    switch(action.type) {

        case ActionTypes.LOGIN:
            _username = action.username;
            BSAPIAuthUtils.authenticate(action.username, action.password);
            break;

        case ActionTypes.LOGIN_SUCCESS:
            _accessToken = action.response.access_token;
            LoginStore.emitLogin();
            break;

        case ActionTypes.LOGIN_FAILURE:
            _username = action.username;
            _accessToken = '';
            LoginStore.emitLogin();
            break;

        case ActionTypes.LOGIN_EXPIRED:
            _accessToken = '';
            LoginStore.emitExpired();
            break;

        default:
        // do nothing
    }

});

module.exports = LoginStore;