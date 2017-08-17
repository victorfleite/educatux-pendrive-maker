'use strict';

app.controller('LoadingController', [
    '$rootScope', '$scope', '$log', '$uibModal', 'utilService', 'utilFileService', 'utilTraceService', 'utilNwjsService', 'CONSTANTS',
    function ($rootScope, $scope, $log, $uibModal, utilService, utilFileService, utilTraceService, utilNwjsService, CONSTANTS) {

        $scope.letsDownload = true;
        $scope.current = 0;
        $scope.max = 100;
        $scope.label = '0%';

        var myStream = utilNwjsService.getFileSistem().createReadStream('E:\\EducatuxStretch_v0.1.1.1_8GB.iso');

        var emitter = utilNwjsService.getImageWrite().write('\\\\.\\PHYSICALDRIVE1', myStream, {
            check: true,
            size: utilNwjsService.getFileSistem().statSync('E:\\EducatuxStretch_v0.1.1.1_8GB.iso').size
        });

        emitter.on('progress', function (s) {
            $scope.current = s.percentage;
            $scope.label = parseInt(s.percentage) + '%';
            $scope.$apply();
            $log.log($scope.current);
        });
        emitter.on('error', function (error) {
            $log.error(error);
        });

        emitter.on('done', function (success) {
            if (success) {
                $log.log('Success!');
                $scope.percent = 100;
            } else {
                $log.log('Failed!');
            }
        });



    }]);
