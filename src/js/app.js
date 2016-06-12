var BSAPIApp = require('./components/BSAPIApp.react');
window.$ = window.jQuery = require('jquery');
require('bootstrap');
var React = require('react');
var ReactDOM = require('react-dom');
window.React = React; // export for http://fb.me/react-devtools
var ReactRouter = require('react-router');
var LoginForm = require('./components/LoginForm.react');
var Campaigns = require('./components/Campaigns.react');
var CampaignList = require('./components/lists.react').Campaign;
var Campaign = require('./components/Campaign.react');
var Strategy = require('./components/Strategy.react');
var Creative = require('./components/Creative.react');
var models = require('./models/models');

ReactDOM.render((
    <ReactRouter.Router history={ReactRouter.hashHistory}>
        <ReactRouter.Route path="/" component={BSAPIApp}>
            <ReactRouter.IndexRoute component={Campaigns} />
            <ReactRouter.Route path="login" component={LoginForm} />
            <ReactRouter.Route path={models.Campaign.route} component={Campaigns}>
                <ReactRouter.IndexRoute component={CampaignList} />
                <ReactRouter.Route path={`:${models.Campaign.modelId}`}>
                    <ReactRouter.IndexRoute component={Campaign} />
                    <ReactRouter.Route
                        path={`${models.Strategy.route}/:${models.Strategy.modelId}`}>
                        <ReactRouter.IndexRoute component={Strategy} />
                        <ReactRouter.Route
                            path={`${models.Creative.route}/:${models.Creative.modelId}`}
                            component={Creative} />
                    </ReactRouter.Route>
                </ReactRouter.Route>
            </ReactRouter.Route>
        </ReactRouter.Route>
    </ReactRouter.Router>
), document.getElementById('react'));