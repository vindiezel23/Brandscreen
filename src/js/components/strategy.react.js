var ModelFormCreator = require('./ModelFormCreator');
var models = require('../models/models');
var Spinner = require('./Spinner.react');
var CreativeList = require('./lists.react').Creative;

var model = models.Strategy;

module.exports = ModelFormCreator.create({
    model: model,
    otherModels: {account: models.Account},
    renderFunc: function(component) {
        var currencyCode = (<Spinner />);
        if (component.state.account !== null) {
            currencyCode = component.state.account.CurrencyCode;
        }
        var percentTimeElapsed;
        // TODO: moment
        /*if (component.state.strategy.UtcStartDateTime &&
         component.state.strategy.UtcEndDateTime) {
         var start = moment(component.state.strategy.UtcStartDateTime);
         var end = moment(component.state.strategy.UtcEndDateTime);
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
        }[component.state.item.PacingStyleId];
        if (component.state.item.PacingStyleId === 2) {
            pacingStyle += ' (' + {
                    1: 'Behind',
                    2: 'Normal',
                    3: 'Ahead',
                    4: 'Aggressive'
                }[component.state.item.PacingStyleOptionId] + ')';
        } else if (component.state.item.PacingStyleId === 3 &&
            component.state.item.PacingAmount !== null) {
            pacingStyle += ' (' + component.state.item.PacingAmount + ' ' +
                currencyCode + ' per day)';
        }
        // TODO: filters
        return (
            <div>
                <h2>{component.state.item.StrategyName}</h2>
                <h3>Creatives for Strategy</h3>
                <CreativeList
                    params={{StrategyUuid: component.props.params[model.modelId]}}
                    urlPrefix={`/${models.Campaign.route}/${component.props.params[models.Campaign.modelId]}/${models.Strategy.route}/${component.props.params[models.Strategy.modelId]}`} />
                <h3>Strategy Details</h3>
                <form className="form-horizontal" role="form">
                    {component._inputField({name: 'StrategyName', label: 'Strategy Name'})}
                    {component._staticField({
                        label: 'Media Type', value: component.state.item.MediaType
                    })}
                    <h4>Activity Status</h4>
                    {component._staticField({
                        label: 'Current Status', value: component.state.item.StrategyStatus
                    })}
                    {component._staticField({
                        label: 'Last Activity',
                        value: component.state.item.UtcModifiedDateTime
                    })}
                    {component._staticField({
                        label: 'Supply Source', value: component.state.item.SupplySource
                    })}
                    <h4>Budget and Schedule</h4>
                    {component._inputField({
                        name: 'BudgetAmount', label: 'Budget', type: 'number', min: 0,
                        step: 0.01, fieldAddon: currencyCode
                    })}
                    {/* TODO: date */}
                    {component._inputField({
                        name: 'UtcStartDateTime', label: 'Start Date'
                    })}
                    {component._inputField({name: 'UtcEndDateTime', label: 'End Date'})}
                    {component._staticField({
                        label: '% Time Elapsed', value: percentTimeElapsed
                    })}
                    <h4>Price Health</h4>
                    {component._staticField({
                        label: 'Strategy Type', value: component.state.item.FlightType
                    })}
                    {component._inputField({
                        name: 'GoalTargetRate', label: 'Goal Target Rate', type: 'number',
                        min: 0, step: 0.01, fieldAddon: currencyCode
                    })}
                    {/* TODO: goal rate from name */}
                    {/* TODO: select goal type */}
                    {component._staticField({
                        label: 'Goal Type', value: component.state.item.GoalType
                    })}
                    <h4>Quantity Health</h4>
                    {component._staticField({
                        label: 'Goal Type', value: component.state.item.GoalType
                    })}
                    {component._inputField({
                        name: 'GoalTargetQuantity', label: 'Goal Target Quantity',
                        type: 'number', min: 0
                    })}
                    <h4>Other Details</h4>
                    {/* TODO: select pacing style (PacingStyleId, PacingStyleOptionId) */}
                    {component._staticField({label: 'Pacing', value: pacingStyle})}
                    {/* TODO: checkbox */}
                    {component._staticField({
                        label: 'Use Pacing (Administrator)',
                        value: component.state.item.UsePacing
                    })}
                    {component._staticField({
                        label: 'Use Pricing (Administrator)',
                        value: component.state.item.UsePricing
                    })}
                </form>
            </div>
        );
    }
});