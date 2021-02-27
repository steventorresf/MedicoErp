(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenDepartamentosService', GenDepartamentosService);

    GenDepartamentosService.$inject = ['$http', '$q'];

    function GenDepartamentosService($http, $q) {
        var nameSpace = '/General/api/Departamentos/';

        var service = {
            getAll: getAll,
        };

        return service;

        function getAll() {
            return $http.get(nameSpace)
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