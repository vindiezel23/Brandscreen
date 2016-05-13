var React = require('react');
var ReactRouter = require('react-router');
var CampaignStore = require('../stores/CampaignStore');

function getStateFromStores() {
    return {currentCampaign: CampaignStore.current()};
}

var Campaigns = React.createClass({

    getInitialState: function() {
        return getStateFromStores();
    },

    componentDidMount: function() {
        CampaignStore.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        CampaignStore.removeChangeListener(this._onChange);
    },

    render: function() {
        var campaignLink = null;
        if (this.state.currentCampaign !== null) {
            campaignLink = (
                <li>
                    <ReactRouter.Link activeClassName="active"
                                      to={`/campaign/${this.state.currentCampaign.CampaignUuid}`}>
                        Campaign: {this.state.currentCampaign.CampaignName}
                    </ReactRouter.Link>
                </li>
            );
        }
        return (
            <div>
                <ol className="breadcrumb">
                    <li>
                        <ReactRouter.IndexLink activeClassName="active" to="/campaign">
                            Campaigns
                        </ReactRouter.IndexLink>
                    </li>
                    {campaignLink}
                </ol>
                {this.props.children}
            </div>
        );
    },

    _onChange: function() {
        this.setState(getStateFromStores());
    }

});

module.exports = Campaigns;