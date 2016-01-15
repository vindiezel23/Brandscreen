var CampaignListStore = require('../stores/CampaignListStore');
var LoginActionCreators = require('../actions/LoginActionCreators');
var React = require('react');

function getStateFromStores() {
  return {
    campaigns: CampaignListStore.get()
  };
}

function getCampaignItem(campaign) {
  return (
    <tr>
      <td>
        <a href="foobar">Hello world</a>
      </td>
    </tr>
  );
}

var CampaignList = React.createClass({

  getInitialState: function() {
    return getStateFromStores();
  },

  componentDidMount: function() {
    CampaignListStore.addChangeListener(this._onChange);
  },

  componentWillUnmount: function() {
    CampaignListStore.removeChangeListener(this._onChange);
  },

  render: function() {
    var emptyElement;
    var tableElement;
    if (this.state.campaigns.length === 0) {
      emptyElement = (<p>No Campaigns</p>);
    } else {
      var campaignItems = this.state.campaigns.map(getCampaignItem);
      tableElement = (
        <div>
          <table className="table table-striped">
            <tbody>
              {campaignItems}
            </tbody>
          </table>
          // TODO: pagination
        </div>
      );
    }
    return (
      <div>
        {emptyElement}
        <div className="pull-right">
          <input className="form-control" type="text" placeholder="Search" />
        </div>
        {tableElement}
      </div>
    );
  },

  _onChange: function(event, value) {
    this.setState(getStateFromStores());
  }
});

module.exports = CampaignList;