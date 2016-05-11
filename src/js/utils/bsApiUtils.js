var $ = require('jquery');
var CampaignListActionCreators = require('../actions/CampaignListActionCreators');
var CampaignActionCreators = require('../actions/CampaignActionCreators');
var LoginActionCreators = require('../actions/LoginActionCreators');
var LoginStore = require('../stores/LoginStore');
var BSAPIConstants = require('../constants/BSAPIConstants');

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

    getCampaign: function(id) {
        var url = BSAPIConstants.url + 'api/campaigns/' + id + '?UserId=';
        $.ajax({
            url: url,
            headers: {'Authorization': 'Bearer ' + LoginStore.getAccessToken()}
        }).done(function(response) {
            CampaignActionCreators.receive(response);
        }).fail(function(error) {
            LoginActionCreators.expired();
        });
    }

};