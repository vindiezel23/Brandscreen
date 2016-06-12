var ModelFormCreator = require('./ModelFormCreator');
var models = require('../models/models');
var Spinner = require('./Spinner.react');
var StrategyList = require('./lists.react').Strategy;

var model = models.Creative;

module.exports = ModelFormCreator.create({
    model: model,
    renderFunc: function(component) {
        var item = component.state.item;
        // Create the appropriate creative preview div
        var preview;
        if (item.CreativeRawUrl || item.VideoSpecUrl) {
            var picture;
            if (item.VideoSpecUrl) {
                picture = (
                    <video className="img-responsive img-thumbnail"
                           width={item.CreativeSize.Width}
                           height={item.CreativeSize.Height} controls>
                        <source src={item.VideoSpecUrl} type="video/mp4" />
                        Your browser does not support the video tag.
                    </video>
                );
            } else if (item.CreativeTypeId === 1 || item.CreativeTypeId === 6) {
                picture = (
                    <img src={item.CreativeRawUrl}
                         className="img-responsive img-thumbnail"
                         width={item.CreativeSize.Width}
                         height={item.CreativeSize.Height} />
                );
            } else if (item.CreativeTypeId === 7 &&
                item.CreativeFile.FileExtension === '.html') {
                picture = (
                    <iframe src={item.CreativeRawUrl}
                            width={item.CreativeSize.Width} height={item.CreativeSize.Height}>
                    </iframe>
                );
            }
            preview = (
                <div className="text-center well">
                    <a href={item.ClickThroughUrl}>{picture}</a>
                </div>
            );
        }
        // TODO: reviews
        var reviews = (<p>No Reviews</p>);
        /*
         <div ng-show="reviews.length > 0">
         <h3>Review Status</h3>
         <table class="table table-striped">
         <tbody>
         <thead>
         <th>Partner</th><th>Status</th><th>Reason</th><th>Modified</th>
         </thead>
         <tr ng-repeat="review in reviews">
         <td>{{review.PartnerId}}</td>
         <td>{{review.Status}}</td>
         <td>{{review.ExchangeErrorString}}</td>
         <td>{{review.UtcModifiedDateTime|timeAgo}}</td>
         </tr>
         </tbody>
         </table>
         </div>
         */
        return (
            <div>
                <h2>{item.CreativeName}</h2>
                {preview}
                {reviews}
                <h3>Linked Strategies</h3>
                <StrategyList params={{CreativeUuid: item[model.modelId]}} />
                <h3>Creative Details</h3>
                <form name="creativeForm" className="form-horizontal" role="form">
                    {component._inputField({name: 'CreativeName', label: 'Name'})}
                    {/* TODO: media type ID */}
                    {component._staticField({
                        label: 'Media Type', value: item.CreativeSize.MediaTypeId
                    })}
                    {component._staticField({
                        label: 'Dimensions', value: item.CreativeSize.CreativeSizeName
                    })}
                </form>
            </div>
        );
    }
});