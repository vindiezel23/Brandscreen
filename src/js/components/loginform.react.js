var LoginStore = require('../stores/LoginStore');
var LoginActionCreators = require('../actions/LoginActionCreators');
var React = require('react');
var Spinner = require('./Spinner.react');

var LoginForm = React.createClass({

    getInitialState: function() {
        return {
            username: LoginStore.getUsername(),
            password: '',
            accessToken: LoginStore.getAccessToken(),
            loggingIn: false
        };
    },

    componentDidMount: function() {
        LoginStore.addLoginListener(this._onLogin);
        LoginStore.addExpiredListener(this._onExpired);
    },

    componentWillUnmount: function() {
        LoginStore.removeLoginListener(this._onLogin);
        LoginStore.removeExpiredListener(this._onExpired);
    },

    render: function() {
        var tick;
        if (this.state.loggingIn) {
            // Show spinner if login attempt is happening
            tick = (<Spinner />);
        } else if (this.state.accessToken !== '') {
            // Otherwise, if we've logged in already, show a green tick
            tick = (
                <span className="glyphicon glyphicon-ok green-tick" aria-hidden="true">
        </span>
            );
        }
        return (
            <div className="well">
                <form>
                    <div className="form-inline">
                        <div className="form-group">
                            <label htmlFor="id-username">Username</label>
                            <input type="text" className="form-control" id="id-username"
                                   name="username" placeholder="name@brandscreen.com" required
                                   value={this.state.username} onChange={this._usernameOnChange} />
                        </div>
                        <div className="form-group">
                            <label htmlFor="id-password">Password</label>
                            <input type="password" className="form-control" id="id-password"
                                   name="password" placeholder="password" required
                                   value={this.state.password} onChange={this._passwordOnChange} />
                        </div>
                        {tick}
                    </div>
                    <div className="form-group">
                        <label htmlFor="access-token">Access Token
                            {tick}
                        </label>
                        <textarea id="access-token" name="accessTokenField" rows="6"
                                  className="form-control validate" placeholder="Access Token"
                                  value={this.state.accessToken}></textarea>
                    </div>
                </form>
            </div>
        );
    },

    _usernameOnChange: function(event, value) {
        this.setState({username: event.target.value});
        this._onChange(event);
    },
    _passwordOnChange: function(event, value) {
        this.setState({password: event.target.value});
        this._onChange(event);
    },
    _onChange: function(event) {
        if (this.state.username && this.state.password) {
            // Attempt login after short delay
            if (this.promise) {
                clearInterval(this.promise);
            }
            this.promise = setTimeout(function() {
                LoginActionCreators.createLogin(
                    this.state.username, this.state.password);
                this.setState({loggingIn: true});
            }.bind(this), 500);
        }
    },
    _onLogin: function() {
        this.setState({accessToken: LoginStore.getAccessToken(), loggingIn: false});
    },
    _onExpired: function() {
        // If login has expired, attempt to log in again
        this._onChange(null);
    }
});

module.exports = LoginForm;