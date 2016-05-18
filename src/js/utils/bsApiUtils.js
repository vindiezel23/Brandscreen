var $ = require('jquery');
var CampaignListActionCreators = require('../actions/CampaignListActionCreators');
var ReceiveActionCreators = require('../actions/ReceiveActionCreators');
var LoginActionCreators = require('../actions/LoginActionCreators');
var LoginStore = require('../stores/LoginStore');
var BSAPIConstants = require('../constants/BSAPIConstants');

var ActionTypes = BSAPIConstants.ActionTypes;

// Parameters
// - path (i.e. GET url/api/<path>)
// - actionType
function getModelFunc(options) {
    return function(id) {
        var url = BSAPIConstants.url + 'api/' + options.path + '/' + id + '?UserId=';
        $.ajax({
            url: url,
            headers: {'Authorization': 'Bearer ' + LoginStore.getAccessToken()}
        }).done(function(response) {
            ReceiveActionCreators.receive(response, options.actionType);
        }).fail(function(error) {
            if (error.status === 401) {
                LoginActionCreators.expired();
            } else {
                console.log(error);
            }
        });
    };
}

module.exports = {

    getCampaigns: function(pageNumber) {
        var url = BSAPIConstants.url + 'api/campaigns?PageNumber=' + pageNumber +
            '&UserId=';
        $.ajax({
            url: url,
            headers: {'Authorization': 'Bearer ' + LoginStore.getAccessToken()}
        }).done(function(response) {
            CampaignListActionCreators.receive(response);
        }).fail(function(error) {
            LoginActionCreators.expired();
        });
    },

    getCampaign: getModelFunc({
        path: 'campaigns', actionType: ActionTypes.RECEIVE_CAMPAIGN
    }),
    getBrand: getModelFunc({
        path: 'brands', actionType: ActionTypes.RECEIVE_BRAND
    }),
    getAccount: getModelFunc({
        path: 'accounts', actionType: ActionTypes.RECEIVE_ACCOUNT
    })

};