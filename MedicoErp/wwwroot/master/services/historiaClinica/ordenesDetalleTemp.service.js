(function () {
    'use strict';

    angular
        .module('app')
        .factory('HistClinicaOrdenesDetalleTempService', HistClinicaOrdenesDetalleTempService);

    HistClinicaOrdenesDetalleTempService.$inject = ['$http', '$q'];

    function HistClinicaOrdenesDetalleTempService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/OrdenesDetalleTemp/';

        var service = {
            getAllByIdUsuario: getAllByIdUsuario,
            create: create,
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