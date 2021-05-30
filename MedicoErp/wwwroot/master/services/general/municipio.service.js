(function () {
    'use strict';

    angular
        .module('app')
        .factory('MunicipioService', MunicipioService);

    MunicipioService.$inject = ['$http', '$q'];

    function MunicipioService($http, $q) {
        var nameSpace = url + 'General/api/Municipio/';

        var service = {
            getAll: getAll,
        };

        return service;

        function getAll(codDep) {
            return $http.get(nameSpace + codDep)
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