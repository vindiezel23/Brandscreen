var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var CHANGE_EVENT = 'change';

var _data = null;

var CampaignListStore = assign({}, EventEmitter.prototype, {

    emitChange: function() {
        this.emit(CHANGE_EVENT);
    },

    addChangeListener: function(callback) {
        this.on(CHANGE_EVENT, callback);
    },

    removeChangeListener: function(callback) {
        this.removeListener(CHANGE_EVENT, callback);
    },

    items: function() {
        if (_data === null) {
            return [];
        }
        return _data.Data;
    },
    _get: function(key) {
        if (_data === null) {
            return null;
        }
        return _data[key];
    },
    pageSize: function() {
        return this._get('PageSize');
    },
    pageCount: function() {
        return this._get('PageCount');
    },
    pageNumber: function() {
        return this._get('PageNumber');
    }

});

CampaignListStore.dispatchToken = BSAPIAppDispatcher.register(function(action) {

    switch(action.type) {

        case ActionTypes.LOGIN_SUCCESS:
            BSAPIUtils.getCampaigns();
            break;

        case ActionTypes.LOGIN_FAILURE:
            _data = null;
            CampaignListStore.emitChange();
            break;

        case ActionTypes.RECEIVE_CAMPAIGN_LIST:
            _data = action.response;
            CampaignListStore.emitChange();
            break;

        default:
        // do nothing
    }

});

module.exports = CampaignListStore;