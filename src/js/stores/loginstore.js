var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var EventEmitter = require('events').EventEmitter;
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIAuthUtils = require('../utils/BSAPIAuthUtils');
var LoginActionCreators = require('../actions/LoginActionCreators');
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var LOGIN_EVENT = 'login';
var EXPIRED_EVENT = 'expired';

// Cache username and access token in localstorage
var _accessToken = localStorage.getItem('bsapi_react.accessToken') || '';
var _username = localStorage.getItem('bsapi_react.username') || '';

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
            localStorage.setItem('bsapi_react.username', _username);
            BSAPIAuthUtils.authenticate(action.username, action.password);
            break;

        case ActionTypes.LOGIN_SUCCESS:
            _accessToken = action.accessToken;
            localStorage.setItem('bsapi_react.accessToken', _accessToken);
            LoginStore.emitLogin();
            break;

        case ActionTypes.LOGIN_FAILURE:
            _username = action.username;
            localStorage.setItem('bsapi_react.username', _username);
            _accessToken = '';
            localStorage.setItem('bsapi_react.accessToken', _accessToken);
            LoginStore.emitLogin();
            break;

        case ActionTypes.LOGIN_EXPIRED:
            _accessToken = '';
            localStorage.setItem('bsapi_react.accessToken', _accessToken);
            LoginStore.emitExpired();
            break;

        default:
        // do nothing
    }

});

module.exports = LoginStore;

// If we have a cached access token, fake a logged in event
if (_accessToken !== '') {
    setTimeout(function() {
        LoginActionCreators.success(_accessToken);
    }, 1000);
}