(function () {
    'use strict';

    angular
        .module('app')
        .factory('FolioService', FolioService);

    FolioService.$inject = ['$http', '$q'];

    function FolioService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Folio/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            getAllByIdFolio: getAllByIdFolio,
            create: create,
            anular: anular,
        };

        return service;


        function getAllByIdEvento(idEvento) {
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

        function getAllByIdPaciente(idPaciente, idCentro) {
            return $http.get(nameSpace + 'ByIdPac/' + idPaciente + '/' + idCentro)
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

        function getAllByIdFolio(idFolio) {
            return $http.get(nameSpace + 'ByIdFolio/' + idFolio)
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

        function anular(data) {
            return $http.post(nameSpace + 'An/', data)
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