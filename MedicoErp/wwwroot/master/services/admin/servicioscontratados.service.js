(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminServiciosContratadosService', AdminServiciosContratadosService);

    AdminServiciosContratadosService.$inject = ['$http', '$q'];

    function AdminServiciosContratadosService($http, $q) {
        var nameSpace = '/Administracion/api/ServiciosContratados/';

        var service = {
            getAll: getAll,
            getAllNo: getAllNo,
            create: create,
            update: update,
            remove: remove,
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

        function getAllNo(idCen, idCon) {
            return $http.get(nameSpace + 'GetNo/' + idCen + '/' + idCon)
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

        function update(data) {
            return $http.post(nameSpace + 'UpTar/', data)
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