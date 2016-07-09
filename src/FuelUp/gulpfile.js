'use strict';

var gulp = require('gulp');

gulp.paths = {
  src: 'src',
  dist: 'wwwroot',  //'dist',
  tmp: '.tmp'
};

require('require-dir')('./gulp');

gulp.task('build', ['clean'], function () {
    gulp.start('buildapp');
});
