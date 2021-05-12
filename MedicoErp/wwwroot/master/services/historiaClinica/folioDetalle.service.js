(function () {
    'use strict';

    angular
        .module('app')
        .factory('FolioDetalleService', FolioDetalleService);

    FolioDetalleService.$inject = ['$http', '$q'];

    function FolioDetalleService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/FolioDetalle/';

        var service = {
            getAllByIdFolio: getAllByIdFolio,
            update: update,
        };

        return service;


        function getAllByIdFolio(idEvento) {
            return $http.get(nameSpace + idEvento)
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

        function update(id, data) {
            return $http.put(nameSpace + id, data)
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