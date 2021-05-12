(function () {
    'use strict';

    angular
        .module('app')
        .factory('FormatoService', FormatoService);

    FormatoService.$inject = ['$http', '$q'];

    function FormatoService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Formato/';

        var service = {
            getAll: getAll,
            getAllNotEvento: getAllNotEvento,
        };

        return service;


        function getAll(idCentro) {
            return $http.get(nameSpace + idCentro)
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

        function getAllNotEvento(idCentro, idEvento) {
            return $http.get(nameSpace + 'NotEvento/' + idCentro + '/' + idEvento)
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