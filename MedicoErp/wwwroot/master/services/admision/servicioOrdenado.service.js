(function () {
    'use strict';

    angular
        .module('app')
        .factory('ServicioOrdenadoService', ServicioOrdenadoService);

    ServicioOrdenadoService.$inject = ['$http', '$q'];

    function ServicioOrdenadoService($http, $q) {
        var nameSpace = '/Admision/api/ServicioOrdenado/';

        var service = {
            getAllByIdPacAndIdCon: getAllByIdPacAndIdCon,
            create: create,
            updateTarifaDescuento: updateTarifaDescuento,
            remove: remove,
        };

        return service;

        function getAllByIdPacAndIdCon(idCentro, idpaciente, idConvenio) {
            return $http.get(nameSpace + idCentro + '/' + idpaciente + '/' + idConvenio)
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

        function updateTarifaDescuento(data) {
            return $http.post(nameSpace + 'UpTarDesc', data)
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

        function remove(id) {
            return $http.delete(nameSpace + id)
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