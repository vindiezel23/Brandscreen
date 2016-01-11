var gulp = require('gulp');
var bower = require('gulp-bower');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var sourcemaps = require('gulp-sourcemaps');
var strip = require('gulp-strip-comments');
var cleanCss = require('gulp-clean-css');
var newer = require('gulp-newer');
var flatten = require('gulp-flatten');
var del = require('del');

var config = {
    vendorJs: [
        'wwwroot/lib/modernizr-built/dist/modernizr.min.js',
        'wwwroot/lib/jquery/dist/jquery.min.js',
        'wwwroot/lib/jquery-validation/dist/jquery.validate.min.js',
        'wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js',
        'wwwroot/lib/angular/angular.min.js',
        'wwwroot/lib/angular-route/angular-route.min.js',
        'wwwroot/lib/bootstrap/dist/js/bootstrap.min.js',
        'wwwroot/lib/respond/dest/respond.min.js'
    ],

    appJs: [
        'app/app.module.js',
        'app/app.config.js',
        'app/common/*.js',
        'app/shared/*.js',
        'app/account/*.js',
        'app/help/*.js',
        'app/manage/*.js',
        'app/user/*.js'
    ],

    vendorCss: [
        'wwwroot/lib/bootstrap/dist/css/bootstrap.min.css'
    ],

    appCss: [
        'content/site.css'
    ],

    fonts: [
        'wwwroot/lib/bootstrap/dist/fonts/*'
    ],

    scriptOut: 'scripts/dist/',
    cssOut: 'content/dist/css/',
    fontsOut: 'content/dist/fonts/',

    devScriptOut: 'scripts/src/',
    devCssOut: 'content/src/css/',
    devFontsOut: 'content/src/fonts/'
};

gulp.task('restore-bower', function() {
    return bower();
});

gulp.task('bundle-vendor-js', ['restore-bower'], function() {
    return gulp.src(config.vendorJs)
        .pipe(newer(config.scriptOut + 'vendor.min.js'))
        .pipe(strip())
        .pipe(concat('vendor.min.js'))
        .pipe(gulp.dest(config.scriptOut));
});

gulp.task('bundle-js', ['restore-bower'], function() {
    return gulp.src(config.appJs)
        .pipe(newer(config.scriptOut + 'app.js'))
        .pipe(strip())
        .pipe(concat('app.js'))
        .pipe(gulp.dest(config.scriptOut))
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(concat('app.min.js'))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(config.scriptOut));
});

gulp.task('build-script', ['bundle-vendor-js', 'bundle-js'], function() {
});

gulp.task('bundle-css', ['restore-bower'], function() {
    var allCssSrc = [].concat(config.vendorCss, config.appCss);
    return gulp.src(allCssSrc)
        .pipe(newer(config.cssOut + 'app.css'))
        .pipe(strip.text())
        .pipe(concat('app.css'))
        .pipe(gulp.dest(config.cssOut))
        .pipe(sourcemaps.init())
        .pipe(cleanCss())
        .pipe(concat('app.min.css'))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest(config.cssOut));
});

gulp.task('copy-fonts', ['restore-bower'], function() {
    return gulp.src(config.fonts)
        .pipe(newer(config.fontsOut))
        .pipe(gulp.dest(config.fontsOut));
});

gulp.task('build-style', ['bundle-css', 'copy-fonts'], function() {
});

gulp.task('clean', function() {
    return del([
        config.scriptOut,
        config.cssOut,
        config.fontsOut
    ]);
});

gulp.task('build', ['build-script', 'build-style']);

///////////////////////////
// DEV ENVIRONMENT TASKS //
///////////////////////////

gulp.task('copy-dev-vendor-script', ['restore-bower'], function() {
    return gulp.src(config.vendorJs)
        .pipe(flatten())
        .pipe(newer(config.devScriptOut))
        .pipe(gulp.dest(config.devScriptOut));
});

gulp.task('copy-dev-css', ['restore-bower'], function() {
    return gulp.src(config.vendorCss)
        .pipe(flatten())
        .pipe(newer(config.devCssOut))
        .pipe(gulp.dest(config.devCssOut));
});

gulp.task('copy-dev-fonts', ['restore-bower'], function() {
    return gulp.src(config.fonts)
        .pipe(flatten())
        .pipe(newer(config.devFontsOut))
        .pipe(gulp.dest(config.devFontsOut));
});

gulp.task('clean-dev', function() {
    return del([
        config.devScriptOut,
        config.devCssOut,
        config.devFontsOut
    ]);
});

gulp.task('build-dev', ['copy-dev-vendor-script', 'copy-dev-css', 'copy-dev-fonts']); // for msbuild gulp task debug environment

///////////////////
// MSBUILD TASKS //
///////////////////

gulp.task('build-Debug', ['build-dev']);
gulp.task('build-Release', ['build']);
gulp.task('build-Production', ['build']);

gulp.task('clean-Debug', ['clean-dev']);
gulp.task('clean-Release', ['clean']);
gulp.task('clean-Production', ['clean']);