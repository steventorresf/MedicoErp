(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'EventoService', 'OrdenService', 'OrdenDetalleTempService', 'ServicioService', 'ConvenioServicioService'];

    function AppController($location, $scope, $cookies, eveService, ordService, orddettempService, serService, conserService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));

        vm.init = init;
        vm.entity = {};
        vm.entityOrd = {
            idEvento: IdEvento,
            idCentro: vm.userApp.idCentro,
            idMedico: vm.userApp.idUsuario,
            codEstado: Estados.Activo,
            creadoPor: vm.userApp.nombreUsuario,
        };
        vm.entityOrdDet = {
            idUsuario: vm.userApp.idUsuario,
        };

        vm.onChangeServicio = onChangeServicio;
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

        function onChangeServicio($item, $model) {
            vm.entitySer = $item;
            getByIdServicio()
        }

        function getByIdServicio() {
            var response = conserService.getByIdServicio(vm.entity.idConvenio, vm.entitySer.idServicio);
            response.then(
                function (response) {
                    var data = response.data;
                    if (data != undefined && data != null && data != "") {
                        vm.entityOrdDet.tarifa = data.tarifa;
                        vm.entityOrdDet.descuento = 0;
                    }
                    else {
                        vm.entityOrdDet.tarifa = 0;
                        vm.entityOrdDet.descuento = 0;
                    }
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
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cant',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'number: 0',
                    width: 100,
                },
                {
                    name: 'tarifa',
                    field: 'tarifa',
                    displayName: 'Tarifa',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'number: 0',
                    width: 100,
                },
                {
                    name: 'descuento',
                    field: 'descuento',
                    displayName: 'Descuento',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'number: 0',
                    width: 100,
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
                    enableCellEdit: false,
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.eliminar(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiOrd = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (colDef.name === 'tarifa' || colDef.name === 'descuento') {
                        update(rowEntity.idDetalle, rowEntity);
                    }
                });
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

        function update(id, data) {
            var response = orddettempService.update(id, data);
            response.then(
                function (response) {
                    
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardar() {
            var response = ordService.create(vm.entityOrd);
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
