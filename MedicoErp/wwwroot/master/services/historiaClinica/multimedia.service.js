(function () {
    'use strict';

    angular
        .module('app')
        .factory('MultimediaService', MultimediaService);

    MultimediaService.$inject = ['$http', '$q'];

    function MultimediaService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Multimedia/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            getAllTemporalesByIdUsuario: getAllTemporalesByIdUsuario,
            subirArchivo: subirArchivo,
            subirImgTemp: subirImgTemp,
            removeImagenTemporal: removeImagenTemporal,
            removeAllTemporal: removeAllTemporal,
            multimediaPdf: multimediaPdf,
            update: update,
            remove: remove,
        };

        return service;

        function getAllByIdEvento(idEvento) {
            return $http.get(nameSpace + idEvento)
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

        function getAllByIdPaciente(idPaciente) {
            return $http.get(nameSpace + 'ByPac/' + idPaciente)
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

        function getAllTemporalesByIdUsuario(idUsuario) {
            return $http.get(nameSpace + 'ByTemp/' + idUsuario)
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
        
        function subirArchivo(data) {
            return $http.post(nameSpace + 'Arch/', data)
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

        function subirImgTemp(data) {
            return $http.post(nameSpace + 'Img/', data)
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

        function removeImagenTemporal(idDetalle, idCentro) {
            return $http.delete(nameSpace + 'DelImgTemp/' + idDetalle + '/' + idCentro)
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

        function removeAllTemporal(idUsuario, idCentro) {
            return $http.delete(nameSpace + 'DelAll/' + idUsuario + '/' + idCentro)
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

        function multimediaPdf(tip, data) {
            return $http.post(nameSpace + 'MulPdf/' + tip + '/', data)
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

        function update(id, data) {
            return $http.put(nameSpace + id, data)
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

        function remove(data) {
            return $http.post(nameSpace + 'Cancel/', data)
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