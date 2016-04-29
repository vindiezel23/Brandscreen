var React = require('react');
var Navbar = require('./Navbar.react');

var BSAPIApp = React.createClass({

    render: function() {
        return (
            <div>
                <Navbar />
                <div className="container">
                    <div className="row">
                        {this.props.children}
                    </div>
                </div>
            </div>
        );
    }

});

module.exports = BSAPIApp;