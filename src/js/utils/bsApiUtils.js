var $ = require('jquery');
var ReceiveActionCreators = require('../actions/ReceiveActionCreators');
var LoginActionCreators = require('../actions/LoginActionCreators');
var LoginStore = require('../stores/LoginStore');
var BSAPIConstants = require('../constants/BSAPIConstants');

var ActionTypes = BSAPIConstants.ActionTypes;

module.exports = {

    getCampaigns: getListFunc({
        path: 'campaigns', actionType: ActionTypes.RECEIVE_CAMPAIGN_LIST
    }),
    getStrategies: getListFunc({
        path: 'strategies', actionType: ActionTypes.RECEIVE_STRATEGY_LIST
    }),
    getCreatives: getListFunc({
        path: 'creatives', actionType: ActionTypes.RECEIVE_CREATIVE_LIST
    }),

    getCampaign: getModelFunc({
        path: 'campaigns', actionType: ActionTypes.RECEIVE_CAMPAIGN
    }),
    getBrand: getModelFunc({
        path: 'brands', actionType: ActionTypes.RECEIVE_BRAND
    }),
    getAccount: getModelFunc({
        path: 'accounts', actionType: ActionTypes.RECEIVE_ACCOUNT
    }),
    getStrategy: getModelFunc({
        path: 'strategies', actionType: ActionTypes.RECEIVE_STRATEGY
    }),

    patchCampaign: function(id, name, value) {
        patch('campaigns', id, name, value, ActionTypes.PATCH_CAMPAIGN);
    },
    patchStrategy: function(id, name, value) {
        patch('strategies', id, name, value, ActionTypes.PATCH_STRATEGY);
    }

};

// Parameters
// - path (i.e. GET url/api/<path>)
// - actionType
function getListFunc(options) {
    return function(params) {
        var url = BSAPIConstants.url + 'api/' + options.path;
        get(url, params, options.actionType);
    };
}

// Parameters
// - path (i.e. GET url/api/<path>)
// - actionType
function getModelFunc(options) {
    return function(id, params) {
        var url = BSAPIConstants.url + 'api/' + options.path + '/' + id;
        get(url, params, options.actionType);
    };
}

function get(url, params, actionType) {
    if (typeof params === 'undefined') {
        params = {};
    }
    params.UserId = '';
    $.ajax({
        url: url + '?' + $.param(params),
        headers: {'Authorization': 'Bearer ' + LoginStore.getAccessToken()}
    }).done(function(response) {
        ReceiveActionCreators.receive(response, actionType);
    }).fail(function(error) {
        if (error.status === 401) {
            LoginActionCreators.expired();
        } else {
            console.log(error);
        }
    });
}

function patch(path, id, name, value, actionType) {
    var url = BSAPIConstants.url + 'api/' + path + '/' + id;
    var fd = new FormData();
    fd.append(name, value);
    $.ajax({
        method: 'PATCH',
        url: url,
        data: fd,
        contentType: false,
        processData: false,
        headers: {'Authorization': 'Bearer ' + LoginStore.getAccessToken()}
    }).done(function(response) {
        ReceiveActionCreators.patchedField(actionType, name);
    }).fail(function(error) {
        if (error.status === 401) {
            LoginActionCreators.expired();
        } else {
            console.log(error);
        }
    });
}