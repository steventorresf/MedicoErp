(function () {
    'use strict';

    angular
        .module('app')
        .factory('DiagnosticoService', DiagnosticoService);

    DiagnosticoService.$inject = ['$http', '$q'];

    function DiagnosticoService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Diagnostico/';

        var service = {
            getByPrefix: getByPrefix,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getByPrefix(data) {
            return $http.post(nameSpace + 'Prefix/', data)
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

        function updateTar(data) {
            return $http.post(nameSpace + 'UpTar', data)
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

        function remove(data) {
            return $http.post(nameSpace + 'Cancel/', data)
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