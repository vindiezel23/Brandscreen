var StrategyStore = require('../stores/StrategyStore');
var AccountStore = require('../stores/AccountStore');
var React = require('react');
var Spinner = require('./Spinner.react');
var CreativeList = require('./CreativeList.react');
var BSAPIUtils = require('../utils/BSAPIUtils');

function getStateFromStores(id) {
    var state = {strategy: StrategyStore.get(id)};
    if (state.strategy !== null) {
        state.updating = {};
        for (var key in state.strategy) {
            state.updating[key] = false;
        }
        state.account = AccountStore.get(state.strategy.BuyerAccountUuid);
    }
    return state;
}

var Strategy = React.createClass({

    getInitialState: function() {
        return getStateFromStores(this.props.params.StrategyUuid);
    },

    componentDidMount: function() {
        StrategyStore.addChangeListener(this._onChange);
        StrategyStore.addPatchListener(this._onPatch);
        AccountStore.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        StrategyStore.removeChangeListener(this._onChange);
        StrategyStore.removePatchListener(this._onPatch);
        AccountStore.removeChangeListener(this._onChange);
    },

    render: function() {
        if (this.state.strategy === null) {
            return null;
        }
        var currencyCode = (<Spinner />);
        if (this.state.account !== null) {
            currencyCode = this.state.account.CurrencyCode;
        }
        var percentTimeElapsed;
        // TODO: moment
        /*if (this.state.strategy.UtcStartDateTime &&
         this.state.strategy.UtcEndDateTime) {
         var start = moment(this.state.strategy.UtcStartDateTime);
         var end = moment(this.state.strategy.UtcEndDateTime);
         var durationSeconds = moment.duration(end - start).asSeconds();
         if (durationSeconds === 0) {
         if (moment() > start) {
         percentTimeElapsed = '100%';
         } else {
         percentTimeElapsed = '0%';
         }
         } else {
         percentTimeElapsed = Math.round(Math.max(Math.min(
         moment.duration(moment() - start).asSeconds() / durationSeconds,
         1.0), 0) * 100) + '%';
         }
         }*/
        var pacingStyle = {
            1: 'As soon as possible',
            2: 'Evenly',
            3: 'Fixed'
        }[this.state.strategy.PacingStyleId];
        if (this.state.strategy.PacingStyleId === 2) {
            pacingStyle += ' (' + {
                    1: 'Behind',
                    2: 'Normal',
                    3: 'Ahead',
                    4: 'Aggressive'
                }[this.state.strategy.PacingStyleOptionId] + ')';
        } else if (this.state.strategy.PacingStyleId === 3 &&
            this.state.strategy.PacingAmount !== null) {
            pacingStyle += ' (' + this.state.strategy.PacingAmount + ' ' +
                currencyCode + ' per day)';
        }
        // TODO: filters
        return (
            <div>
                <h2>{this.state.strategy.StrategyName}</h2>
                <h3>Creatives for Strategy</h3>
                <CreativeList params={{StrategyUuid: this.props.params.StrategyUuid}}
                              urlPrefix={`/campaign/${this.props.params.CampaignUuid}/strategy/${this.props.params.StrategyUuid}`} />
                <h3>Strategy Details</h3>
                <form className="form-horizontal" role="form">
                    {this._inputField({name: 'StrategyName', label: 'Strategy Name'})}
                    {this._staticField({
                        label: 'Media Type', value: this.state.strategy.MediaType
                    })}
                    <h4>Activity Status</h4>
                    {this._staticField({
                        label: 'Current Status', value: this.state.strategy.StrategyStatus
                    })}
                    {this._staticField({
                        label: 'Last Activity',
                        value: this.state.strategy.UtcModifiedDateTime
                    })}
                    {this._staticField({
                        label: 'Supply Source', value: this.state.strategy.SupplySource
                    })}
                    <h4>Budget and Schedule</h4>
                    {this._inputField({
                        name: 'BudgetAmount', label: 'Budget', type: 'number', min: 0,
                        step: 0.01, fieldAddon: currencyCode
                    })}
                    {/* TODO: date */}
                    {this._inputField({name: 'UtcStartDateTime', label: 'Start Date'})}
                    {this._inputField({name: 'UtcEndDateTime', label: 'End Date'})}
                    {this._staticField({
                        label: '% Time Elapsed', value: percentTimeElapsed
                    })}
                    <h4>Price Health</h4>
                    {this._staticField({
                        label: 'Strategy Type', value: this.state.strategy.FlightType
                    })}
                    {this._inputField({
                        name: 'GoalTargetRate', label: 'Goal Target Rate', type: 'number',
                        min: 0, step: 0.01, fieldAddon: currencyCode
                    })}
                    {/* TODO: goal rate from name */}
                    {/* TODO: select goal type */}
                    {this._staticField({
                        label: 'Goal Type', value: this.state.strategy.GoalType
                    })}
                    <h4>Quantity Health</h4>
                    {this._staticField({
                        label: 'Goal Type', value: this.state.strategy.GoalType
                    })}
                    {this._inputField({
                        name: 'GoalTargetQuantity', label: 'Goal Target Quantity',
                        type: 'number', min: 0
                    })}
                    <h4>Other Details</h4>
                    {/* TODO: select pacing style (PacingStyleId, PacingStyleOptionId) */}
                    {this._staticField({label: 'Pacing', value: pacingStyle})}
                    {/* TODO: checkbox */}
                    {this._staticField({
                        label: 'Use Pacing (Administrator)',
                        value: this.state.strategy.UsePacing
                    })}
                    {this._staticField({
                        label: 'Use Pricing (Administrator)',
                        value: this.state.strategy.UsePricing
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
            value = this.state.strategy[options.name];
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
    // - value
    _staticField: function(options) {
        var value;
        if ('value' in options) {
            value = options.value;
        } else {
            value = this.state.strategy[options.name];
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
        this.setState(getStateFromStores(this.props.params.StrategyUuid));
    },
    _onFieldChange: function(event) {
        // Update our own state
        var strategy = this.state.strategy;
        strategy[event.target.name] = event.target.value;
        var updating = this.state.updating;
        updating[event.target.name] = true;
        this.setState({strategy: strategy, updating: updating});
        // Update the API
        BSAPIUtils.patchStrategy(
            this.props.params.StrategyUuid, event.target.name, event.target.value);
    },
    _onPatch: function(name) {
        var updating = this.state.updating;
        updating[name] = false;
        this.setState({updating: updating});
    }

});

module.exports = Strategy;