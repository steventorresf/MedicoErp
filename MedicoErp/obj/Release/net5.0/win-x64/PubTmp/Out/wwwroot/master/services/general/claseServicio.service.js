(function () {
    'use strict';

    angular
        .module('app')
        .factory('ClaseServicioService', ClaseServicioService);

    ClaseServicioService.$inject = ['$http', '$q'];

    function ClaseServicioService($http, $q) {
        var nameSpace = url + 'General/api/ClaseServicio/';

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