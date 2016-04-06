var React = require('react');

var ReactPropTypes = React.PropTypes;

var CampaignListItem = React.createClass({

    propTypes: {
        campaign: ReactPropTypes.object
    },

    render: function() {
        var campaign = this.props.campaign;
        return (
            <tr>
                <td>
                    <a href="foobar">{campaign.CampaignName}</a>
                </td>
            </tr>
        );
    }

});

module.exports = CampaignListItem;