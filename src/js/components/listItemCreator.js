var React = require('react');
var Link = require('react-router').Link;

var ReactPropTypes = React.PropTypes;

module.exports = {
    // Parameters:
    // - modelId
    // - path
    // - columns (array of fields to display; must have at least one, the first
    //   will be hyperlinked)
    create: function(options) {
        return React.createClass({

            propTypes: {
                value: ReactPropTypes.object.isRequired,
                urlPrefix: ReactPropTypes.string
            },

            getDefaultProps: function() {
                return {
                    urlPrefix: ''
                };
            },

            render: function() {
                var columns = [];
                for (var i = 0; i < options.columns.length; i++) {
                    if (i === 0) {
                        columns.push((
                            <td key={i}>
                                <Link to={`${this.props.urlPrefix}/${options.path}/${this.props.value[options.modelId]}`}>
                                    {this.props.value[options.columns[i]]}
                                </Link>
                            </td>
                        ));
                    } else {
                        columns.push((
                            <td key={i}>{this.props.value[options.columns[i]]}</td>
                        ));
                    }
                }
                return (<tr>{columns}</tr>);
            }

        });
    }
};