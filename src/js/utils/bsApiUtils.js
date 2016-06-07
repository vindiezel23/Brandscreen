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

    get: function(model, id, params) {
        var url = BSAPIConstants.url + 'api/' + model.path + '/' + id;
        get(url, params, 'RECEIVE_' + model.name);
    },

    patch: function(model, id, name, value) {
        patch(model.path, id, name, value, 'PATCH_' + model.name);
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