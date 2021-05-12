(function () {
    'use strict';

    angular
        .module('app')
        .factory('EventoService', EventoService);

    EventoService.$inject = ['$http', '$q'];

    function EventoService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Evento/';

        var service = {
            getAllByIdPaciente: getAllByIdPaciente,
            getByIdEvento: getByIdEvento,
            atenderCita: atenderCita,
            createExt: createExt,
            update: update,
            imprimirEvento: imprimirEvento,
            finalizarEvento: finalizarEvento,
            anular: anular,
        };

        return service;


        function getAllByIdPaciente(idPaciente) {
            return $http.get(nameSpace + 'GetAllByIdPaciente/' + idPaciente)
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

        function getByIdEvento(idEvento) {
            return $http.get(nameSpace + 'GetByIdEvento/' + idEvento)
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

        function atenderCita(data) {
            return $http.post(nameSpace + 'AtCita/', data)
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

        function createExt(data) {
            return $http.post(nameSpace + 'Ext/', data)
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

        function update(idEvento, data) {
            return $http.put(nameSpace + idEvento, data)
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

        function finalizarEvento(idEvento, data) {
            return $http.put(nameSpace + 'Finalizar/' + idEvento, data)
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

        function anular(data) {
            return $http.post(nameSpace + 'An/', data)
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


        function imprimirEvento(idEvento, idFolio) {
            return $http.get(nameSpace + 'Imp/' + idEvento + '/' + idFolio + '/')
                .then(
                    function (response) {
                        fnImprimirEvento(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirEvento(entity) {
            var eventoEnc = [
                [
                    {
                        text: 'Datos Del Paciente',
                        colSpan: 6,
                        alignment: 'center',
                        bold: true,
                        fillColor: '#eeeeee',
                        fontSize: 12,
                    },
                    {}, {}, {}, {}, {},
                ],
                [
                    { text: 'NoEvento:', bold: true },
                    { text: entity.noEvento, colSpan: 3 },
                    {},
                    {},
                    { text: 'Fecha:', bold: true },
                    { text: entity.sFechaEvento }
                ],
                [
                    { text: 'Paciente:', bold: true },
                    { text: entity.paciente.nombrePaciente, colSpan: 3 },
                    {},
                    {},
                    { text: 'Documento:', bold: true },
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
                    { text: 'Dirección:', bold: true },
                    { text: entity.paciente.direccion, colSpan: 3 },
                    {},
                    {},
                    { text: 'Teléfonos:', bold: true },
                    entity.paciente.telefono
                ],
                //[
                //    { text: 'Convenio:', bold: true },
                //    { text: entity.convenio.nombreConvenio, colSpan: 3 },
                //    {}, {},
                //],
                [
                    { text: 'Barrio:', bold: true },
                    entity.paciente.barrio,
                    { text: 'Estado Civil:', bold: true },
                    entity.estadoCivil,
                    { text: 'Correo:', bold: true },
                    entity.paciente.correo
                ],
                [
                    { text: 'EPS:', bold: true },
                    { text: entity.convenio.nombreEps, colSpan: 3 },
                    {},
                    {},
                    { text: 'Tipo Usuario:', bold: true },
                    entity.tipoUsuario
                ],
            ];

            if (entity.nombreAcomp != null) {
                eventoEnc.push(
                    [
                        { text: 'Acomp.:', bold: true },
                        { text: entity.nombreAcomp, colSpan: 3 },
                        {},
                        {},
                        { text: 'Tel. Acomp.:', bold: true },
                        entity.telefonoAcomp
                    ],
                );
            }

            var content = [
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
                    style: 'estilo',
                },
                {
                    text: entity.centro.direccion,
                    alignment: 'center',
                    bold: true,
                    style: 'estilo',
                },
                {
                    text: entity.centro.telefono,
                    alignment: 'center',
                    bold: true,
                    style: 'estilo',
                    margin: [0, 0, 0, 15],
                },
                {
                    style: 'estilo',
                    table: {
                        widths: ['11%', '25%', '11%', '15%', '11%', '27%'],
                        body: eventoEnc
                    },
                    layout: {
                        hLineColor: 'lightgray',
                        vLineColor: 'lightgray',
                    },
                    margin: [0, 0, 0, 15],
                },
            ];

            var listaFolios = entity.listaFolios;
            for (var i = 0; i < listaFolios.length; i++) {

                // Encabezado Folio
                var entityFol = listaFolios[i];
                content.push(
                    {
                        style: 'estilo',
                        table: {
                            widths: ['25%', '25%', '25%', '25%'],
                            body: [
                                [
                                    {
                                        text: entityFol.formato.nombreFormato,
                                        bold: true,
                                        fontSize: 11,
                                        fillColor: '#eeeeee',
                                        alignment: 'center',
                                        colSpan: 4,
                                    },
                                    {}, {}, {},
                                ],
                                [
                                    { text: 'No Folio:', bold: true, },
                                    { text: entityFol.noFolio, },
                                    { text: 'Fecha Formato:', bold: true, },
                                    { text: entityFol.sFechaFolio, },
                                ]
                            ],
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                );

                // Detalle de folio
                var arrayFolioDet = [];
                var listaAreas = entityFol.listaAreas;

                for (var j = 0; j < listaAreas.length; j++) {
                    var a = listaAreas[j];
                    arrayFolioDet.push(
                        [
                            { text: a.nombreArea, bold: true, fontSize: 11, colSpan: 2, },
                            {},
                        ],
                    );

                    for (var k = 0; k < a.listaPreguntas.length; k++) {
                        var p = a.listaPreguntas[k];
                        arrayFolioDet.push(
                            [
                                { text: p.nombrePregunta, bold: true, },
                                { text: p.respuesta, },
                            ],
                        );
                    }
                }

                content.push(
                    {
                        style: 'estilo',
                        table: {
                            widths: ['25%', '75%'],
                            body: arrayFolioDet,
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'transparent',
                        },
                        margin: [0, 0, 0, 15],
                    },
                );

                // Diagnostico
                if (entityFol.formato.incluyeDiag) {
                    content.push(
                        {
                            style: 'estilo',
                            table: {
                                widths: ['25%', '75%'],
                                body: [
                                    [
                                        { text: 'Diagnostico Principal:', bold: true, },
                                        { text: entity.diagnosticoPal != null ? entity.diagnosticoPal.nombreDiagnostico : '', },
                                    ],
                                    [
                                        { text: 'Diagnostico Relacional:', bold: true, },
                                        { text: entity.diagnosticoRel1 != null ? entity.diagnosticoRel1.nombreDiagnostico : '', },
                                    ],
                                ]
                            },
                            layout: {
                                hLineColor: 'lightgray',
                                vLineColor: 'transparent',
                            },
                            margin: [0, 0, 0, 15],
                        },
                    );
                }

                // Firma
                content.push(
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
                        margin: [0, 0, 0, 25],
                    },
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
                content: content,
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