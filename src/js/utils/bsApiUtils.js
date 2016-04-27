var $ = require('jquery');
var CampaignListActionCreators = require('../actions/CampaignListActionCreators');
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
    }

};