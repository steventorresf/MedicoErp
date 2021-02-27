(function () {
    'use strict';

    angular
        .module('app')
        .factory('HistClinicaEventosService', HistClinicaEventosService);

    HistClinicaEventosService.$inject = ['$http', '$q'];

    function HistClinicaEventosService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Eventos/';

        var service = {
            getAllByIdPaciente: getAllByIdPaciente,
            getByIdEvento: getByIdEvento,
            atenderCita: atenderCita,
            update: update,
            imprimirEvento: imprimirEvento,
            finalizarEvento: finalizarEvento,
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


        function imprimirEvento(idEvento) {
            return $http.get(nameSpace + 'GetByIdEvento/' + idEvento)
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
                        text: 'Historia Clinica',
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


            var eventoDet = [
                [
                    { text: 'Evolución:', bold: true, },
                    { text: entity.evolucion, },
                ],
            ];

            if (entity.biopsiaAnterior != '' && entity.biopsiaAnterior != null) {
                eventoDet.push(
                    [
                        { text: 'Biopsia Anterior:', bold: true, },
                        { text: entity.biopsiaAnterior, },
                    ],
                );
            }

            eventoDet.push(
                [
                    { text: 'Diagnostico Principal:', bold: true, },
                    { text: entity.diagnosticoPal != null ? entity.diagnosticoPal.diagnostico : '', },
                ],
                [
                    { text: 'Diagnostico Relacional:', bold: true, },
                    { text: entity.diagnosticoRel1 != null ? entity.diagnosticoRel1.diagnostico : '', },
                ],
            );

            if (entity.ayudasDiagnosticas != '' && entity.ayudasDiagnosticas != null) {
                eventoDet.push(
                    [
                        { text: 'Ayudas Diagnosticas:', bold: true, },
                        { text: entity.ayudasDiagnosticas, },
                    ],
                );
            }

            if (entity.anexos != '' && entity.anexos != null) {
                eventoDet.push(
                    [
                        { text: 'Anexos:', bold: true, },
                        { text: entity.anexos, },
                    ],
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
                            widths: ['11%', '25%', '11%', '15%', '11%', '27%'],
                            body: eventoEnc
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
                            widths: ['30%', '70%'],
                            body: eventoDet
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
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
                        fontSize: 8,
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