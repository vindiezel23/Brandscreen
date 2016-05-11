var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var CHANGE_EVENT = 'change';

// CampaignUuid to object
var _campaigns = {};
var _currentCampaignId = null;

var CampaignStore = assign({}, EventEmitter.prototype, {

    emitChange: function() {
        this.emit(CHANGE_EVENT);
    },

    addChangeListener: function(callback) {
        this.on(CHANGE_EVENT, callback);
    },

    removeChangeListener: function(callback) {
        this.removeListener(CHANGE_EVENT, callback);
    },

    get: function(id) {
        _currentCampaignId = id;
        if (!(id in _campaigns)) {
            BSAPIUtils.getCampaign(id);
            return null;
        }
        return _campaigns[id];
    },

    current: function() {
        if (_currentCampaignId !== null && _currentCampaignId in _campaigns) {
            return this.get(_currentCampaignId);
        }
        return null;
    }

});

CampaignStore.dispatchToken = BSAPIAppDispatcher.register(function(action) {

    switch(action.type) {

        case ActionTypes.LOGIN_SUCCESS:
            if (_currentCampaignId !== null) {
                BSAPIUtils.getCampaign(_currentCampaignId);
            }
            break;

        case ActionTypes.LOGIN_FAILURE:
            _campaigns = null;
            CampaignStore.emitChange();
            break;

        case ActionTypes.RECEIVE_CAMPAIGN:
            _campaigns[action.response.CampaignUuid] = action.response;
            CampaignStore.emitChange();
            break;

        default:
        // do nothing
    }

});

module.exports = CampaignStore;