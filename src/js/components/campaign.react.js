var CampaignStore = require('../stores/CampaignStore');
var BrandStore = require('../stores/BrandStore');
var AccountStore = require('../stores/AccountStore');
var React = require('react');
var LoginStore = require('../stores/LoginStore');
var Spinner = require('./Spinner.react');

function getStateFromStores(id) {
    var state = {campaign: CampaignStore.get(id)};
    if (state.campaign !== null) {
        //strategies
        state.brand = BrandStore.get(state.campaign.BrandUuid);
        state.account = AccountStore.get(state.campaign.BuyerAccountUuid);
    }
    return state;
}

var Campaign = React.createClass({

    getInitialState: function() {
        return getStateFromStores(this.props.params.id);
    },

    componentDidMount: function() {
        CampaignStore.addChangeListener(this._onChange);
        BrandStore.addChangeListener(this._onChange);
        AccountStore.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        CampaignStore.removeChangeListener(this._onChange);
        BrandStore.removeChangeListener(this._onChange);
        AccountStore.removeChangeListener(this._onChange);
    },

    render: function() {
        if (this.state.campaign === null) {
            return null;
        }
        var strategies = 'TODO strategies';
        /*
         <p ng-show="strategies.length === 0">No Strategies</p>
         <div ng-show="strategies.length > 0">
         <h3>Strategies for Campaign</h3>
         <table class="table table-striped">
         <tbody>
         <tr ng-repeat="strategy in strategies">
         <td>
         <a href="/c/{{campaign.CampaignUuid}}/s/{{strategy.StrategyUuid}}">
         {{strategy.StrategyName}}
         </a>
         </td>
         </tr>
         </tbody>
         </table>
         <uib-pagination total-items="campaignCtrl.totalItems"
         ng-model="currentPage" max-size="5" class="pagination-sm"
         boundary-links="true" rotate="false">
         </uib-pagination>
         </div>
         */
        var brandName = (<Spinner />);
        if (this.state.brand !== null) {
            brandName = this.state.brand.BrandName;
        }
        var currencyCode = (<Spinner />);
        if (this.state.account !== null) {
            currencyCode = this.state.account.CurrencyCode;
        }
        return (
            <div>
                <h2>{this.state.campaign.CampaignName}</h2>
                {strategies}
                <h3>Campaign Details</h3>
                <form name="campaignForm" className="form-horizontal" role="form">
                    {/* TODO: functional form */}
                    {this._inputField({name: 'CampaignName', label: 'Campaign Name'})}
                    {this._inputField({name: 'AgencyReference', label: 'Agency Reference'})}
                    {this._inputField({
                        name: 'Margin', label: 'Margin', type: 'number',
                        min: 0, max: 1, step: 0.01
                    })}
                    {this._staticField({label: 'Brand', value: brandName})}
                    {this._inputField({
                        name: 'BudgetAmount', label: 'Budget', type: 'number', min: 0,
                        fieldAddon: currencyCode
                    })}
                </form>
            </div>
        );
    },

    // Attributes:
    // - name
    // - label
    // - value (optional, default this.state.campaign[name])
    // - type (optional, default text)
    // - min (optional)
    // - max (optional)
    // - step (optional)
    // - fieldAddon (optional)
    _inputField: function(options) {
        var fieldAddonClass = '';
        var fieldAddon = '';
        if ('fieldAddon' in options) {
            fieldAddonClass = 'input-group';
            fieldAddon = (
                <span className="input-group-addon">{options.fieldAddon}</span>
            );
        }
        var value;
        if ('value' in options) {
            value = options.value;
        } else {
            value = this.state.campaign[options.name];
        }
        if (!('type' in options)) {
            options.type = 'text';
        }
        var min = 'min' in options ? options.min : '';
        var max = 'max' in options ? options.max : '';
        var step = 'step' in options ? options.step : '';
        return (
            <div className="form-group">
                <div className="col-md-3 text-right">
                    <label htmlFor="id-{options.name}" className="control-label">
                        {options.label}
                    </label>
                </div>
                <div className="col-md-9">
                    <div className={fieldAddonClass}>
                        {fieldAddon}
                        <input id="id-{options.name}" value={value}
                               className="form-control validate" type={options.type}
                               min={min} max={max} step={step} />
                    </div>
                </div>
            </div>
        );
    },

    // Attributes:
    // - label
    // - value (optional, default this.state.campaign[name])
    _staticField: function(options) {
        var value;
        if ('value' in options) {
            value = options.value;
        } else {
            value = this.state.campaign[options.name];
        }
        return (
            <div className="form-group">
                <div className="col-md-3 text-right">
                    <label className="control-label">{options.label}</label>
                </div>
                <div className="col-md-9">
                    <div>
                        <p className="form-control-static">{value}</p>
                    </div>
                </div>
            </div>
        );
    },

    _onChange: function() {
        this.setState(getStateFromStores(this.props.params.id));
    }

});

module.exports = Campaign;