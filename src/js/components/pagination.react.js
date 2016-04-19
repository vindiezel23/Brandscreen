//var LoginStore = require('../stores/LoginStore');
//var LoginActionCreators = require('../actions/LoginActionCreators');
var React = require('react');

var ReactPropTypes = React.PropTypes;

function getStateFromStores(store) {
    return {
        pageSize: store.pageSize(),
        pageCount: store.pageCount(),
        pageNumber: store.pageNumber()
    };
}

var Pagination = React.createClass({

    propTypes: {
        store: ReactPropTypes.object.isRequired,
        getFunc: React.PropTypes.func.isRequired
    },

    getInitialState: function() {
        return getStateFromStores(this.props.store);
    },

    componentDidMount: function() {
        this.props.store.addChangeListener(this._onChange);
    },

    componentWillUnmount: function() {
        this.props.store.removeChangeListener(this._onChange);
    },

    render: function() {
        if (this.state.numPages === 0) {
            return false;
        }
        var links = [];
        for (var i = 1; i <= this.state.pageCount; i++) {
            links.push((
                <li className={this.state.pageNumber === i ? 'active' : ''} key={i}>
                    <a href="#" onClick={this._onClick.bind(this, i)}>{i}</a>
                </li>
            ));
        }
        return (
            <nav>
                <ul className="pagination">
                    <li className={this.state.pageNumber === 1 ? 'disabled' : ''}>
                        <a href="#" aria-label="Previous"
                           onClick={this._onClick.bind(this, this.state.pageNumber - 1)}>
                            <span aria-hidden="true">&laquo;</span>
                        </a>
                    </li>
                    {links}
                    <li className={this.state.pageNumber === this.state.pageCount ? 'disabled' : ''}>
                        <a href="#" aria-label="Next"
                           onClick={this._onClick.bind(this, this.state.pageNumber + 1)}>
                            <span aria-hidden="true">&raquo;</span>
                        </a>
                    </li>
                </ul>
            </nav>
        );
    },

    _onChange: function(event, value) {
        this.setState(getStateFromStores(this.props.store));
    },

    _onClick: function(pageNumber, event) {
        event.preventDefault();
        if (pageNumber >= 1 && pageNumber <= this.state.pageCount) {
            this.setState({pageNumber: pageNumber});
            this.props.getFunc(pageNumber);
        }
    }

});

module.exports = Pagination;