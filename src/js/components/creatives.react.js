var React = require('react');
var ReactRouter = require('react-router');
var stores = require('../stores/stores');
var models = require('../models/models');
var LoginStore = require('../stores/LoginStore');
var Expired = require('./Expired.react');

function getStateFromStores() {
    return {
        currentCreative: stores.Creative.current(),
        isExpired: LoginStore.getAccessToken() === ''
    };
}

var Creatives = React.createClass({

    getInitialState: function() {
        return getStateFromStores();
    },

    componentDidMount: function() {
        stores.Creative.addListeners(this._onChange, null);
        LoginStore.addExpiredListener(this._onChange);
        // If we have entities in the URL, attempt to load them
        if ('CreativeUuid' in this.props.params) {
            stores.Creative.setCurrent(this.props.params.CreativeUuid);
        }
    },

    componentWillUnmount: function() {
        stores.Creative.removeListeners(this._onChange, null);
        LoginStore.removeExpiredListener(this._onChange);
    },

    render: function() {
        if (this.state.isExpired) {
            return (<Expired />);
        }
        var creativeLink = null;
        if (this.state.currentCreative !== null) {
            var creativeUrl = `/${models.Creative.route}/${this.state.currentCreative.CreativeUuid}`;
            creativeLink = (
                <li>
                    <ReactRouter.IndexLink activeClassName="active" to={creativeUrl}>
                        Creative: {this.state.currentCreative.CreativeName}
                    </ReactRouter.IndexLink>
                </li>
            );
        }
        return (
            <div>
                <ol className="breadcrumb">
                    <li>
                        <ReactRouter.IndexLink activeClassName="active"
                                               to={`/${models.Creative.route}`}>
                            Creatives
                        </ReactRouter.IndexLink>
                    </li>
                    {creativeLink}
                </ol>
                {this.props.children}
            </div>
        );
    },

    _onChange: function() {
        this.setState(getStateFromStores());
    }

});

module.exports = Creatives;