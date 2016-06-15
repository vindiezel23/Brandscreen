var models = require('../models/models.js');
var React = require('react');
var Link = require('react-router').Link;
var lists = require('../stores/lists');
var LoginActionCreators = require('../actions/LoginActionCreators');
var Pagination = require('../components/Pagination.react');

// Create a list component for each model
var listComponents = {};
for (var key in models) {
    listComponents[key] = createList(models[key]);
}

function createList(model) {
    var ReactPropTypes = React.PropTypes;

    return React.createClass({

        propTypes: {
            urlPrefix: ReactPropTypes.string
        },

        _getStateFromStores: function() {
            return {
                items: lists[model.name].items()
            };
        },

        _getItem: function(item) {
            var columns = [];
            var urlPrefix = this.props.urlPrefix;
            if (typeof urlPrefix === 'undefined') {
                if (model.urlPrefix) {
                    urlPrefix = model.urlPrefix(item, models);
                } else {
                    urlPrefix = '';
                }
            }
            for (var i = 0; i < model.columns.length; i++) {
                if (i === 0) {
                    columns.push((
                        <td key={i}>
                            <Link to={`${urlPrefix}/${model.route}/${item[model.modelId]}`}>
                                {item[model.columns[i]]}
                            </Link>
                        </td>
                    ));
                } else {
                    columns.push((
                        <td key={i}>{item[model.columns[i]]}</td>
                    ));
                }
            }
            return (<tr key={item[model.modelId]}>{columns}</tr>);
        },

        getInitialState: function() {
            return this._getStateFromStores();
        },

        componentDidMount: function() {
            lists[model.name].addChangeListener(this._onChange);
        },

        componentWillUnmount: function() {
            lists[model.name].removeChangeListener(this._onChange);
        },

        render: function() {
            var emptyElement;
            var tableElement;
            if (this.state.items.length === 0) {
                emptyElement = (<p>{model.emptyMessage}</p>);
            } else {
                var items = this.state.items.map(this._getItem);
                var thead;
                if ('headers' in model) {
                    var headers = [];
                    for (var i = 0; i < model.headers.length; i++) {
                        headers.push((<th key={i}>{model.headers[i]}</th>));
                    }
                    thead = (<thead><tr>{headers}</tr></thead>);
                }
                tableElement = (
                    <div>
                        <table className="table table-striped">
                            {thead}
                            <tbody>{items}</tbody>
                        </table>
                        <Pagination model={model} params={this.props.params} />
                    </div>
                );
            }
            return (
                <div>
                    {emptyElement}
                    <div className="pull-right">
                        {/* TODO: working search */}
                        <input className="form-control" type="text" placeholder="Search" />
                    </div>
                    {tableElement}
                </div>
            );
        },

        _onChange: function(event, value) {
            this.setState(this._getStateFromStores());
        }
    });
}

module.exports = listComponents;