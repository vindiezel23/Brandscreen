var React = require('react');
var Navbar = require('./Navbar.react');
var LoginActionCreators = require('../actions/LoginActionCreators');
var LoginStore = require('../stores/LoginStore');

var BSAPIApp = React.createClass({

    componentDidMount: function() {
        // If we have a cached access token, fake a logged in event
        if (LoginStore.getAccessToken() !== '') {
            LoginActionCreators.success(LoginStore.getAccessToken());
        }
    },

    render: function() {
        return (
            <div>
                <Navbar />
                <div className="container">
                    <div className="row">
                        {this.props.children}
                    </div>
                </div>
            </div>
        );
    }

});

module.exports = BSAPIApp;