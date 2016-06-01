var LoginActionCreators = require('../actions/LoginActionCreators');
var Pagination = require('../components/Pagination.react');
var React = require('react');

var ReactPropTypes = React.PropTypes;

module.exports = {
    // Parameters:
    // - store
    // - listItemComponent
    // - modelId
    // - emptyMessage
    // - getFunc
    // - headers (optional; if present specify array of column header names)
    create: function(options) {
        return React.createClass({

            propTypes: {
                urlPrefix: ReactPropTypes.string
            },

            _getStateFromStores: function() {
                return {
                    items: options.store.items()
                };
            },

            _getItem: function(item) {
                return (
                    <options.listItemComponent key={item[options.modelId]} value={item}
                                               urlPrefix={this.props.urlPrefix} />
                );
            },

            getInitialState: function() {
                return this._getStateFromStores();
            },

            componentDidMount: function() {
                options.store.addChangeListener(this._onChange);
            },

            componentWillUnmount: function() {
                options.store.removeChangeListener(this._onChange);
            },

            render: function() {
                var emptyElement;
                var tableElement;
                if (this.state.items.length === 0) {
                    emptyElement = (<p>{options.emptyMessage}</p>);
                } else {
                    var items = this.state.items.map(this._getItem);
                    var thead;
                    if ('headers' in options) {
                        var headers = [];
                        for (var i = 0; i < options.headers.length; i++) {
                            headers.push((<th key={i}>{options.headers[i]}</th>));
                        }
                        thead = (<thead><tr>{headers}</tr></thead>);
                    }
                    tableElement = (
                        <div>
                            <table className="table table-striped">
                                {thead}
                                <tbody>{items}</tbody>
                            </table>
                            <Pagination store={options.store} getFunc={options.getFunc}
                                        params={this.props.params} />
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
};