(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminEspecialidadesService', AdminEspecialidadesService);

    AdminEspecialidadesService.$inject = ['$http', '$q'];

    function AdminEspecialidadesService($http, $q) {
        var nameSpace = '/Administracion/api/Especialidades/';

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