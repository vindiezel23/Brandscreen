var React = require('react');
var LoginForm = require('./LoginForm.react')
var CampaignList = require('./CampaignList.react')

var BSAPIApp = React.createClass({

  render: function() {
    return (
      <div className="bsapiapp">
        <LoginForm />
        <CampaignList />
      </div>
    );
  }

});

module.exports = BSAPIApp;