(function () {
    'use strict';

    angular
        .module('app')
        .factory('TipoServicioService', TipoServicioService);

    TipoServicioService.$inject = ['$http', '$q'];

    function TipoServicioService($http, $q) {
        var nameSpace = '/General/api/TipoServicio/';

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