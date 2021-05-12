(function () {
    'use strict';

    angular
        .module('app')
        .factory('DepartamentoService', DepartamentoService);

    DepartamentoService.$inject = ['$http', '$q'];

    function DepartamentoService($http, $q) {
        var nameSpace = '/General/api/Departamento/';

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