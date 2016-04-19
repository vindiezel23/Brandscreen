var _store = require('../stores/CampaignListStore');
var LoginActionCreators = require('../actions/LoginActionCreators');
var CampaignListItem = require('../components/CampaignListItem.react');
var Pagination = require('../components/Pagination.react');
var BSAPIUtils = require('../utils/BSAPIUtils');
var React = require('react');

function getStateFromStores() {
    return {
        campaigns: _store.items()
    };
}

function getCampaignItem(campaign) {
    return (
        <CampaignListItem key={campaign.CampaignUuid} campaign={campaign} />
    );
}

var CampaignList = React.createClass({

    getInitialState: function() {
        return getStateFromStores();
    },

    componentDidMount: function() {
        _store.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        _store.removeChangeListener(this._onChange);
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
                  <Pagination store={_store} getFunc={BSAPIUtils.getCampaigns} />
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