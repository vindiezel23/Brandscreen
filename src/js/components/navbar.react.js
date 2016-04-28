var React = require('react');

var Navbar = React.createClass({

    render: function() {
        return (
            <nav className="navbar navbar-default navbar-static-top">
                <div className="container">
                    <div className="navbar-header">
                        <a className="navbar-brand" href="#">Brandscreen API React Demo</a>
                    </div>
                    <div id="navbar" className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            {/* TODO: dynamic active class */}
                            {/* TODO: react router links */}
                            <li className="active"><a href="#">Home</a></li>
                            <li><a href="#">Foo</a></li>
                            <li><a href="#">Bar</a></li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">
                            {/* TODO: dynamic logged in status */}
                            <li><a href="#">Login</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }

});

module.exports = Navbar;