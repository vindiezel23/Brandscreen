var React = require('react');
var Link = require('react-router').Link;
var LoginStore = require('../stores/LoginStore');
var CampaignStore = require('../stores/CampaignStore');

var Navbar = React.createClass({

    getInitialState: function() {
        return {username: ''};
    },

    componentDidMount: function() {
        LoginStore.addLoginListener(this._onLogin);
        LoginStore.addExpiredListener(this._onLogin);
    },

    componentWillUnmount: function() {
        LoginStore.removeLoginListener(this._onLogin);
        LoginStore.removeExpiredListener(this._onLogin);
    },

    render: function() {
        var loginText = 'Login';
        var loginLinkClass = 'active';
        if (this.state.username != '') {
            loginText = 'Logged in as ' + this.state.username;
            loginLinkClass = '';
        }
        var campaignLink = (<a href="#">Campaign</a>);
        var currentCampaign = CampaignStore.current();
        if (currentCampaign !== null) {
            campaignLink = (
                <Link to={`/campaign/${currentCampaign.CampaignUuid}`}>
                    Campaign: {currentCampaign.CampaignName}
                </Link>
            );
        }
        return (
            <nav className="navbar navbar-default navbar-static-top">
                <div className="container">
                    <div className="navbar-header">
                        <Link className="navbar-brand" to="/">
                            Brandscreen API React Demo
                        </Link>
                    </div>
                    <div id="navbar" className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            {/* TODO: dynamic active class */}
                            {/* TODO: react router links */}
                            <li className="active"><Link to="/">Home</Link></li>
                            <li className="active">{campaignLink}</li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">
                            <li className={loginLinkClass}>
                                <Link to='/login'>{loginText}</Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    },

    _onLogin: function() {
        if (LoginStore.getAccessToken() === '') {
            this.setState({username: ''});
        } else {
            this.setState({username: LoginStore.getUsername()});
        }
    }

});

module.exports = Navbar;