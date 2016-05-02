var BSAPIApp = require('./components/BSAPIApp.react');
window.$ = window.jQuery = require('jquery');
require('bootstrap');
var React = require('react');
var ReactDOM = require('react-dom');
window.React = React; // export for http://fb.me/react-devtools
var ReactRouter = require('react-router');
var LoginForm = require('./components/LoginForm.react');
var CampaignList = require('./components/CampaignList.react');

ReactDOM.render((
    <ReactRouter.Router history={ReactRouter.hashHistory}>
        <ReactRouter.Route path="/" component={BSAPIApp}>
            <ReactRouter.IndexRoute component={CampaignList} />
            <ReactRouter.Route path="login" component={LoginForm} />
        </ReactRouter.Route>
    </ReactRouter.Router>
), document.getElementById('react'));