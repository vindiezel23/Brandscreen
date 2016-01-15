var BSAPIApp = require('./components/BSAPIApp.react');
window.$ = window.jQuery = require('jquery');
require('bootstrap');
var React = require('react');
var ReactDOM = require('react-dom');
window.React = React; // export for http://fb.me/react-devtools

ReactDOM.render(
    <BSAPIApp />,
    document.getElementById('react')
);