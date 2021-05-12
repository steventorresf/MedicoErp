(function () {
    'use strict';

    angular
        .module('app')
        .factory('TablaDetalleService', TablaDetalleService);

    TablaDetalleService.$inject = ['$http', '$q'];

    function TablaDetalleService($http, $q) {
        var nameSpace = '/General/api/TablaDetalle/';
        var service = {
            getAll: getAll,
        };

        return service;

        function getAll(cod) {
            return $http.get(nameSpace + cod)
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