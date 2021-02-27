(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminClasesServiciosService', AdminClasesServiciosService);

    AdminClasesServiciosService.$inject = ['$http', '$q'];

    function AdminClasesServiciosService($http, $q) {
        var nameSpace = '/Administracion/api/ClasesServicio/';

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
        .factory('AdminConveniosService', AdminConveniosService);

    AdminConveniosService.$inject = ['$http', '$q'];

    function AdminConveniosService($http, $q) {
        var nameSpace = '/Administracion/api/Convenios/';

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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminPacientesService', AdminPacientesService);

    AdminPacientesService.$inject = ['$http', '$q'];

    function AdminPacientesService($http, $q) {
        var nameSpace = '/Administracion/api/Pacientes/';

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
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdminServiciosService', AdminServiciosService);

    AdminServiciosService.$inject = ['$http', '$q'];

    function AdminServiciosService($http, $q) {
        var nameSpace = '/Administracion/api/Servicios/';

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
        .factory('AdminServiciosContratadosService', AdminServiciosContratadosService);

    AdminServiciosContratadosService.$inject = ['$http', '$q'];

    function AdminServiciosContratadosService($http, $q) {
        var nameSpace = '/Administracion/api/ServiciosContratados/';

        var service = {
            getAll: getAll,
            getAllNo: getAllNo,
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
        .factory('AdminUsuariosService', AdminUsuariosService);

    AdminUsuariosService.$inject = ['$http', '$q'];

    function AdminUsuariosService($http, $q) {
        var nameSpace = '/Administracion/api/Usuarios/';

        var service = {
            Login: Login,
            getAll: getAll,
            getAllMed: getAllMed,
            create: create,
            update: update,
            upEstado: upEstado,
            resetClave: resetClave,
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
            return $http.put(nameSpace + 'Reset/' + id + '/')
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
        .factory('AdmisionCitasService', AdmisionCitasService);

    AdmisionCitasService.$inject = ['$http', '$q'];

    function AdmisionCitasService($http, $q) {
        var nameSpace = '/Admision/api/Citas/';

        var service = {
            getAllHor: getAllHor,
            getAllFec: getAllFec,
            getAllFecMed: getAllFecMed,
            getAsigsConvenio: getAsigsConvenio,
            getAgendaMed: getAgendaMed,
            getMiAgenda: getMiAgenda,
            create: create,
            update: update,
            updateTar: updateTar,
            remove: remove,
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

        function updateTar(data) {
            return $http.post(nameSpace + 'UpTar', data)
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
        .factory('AdmisionFacturacionService', AdmisionFacturacionService);

    AdmisionFacturacionService.$inject = ['$http', '$q'];

    function AdmisionFacturacionService($http, $q) {
        var nameSpace = '/Admision/api/Facturacion/';

        var service = {
            createFacturacion: createFacturacion,
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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('AdmisionHorariosService', AdmisionHorariosService);

    AdmisionHorariosService.$inject = ['$http', '$q'];

    function AdmisionHorariosService($http, $q) {
        var nameSpace = '/Admision/api/Horarios/';

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

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('GenDepartamentosService', GenDepartamentosService);

    GenDepartamentosService.$inject = ['$http', '$q'];

    function GenDepartamentosService($http, $q) {
        var nameSpace = '/General/api/Departamentos/';

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
        .factory('GenMenuUsuarioService', GenMenuUsuarioService);

    GenMenuUsuarioService.$inject = ['$http', '$q'];

    function GenMenuUsuarioService($http, $q) {
        var nameSpace = '/General/api/MenuUsuario/';
        var service = {
            setMenuUsuario: setMenuUsuario,
            getAllByIdUsuario: getAllByIdUsuario,
            getNotAllByIdUsuario: getNotAllByIdUsuario,
            create: create,
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
        .factory('GenMunicipiosService', GenMunicipiosService);

    GenMunicipiosService.$inject = ['$http', '$q'];

    function GenMunicipiosService($http, $q) {
        var nameSpace = '/General/api/Municipios/';

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
        .factory('GenTablasDetalleService', GenTablasDetalleService);

    GenTablasDetalleService.$inject = ['$http', '$q'];

    function GenTablasDetalleService($http, $q) {
        var nameSpace = '/General/api/TablasDetalle/';
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
        .factory('HistClinicaDiagnosticosService', HistClinicaDiagnosticosService);

    HistClinicaDiagnosticosService.$inject = ['$http', '$q'];

    function HistClinicaDiagnosticosService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Diagnosticos/';

        var service = {
            getByPrefix: getByPrefix,
            create: create,
            update: update,
            remove: remove,
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

        function updateTar(data) {
            return $http.post(nameSpace + 'UpTar', data)
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('HistClinicaFormulacionesDetalleTempService', HistClinicaFormulacionesDetalleTempService);

    HistClinicaFormulacionesDetalleTempService.$inject = ['$http', '$q'];

    function HistClinicaFormulacionesDetalleTempService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/FormulacionesDetalleTemp/';

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
        .factory('HistClinicaMultimediaService', HistClinicaMultimediaService);

    HistClinicaMultimediaService.$inject = ['$http', '$q'];

    function HistClinicaMultimediaService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Multimedia/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            getAllTemporalesByIdUsuario: getAllTemporalesByIdUsuario,
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
(function () {
    'use strict';

    angular
        .module('app')
        .factory('HistClinicaOrdenesService', HistClinicaOrdenesService);

    HistClinicaOrdenesService.$inject = ['$http', '$q'];

    function HistClinicaOrdenesService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/Ordenes/';

        var service = {
            getAllByIdEvento: getAllByIdEvento,
            getAllByIdPaciente: getAllByIdPaciente,
            create: create,
            update: update,
            remove: remove,
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

        function updateTar(data) {
            return $http.post(nameSpace + 'UpTar', data)
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
        .factory('HistClinicaOrdenesDetalleTempService', HistClinicaOrdenesDetalleTempService);

    HistClinicaOrdenesDetalleTempService.$inject = ['$http', '$q'];

    function HistClinicaOrdenesDetalleTempService($http, $q) {
        var nameSpace = '/HistoriaClinica/api/OrdenesDetalleTemp/';

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