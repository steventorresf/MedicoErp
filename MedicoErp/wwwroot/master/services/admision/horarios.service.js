(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdmisionHorariosService', AdmisionHorariosService);

    AdmisionHorariosService.$inject = ['$http', '$q'];

    function AdmisionHorariosService($http, $q) {
        var nameSpace = '/Admision/api/Horarios/';

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