var stores = require('../stores/stores');
var React = require('react');
var Spinner = require('./Spinner.react');
var StrategyList = require('./lists.react').Strategy;
var BSAPIUtils = require('../utils/BSAPIUtils');
var models = require('../models/models.js');

var model = models.Campaign;
var store = stores.Campaign;

function getStateFromStores(id) {
    var state = {item: store.get(id)};
    if (state.item !== null) {
        state.updating = {};
        for (var key in state.item) {
            state.updating[key] = false;
        }
        state.brand = stores.Brand.get(state.item.BrandUuid);
        state.account = stores.Account.get(state.item.BuyerAccountUuid);
    }
    return state;
}

var Campaign = React.createClass({

    getInitialState: function() {
        return getStateFromStores(this.props.params[model.modelId]);
    },

    componentDidMount: function() {
        store.addListeners(this._onChange, this._onPatch);
        stores.Brand.addListeners(this._onChange, null);
        stores.Account.addListeners(this._onChange, null);
    },

    componentWillUnmount: function() {
        store.removeListeners(this._onChange, this._onPatch);
        stores.Brand.removeListeners(this._onChange, null);
        stores.Account.removeListeners(this._onChange, null);
    },

    render: function() {
        if (this.state.item === null) {
            return null;
        }
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
                <h2>{this.state.item.CampaignName}</h2>
                <h3>Strategies</h3>
                <StrategyList params={{CampaignUuid: this.props.params[model.modelId]}}
                              urlPrefix={`/${model.route}/${this.props.params[model.modelId]}`} />
                <h3>Campaign Details</h3>
                <form className="form-horizontal" role="form">
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
    // - value (optional, default this.state.item[name])
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
            value = this.state.item[options.name];
        }
        if (!('type' in options)) {
            options.type = 'text';
        }
        var min = 'min' in options ? options.min : '';
        var max = 'max' in options ? options.max : '';
        var step = 'step' in options ? options.step : '';
        var spinner;
        if (this.state.updating[options.name]) {
            spinner = (
                <div className='col-md-1'><div style={{paddingTop: "7px"}}>
                    <Spinner />
                </div></div>
            );
        }
        return (
            <div className="form-group">
                <div className="col-md-3 text-right">
                    <label htmlFor={`id-${options.name}`} className="control-label">
                        {options.label}
                    </label>
                </div>
                <div className="col-md-8">
                    <div className={fieldAddonClass}>
                        {fieldAddon}
                        <input id={`id-${options.name}`} name={options.name} value={value}
                               onChange={this._onFieldChange}
                               className="form-control validate" type={options.type}
                               min={min} max={max} step={step} />
                    </div>
                </div>
                {spinner}
            </div>
        );
    },

    // Attributes:
    // - label
    // - value (optional, default this.state.item[name])
    _staticField: function(options) {
        var value;
        if ('value' in options) {
            value = options.value;
        } else {
            value = this.state.item[options.name];
        }
        return (
            <div className="form-group">
                <div className="col-md-3 text-right">
                    <label className="control-label">{options.label}</label>
                </div>
                <div className="col-md-8">
                    <div>
                        <p className="form-control-static">{value}</p>
                    </div>
                </div>
            </div>
        );
    },

    _onChange: function() {
        this.setState(getStateFromStores(this.props.params[model.modelId]));
    },
    _onFieldChange: function(event) {
        // Update our own state
        var item = this.state.item;
        item[event.target.name] = event.target.value;
        var updating = this.state.updating;
        updating[event.target.name] = true;
        this.setState({item: item, updating: updating});
        // Update the API
        BSAPIUtils.patch(
            model, this.props.params[model.modelId],
            event.target.name, event.target.value);
    },
    _onPatch: function(name) {
        var updating = this.state.updating;
        updating[name] = false;
        this.setState({updating: updating});
    }

});

module.exports = Campaign;