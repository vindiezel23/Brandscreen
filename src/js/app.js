var BSAPIApp = require('./components/BSAPIApp.react');
window.$ = window.jQuery = require('jquery');
require('bootstrap');
var React = require('react');
var ReactDOM = require('react-dom');
window.React = React; // export for http://fb.me/react-devtools
var ReactRouter = require('react-router');
var LoginForm = require('./components/LoginForm.react');
var Campaigns = require('./components/Campaigns.react');
var CampaignList = require('./components/CampaignList.react');
var Campaign = require('./components/Campaign.react');
var Strategy = require('./components/Strategy.react');

ReactDOM.render((
    <ReactRouter.Router history={ReactRouter.hashHistory}>
        <ReactRouter.Route path="/" component={BSAPIApp}>
            <ReactRouter.IndexRoute component={Campaigns} />
            <ReactRouter.Route path="login" component={LoginForm} />
            <ReactRouter.Route path="campaign" component={Campaigns}>
                <ReactRouter.IndexRoute component={CampaignList} />
                <ReactRouter.Route path=":CampaignUuid">
                    <ReactRouter.IndexRoute component={Campaign} />
                    <ReactRouter.Route path="strategy/:StrategyUuid" component={Strategy} />
                </ReactRouter.Route>
            </ReactRouter.Route>
        </ReactRouter.Route>
    </ReactRouter.Router>
), document.getElementById('react'));