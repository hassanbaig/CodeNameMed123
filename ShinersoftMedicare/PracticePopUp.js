
angular.module('app').controller('ModalDemoCtrl', ['$scope','$modal','$log', 'ui.bootstrap', PopController]);
    $scope.selectedvalue = '';
  

    function PopController($scope, $modal, $log) {
        $scope.open = function (size) {

            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };
    };

// Please note that $modalInstance represents a modal window (instance) dependency.
// It is not the same as the $modal service used above.

    //angular.module('app').controller('ModalDemoCtrl',['$scope','$modal','$log','ui.bootstrap',PopController] ); 
    //$scope.selectedvalue = '';

//angular.module('ui.bootstrap.demo').controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {

    angular.module('app').controller('ModalInstanceCtrl', ['$scope', '$modalInstance', 'items', 'ui.bootstrap.demo', PopDemoController]);
    $scope.selectedvalue = '';

    function PopDemoController ($scope,$modalInstance,items){

    $scope.ok = function () {
        $modalInstance.close($scope.selectedvalue);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};