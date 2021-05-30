(function () {
    'use strict';

    angular
        .module('app')
        .factory('PacienteService', PacienteService);

    PacienteService.$inject = ['$http', '$q'];

    function PacienteService($http, $q) {
        var nameSpace = url + 'Admision/api/Paciente/';

        var service = {
            getByIden: getByIden,
            create: create,
            update: update,
        };

        return service;

        function getByIden(data) {
            return $http.post(nameSpace + 'Get/', data)
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