angular.module("umbraco").controller("Ekom.Cache", function ($scope, assetsService, $http, notificationsService) {
  $scope.loading = false;
  $scope.PopulateCache = function () {

    $scope.loading = true;

    $http.post('/umbraco/backoffice/ekom/api/populateCache').then(function (res) {

      if (res.data) {
        notificationsService.success("Success", "Cache has been populated.");
      } else {
        notificationsService.error("Error", "Error on cache update");
      }

      $scope.loading = false;
    });

  };
});
