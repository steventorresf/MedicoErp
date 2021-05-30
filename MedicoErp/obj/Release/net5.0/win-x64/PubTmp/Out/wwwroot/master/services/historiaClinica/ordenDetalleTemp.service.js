(function () {
    'use strict';

    angular
        .module('app')
        .factory('OrdenDetalleTempService', OrdenDetalleTempService);

    OrdenDetalleTempService.$inject = ['$http', '$q'];

    function OrdenDetalleTempService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/OrdenDetalleTemp/';

        var service = {
            getAllByIdUsuario: getAllByIdUsuario,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getAllByIdUsuario(idUsuario) {
            return $http.get(nameSpace + idUsuario)
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

        function create(data) {
            return $http.post(nameSpace, data)
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
            return $http.post(nameSpace + id, data)
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

        function remove(idDetalle) {
            return $http.delete(nameSpace + idDetalle)
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