var ModelFormCreator = require('./ModelFormCreator');
var models = require('../models/models');
var Spinner = require('./Spinner.react');
var CreativeList = require('./lists.react').Creative;

var model = models.Strategy;

module.exports = ModelFormCreator.create({
    model: model,
    otherModels: {account: models.Account},
    renderFunc: function(component) {
        var item = component.state.item;
        var currencyCode = (<Spinner />);
        if (component.state.account !== null) {
            currencyCode = component.state.account.CurrencyCode;
        }
        var percentTimeElapsed;
        // TODO: moment
        /*if (item.UtcStartDateTime &&
         item.UtcEndDateTime) {
         var start = moment(item.UtcStartDateTime);
         var end = moment(item.UtcEndDateTime);
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
        }[item.PacingStyleId];
        if (item.PacingStyleId === 2) {
            pacingStyle += ' (' + {
                    1: 'Behind',
                    2: 'Normal',
                    3: 'Ahead',
                    4: 'Aggressive'
                }[item.PacingStyleOptionId] + ')';
        } else if (item.PacingStyleId === 3 &&
            item.PacingAmount !== null) {
            pacingStyle += ' (' + item.PacingAmount + ' ' +
                currencyCode + ' per day)';
        }
        // TODO: filters
        return (
            <div>
                <h2>{item.StrategyName}</h2>
                <h3>Creatives for Strategy</h3>
                <CreativeList params={{StrategyUuid: item[model.modelId]}}
                              urlPrefix={`/${models.Campaign.route}/${component.props.params[models.Campaign.modelId]}/${model.route}/${item[model.modelId]}`} />
                <h3>Strategy Details</h3>
                <form className="form-horizontal" role="form">
                    {component._inputField({name: 'StrategyName', label: 'Strategy Name'})}
                    {component._staticField({label: 'Media Type', value: item.MediaType})}
                    <h4>Activity Status</h4>
                    {component._staticField({
                        label: 'Current Status', value: item.StrategyStatus
                    })}
                    {component._staticField({
                        label: 'Last Activity', value: item.UtcModifiedDateTime
                    })}
                    {component._staticField({
                        label: 'Supply Source', value: item.SupplySource
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
                        label: 'Strategy Type', value: item.FlightType
                    })}
                    {component._inputField({
                        name: 'GoalTargetRate', label: 'Goal Target Rate', type: 'number',
                        min: 0, step: 0.01, fieldAddon: currencyCode
                    })}
                    {/* TODO: goal rate from name */}
                    {/* TODO: select goal type */}
                    {component._staticField({label: 'Goal Type', value: item.GoalType})}
                    <h4>Quantity Health</h4>
                    {component._staticField({label: 'Goal Type', value: item.GoalType})}
                    {component._inputField({
                        name: 'GoalTargetQuantity', label: 'Goal Target Quantity',
                        type: 'number', min: 0
                    })}
                    <h4>Other Details</h4>
                    {/* TODO: select pacing style (PacingStyleId, PacingStyleOptionId) */}
                    {component._staticField({label: 'Pacing', value: pacingStyle})}
                    {/* TODO: checkbox */}
                    {component._staticField({
                        label: 'Use Pacing (Administrator)', value: item.UsePacing
                    })}
                    {component._staticField({
                        label: 'Use Pricing (Administrator)', value: item.UsePricing
                    })}
                </form>
            </div>
        );
    }
});