// This file contains definitions of models
// Each model represents an API endpoint in the Brandscreen web API, and should
// result in various flux classes being created
var models = [
    {
        name: 'Account',
        modelId: 'BuyerAccountUuid',
        path: 'accounts',
        route: 'a',
        columns: ['CompanyName'],
        emptyMessage: 'No accounts'
    },
    {
        name: 'Brand',
        modelId: 'BrandUuid',
        path: 'brands',
        route: 'b',
        columns: ['BrandName'],
        emptyMessage: 'No brands'
    },
    {
        name: 'Campaign',
        modelId: 'CampaignUuid',
        path: 'campaigns',
        route: 'c',
        columns: ['CampaignName'],
        emptyMessage: 'No campaigns'
    },
    {
        name: 'Strategy',
        modelId: 'StrategyUuid',
        path: 'strategies',
        route: 's',
        columns: ['StrategyName', 'MediaType', 'FlightType'],
        emptyMessage: 'No strategies',
        headers: ['Strategy Name', 'Media Type', 'Flight Type'],
        // Custom function to create URL prefix if it is not given
        urlPrefix: function(item, models) {
            var parentModel = models.Campaign;
            return parentModel.route + '/' + item[parentModel.modelId];
        }
    },
    {
        name: 'Creative',
        modelId: 'CreativeUuid',
        path: 'creatives',
        route: 'cr',
        columns: ['CreativeName', 'CreativeTypeId'],
        emptyMessage: 'No creatives',
        headers: ['Creative Name', 'Creative Type ID']  // TODO: translate ID
    }
];
var modelMap = {};
for (var i = 0; i < models.length; i++) {
    modelMap[models[i].name] = models[i];
}
module.exports = modelMap;