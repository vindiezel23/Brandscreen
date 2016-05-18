var React = require('react');

var Spinner = React.createClass({

    render: function() {
        return (
            <span className="glyphicon glyphicon-refresh glyphicon-spin"
                  aria-hidden="true">
      </span>
        );
    }

});

module.exports = Spinner;