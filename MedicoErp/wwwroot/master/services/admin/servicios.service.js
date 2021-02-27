(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminServiciosService', AdminServiciosService);

    AdminServiciosService.$inject = ['$http', '$q'];

    function AdminServiciosService($http, $q) {
        var nameSpace = '/Administracion/api/Servicios/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            upEstado: upEstado,
        };

        return service;

        function getAll(idc) {
            return $http.get(nameSpace + idc)
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

        function upEstado(data) {
            return $http.post(nameSpace + 'UpEst/', data)
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