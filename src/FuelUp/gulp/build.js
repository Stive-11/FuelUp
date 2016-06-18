'use strict';

var gulp = require('gulp');
var plumber = require('gulp-plumber');
var paths = gulp.paths;

var rename = require('gulp-rename');
var debug = require('gulp-debug');

var $ = require('gulp-load-plugins')({
  pattern: ['gulp-*', 'main-bower-files', 'uglify-save-license', 'del']
});

gulp.task('partials', function () {
  return gulp.src([
    paths.src + '/app/**/*.html',
    paths.tmp + '/app/**/*.html'
  ])
    .pipe(plumber())
    .pipe($.if(function(file) {
        return $.match(file, ['!**/fuelup/*.html']);
      },
      $.minifyHtml({
        empty: true,
        spare: true,
        quotes: true
      }))
    )
    .pipe($.angularTemplatecache('templateCacheHtml.js', {
      module: 'app',
      root: 'app'
    }))
    .pipe(gulp.dest(paths.tmp + '/partials/'));
});

gulp.task('html', ['inject', 'partials'], function () {
  var partialsInjectFile = gulp.src(paths.tmp + '/partials/templateCacheHtml.js', { read: false });
  var partialsInjectOptions = {
    starttag: '<!-- inject:partials -->',
    ignorePath: paths.tmp + '/partials',
    addRootSlash: false
  };

  var htmlFilter = $.filter(['*.html']);
  var jsFilter = $.filter('**/*.js');
  var cssFilter = $.filter('**/*.css');
  var assets;

  return gulp.src(paths.tmp + '/serve/*.html')
    .pipe(plumber())
    .pipe($.inject(partialsInjectFile, partialsInjectOptions))
    .pipe(assets = $.useref.assets())
    .pipe($.rev())
    .pipe(jsFilter)
    .pipe($.ngAnnotate())
    .pipe($.uglify({preserveComments: $.uglifySaveLicense}))///!!!!!!!!!!!!!!!!!!!!!!
    .pipe(jsFilter.restore())
    .pipe(cssFilter)
    .pipe($.csso())
    .pipe(cssFilter.restore())
    .pipe(assets.restore())
    .pipe($.replace('../bower_components/material-design-iconic-font/dist/fonts', '../fonts'))
    .pipe($.useref())
    .pipe($.revReplace())
    .pipe(htmlFilter)
    .pipe($.minifyHtml({
      empty: true,
      spare: true,
      quotes: true
    }))
    .pipe(htmlFilter.restore())
    .pipe(gulp.dest(paths.dist + '/'))
    .pipe($.size({ title: paths.dist + '/', showFiles: true }));
});

gulp.task('images', function () {
    return gulp.src(paths.src + '/assets/images/**/*')
    .pipe(plumber())
    .pipe(gulp.dest(paths.dist + '/assets/images/'));
});

gulp.task('fonts', function () {
    return gulp.src($.mainBowerFiles())
    .pipe(plumber())
    .pipe($.filter('**/*.{eot,otf,svg,ttf,woff,woff2}'))
    .pipe($.flatten())
    .pipe(gulp.dest(paths.dist + '/fonts/'));
});

gulp.task('translations', function () {
  return gulp.src('src/**/il8n/*.json')
    .pipe(plumber())
    .pipe(gulp.dest(paths.dist + '/'))
    .pipe($.size());
});

gulp.task('data', function () {
    return gulp.src('src/**/data/*.json')
    .pipe(plumber())
    .pipe(gulp.dest(paths.dist + '/'))
    .pipe($.size());
});


gulp.task('fuelupjs', function () {
    return gulp.src('src/**/fuelup/*.{js,scss}')
      //.pipe(debug({ minimal: true }))
      .pipe(plumber())
      .pipe(gulp.dest(paths.dist + '/'))
      .pipe($.size());
});

gulp.task('misc', function () {
    return gulp.src(paths.src + '/favicon.png')
    .pipe(plumber())
    .pipe(gulp.dest(paths.dist + '/'));
});

gulp.task('clean', function (done) {
    //console.log('!' + paths.dist + '/**/*.config');
    $.del([paths.dist + '/**', '!' + paths.dist + '{,/web.config}', paths.tmp + '/', 'Views/Home/'], done);
});

gulp.task('copy-index-html', ['html'], function () {
    return gulp.src(paths.dist + '/index.html')
    .pipe(plumber())
    .pipe(rename('Index.cshtml'))
    .pipe(gulp.dest('Views/Home/'));
});

gulp.task('buildapp', ['html', 'images', 'fonts', 'translations', 'misc', 'data', 'fuelupjs',  'copy-index-html']);
