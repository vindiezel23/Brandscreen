var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIUtils = require('../utils/BSAPIUtils');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');
var models = require('../models/models.js');
var BSAPIConstants = require('../constants/BSAPIConstants');

// Create a store for each model
var stores = {};
for (var key in models) {
    stores[key] = createStore(models[key]);
}

function createStore(model) {
    var CHANGE_EVENT = 'change';
    var PATCH_EVENT = 'patch';
    var ActionTypes = BSAPIConstants.ActionTypes;

    var store = assign({}, EventEmitter.prototype, {

        // UUID to item
        _items: {},
        _currentId: null,

        emitChange: function() {
            this.emit(CHANGE_EVENT);
        },

        emitPatch: function(name) {
            this.emit(PATCH_EVENT, name);
        },

        addListeners: function(changeCallback, patchCallback) {
            if (changeCallback) {
                this.on(CHANGE_EVENT, changeCallback);
            }
            if (patchCallback) {
                this.on(PATCH_EVENT, patchCallback);
            }
        },

        removeListeners: function(changeCallback, patchCallback) {
            if (changeCallback) {
                this.removeListener(CHANGE_EVENT, changeCallback);
            }
            if (patchCallback) {
                this.removeListener(PATCH_EVENT, patchCallback);
            }
        },

        get: function(id) {
            this._currentId = id;
            if (!(id in this._items)) {
                BSAPIUtils.get(model, id);
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
                    BSAPIUtils.get(model, store._currentId);
                }
                break;

            case ActionTypes.LOGIN_FAILURE:
                store._items = {};
                store.emitChange();
                break;

            case 'RECEIVE_' + model.name:
                store._items[action.response[model.modelId]] = action.response;
                store.emitChange();
                break;

            case 'PATCH_' + model.name:
                store.emitPatch(action.name);
                break;

            default:
            // do nothing
        }

    });

    return store;
}

module.exports = stores;