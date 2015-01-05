angular.module('ui.bootstrap.demo').controller('ModalInstanceCtrl', function ($scope, $modalInstance, items) {

    //$scope.items = items;
    //$scope.selected = {
    //    item: $scope.items[0]
    //};

    $scope.ok = function () {
        $modalInstance.close($scope.selectedvalue);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});