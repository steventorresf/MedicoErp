(function () {
    'use strict';

    angular
        .module('app')
        .factory('ConvenioService', ConvenioService);

    ConvenioService.$inject = ['$http', '$q'];

    function ConvenioService($http, $q) {
        var nameSpace = url + 'Admision/api/Convenio/';

        var service = {
            getAll: getAll,
            getAllAct: getAllAct,
            create: create,
            update: update,
            updateEst: updateEst,
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

        function getAllAct(idc) {
            return $http.get(nameSpace + 'Act/' + idc)
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

        function updateEst(data) {
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