var $ = require('jquery');
var LoginActionCreators = require('../actions/LoginActionCreators');
var BSAPIConstants = require('../constants/BSAPIConstants');

module.exports = {

    authenticate: function(username, password) {
        // Submit username/password
        $.post(BSAPIConstants.url + 'token', {
            grant_type: 'password',
            username: username,
            password: password,
            client_id: 'brandscreen'
        }).done(function(response) {
            LoginActionCreators.success(response);
        }).fail(function(error) {
            console.log('login failed', error);
        });
    }

};