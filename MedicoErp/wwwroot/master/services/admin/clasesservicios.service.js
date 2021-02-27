(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminClasesServiciosService', AdminClasesServiciosService);

    AdminClasesServiciosService.$inject = ['$http', '$q'];

    function AdminClasesServiciosService($http, $q) {
        var nameSpace = '/Administracion/api/ClasesServicio/';

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