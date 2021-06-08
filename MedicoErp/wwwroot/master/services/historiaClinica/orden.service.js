(function () {
    'use strict';

    angular
        .module('app')
        .factory('OrdenService', OrdenService);

    OrdenService.$inject = ['$http', '$q'];

    function OrdenService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Orden/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            create: create,
            update: update,
            anular: anular,
            imprimirOrden: imprimirOrden,
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
            return $http.post(nameSpace + id, data)
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


        function imprimirOrden(idOrden) {
            return $http.get(nameSpace + 'GetOrdImp/' + idOrden)
                .then(
                    function (response) {
                        // Mandar a imprimir
                        fnImprimirOrden(response.data);
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function fnImprimirOrden(entity) {
            var data = entity.listOrdenDetalle;

            var tableOrdenDet = [
                [
                    {
                        text: 'Detalle Orden Médica',
                        colSpan: 3,
                        alignment: 'center',
                        bold: true,
                        fillColor: '#eeeeee',
                        fontSize: 10,
                    },
                    {}, {},
                ],
                [
                    { text: 'Cups', bold: true, alignment: 'center', },
                    { text: 'Servicio', bold: true, alignment: 'center', },
                    { text: 'Cant', bold: true, alignment: 'center', }
                ]
            ];

            for (var i = 0; i < data.length; i++) {
                tableOrdenDet.push(
                    [
                        { text: data[i].servicio.codigoRef, alignment: 'center', },
                        { text: data[i].servicio.nombreServicio, alignment: 'center', },
                        { text: data[i].cantidad, alignment: 'center', }
                    ]
                );
            }

            var Documento = {
                //footer: function (currentPage, pageCount) { return currentPage.toString() + ' of ' + pageCount; },
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
                        text: entity.medico.nombreCompleto,
                        alignment: 'center',
                        bold: true,
                        fontSize: 20,
                    },
                    {
                        text: entity.medico.numIden,
                        alignment: 'center',
                        bold: true,
                        style: 'estilo8',
                    },
                    {
                        text: entity.medico.direccion,
                        alignment: 'center',
                        bold: true,
                        style: 'estilo8',
                    },
                    {
                        text: entity.medico.telefono,
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
                                        text: 'Orden Médica',
                                        colSpan: 4,
                                        alignment: 'center',
                                        bold: true,
                                        fillColor: '#eeeeee',
                                        fontSize: 12,
                                    },
                                    {}, {}, {},
                                ],
                                [
                                    { text: 'NoOrden:', bold: true },
                                    { text: entity.noOrden },
                                    { text: 'F. Orden:', bold: true },
                                    { text: entity.sFechaOrden }
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
                                    { text: 'Teléfonos:', bold: true },
                                    entity.paciente.telefono,
                                    { text: 'TipoUsuario:', bold: true },
                                    entity.tipoUsuario,
                                ],
                                [
                                    { text: 'Convenio:', bold: true },
                                    entity.convenio.nombreConvenio,
                                    { text: 'EPS:', bold: true },
                                    entity.convenio.nombreEps,                                    
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
                            widths: ['15%', '75%', '10%'],
                            body: tableOrdenDet
                        },
                        layout: {
                            hLineColor: 'lightgray',
                            vLineColor: 'lightgray',
                        },
                        margin: [0, 0, 0, 15],
                    },
                    {
                        text: 'Observaciones:', bold: true, style: 'estilo',
                    },
                    {
                        text: entity.observaciones, style: 'estilo',
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