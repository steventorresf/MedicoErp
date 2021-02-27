(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'HistClinicaEventosService', 'HistClinicaOrdenesService', 'HistClinicaOrdenesDetalleTempService', 'AdminServiciosService'];

    function AppController($location, $scope, $cookies, eveService, ordService, orddettempService, serService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));

        vm.init = init;
        vm.entity = {};
        vm.entityOrd = {
            idEvento: IdEvento,
            idMedico: vm.userApp.idUsuario,
            codEstado: Estados.Activo,
            creadoPor: vm.userApp.nombreUsuario,
        };
        vm.entityOrdDet = {
            idUsuario: vm.userApp.idUsuario,
        };

        vm.agregarServicio = agregarServicio;
        vm.guardar = guardar;
        vm.eliminar = eliminar;
        vm.regresar = regresar;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }
        
        function init() {
            vm.gridVisible = true;
            getEvento();
            getOrdenDetalleTemp();
            getServicios();
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

        function getOrdenDetalleTemp() {
            var response = orddettempService.getAllByIdUsuario(vm.userApp.idUsuario);
            response.then(
                function (response) {
                    vm.gridOptionsOrd.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getServicios() {
            var response = serService.getAll(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listServicios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregarServicio() {
            var response = orddettempService.create(vm.entityOrdDet);
            response.then(
                function (response) {
                    getOrdenDetalleTemp();
                    vm.entityOrdDet = {
                        idUsuario: vm.userApp.idUsuario,
                    };
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsOrd = {
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
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
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
                vm.gridApiOrd = gridApi;
            },
        };

        function eliminar(entity) {
            var response = orddettempService.remove(entity.idDetalle);
            response.then(
                function (response) {
                    getOrdenDetalleTemp();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardar() {
            var data = {
                entityOrd: vm.entityOrd,
                idCentro: vm.userApp.idCentro,
            };

            var response = ordService.create(data);
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
