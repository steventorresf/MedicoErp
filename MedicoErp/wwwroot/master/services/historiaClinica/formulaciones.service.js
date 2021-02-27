(function () {
    'use strict';

    angular
        .module('app')
        .factory('HistClinicaFormulacionesService', HistClinicaFormulacionesService);

    HistClinicaFormulacionesService.$inject = ['$http', '$q'];

    function HistClinicaFormulacionesService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Formulaciones/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            create: create,
            update: update,
            remove: remove,
            imprimirFormulacion: imprimirFormulacion,
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


        function imprimirFormulacion(idFormulacion) {
            return $http.get(nameSpace + 'GetForImp/' + idFormulacion)
                .then(
                    function (response) {
                        // Mandar a imprimir
                        fnImprimirFormulacion(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirFormulacion(entity) {
            var data = entity.listFormulacionDetalle;

            var tableFormulacionDet = [
                [
                    {
                        text: 'Formulación Médica No.' + entity.noFormulacion,
                        colSpan: 4,
                        alignment: 'center',
                        bold: true,
                        fillColor: '#eeeeee',
                        fontSize: 12,
                    },
                    {}, {}, {},
                ],
                [
                    { text: 'Medicamento', bold: true, alignment: 'center', },
                    { text: 'ViaAdmon', bold: true, alignment: 'center', },
                    { text: 'Cant', bold: true, alignment: 'center', },
                    { text: 'Posologia', bold: true, alignment: 'center', },
                ]
            ];

            for (var i = 0; i < data.length; i++) {
                tableFormulacionDet.push(
                    [
                        { text: data[i].medicamento },
                        { text: data[i].viaAdmon },
                        { text: data[i].cantidad, alignment: 'center', },
                        { text: data[i].posologia },
                    ]
                );
            }

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
                        text: entity.centro.nombreCentro,
                        alignment: 'center',
                        bold: true,
                        fontSize: 20,
                    },
                    {
                        text: entity.centro.nitCentro,
                        alignment: 'center',
                        bold: true,
                        style: 'estilo8',
                    },
                    {
                        text: entity.centro.direccion,
                        alignment: 'center',
                        bold: true,
                        style: 'estilo8',
                    },
                    {
                        text: entity.centro.telefono,
                        alignment: 'center',
                        bold: true,
                        style: 'estilo8',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['15%', '45%', '15%', '25%'],
                            body: [
                                [
                                    {
                                        text: 'Datos del paciente',
                                        colSpan: 4,
                                        alignment: 'center',
                                        bold: true,
                                        fillColor: '#eeeeee',
                                        fontSize: 12,
                                    },
                                    {}, {}, {},
                                ],
                                [
                                    { text: 'Paciente:', bold: true },
                                    entity.paciente.nombrePaciente,
                                    { text: 'Doc. Identidad:', bold: true },
                                    entity.paciente.tipoIden + ' ' + entity.paciente.numIden
                                ],
                                [
                                    { text: 'Fecha Nac.:', bold: true },
                                    entity.sFechaNacimiento,
                                    { text: 'Sexo:', bold: true },
                                    entity.paciente.codSexo
                                ],
                                [
                                    { text: 'Dirección:', bold: true },
                                    entity.paciente.direccion,
                                    { text: 'Teléfonos:', bold: true },
                                    entity.paciente.telefono
                                ],
                                [
                                    { text: 'EPS:', bold: true },
                                    entity.convenio.nombreEps,
                                    { text: 'Tipo Usuario:', bold: true },
                                    entity.tipoUsuario
                                ],
                                [
                                    { text: 'Convenio:', bold: true },
                                    { text: entity.convenio.nombreConvenio },
                                    { text: 'F. Formulación:', bold: true },
                                    { text: entity.sFechaFormulacion }
                                ],
                            ]
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['30%', '15%', '10%', '45%'],
                            body: tableFormulacionDet
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 10],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['10%', '90%'],
                            body: [
                                [
                                    { text: entity.tiempoEvo != '' ? 'Tiempo Evolución:' : '', bold: true },
                                    { text: entity.tiempoEvo, }
                                ],
                                [
                                    { text: entity.proxControl != '' ? 'Próximo Control:' : '', bold: true },
                                    { text: entity.proxControl, }
                                ]
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 10],
                    },
                    {
                        image: 'data:image/png;base64,' + entity.firma,
                        width: 100,
                        height: 70,
                        alignment: 'center',
                    },
                    {
                        style: 'estilo',
                        text: entity.medico.nombreCompleto,
                        alignment: 'center',
                    },
                    {
                        style: 'estilo',
                        text: entity.medico.especialidad,
                        alignment: 'center',
                    },
                    {
                        style: 'estilo',
                        text: 'R.M. ' + entity.medico.registro,
                        alignment: 'center',
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 9,
                    },
                    estilo8: {
                        fontSize: 8,
                    }
                },
            };

            pdfMake.createPdf(Documento).open();
        }

    }
})();