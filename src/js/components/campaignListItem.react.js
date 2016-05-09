var React = require('react');
var Link = require('react-router').Link;

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
                    <Link to={`/campaign/${campaign.CampaignUuid}`}>
                        {campaign.CampaignName}
                    </Link>
                </td>
            </tr>
        );
    }

});

module.exports = CampaignListItem;