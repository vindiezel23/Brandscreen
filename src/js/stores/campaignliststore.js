var BSAPIAppDispatcher = require('../dispatcher/BSAPIAppDispatcher');
var BSAPIConstants = require('../constants/BSAPIConstants');
var BSAPIUtils = require('../utils/BSAPIUtils');
var EventEmitter = require('events').EventEmitter;
var assign = require('object-assign');

var ActionTypes = BSAPIConstants.ActionTypes;
var CHANGE_EVENT = 'change';

var _campaigns = [];

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

    get: function() {
        return _campaigns;
    }

});

CampaignListStore.dispatchToken = BSAPIAppDispatcher.register(function(action) {

    switch(action.type) {

        case ActionTypes.LOGIN_SUCCESS:
            BSAPIUtils.getCampaigns();
            break;

        case ActionTypes.RECEIVE_CAMPAIGN_LIST:
            _campaigns = action.response.Data;
            CampaignListStore.emitChange();
            break;

        default:
        // do nothing
    }

});

module.exports = CampaignListStore;