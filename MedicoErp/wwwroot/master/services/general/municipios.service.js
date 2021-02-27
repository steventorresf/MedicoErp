(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenMunicipiosService', GenMunicipiosService);

    GenMunicipiosService.$inject = ['$http', '$q'];

    function GenMunicipiosService($http, $q) {
        var nameSpace = '/General/api/Municipios/';

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