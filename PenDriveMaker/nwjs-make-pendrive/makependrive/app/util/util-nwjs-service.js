'use strict';

angular.module('utilModule')
        .service('utilNwjsService', [
            '$log',
            function ($log) {
                var self = this;

                // Import 
                self.manifest = '';
                self.os = '';
                self.dns = '';
                self.childProcess = '';
                self.fs = '';
                self.path = '';
                self.nw_gui = '';
                self.request = '';
                self.progress = '';
                self.fileSize = '';
                self.hashFiles = '';

                self.getManifest = function () {
                    if (self.manifest == '') {
                        self.manifest = require('./package.json')
                    }
                    return self.manifest;
                }

                self.getCurrentWindow = function () {
                    // Get the current window
                    return nw.Window.get();
                }
                // Create a new window and get it
                self.open = function (url, options, callback) {
                    // Create a new window and get it
                    nw.Window.open(url, options, callback);
                }
                self.getNwGui = function () {
                    if (self.nw_gui == '') {
                        self.nw_gui = require("nw.gui");
                    }
                    return self.nw_gui;  
                }

                self.getChildProcess = function () {
                    if (self.childProcess == '') {
                        self.childProcess = require("child_process");
                    }
                    return self.childProcess;
                }
                self.getFileSistem = function () { 
                    if (self.fs == '') {
                        self.fs = require("fs");
                    }
                    return self.fs;
                }

                self.getOS = function () {
                    if (self.os == '') {
                        self.os = require("os");
                    }
                    return self.os;
                }
                self.getDNS = function () {
                    if (self.dns == '') {
                        self.dns = require("dns");
                    }
                    return self.dns;
                }
                self.getPath = function () {
                    if (self.path == '') {
                        self.path = require("path");
                    }
                    return self.path;
                }
                self.getRequest = function () {
                    if (self.request == '') {
                        self.request = require('request');
                    }
                    return self.request;
                }
                self.getRequestProgress = function () {
                    if (self.progress == '') {
                        self.progress = require('request-progress');
                    }
                    return self.progress;
                }
                self.getFileSize = function (val, options) {
                    if (self.fileSize == '') {
                        self.fileSize = require('file-size');
                    }
                    return self.fileSize(val, options);
                }
                self.getHashFiles = function () {
                    if (self.hashFiles == '') {
                        self.hashFiles = require('hash-files');
                    }
                    return self.hashFiles;
                }

                self.getImageWrite = function () {
                    return require("resin-image-write");
                }

            }
        ]);     	