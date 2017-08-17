
'use strict';

angular.module('utilModule')
        .service('utilFileService', [
            '$log', 
            'utilNwjsService',
            'utilTraceService',
            function ($log, utilNwjsService, utilTraceService) {
                var self = this;

                self.fs = utilNwjsService.getFileSistem();
                /**
                 *	Function to verify if file exists
                 **/ 
                self.exists = function (path) {
                    var exists = self.fs.existsSync(path);
                    if (exists) {
                        utilTraceService.saveInTraceFile('Arquivo existente > ' + path);
                        return true;
                    } else {
                        utilTraceService.saveInTraceFile('Arquivo inexistente > ' + path);
                        return false;
                    }
                }
                /**
                 *	Function to verify if folder exists
                 **/
                self.existsFolder = function (path) {
                    try {
                        var stats = self.fs.lstatSync(path);
                        // Is it a directory?
                        if (stats.isDirectory()) {
                            return true;
                        }
                        return false;
                    } catch (e) {
                        return false;
                    }
                }
                /**
                 *	Function for delete file if exists
                 **/
                self.deleteFileIfExists = function (path) {

                    // Load File System	
                    if (self.exists(path)) {
                        //Delete File
                        self.fs.unlinkSync(path);
                        utilTraceService.saveInTraceFile('Deletou arquivo > ' + path);
                    }

                }
                /**
                 *	Remove files using rm bash
                 **/
                self.rmFiles = function (files) {

                    var rmFiles = utilNwjsService.getChildProcess().exec('rm -f ' + files);
                    rmFiles.stdout.on('data', function (data) {
                        $log.log('stdout: ' + data);
                    });
                    rmFiles.stderr.on('data', function (data) {
                        $log.log('stdout: ' + data);
                    });
                    utilTraceService.saveInTraceFile('Deletou arquivos (rm -f) > ' + files);


                }

                /**
                 *	Remove folder using rm bash
                 **/
                self.rmFolder = function (folder) {

                    var rmFiles = utilNwjsService.getChildProcess().exec('rm -fR ' + folder);
                    rmFiles.stdout.on('data', function (data) {
                        $log.log('stdout: ' + data);
                    });
                    rmFiles.stderr.on('data', function (data) {
                        $log.log('stdout: ' + data);
                    });
                    utilTraceService.saveInTraceFile('Deletou pasta (rm -fR) > ' + folder);


                }

                /**
                 *	Function for write a file
                 **/
                self.writeFile = function (path, value, callback) {

                    self.fs.writeFile(path, value, callback);
                    utilTraceService.saveInTraceFile('Criou arquivo > ' + path);
                }

                /**
                 *	Function for write sync a file
                 **/
                self.writeFileSync = function (path, value) {

                    self.fs.writeFileSync(path, value);
                    utilTraceService.saveInTraceFile('Criou arquivo (sync) > ' + path);

                }
                /**
                 * Listen the folder
                 **/
                self.watch = function (path, callback) {

                    self.fs.watch(path, callback);
                    utilTraceService.saveInTraceFile('Adicionou listener > ' + path);

                }
                /**
                 * remove Listen to the file
                 **/
                self.unwatchFile = function (path) {

                    self.fs.unwatchFile(path);
                    utilTraceService.saveInTraceFile('Removeu listener de arquivo > ' + path);

                }
                /**
                 * read file
                 **/
                self.readFile = function (path, encoding, callback) {

                    self.fs.readFile(path, encoding, callback);
                    utilTraceService.saveInTraceFile('Leu arquivo > ' + path);

                }

                /**
                 * read file Sync
                 **/
                self.readFileSync = function (path, encoding) {
                    utilTraceService.saveInTraceFile('Leu arquivo > ' + path);
                    return self.fs.readFileSync(path, encoding);
                }
                /**
                 * create folder
                 **/
                self.mkdir = function (path, mode, callback) {
                    if (mode) {
                        self.fs.mkdir(path, mode, callback);
                        utilTraceService.saveInTraceFile('Criou Pasta > ' + path + '(' + mode + ')');
                    } else {
                        self.fs.mkdir(path, callback);
                        utilTraceService.saveInTraceFile('Criou Pasta > ' + path + '(0o777)');
                    }
                }
                /**
                 * create folder sync
                 **/
                self.mkdirSync = function (path, mode) {
                    if (mode) {
                        utilTraceService.saveInTraceFile('Criou Pasta > ' + path + '(' + mode + ')');
                        return self.fs.mkdirSync(path, mode);
                    } else {
                        utilTraceService.saveInTraceFile('Criou Pasta > ' + path + '(0o777)');
                        return self.fs.mkdirSync(path);

                    }
                }
                /**
                 * Calculate File Size
                 **/
                self.calculateFileSize = function (size, options) {
                    return utilNwjsService.getFileSize(size, options);
                }
                /**
                 * Rename file name
                 **/
                self.rename = function (path1, path2, callback) {
                    return self.fs.rename(path1, path2, callback);
                }
                /**
                 * Rename file name sync
                 **/
                self.renameSync = function (path1, path2) {
                    return self.fs.renameSync(path1, path2);
                }
                /**
                  * Hash Files UnSyncronized
                  **/
                 self.getHashFiles = function (options, cb) {
                     var hashFiles = utilNwjsService.getHashFiles();
                     return hashFiles(options, cb);
                 }
                /**
                 * Hash Files Syncronized
                 **/
                self.getHashFilesSync = function (options) {
                    return utilNwjsService.getHashFiles().sync(options);
                }

            }]);     	