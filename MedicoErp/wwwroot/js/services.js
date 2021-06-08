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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ConvenioService', ConvenioService);

    ConvenioService.$inject = ['$http', '$q'];

    function ConvenioService($http, $q) {
        var nameSpace = url + 'Admision/api/Convenio/';

        var service = {
            getAll: getAll,
            getAllAct: getAllAct,
            create: create,
            update: update,
            updateEst: updateEst,
        };

        return service;

        function getAll(idc) {
            return $http.get(nameSpace + idc)
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

        function getAllAct(idc) {
            return $http.get(nameSpace + 'Act/' + idc)
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

        function updateEst(data) {
            return $http.post(nameSpace + 'UpEst/', data)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ConvenioServicioService', ConvenioServicioService);

    ConvenioServicioService.$inject = ['$http', '$q'];

    function ConvenioServicioService($http, $q) {
        var nameSpace = url + 'Admision/api/ConvenioServicio/';

        var service = {
            getAll: getAll,
            getAllNo: getAllNo,
            getByIdServicio: getByIdServicio,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getAll(idc) {
            return $http.get(nameSpace + idc)
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

        function getAllNo(idCen, idCon) {
            return $http.get(nameSpace + 'GetNo/' + idCen + '/' + idCon)
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

        function getByIdServicio(idCon, idSer) {
            return $http.get(nameSpace + 'ByIdSer/' + idCon + '/' + idSer)
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

        function update(data) {
            return $http.post(nameSpace + 'UpTar/', data)
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

        function remove(id) {
            return $http.delete(nameSpace + id)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FacturacionService', FacturacionService);

    FacturacionService.$inject = ['$http', '$q'];

    function FacturacionService($http, $q) {
        var nameSpace = url + 'Admision/api/Facturacion/';

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
                                        text: entity.medico.nombreCompleto,
                                        alignment: 'center',
                                        bold: true,
                                        fontSize: 14,
                                    },
                                    { text: ' ', },
                                    { text: ' ', },
                                ],
                                [
                                    {
                                        text: entity.medico.numIden,
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
                                        text: entity.medico.direccion,
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
                                        text: entity.medico.telefono,
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
                            widths: ['8%', '66%', '12%', '4%', '10%'],
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
                                    { text: entity.centroAtencionNombre, bold: true, colSpan: 2, },
                                    {},
                                ],
                                [
                                    { text: entity.centroAtencionDireccion, colSpan: 2 },
                                    {},
                                ],
                                [
                                    { text: entity.centroAtencionTelefono, colSpan: 2 },
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('HorarioService', HorarioService);

    HorarioService.$inject = ['$http', '$q'];

    function HorarioService($http, $q) {
        var nameSpace = url + 'Admision/api/Horario/';

        var service = {
            getAllHor: getAllHor,
            getAllFec: getAllFec,
            getAllFecMed: getAllFecMed,
            create: create,
            update: update,
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('PacienteService', PacienteService);

    PacienteService.$inject = ['$http', '$q'];

    function PacienteService($http, $q) {
        var nameSpace = url + 'Admision/api/Paciente/';

        var service = {
            getByIden: getByIden,
            create: create,
            update: update,
        };

        return service;

        function getByIden(data) {
            return $http.post(nameSpace + 'Get/', data)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ServicioOrdenadoService', ServicioOrdenadoService);

    ServicioOrdenadoService.$inject = ['$http', '$q'];

    function ServicioOrdenadoService($http, $q) {
        var nameSpace = url + 'Admision/api/ServicioOrdenado/';

        var service = {
            getAllByIdPacAndIdCon: getAllByIdPacAndIdCon,
            create: create,
            updateTarifaDescuento: updateTarifaDescuento,
            remove: remove,
        };

        return service;

        function getAllByIdPacAndIdCon(idCentro, idpaciente, idConvenio) {
            return $http.get(nameSpace + idCentro + '/' + idpaciente + '/' + idConvenio)
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

        function remove(id) {
            return $http.delete(nameSpace + id)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('CentroAtencionService', CentroAtencionService);

    CentroAtencionService.$inject = ['$http', '$q'];

    function CentroAtencionService($http, $q) {
        var nameSpace = url + 'General/api/CentroAtencion/';

        var service = {
            get: get,
            getAll: getAll,
            getAllExternos: getAllExternos,
            create: create,
            update: update,
            updateExterno: updateExterno,
        };

        return service;

        function get(idCentro) {
            return $http.get(nameSpace + 'ById/' + idCentro)
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

        function getAll(idCentro) {
            return $http.get(nameSpace + idCentro)
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

        function getAllExternos(idCentro) {
            return $http.get(nameSpace + 'Ext/' + idCentro)
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

        function updateExterno(id, data) {
            return $http.post(nameSpace + 'Ext/' + id, data)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ClaseServicioService', ClaseServicioService);

    ClaseServicioService.$inject = ['$http', '$q'];

    function ClaseServicioService($http, $q) {
        var nameSpace = url + 'General/api/ClaseServicio/';

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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('DepartamentoService', DepartamentoService);

    DepartamentoService.$inject = ['$http', '$q'];

    function DepartamentoService($http, $q) {
        var nameSpace = url + 'General/api/Departamento/';

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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('MenuUsuarioService', MenuUsuarioService);

    MenuUsuarioService.$inject = ['$http', '$q'];

    function MenuUsuarioService($http, $q) {
        var nameSpace = url + 'General/api/MenuUsuario/';
        var service = {
            setMenuUsuario: setMenuUsuario,
            getAllByIdUsuario: getAllByIdUsuario,
            getNotAllByIdUsuario: getNotAllByIdUsuario,
            create: create,
            creates: creates,
            remove: remove
        };

        return service;

        function setMenuUsuario(idUsu) {
            return $http.get(nameSpace + 'GetMenu/' + idUsu)
                .then(
                    function (response) {
                        $("#MenuId").html(response.data);
                        return response;
                    },
                    function (errResponse) {
                        console.log(errResponse);
                        return $q.reject(errResponse);
                    }
                );
        }

        function getAllByIdUsuario(idUsu) {
            return $http.get(nameSpace + idUsu)
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

        function getNotAllByIdUsuario(idUsu) {
            return $http.get(nameSpace + 'Not/' + idUsu)
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

        function creates(data) {
            return $http.post(nameSpace + 'Creates/', data)
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

        function remove(idMenuUsu) {
            return $http.delete(nameSpace + idMenuUsu)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('MunicipioService', MunicipioService);

    MunicipioService.$inject = ['$http', '$q'];

    function MunicipioService($http, $q) {
        var nameSpace = url + 'General/api/Municipio/';

        var service = {
            getAll: getAll,
        };

        return service;

        function getAll(codDep) {
            return $http.get(nameSpace + codDep)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('ServicioService', ServicioService);

    ServicioService.$inject = ['$http', '$q'];

    function ServicioService($http, $q) {
        var nameSpace = url + 'General/api/Servicio/';

        var service = {
            getAll: getAll,
            create: create,
            update: update,
            upEstado: upEstado,
        };

        return service;

        function getAll(idc) {
            return $http.get(nameSpace + idc)
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

        function upEstado(data) {
            return $http.post(nameSpace + 'UpEst/', data)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('TablaDetalleService', TablaDetalleService);

    TablaDetalleService.$inject = ['$http', '$q'];

    function TablaDetalleService($http, $q) {
        var nameSpace = url + 'General/api/TablaDetalle/';
        var service = {
            getAll: getAll,
        };

        return service;

        function getAll(cod) {
            return $http.get(nameSpace + cod)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('TipoServicioService', TipoServicioService);

    TipoServicioService.$inject = ['$http', '$q'];

    function TipoServicioService($http, $q) {
        var nameSpace = url + 'General/api/TipoServicio/';

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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('UsuarioService', UsuarioService);

    UsuarioService.$inject = ['$http', '$q'];

    function UsuarioService($http, $q) {
        var nameSpace = url + 'General/api/Usuario/';

        var service = {
            Login: Login,
            getAll: getAll,
            getAllMed: getAllMed,
            create: create,
            update: update,
            upEstado: upEstado,
            resetClave: resetClave,
            updateContraseña: updateContraseña,
        };

        return service;

        function Login(data) {
            return $http.post(nameSpace + 'Login/', data)
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

        function getAll(idc) {
            return $http.get(nameSpace + idc)
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

        function getAllMed(idc) {
            return $http.get(nameSpace + 'Med/' + idc)
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

        function upEstado(data) {
            return $http.post(nameSpace + 'UpEst/', data)
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

        function resetClave(id) {
            return $http.post(nameSpace + 'Reset/' + id + '/')
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

        function updateContraseña(data) {
            return $http.post(nameSpace + 'UpClave/', data)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('EventoService', EventoService);

    EventoService.$inject = ['$http', '$q'];

    function EventoService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Evento/';

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
            return $http.post(nameSpace + idEvento, data)
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
            return $http.post(nameSpace + 'Finalizar/' + idEvento, data)
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
                    text: entity.medico.nombreCompleto,
                    alignment: 'center',
                    bold: true,
                    fontSize: 20,
                },
                {
                    text: entity.medico.numIden,
                    alignment: 'center',
                    bold: true,
                    style: 'estilo',
                },
                {
                    text: entity.medico.direccion,
                    alignment: 'center',
                    bold: true,
                    style: 'estilo',
                },
                {
                    text: entity.medico.telefono,
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
                                        { text: 'Diagnostico Relacional 1:', bold: true, },
                                        { text: entity.diagnosticoRel1 != null ? entity.diagnosticoRel1.nombreDiagnostico : '', },
                                    ],
                                    [
                                        { text: 'Diagnostico Relacional 2:', bold: true, },
                                        { text: entity.diagnosticoRel2 != null ? entity.diagnosticoRel2.nombreDiagnostico : '', },
                                    ],
                                    [
                                        { text: 'Diagnostico Relacional 3:', bold: true, },
                                        { text: entity.diagnosticoRel3 != null ? entity.diagnosticoRel3.nombreDiagnostico : '', },
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
                if (entity.firma != null) {
                    content.push(
                        {
                            image: 'data:image/png;base64,' + entity.firma,
                            width: 100,
                            height: 70,
                            alignment: 'center',
                        },
                    );
                }

                content.push(
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FolioService', FolioService);

    FolioService.$inject = ['$http', '$q'];

    function FolioService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Folio/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            getAllByIdFolio: getAllByIdFolio,
            create: create,
            anular: anular,
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

        function getAllByIdPaciente(idPaciente, idCentro) {
            return $http.get(nameSpace + 'ByIdPac/' + idPaciente + '/' + idCentro)
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

        function getAllByIdFolio(idFolio) {
            return $http.get(nameSpace + 'ByIdFolio/' + idFolio)
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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FolioDetalleService', FolioDetalleService);

    FolioDetalleService.$inject = ['$http', '$q'];

    function FolioDetalleService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/FolioDetalle/';

        var service = {
            getAllByIdFolio: getAllByIdFolio,
            update: update,
        };

        return service;


        function getAllByIdFolio(idEvento) {
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FormatoService', FormatoService);

    FormatoService.$inject = ['$http', '$q'];

    function FormatoService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Formato/';

        var service = {
            getAll: getAll,
            getAllNotEvento: getAllNotEvento,
        };

        return service;


        function getAll(idCentro) {
            return $http.get(nameSpace + idCentro)
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

        function getAllNotEvento(idCentro, idEvento) {
            return $http.get(nameSpace + 'NotEvento/' + idCentro + '/' + idEvento)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FormulacionService', FormulacionService);

    FormulacionService.$inject = ['$http', '$q'];

    function FormulacionService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/Formulacion/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            create: create,
            update: update,
            anular: anular,
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
                            widths: ['25%', '75%'],
                            body: [
                                [
                                    { text: entity.tiempoEvo != '' ? 'Tiempo Evolución:' : '', bold: true },
                                    { text: entity.tiempoEvo, }
                                ],
                                [
                                    { text: entity.proxControl != '' ? 'Próximo Control:' : '', bold: true },
                                    { text: entity.proxControl, }
                                ],
                                [
                                    { text: 'Observaciones:', bold: true },
                                    { text: entity.observaciones, }
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('FormulacionDetalleTempService', FormulacionDetalleTempService);

    FormulacionDetalleTempService.$inject = ['$http', '$q'];

    function FormulacionDetalleTempService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/FormulacionDetalleTemp/';

        var service = {
            getAllByIdUsuario: getAllByIdUsuario,
            create: create,
            remove: remove,
        };

        return service;

        function getAllByIdUsuario(idUsuario) {
            return $http.get(nameSpace + idUsuario)
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

        function remove(idDetalle) {
            return $http.delete(nameSpace + idDetalle)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('OrdenDetalleTempService', OrdenDetalleTempService);

    OrdenDetalleTempService.$inject = ['$http', '$q'];

    function OrdenDetalleTempService($http, $q) {
        var nameSpace = url + 'HistoriaClinica/api/OrdenDetalleTemp/';

        var service = {
            getAllByIdUsuario: getAllByIdUsuario,
            create: create,
            update: update,
            remove: remove,
        };

        return service;

        function getAllByIdUsuario(idUsuario) {
            return $http.get(nameSpace + idUsuario)
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

        function remove(idDetalle) {
            return $http.delete(nameSpace + idDetalle)
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