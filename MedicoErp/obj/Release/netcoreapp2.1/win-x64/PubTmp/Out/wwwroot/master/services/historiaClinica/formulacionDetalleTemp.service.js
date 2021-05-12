(function () {
    'use strict';

    angular
        .module('app')
        .factory('FormulacionDetalleTempService', FormulacionDetalleTempService);

    FormulacionDetalleTempService.$inject = ['$http', '$q'];

    function FormulacionDetalleTempService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/FormulacionDetalleTemp/';

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