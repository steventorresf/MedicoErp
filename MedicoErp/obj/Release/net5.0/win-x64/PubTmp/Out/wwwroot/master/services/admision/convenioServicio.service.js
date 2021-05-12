(function () {
    'use strict';

    angular
        .module('app')
        .factory('ConvenioServicioService', ConvenioServicioService);

    ConvenioServicioService.$inject = ['$http', '$q'];

    function ConvenioServicioService($http, $q) {
        var nameSpace = '/Admision/api/ConvenioServicio/';

        var service = {
            getAll: getAll,
            getAllNo: getAllNo,
            getByIdServicio: getByIdServicio,
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

        function getByIdServicio(idCon, idSer) {
            return $http.get(nameSpace + 'ByIdSer/' + idCon + '/' + idSer)
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