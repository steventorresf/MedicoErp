(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'PacienteService', 'EventoService', 'ConvenioService', 'TablaDetalleService'];

    function AppController($location, $scope, $cookies, pacService, eveService, conService, tabdetService) {
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
        vm.atenderEvento = atenderEvento;
        vm.imprimirEvento = imprimirEvento;
        vm.anularEvento = anularEvento;
        vm.nuevoEvento = nuevoEvento;
        vm.cancelar = cancelar;
        vm.generarEvento = generarEvento;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            vm.gridVisible = true;

            getTiposIden();
            getAllConvenios();

            vm.entityPac = {};
            vm.gridOptionsEve.data = [];
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
                        }
                        else { vm.entityPac.nombrePaciente = 'No existe un paciente con ese documento de identidad'; }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function getAllConvenios() {
            var response = conService.getAllAct(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listConvenios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
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
                        "<span><a href='' ng-click='grid.appScope.vm.atenderEvento(row.entity)' tooltip='Atender' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-folder-open text-primary'></i></a></span>" +
                        "<span class='ml-2'><a href='' ng-click='grid.appScope.vm.imprimirEvento(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>" +
                        "<span ng-if='row.entity.tipoEvento === \"E\"' class='ml-2'><a href='' ng-click='grid.appScope.vm.anularEvento(row.entity)' tooltip='Anular' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-trash text-danger'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiEve = gridApi;
            },
        };

        function atenderEvento(entity) {
            window.location.href = url + 'HistoriaClinica/Menu/Evento?ide=' + entity.idEvento;
        }

        function imprimirEvento(entity) {
            eveService.imprimirEvento(entity.idEvento, 0);
        }

        function anularEvento(entity) {
            var data = {
                idEvento: entity.idEvento,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            var response = eveService.anular(data);
            response.then(
                function (response) {
                    var val = response.data;
                    if (val > 0) {
                        getEventos();
                    }
                    else { alert("El evento tiene ordenes facturadas."); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function nuevoEvento() {
            vm.gridVisible = false;
            vm.formVisible = true;
        }

        function cancelar() {
            vm.formVisible = false;
            vm.gridVisible = true;
        }

        function generarEvento() {
            var data = {
                tipoEvento: 'E',
                idCentro: vm.userApp.idCentro,
                idPaciente: vm.entityPac.idPaciente,
                idMedico: vm.userApp.idUsuario,
                tipoIden: vm.entityPac.tipoIden,
                numIden: vm.entityPac.numIden,
                idConvenio: vm.entity.idConvenio,
                codEstado: Estados.Pendiente,
                creadoPor: vm.userApp.nombreUsuario,
            };

            var response = eveService.createExt(data);
            response.then(
                function (response) {
                    cancelar();
                    getEventos();
                },
                function (response) {
                    console.log(response);
                }
            );

        }

    }
})();
