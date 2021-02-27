(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdmisionFacturacionService', AdmisionFacturacionService);

    AdmisionFacturacionService.$inject = ['$http', '$q'];

    function AdmisionFacturacionService($http, $q) {
        var nameSpace = '/Admision/api/Facturacion/';

        var service = {
            createFacturacion: createFacturacion,
        };

        return service;

        function createFacturacion(data) {
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

    }
})();