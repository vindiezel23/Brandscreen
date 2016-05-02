var React = require('react');
var Link = require('react-router').Link;

var Navbar = React.createClass({

    render: function() {
        return (
            <nav className="navbar navbar-default navbar-static-top">
                <div className="container">
                    <div className="navbar-header">
                        <Link className="navbar-brand" to="/">
                            Brandscreen API React Demo
                        </Link>
                    </div>
                    <div id="navbar" className="navbar-collapse collapse">
                        <ul className="nav navbar-nav">
                            {/* TODO: dynamic active class */}
                            {/* TODO: react router links */}
                            <li className="active"><Link to="/">Home</Link></li>
                        </ul>
                        <ul className="nav navbar-nav navbar-right">
                            {/* TODO: dynamic logged in status */}
                            <li><Link to="/login">Login</Link></li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }

});

module.exports = Navbar;