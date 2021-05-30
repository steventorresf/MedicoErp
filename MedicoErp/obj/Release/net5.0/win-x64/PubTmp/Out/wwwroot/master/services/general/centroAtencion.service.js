(function () {
    'use strict';

    angular
        .module('app')
        .factory('CentroAtencionService', CentroAtencionService);

    CentroAtencionService.$inject = ['$http', '$q'];

    function CentroAtencionService($http, $q) {
        var nameSpace = url + 'General/api/CentroAtencion/';

        var service = {
            get: get,
            getAll: getAll,
            getAllExternos: getAllExternos,
            create: create,
            update: update,
            updateExterno: updateExterno,
        };

        return service;

        function get(idCentro) {
            return $http.get(nameSpace + 'ById/' + idCentro)
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

        function getAllExternos(idCentro) {
            return $http.get(nameSpace + 'Ext/' + idCentro)
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

        function updateExterno(id, data) {
            return $http.post(nameSpace + 'Ext/' + id, data)
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