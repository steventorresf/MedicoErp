(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ngDialog', 'CitaService', 'EventoService'];

    function AppController($location, $scope, $cookies, ngDialog, citService, eveService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));

        vm.init = init;
        vm.getAll = getAll;
        vm.editarTarifa = editarTarifa;
        vm.regresar = regresar;
        vm.actuaizarTarifa = actuaizarTarifa;
        vm.atenderCita = atenderCita;

        vm.entity = {
            fecha: new Date(),
        };

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            vm.gridVisible = true;
            getAll();
        }


        function getAll() {
            vm.gridOptions.data = [];

            var data = {
                Fecha: new Date(vm.entity.fecha).toDateString(),
                IdMed: vm.userApp.idUsuario,
            };

            var response = citService.getMiAgenda(data);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptions = {
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
                    name: 'hora',
                    field: 'hora',
                    displayName: 'Hora',
                    headerCellClass: 'bg-header',
                    width: 120,
                },
                {
                    name: 'identificacion',
                    field: 'identificacion',
                    displayName: 'Identificación',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'nombrePaciente',
                    field: 'nombrePaciente',
                    displayName: 'Paciente',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 280,
                },
                {
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'bg-header',
                    width: 280,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    width: 350,
                },
                {
                    name: 'nombreEstado',
                    field: 'nombreEstado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'tarifa',
                    field: 'tarifa',
                    displayName: 'Tarifa',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'descuento',
                    field: 'descuento',
                    displayName: 'Descuento',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass:'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.editarTarifa(row.entity)' tooltip='Editar Tarifa' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-money text-success'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function editarTarifa(entity) {
            vm.entityCit = angular.copy(entity);
            vm.entityCit.sFecha = entity.sFecha + ' ' + entity.hora;

            vm.gridVisible = false;
            vm.formTarifa = true;
        }

        function regresar() {
            vm.formTarifa = false;
            vm.gridVisible = true;
        }

        function actuaizarTarifa() {
            var data = {
                idCita: vm.entityCit.idCita,
                tarifa: vm.entityCit.tarifa,
                descuento: vm.entityCit.descuento,
            };

            var response = citService.updateTarifaDescuento(data);
            response.then(
                function (response) {
                    regresar();
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function atenderCita() {
            vm.entity = angular.copy(vm.gridApi.selection.getSelectedRows()[0]);

            var data = {
                idCita: vm.entity.idCita,
                nomUsu: vm.userApp.nombreUsuario,
            };

            var response = eveService.atenderCita(data);
            response.then(
                function (response) {
                    var idEvento = response.data;
                    window.location.href = url + 'HistoriaClinica/Menu/Evento?ide=' + idEvento;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
