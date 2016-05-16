var React = require('react');
var Link = require('react-router').Link;
var LoginStore = require('../stores/LoginStore');

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
        if (this.state.username != '') {
            loginText = 'Logged in as ' + this.state.username;
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
                            <li>
                                <Link activeClassName="active" to="/campaign">Campaigns</Link>
                            </li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">
                            <li>
                                <Link activeClassName="active" to='/login'>{loginText}</Link>
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