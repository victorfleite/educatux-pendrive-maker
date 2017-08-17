'use strict';

angular.module('utilModule')
.service('utilService', [
	 '$log',
	 'utilNwjsService',
	 'UTIL_CONSTANTS',
     function($log, utilNwjsService, UTIL_CONSTANTS) {
     	var self = this;
     	self.localIp = ''; 
        self.parameters = [];
        /**
        *   Set Parameter
        **/
        self.setParameter = function(key, value){
            self.parameters[key] = value;
                  
        }
        /**
        *   Get Parameter
        **/
        self.getParameter = function(key){
            return self.parameters[key];
        }

        /**
        *   Generate Hash string
        **/
        self.generateHash = function(size){
            return Math.random().toString(36).replace(/[^a-z]+/g, '').substr(0, size);
        }

        /**
        *   Get an local ip/masc/address mac
        */   	
     	self.getLocalIp = function(){
     		if(self.localIp == ''){
  			   	self.loadLocalIp();
	     	}
	     	return self.localIp;
     	}
        /**
        *   Load an local ip/masc/address mac
        */
     	self.loadLocalIp = function(){
       		var interfaces = utilNwjsService.getOS().networkInterfaces();
       		
			var addresses = [];
			for (var k in interfaces) {
			    for (var k2 in interfaces[k]) {
			        var address = interfaces[k][k2];
			        if (address.family === 'IPv4' && !address.internal) {
			            addresses.push(address.address + '/'+ address.netmask+'/'+address.mac);
			        }
			    }
			}
			self.localIp = addresses.join();
     	}
        /**
        *   Get a international current time YYYY-mm-dd H:i:s
        */
     	self.getCurrentDateTime = function(){
     		var data = new Date();
     		return data.getFullYear()+'-'+
     			    self.completeWithLeftZeros(data.getMonth(),2)+'-'+
     			    self.completeWithLeftZeros(data.getDate(), 2)+' '+
     			    self.completeWithLeftZeros(data.getHours(),2)+':'+
     			    self.completeWithLeftZeros(data.getMinutes(),2)+':'+
     			    self.completeWithLeftZeros(data.getSeconds(),2);
     	}
        /**
        *   Complete by left zeros
        */
        self.completeWithLeftZeros = function(value, size){
            var s = value+"";
            while (s.length < size) s = "0" + s;
            return s;
        }
        /**
        *   Check internet connectivity
        **/
        self.checkInternet = function (callback) {
            utilNwjsService.getDNS().resolve(UTIL_CONSTANTS.GOOGLE_SITE,function(err) {
                if (err) {
                    callback(false);
                } else {
                    callback(true);
                }
            });
        }
        /**
        *   Get Hostname
        **/
        self.getOperatingSystemHostName = function(){
            return utilNwjsService.getOS().hostname();
        }
         /**
        *   Get Plataform
        **/
        self.getOperatingSystemPlataform = function(){
            return utilNwjsService.getOS().platform();
        }
         /**
        *   Get Arcteture of machine
        **/
        self.getOperatingSystemArchitecture = function(){
            return utilNwjsService.getOS().arch();
        }
         /**
        *   Returns the operating system release. 
        **/
        self.getOperatingSystemRelease = function(){
            return utilNwjsService.getOS().release();
        }
        /**
        * Returns the current JDK path. Exemple:
        * /var/www/html/educatux-game-container/nwjs/nwjs-sdk-v0.14.0-linux-ia32/nw
        **/
        self.getJDKCurrentPath = function(){
            return process.execPath;
        }

        self.getCurrentAppPath = function(){
            return utilNwjsService.getNwGui().__dirname;
        }

        self.sanitizeVersion = function(version){
            return parseInt(version.replace(/v/g, '').replace(/\./g, ''));
        }

        

    
		
}]);     	