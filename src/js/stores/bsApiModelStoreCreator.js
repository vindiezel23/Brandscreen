var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var CHANGE_EVENT = 'change';
var PATCH_EVENT = 'patch';

module.exports = {
    // Create a model store that uses BSAPI
    // Options:
    // - getFunc
    // - receiveActionType
    // - patchActionType
    // - modelId
    create: function(options) {
        var store = assign({}, EventEmitter.prototype, {

            // UUID to item
            _items: {},
            _currentId: null,

            emitChange: function() {
                this.emit(CHANGE_EVENT);
            },

            addChangeListener: function(callback) {
                this.on(CHANGE_EVENT, callback);
            },

            removeChangeListener: function(callback) {
                this.removeListener(CHANGE_EVENT, callback);
            },

            emitPatch: function(name) {
                this.emit(PATCH_EVENT, name);
            },

            addPatchListener: function(callback) {
                this.on(PATCH_EVENT, callback);
            },

            removePatchListener: function(callback) {
                this.removeListener(PATCH_EVENT, callback);
            },

            get: function(id) {
                this._currentId = id;
                if (!(id in this._items)) {
                    options.getFunc(id);
                    return null;
                }
                return this._items[id];
            },

            current: function() {
                if (this._currentId !== null && this._currentId in this._items) {
                    return this.get(this._currentId);
                }
                return null;
            },

            setCurrent: function(id) {
                if (this._currentId === null) {
                    this.get(id);
                }
            }

        });

        store.dispatchToken = BSAPIAppDispatcher.register(function(action) {

            switch(action.type) {

                case ActionTypes.LOGIN_SUCCESS:
                    if (store._currentId !== null) {
                        options.getFunc(store._currentId);
                    }
                    break;

                case ActionTypes.LOGIN_FAILURE:
                    store._items = {};
                    store.emitChange();
                    break;

                case options.receiveActionType:
                    store._items[action.response[options.modelId]] = action.response;
                    store.emitChange();
                    break;

                case options.patchActionType:
                    store.emitPatch(action.name);
                    break;

                default:
                // do nothing
            }

        });

        return store;
    }
};