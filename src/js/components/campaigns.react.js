var React = require('react');
var ReactRouter = require('react-router');
var CampaignStore = require('../stores/CampaignStore');
var StrategyStore = require('../stores/StrategyStore');
var LoginStore = require('../stores/LoginStore');

function getStateFromStores() {
    return {
        currentCampaign: CampaignStore.current(),
        currentStrategy: StrategyStore.current(),
        isExpired: LoginStore.getAccessToken() === ''
    };
}

var Campaigns = React.createClass({

    getInitialState: function() {
        return getStateFromStores();
    },

    componentDidMount: function() {
        CampaignStore.addChangeListener(this._onChange);
        LoginStore.addExpiredListener(this._onChange);
    },

    componentWillUnmount: function() {
        CampaignStore.removeChangeListener(this._onChange);
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