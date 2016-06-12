var ModelFormCreator = require('./ModelFormCreator');
var models = require('../models/models');
var Spinner = require('./Spinner.react');
var StrategyList = require('./lists.react').Strategy;

var model = models.Campaign;

module.exports = ModelFormCreator.create({
    model: model,
    otherModels: {brand: models.Brand, account: models.Account},
    renderFunc: function(component) {
        var item = component.state.item;
        var brandName = (<Spinner />);
        if (component.state.brand !== null) {
            brandName = component.state.brand.BrandName;
        }
        var currencyCode = (<Spinner />);
        if (component.state.account !== null) {
            currencyCode = component.state.account.CurrencyCode;
        }
        return (
            <div>
                <h2>{item.CampaignName}</h2>
                <h3>Strategies</h3>
                <StrategyList params={{CampaignUuid: item[model.modelId]}}
                              urlPrefix={`/${model.route}/${item[model.modelId]}`} />
                <h3>Campaign Details</h3>
                <form className="form-horizontal" role="form">
                    {component._inputField({
                        name: 'CampaignName', label: 'Campaign Name'
                    })}
                    {component._inputField({
                        name: 'AgencyReference', label: 'Agency Reference'
                    })}
                    {component._inputField({
                        name: 'Margin', label: 'Margin', type: 'number',
                        min: 0, max: 1, step: 0.01
                    })}
                    {component._staticField({label: 'Brand', value: brandName})}
                    {component._inputField({
                        name: 'BudgetAmount', label: 'Budget', type: 'number', min: 0,
                        fieldAddon: currencyCode
                    })}
                </form>
            </div>
        );
    }
});