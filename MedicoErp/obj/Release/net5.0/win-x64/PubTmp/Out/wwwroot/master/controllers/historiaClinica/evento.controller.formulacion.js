(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ngDialog', 'EventoService', 'FormulacionService', 'FormulacionDetalleTempService', 'TablaDetalleService'];

    function AppController($location, $scope, $cookies, ngDialog, eveService, forService, fordettempService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));

        vm.init = init;
        vm.entity = {};
        vm.entityFor = {
            idEvento: IdEvento,
            idCentro: vm.userApp.idCentro,
            idMedico: vm.userApp.idUsuario,
            codEstado: Estados.Activo,
            creadoPor: vm.userApp.nombreUsuario,
        };
        vm.entityForDet = {};

        vm.agregarMed = agregarMed;
        vm.agregarMedicamento = agregarMedicamento;
        vm.cancelar = cancelar;
        vm.eliminar = eliminar;
        vm.guardar = guardar;
        vm.regresar = regresar;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }
        
        function init() {
            vm.gridVisible = true;
            getEvento();
            getFormulacionDetalleTemp();
            getViasAdmon();
        }

        function getEvento() {
            var response = eveService.getByIdEvento(IdEvento);
            response.then(
                function (response) {
                    vm.entity = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getFormulacionDetalleTemp() {
            var response = fordettempService.getAllByIdUsuario(vm.userApp.idUsuario);
            response.then(
                function (response) {
                    vm.gridOptionsFor.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getViasAdmon() {
            var response = tabdetService.getAll(Tab.ViasAdmon);
            response.then(
                function (response) {
                    vm.listViasAdmon = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregarMedicamento() {
            var response = fordettempService.create(vm.entityForDet);
            response.then(
                function (response) {
                    cancelar();
                    getFormulacionDetalleTemp();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsFor = {
            data: [],
            enableSorting: false,
            enableRowSelection: false,
            enableFullRowSelection: false,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: false,
            columnDefs: [
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cant',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'medicamento',
                    field: 'medicamento',
                    displayName: 'Medicamento',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'viaAdmon',
                    field: 'viaAdmon',
                    displayName: 'Via Admon',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'posologia',
                    field: 'posologia',
                    displayName: 'Posologia',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.eliminar(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFor = gridApi;
            },
        };

        function eliminar(entity) {
            var response = fordettempService.remove(entity.idDetalle);
            response.then(
                function (response) {
                    getFormulacionDetalleTemp();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregarMed() {
            vm.entityForDet = {
                idUsuario: vm.userApp.idUsuario,
            };
            vm.gridVisible = false;
            vm.formVisible = true;
        }

        function cancelar() {
            vm.formVisible = false;
            vm.gridVisible = true;
        }

        function guardar() {
            var response = forService.create(vm.entityFor);
            response.then(
                function (response) {
                    regresar();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresar() {
            window.location.href = url + 'HistoriaClinica/Menu/Evento?ide=' + vm.entity.idEvento;
        }

    }
})();
