(function () {
    'use strict';

    angular
        .module('app')
        .factory('CitaService', CitaService);

    CitaService.$inject = ['$http', '$q'];

    function CitaService($http, $q) {
        var nameSpace = url + 'Admision/api/Cita/';

        var service = {
            getAllHor: getAllHor,
            getAllFec: getAllFec,
            getAllFecMed: getAllFecMed,
            getAsigsConvenio: getAsigsConvenio,
            getAgendaMed: getAgendaMed,
            getMiAgenda: getMiAgenda,
            create: create,
            update: update,
            updateTarifaDescuento: updateTarifaDescuento,
            remove: remove,
            imprimirCita: imprimirCita,
        };

        return service;

        function getAllHor(idMed) {
            return $http.get(nameSpace + 'HorMed/' + idMed)
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

        function getAllFec(idMed) {
            return $http.get(nameSpace + 'FecMed/' + idMed)
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

        function getAllFecMed(data) {
            return $http.post(nameSpace + 'FecMed/', data)
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

        function getAsigsConvenio(idPac, idCon) {
            return $http.get(nameSpace + idPac + '/' + idCon)
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

        function getAgendaMed(data) {
            return $http.post(nameSpace + 'CAg/', data)
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

        function getMiAgenda(data) {
            return $http.post(nameSpace + 'CAgMed/', data)
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

        function create(data) {
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

        function updateTarifaDescuento(data) {
            return $http.post(nameSpace + 'UpTarDesc', data)
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



        function imprimirCita(idCita) {
            return $http.get(nameSpace + 'Imp/' + idCita)
                .then(
                    function (response) {
                        fnImprimirCita(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirCita(entity) {
            var Documento = {
                header: function (currentPage, pageCount, pageSize) {
                    return [
                        {
                            text: 'Página ' + currentPage.toString() + '/' + pageCount,
                            alignment: 'right',
                            margin: [0, 15, 40, 0],
                            style: 'estilo',
                        },
                    ]
                },
                content: [
                    {
                        text: 'DATOS DE LA CITA # ' + entity.noCita,
                        alignment: 'center',
                        bold: true,
                        fontSize: 14,
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['20%', '80%'],
                            body: [
                                [
                                    {
                                        text: 'Paciente:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.nombrePaciente,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Identificación:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.identificacion,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Convenio:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.nombreConvenio,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Servicio:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.nombreServicio,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Centro de atención:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.nombreCentro,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Dirección:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.direccionCentro,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Médico:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.nombreMedico,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Fecha:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.sFecha,
                                        alignment: 'left',
                                    },
                                ],
                                [
                                    {
                                        text: 'Hora:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.hora,
                                        alignment: 'left',
                                    },
                                ],
                            ]
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 9,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }

    }
})();