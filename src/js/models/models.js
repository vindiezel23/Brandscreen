// This file contains definitions of models
// Each model represents an API endpoint in the Brandscreen web API, and should
// result in various flux classes being created
var models = [
    {
        name: 'Account',
        modelId: 'BuyerAccountUuid',
        path: 'accounts'
    },
    {
        name: 'Brand',
        modelId: 'BrandUuid',
        path: 'brands'
    },
    {
        name: 'Campaign',
        modelId: 'CampaignUuid',
        path: 'campaigns'
    },
    {
        name: 'Strategy',
        modelId: 'StrategyUuid',
        path: 'strategies'
    }
];
var modelMap = {};
for (var i = 0; i < models.length; i++) {
    modelMap[models[i].name] = models[i];
}
module.exports = modelMap;