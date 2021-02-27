(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenTablasDetalleService', GenTablasDetalleService);

    GenTablasDetalleService.$inject = ['$http', '$q'];

    function GenTablasDetalleService($http, $q) {
        var nameSpace = '/General/api/TablasDetalle/';
        var service = {
            getAll: getAll,
        };

        return service;

        function getAll(cod) {
            return $http.get(nameSpace + cod)
                .then(
                    function (response) {
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }
    }
})();