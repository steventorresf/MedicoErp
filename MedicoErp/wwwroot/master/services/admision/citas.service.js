(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdmisionCitasService', AdmisionCitasService);

    AdmisionCitasService.$inject = ['$http', '$q'];

    function AdmisionCitasService($http, $q) {
        var nameSpace = '/Admision/api/Citas/';

        var service = {
            getAllHor: getAllHor,
            getAllFec: getAllFec,
            getAllFecMed: getAllFecMed,
            getAsigsConvenio: getAsigsConvenio,
            getAgendaMed: getAgendaMed,
            getMiAgenda: getMiAgenda,
            create: create,
            update: update,
            updateTar: updateTar,
            remove: remove,
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

        function getAsigsConvenio(idPac, idCon) {
            return $http.get(nameSpace + idPac + '/' + idCon)
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

        function getAgendaMed(data) {
            return $http.post(nameSpace + 'CAg/', data)
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

        function getMiAgenda(data) {
            return $http.post(nameSpace + 'CAgMed/', data)
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