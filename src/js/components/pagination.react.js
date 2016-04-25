//var LoginStore = require('../stores/LoginStore');
//var LoginActionCreators = require('../actions/LoginActionCreators');
var React = require('react');

var ReactPropTypes = React.PropTypes;

function getStateFromStores(store) {
    return {
        pageSize: store.pageSize(),
        pageCount: store.pageCount(),
        pageNumber: store.pageNumber(),
        paginationNumber: store.pageNumber()
    };
}

var Pagination = React.createClass({

    propTypes: {
        store: ReactPropTypes.object.isRequired,
        getFunc: React.PropTypes.func.isRequired,
        linkCount: React.PropTypes.number
    },

    getInitialState: function() {
        return getStateFromStores(this.props.store);
    },

    getDefaultProps: function () {
        return {linkCount: 10};
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
        // Only show a limited number of links
        // If there are more, replace with a '...'
        var first = Math.max(1, this.state.paginationNumber - (this.props.linkCount / 2 - 1));
        var last = Math.min(this.state.pageCount, first + this.props.linkCount - 1);
        if (last - first < this.props.linkCount - 1) {
            first = Math.max(1, last - this.props.linkCount - 1);
        }
        if (this.state.pageCount <= this.props.linkCount) {
            first = 1;
            last = this.state.pageCount;
        }
        if (first !== 1) {
            links.push(this._createLink(1));
            var expandIndex = Math.max(
                1, this.state.paginationNumber - this.props.linkCount);
            links.push((
                <li key='expandBefore'>
                    <a href="#" onClick={this._paginateOnClick.bind(this, expandIndex)}>
                        ...
                    </a>
                </li>
            ));
        }
        for (var i = first; i <= last; i++) {
            links.push(this._createLink(i));
        }
        if (last !== this.state.pageCount) {
            var expandIndex = Math.min(
                this.state.pageCount, this.state.paginationNumber + this.props.linkCount);
            links.push((
                <li key='expandAfter'>
                    <a href="#" onClick={this._paginateOnClick.bind(this, expandIndex)}>
                        ...
                    </a>
                </li>
            ));
            links.push(this._createLink(this.state.pageCount));
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

    _createLink: function(index) {
        return (
            <li className={this.state.pageNumber === index ? 'active' : ''}
                key={index}>
                <a href="#" onClick={this._onClick.bind(this, index)}>{index}</a>
            </li>
        );
    },

    _onChange: function(event, value) {
        this.setState(getStateFromStores(this.props.store));
    },

    _onClick: function(pageNumber, event) {
        event.preventDefault();
        if (pageNumber >= 1 && pageNumber <= this.state.pageCount) {
            this.setState({pageNumber: pageNumber, paginationNumber: pageNumber});
            this.props.getFunc(pageNumber);
        }
    },

    _paginateOnClick: function(paginationNumber, event) {
        event.preventDefault();
        if (paginationNumber >= 1 && paginationNumber <= this.state.pageCount) {
            this.setState({paginationNumber: paginationNumber});
        }
    }

});

module.exports = Pagination;