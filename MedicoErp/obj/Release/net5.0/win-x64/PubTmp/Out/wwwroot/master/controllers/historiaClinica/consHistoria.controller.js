(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'PacienteService', 'EventoService', 'FolioService', 'FormulacionService', 'OrdenService', 'MultimediaService', 'TablaDetalleService'];

    function AppController($location, $scope, $cookies, pacService, eveService, foService, forService, ordService, mulService, tabdetService) {
        var vm = this;

        vm.col1 = true;
        vm.col2 = false;
        vm.formPac = false;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        
        vm.entity = {};
        vm.entityPac = {};
        
        vm.getPacienteByIden = getPacienteByIden;
        vm.imprimirEvento = imprimirEvento;
        vm.imprimirFolio = imprimirFolio;
        vm.imprimirFormulacion = imprimirFormulacion;
        vm.imprimirOrden = imprimirOrden;
        vm.imprimirMultimedia = imprimirMultimedia;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getTiposIden();

            vm.entityPac = {};
            vm.gridOptionsEve.data = [];
            vm.gridOptionsFrm.data = [];
            vm.gridOptionsFor.data = [];
            vm.gridOptionsOrd.data = [];
            vm.gridOptionsMul.data = [];
        }

        function getTiposIden() {
            var response = tabdetService.getAll(Tab.TiposIden);
            response.then(
                function (response) {
                    vm.listTiposIden = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getPacienteByIden() {
            vm.entityPac = {};
            vm.gridOptionsEve.data = [];
            vm.gridOptionsFor.data = [];
            vm.gridOptionsOrd.data = [];
            vm.gridOptionsMul.data = [];

            if (vm.entity.tipoIden != null && vm.entity.tipoIden != undefined && vm.entity.numIden != '' && vm.entity.numIden != undefined) {
                var data = {
                    IdCentro: vm.userApp.idCentro,
                    TipoIden: vm.entity.tipoIden,
                    NumIden: vm.entity.numIden,
                };

                var response = pacService.getByIden(data);
                response.then(
                    function (response) {
                        if (response.data != null) {
                            vm.entityPac = response.data;
                            getEventos();
                            getFolios();
                            getFormulaciones();
                            getOrdenes();
                            getMultimedia();
                        }
                        else { vm.entityPac.nombrePaciente = 'No existe un paciente con ese documento de identidad'; }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function getEventos() {
            var response = eveService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptionsEve.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsEve = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'sFechaEvento',
                    field: 'sFechaEvento',
                    displayName: 'Fecha',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'nombreConvenio',
                    field: 'convenio.nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombreMedico',
                    field: 'medico.nombreCompleto',
                    displayName: 'Médico',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirEvento(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiEve = gridApi;
            },
        };

        function imprimirEvento(entity) {
            eveService.imprimirEvento(entity.idEvento, 0);
        }



        function getFolios() {
            var response = foService.getAllByIdPaciente(vm.entityPac.idPaciente, vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.gridOptionsFrm.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsFrm = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'noFolio',
                    field: 'noFolio',
                    displayName: 'NoFolio',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 90,
                },
                {
                    name: 'evento.noEvento',
                    field: 'evento.noEvento',
                    displayName: 'NoEvento',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 90,
                },
                {
                    name: 'sFechaFolio',
                    field: 'sFechaFolio',
                    displayName: 'Fecha',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirFolio(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFrm = gridApi;
            },
        };

        function imprimirFolio(entity) {
            eveService.imprimirEvento(entity.idEvento, entity.idFolio);
        }



        function getFormulaciones() {
            var response = forService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptionsFor.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsFor = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'sFechaFormulacion',
                    field: 'sFechaFormulacion',
                    displayName: 'Fecha',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirFormulacion(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFor = gridApi;
            },
        };

        function imprimirFormulacion(entity) {
            forService.imprimirFormulacion(entity.idFormulacion);
        }



        function getOrdenes() {
            var response = ordService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptionsOrd.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsOrd = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'sFechaOrden',
                    field: 'sFechaOrden',
                    displayName: 'Fecha',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirOrden(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiOrd = gridApi;
            },
        };

        function imprimirOrden(entity) {
            ordService.imprimirOrden(entity.idOrden);
        }



        function getMultimedia() {
            var response = mulService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptionsMul.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsMul = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'sFechaCreacion',
                    field: 'sFechaCreacion',
                    displayName: 'Fecha Creación',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'noEvento',
                    field: 'noEvento',
                    displayName: 'NoEvento',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreArchivo',
                    field: 'nombreArchivo',
                    displayName: 'Nombre Archivo',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'creadoPor',
                    field: 'creadoPor',
                    displayName: 'CreadoPor',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirMultimedia(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-download text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiMul = gridApi;
            },
        };

        function imprimirMultimedia(entity) {
            window.open(url + 'Visor/Archivo?idm=' + entity.idMultimedia);
        }


    }
})();
