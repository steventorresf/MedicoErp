(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ServicioService', 'ClaseServicioService', 'TipoServicioService'];

    function AppController($location, $scope, $cookies, serService, cserService, tserService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;
        $scope.upEstado = upEstado;
        vm.entity = {};

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getAll();
            getClasesServicio();
            getTiposServicio();
        }

        function getAll() {
            var response = serService.getAll(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getClasesServicio() {
            var response = cserService.getAll();
            response.then(
                function (response) {
                    vm.listClasesServicios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposServicio() {
            var response = tserService.getAll();
            response.then(
                function (response) {
                    vm.listTiposServicios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function nuevo() {
            vm.entity = {};
            vm.entity.idCentro = vm.userApp.idCentro;
            vm.entity.activo = true;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            var response = null;
            if (vm.formModify) { response = serService.update(vm.entity.idServicio, vm.entity); }
            else { response = serService.create(vm.entity); }

            response.then(
                function (response) {
                    cancelar();
                    getAll();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelar() {
            vm.formVisible = false;
        }

        function upEstado(idServicio, activo) {
            var data = {
                IdServicio: idServicio,
                Activo: activo,
            }

            var response = serService.upEstado(data);
            response.then(
                function (response) {
                    getAll();
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
                    name: 'codigoRef',
                    field: 'codigoRef',
                    displayName: 'CodigoRef',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Nombre Servicio',
                    headerCellClass: 'bg-header',
                    width: 400,
                },
                {
                    name: 'claseServicio.nombreClaseServicio',
                    field: 'claseServicio.nombreClaseServicio',
                    displayName: 'Clase Servicio',
                    headerCellClass: 'bg-header',
                    width: 300,
                },
                {
                    name: 'tipoServicio.nombreTipoServicio',
                    field: 'tipoServicio.nombreTipoServicio',
                    displayName: 'Tipo Servicio',
                    headerCellClass: 'bg-header',
                    width: 300,
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
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit text-success'></i></a></span>" +
                        "<span class='ml-1'><a href='' ng-click='grid.appScope.upEstado(row.entity.idServicio, false)' tooltip='Inactivar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-ban text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

    }
})();
