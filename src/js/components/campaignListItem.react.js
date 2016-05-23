var ListItemCreator = require('./ListItemCreator');

module.exports = ListItemCreator.create({
    modelId: 'CampaignUuid',
    path: 'campaign',
    columns: ['CampaignName']
});