(function () {
    'use strict';

    angular
        .module('app')
        .factory('DiagnosticoService', DiagnosticoService);

    DiagnosticoService.$inject = ['$http', '$q'];

    function DiagnosticoService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Diagnostico/';

        var service = {
            getByPrefix: getByPrefix,
        };

        return service;

        function getByPrefix(data) {
            return $http.post(nameSpace + 'Prefix/', data)
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