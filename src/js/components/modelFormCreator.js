var stores = require('../stores/stores');
var models = require('../models/models');
var React = require('react');
var Spinner = require('./Spinner.react');
var BSAPIUtils = require('../utils/BSAPIUtils');


module.exports = {
    // Attributes:
    // - model
    // - otherModels - dict of other models to get data from; keys will be added
    //                 to the state. The main model must contain the correct key
    //                 for these stores
    // - renderFunc - function to render the actual model, taking this as an
    //                argument (state available via this.state)
    create: function(options) {
        var store = stores[options.model.name];
        return React.createClass({

            _getStateFromStores: function(id) {
                var state = {item: store.get(id)};
                if (state.item !== null) {
                    state.updating = {};
                    for (var key in state.item) {
                        state.updating[key] = false;
                    }
                    for (var key in options.otherModels) {
                        var modelName = options.otherModels[key].name;
                        state[key] = stores[modelName].get(
                            state.item[models[modelName].modelId]);
                    }
                }
                return state;
            },

            getInitialState: function() {
                return this._getStateFromStores(
                    this.props.params[options.model.modelId]);
            },

            componentDidMount: function() {
                store.addListeners(this._onChange, this._onPatch);
                for (var key in options.otherModels) {
                    stores[options.otherModels[key].name].addListeners(
                        this._onChange, null);
                }
            },

            componentWillUnmount: function() {
                store.removeListeners(this._onChange, this._onPatch);
                for (var key in options.otherModels) {
                    stores[options.otherModels[key].name].removeListeners(
                        this._onChange, null);
                }
            },

            render: function() {
                if (this.state.item === null) {
                    return null;
                }
                return options.renderFunc(this);
            },

            // Attributes:
            // - name
            // - label
            // - value (optional, default this.state.item[name])
            // - type (optional, default text)
            // - min (optional)
            // - max (optional)
            // - step (optional)
            // - fieldAddon (optional)
            _inputField: function(options) {
                var fieldAddonClass = '';
                var fieldAddon = '';
                if ('fieldAddon' in options) {
                    fieldAddonClass = 'input-group';
                    fieldAddon = (
                        <span className="input-group-addon">{options.fieldAddon}</span>
                    );
                }
                var value;
                if ('value' in options) {
                    value = options.value;
                } else {
                    value = this.state.item[options.name];
                }
                if (!('type' in options)) {
                    options.type = 'text';
                }
                var min = 'min' in options ? options.min : '';
                var max = 'max' in options ? options.max : '';
                var step = 'step' in options ? options.step : '';
                var spinner;
                if (this.state.updating[options.name]) {
                    spinner = (
                        <div className='col-md-1'><div style={{paddingTop: "7px"}}>
                            <Spinner />
                        </div></div>
                    );
                }
                return (
                    <div className="form-group">
                        <div className="col-md-3 text-right">
                            <label htmlFor={`id-${options.name}`} className="control-label">
                                {options.label}
                            </label>
                        </div>
                        <div className="col-md-8">
                            <div className={fieldAddonClass}>
                                {fieldAddon}
                                <input id={`id-${options.name}`} name={options.name} value={value}
                                       onChange={this._onFieldChange}
                                       className="form-control validate" type={options.type}
                                       min={min} max={max} step={step} />
                            </div>
                        </div>
                        {spinner}
                    </div>
                );
            },

            // Attributes:
            // - label
            // - value (optional, default this.state.item[name])
            _staticField: function(options) {
                var value;
                if ('value' in options) {
                    value = options.value;
                } else {
                    value = this.state.item[options.name];
                }
                return (
                    <div className="form-group">
                        <div className="col-md-3 text-right">
                            <label className="control-label">{options.label}</label>
                        </div>
                        <div className="col-md-8">
                            <div>
                                <p className="form-control-static">{value}</p>
                            </div>
                        </div>
                    </div>
                );
            },

            _onChange: function() {
                this.setState(
                    this._getStateFromStores(this.props.params[options.model.modelId]));
            },
            _onFieldChange: function(event) {
                // Update our own state
                var item = this.state.item;
                item[event.target.name] = event.target.value;
                var updating = this.state.updating;
                updating[event.target.name] = true;
                this.setState({item: item, updating: updating});
                // Update the API
                BSAPIUtils.patch(
                    options.model, this.props.params[options.model.modelId],
                    event.target.name, event.target.value);
            },
            _onPatch: function(name) {
                var updating = this.state.updating;
                updating[name] = false;
                this.setState({updating: updating});
            }

        });
    }
};