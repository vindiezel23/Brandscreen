var React = require('react');
var Navbar = require('./Navbar.react')
var LoginForm = require('./LoginForm.react')
var CampaignList = require('./CampaignList.react')

var BSAPIApp = React.createClass({

    render: function() {
        return (
            <div>
                <Navbar />
                <div className="container">
                    <div className="row">
                        <div className="bsapiapp">
                            <LoginForm />
                            <CampaignList />
                        </div>
                    </div>
                </div>
            </div>
        );
    }

});

module.exports = BSAPIApp;