var React = require('react');
var ReactRouter = require('react-router');
var stores = require('../stores/stores');
var LoginStore = require('../stores/LoginStore');

function getStateFromStores() {
    return {
        currentCampaign: stores.Campaign.current(),
        currentStrategy: stores.Strategy.current(),
        isExpired: LoginStore.getAccessToken() === ''
    };
}

var Campaigns = React.createClass({

    getInitialState: function() {
        return getStateFromStores();
    },

    componentDidMount: function() {
        stores.Campaign.addListeners(this._onChange, null);
        stores.Strategy.addListeners(this._onChange, null);
        LoginStore.addExpiredListener(this._onChange);
        // If we have entities in the URL, attempt to load them
        if ('CampaignUuid' in this.props.params) {
            stores.Campaign.setCurrent(this.props.params.CampaignUuid);
        }
        if ('StrategyUuid' in this.props.params) {
            stores.Strategy.setCurrent(this.props.params.StrategyUuid);
        }
    },

    componentWillUnmount: function() {
        stores.Campaign.removeListeners(this._onChange, null);
        stores.Strategy.removeListeners(this._onChange, null);
        LoginStore.removeExpiredListener(this._onChange);
    },

    render: function() {
        if (this.state.isExpired) {
            return (
                <p>
                    Session expired; please <ReactRouter.Link to='/login'>log in</ReactRouter.Link> again.
                </p>
            );
        }
        var campaignLink = null;
        var strategyLink = null;
        if (this.state.currentCampaign !== null) {
            var campaignUrl = `/campaign/${this.state.currentCampaign.CampaignUuid}`;
            campaignLink = (
                <li>
                    <ReactRouter.IndexLink activeClassName="active" to={campaignUrl}>
                        Campaign: {this.state.currentCampaign.CampaignName}
                    </ReactRouter.IndexLink>
                </li>
            );
            if (this.state.currentStrategy !== null) {
                strategyLink = (
                    <li>
                        <ReactRouter.IndexLink activeClassName="active"
                                               to={`${campaignUrl}/strategy/${this.state.currentStrategy.StrategyUuid}`}>
                            Strategy: {this.state.currentStrategy.StrategyName}
                        </ReactRouter.IndexLink>
                    </li>
                );
            }
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
                    {strategyLink}
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