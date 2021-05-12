(function () {
    'use strict';

    angular
        .module('app')
        .factory('FacturacionService', FacturacionService);

    FacturacionService.$inject = ['$http', '$q'];

    function FacturacionService($http, $q) {
        var nameSpace = '/Admision/api/Facturacion/';

        var service = {
            createFacturacion: createFacturacion,
            createFacturacionSinCita: createFacturacionSinCita,
            getIdDocumento: getIdDocumento,
            getAllByIdPaciente: getAllByIdPaciente,
            imprimirVol: imprimirVol,
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

        function createFacturacionSinCita(data) {
            return $http.post(nameSpace + 'SinCita/', data)
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

        function getIdDocumento(data) {
            return $http.post(nameSpace + 'GetId/', data)
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
            return $http.get(nameSpace + idPaciente)
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

        function imprimirVol(idFacturacion) {
            return $http.get(nameSpace + 'Imp/' + idFacturacion)
                .then(
                    function (response) {
                        fnImprimirVol(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirVol(entity) {
            var listaCitas = entity.listaCitas;

            var listaDet = [
                [
                    { text: 'Cups', alignment: 'center', bold: true, },
                    { text: 'Servicio', alignment: 'center', bold: true, },
                    { text: 'Médico', alignment: 'center', bold: true, },
                    { text: 'Fecha', alignment: 'center', bold: true, },
                    { text: 'Cant', alignment: 'center', bold: true, },
                    { text: 'Total', alignment: 'center', bold: true, },
                ],
            ];

            var vrTotal = 0;
            for (var i = 0; i < listaCitas.length; i++) {
                var d = listaCitas[i];
                listaDet.push(
                    [
                        { text: d.codigoRef, alignment: 'center', },
                        { text: d.nombreServicio, alignment: 'left', },
                        { text: d.nombreMedico, alignment: 'left', },
                        { text: d.sFecha, alignment: 'center', },
                        { text: d.cantidad, alignment: 'center', },
                        { text: PonerPuntosDouble(d.vrTotal), alignment: 'right', },
                    ],
                );
                vrTotal += d.vrTotal;
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
                        style: 'estilo',
                        table: {
                            widths: ['75%', '10%', '15%'],
                            body: [
                                [
                                    {
                                        text: entity.centroAtencion.nombreCentro,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 14,
                                    },
                                    { text: ' ', },
                                    { text: ' ', },
                                ],
                                [
                                    {
                                        text: entity.centroAtencion.nitCentro,
                                        alignment: 'center',
                                        bold: true,
                                    },
                                    {
                                        text: entity.tipoDocumento + ':',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.numDocumento,
                                        alignment: 'left',
                                        bold: true,
                                    },
                                ],
                                [
                                    {
                                        text: entity.centroAtencion.direccion,
                                        alignment: 'center',
                                        bold: true,
                                    },
                                    {
                                        text: 'Fecha:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.sFechaPago,
                                        alignment: 'left',
                                        bold: true,
                                    },
                                ],
                                [
                                    {
                                        text: entity.centroAtencion.telefono,
                                        alignment: 'center',
                                        bold: true,
                                    },
                                    {
                                        text: 'Usuario:',
                                        alignment: 'left',
                                        bold: true,
                                    },
                                    {
                                        text: entity.creadoPor,
                                        alignment: 'left',
                                        bold: true,
                                    },
                                ],
                            ]
                        },
                        layout: 'noBorders',
                        margin: [0, 0, 0, 15],
                    },
                    {
                        style: 'estilo',
                        table: {
                            widths: ['11%', '25%', '11%', '14%', '12%', '27%'],
                            body: [
                                [
                                    { text: 'Paciente:', bold: true },
                                    { text: entity.paciente.nombrePaciente, colSpan: 3 },
                                    {},
                                    {},
                                    { text: 'Identificación:', bold: true },
                                    entity.paciente.tipoIden + ' ' + entity.paciente.numIden
                                ],
                                [
                                    { text: 'Fecha Nac.:', bold: true },
                                    entity.sFechaNacimiento,
                                    { text: 'Sexo:', bold: true },
                                    entity.paciente.codSexo,
                                    { text: 'Ocupación:', bold: true },
                                    entity.paciente.ocupacion,
                                ],
                                [
                                    { text: 'Convenio:', bold: true },
                                    { text: entity.convenio.nombreConvenio, colSpan: 3 },
                                    {},
                                    {},
                                    { text: 'Tipo Usuario:', bold: true },
                                    { text: entity.tipoUsuario, }
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
                            widths: ['8%', '44%', '22%', '12%', '4%', '10%'],
                            body: listaDet
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
                            widths: ['90%', '10%'],
                            body: [
                                [
                                    { text: 'El servicio será prestado en:' },
                                    { text: '$ ' + PonerPuntosDouble(vrTotal), alignment: 'right', bold: true, },
                                ],
                                [
                                    { text: entity.centroRemision.nombreCentro, bold: true, colSpan: 2, },
                                    {},
                                ],
                                [
                                    { text: entity.centroRemision.direccion, colSpan: 2 },
                                    {},
                                ],
                                [
                                    { text: entity.centroRemision.telefono, colSpan: 2 },
                                    {},
                                ],
                            ]
                        },
                        layout: 'noBorders',
                        //margin: [0, 0, 0, 15],
                    },
                ],
                styles: {
                    estilo: {
                        fontSize: 8,
                    },
                },
            };

            pdfMake.createPdf(Documento).open();
        }

    }
})();