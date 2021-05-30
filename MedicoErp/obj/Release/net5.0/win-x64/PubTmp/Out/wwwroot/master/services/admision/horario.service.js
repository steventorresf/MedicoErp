(function () {
    'use strict';

    angular
        .module('app')
        .factory('HorarioService', HorarioService);

    HorarioService.$inject = ['$http', '$q'];

    function HorarioService($http, $q) {
        var nameSpace = url + 'Admision/api/Horario/';

        var service = {
            getAllHor: getAllHor,
            getAllFec: getAllFec,
            getAllFecMed: getAllFecMed,
            create: create,
            update: update,
        };

        return service;

        function getAllHor(idMed) {
            return $http.get(nameSpace + 'HorMed/' + idMed)
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

        function getAllFec(idMed) {
            return $http.get(nameSpace + 'FecMed/' + idMed)
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

        function getAllFecMed(data) {
            return $http.post(nameSpace + 'FecMed/', data)
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

    }
})();