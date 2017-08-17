'use strict';

angular.module('utilModule')
.service('utilTraceService', [
	 '$log',
	 'utilNwjsService',
      'CONSTANTS',
	 'UTIL_CONSTANTS',
     function($log, utilNwjsService, EDUCATUX_CONSTANTS, UTIL_CONSTANTS) {
     	var self = this;
          self.saveInFile = true;
          self.homeDir = '';

          self.getUserHomeDir = function(){
               if(self.homeDir == ''){
                    self.homeDir = utilNwjsService.getOS().homedir();
               }
               return self.homeDir;
          }

          self.setDebugMode = function(booleano){
               if(booleano){
                    self.saveInFile = true;
               }else{
                    self.saveInFile = false;
               }
          }
          self.isDebugMode = function(){
               return self.saveInFile;
          }

     	self.getLineTrace = function(value){
     		var utc = new Date().toJSON().slice(0,19);
     		var aux = '\n' + utc + ' '+ value;			
     		return aux;
     	}
     
     	self.saveInTraceFile = function(value){

               var homeDir = self.getUserHomeDir();
               var path = homeDir+EDUCATUX_CONSTANTS.EDUCATUXAPP_USER_FOLDER;

     		if(self.saveInFile){
                   /*
                    var fs = utilNwjsService.getFileSistem();
                    var traceFilePath = UTIL_CONSTANTS.TRACE_FILE.replace('{appFolder}', path)
                    var logStream = fs.createWriteStream(
                         traceFilePath, 
                         {'flags': 'a', autoClose: true}
                    );
                    logStream.end(this.getLineTrace(value));
                    */ 
                    $log.log(value);             
               }
               
     		
     	}


}]);     	
