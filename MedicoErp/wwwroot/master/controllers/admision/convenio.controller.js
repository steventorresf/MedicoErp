(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ngDialog', 'ConvenioService', 'ConvenioServicioService', 'TablaDetalleService'];

    function AppController($location, $scope, $cookies, ngDialog, conService, serconService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.formVisible = false;
        vm.formModify = false;
        vm.formVisibleTar = false;
        vm.formModifyTar = false;
        vm.entity = {};
        vm.entityTar = {};
        vm.idsServicio = [];

        vm.init = init;
        vm.getAll = getAll;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;

        vm.listTiposFact = [{ codValor: 'VO', descripcion: 'VOLANTE' }, { codValor: 'FA', descripcion: 'FACTURA' }];
        vm.listBool = [{ codigo: 'false', descripcion: 'NO' }, { codigo: 'true', descripcion: 'SI' }];

        vm.getServiciosContratados = getServiciosContratados;

        $scope.getServiciosContratados = getServiciosContratados;
        vm.nuevoTar = nuevoTar;
        vm.quitarTar = quitarTar;
        vm.guardarTar = guardarTar;
        vm.cancelarTar = cancelarTar;
        vm.regresarTar = regresarTar;
        $scope.quitarTar = quitarTar;

        vm.modoTar = false;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getAll();
            getTiposUsuario();
        }


        function getAll() {
            var response = conService.getAll(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getTiposUsuario() {
            var response = tabdetService.getAll(Tab.TiposUsuario);
            response.then(
                function (response) {
                    vm.listTiposUsuario = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevo() {
            vm.entity = {};
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
            if (vm.formModify) { response = conService.update(vm.entity.idConvenio, vm.entity); }
            else { response = conService.create(vm.entity); }

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
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'bg-header',
                    width: 400,
                },
                {
                    name: 'nombreEps',
                    field: 'nombreEps',
                    displayName: 'EPS',
                    headerCellClass: 'bg-header',
                    width: 300,
                },
                {
                    name: 'textTipoUsuario',
                    field: 'textTipoUsuario',
                    displayName: 'TipoUsuario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'tipoFacturacion',
                    field: 'tipoFacturacion',
                    displayName: 'TipoFacturacion',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },                
                {
                    name: 'nombreEstado',
                    field: 'nombreEstado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 130,
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
                        "<span><a href='' ng-click='grid.appScope.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit text-success'></i></a></span>" +
                        "<span><a href='' ng-click='grid.appScope.getServiciosContratados(row.entity)' tooltip='Tarifas' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-book text-info'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function getServiciosContratados(entity) {
            vm.entity = angular.copy(entity);
            vm.modoTar = true;
            getAllServiciosContratados();
        }

        function getAllServiciosContratados() {
            var response = serconService.getAll(vm.entity.idConvenio);
            response.then(
                function (response) {
                    vm.gridOptionsTar.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsTar = {
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
                    name: 'servicio.codigoRef',
                    field: 'servicio.codigoRef',
                    displayName: 'CódigoRef',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    enableCellEdit: false,
                    width: 120,
                },
                {
                    name: 'servicio.nombreServicio',
                    field: 'servicio.nombreServicio',
                    displayName: 'Nombre Servicio',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
                {
                    name: 'tarifa',
                    type: 'number',
                    field: 'tarifa',
                    displayName: 'Tarifa',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-right',
                    cellFilter: 'number: 0',
                    enableCellEdit: true,
                    width: 120,
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
                        "<span><a href='' ng-click='grid.appScope.quitarTar(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiTar = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (colDef.name === 'tarifa') {
                        var data = {
                            idDetalle: rowEntity.idDetalle,
                            tarifa: newValue,
                        };
                        updateTar(data);
                    }
                });
            },
        };

        function regresarTar() {
            vm.modoTar = false;
        }

        function updateTar(data) {
            var response = serconService.update(data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevoTar() {
            getAllNoContratados();
            vm.formVisibleTar = true;
        }

        function getAllNoContratados() {
            var response = serconService.getAllNo(vm.userApp.idCentro, vm.entity.idConvenio);
            response.then(
                function (response) {
                    vm.gridOptionsSerCon.data = response.data;
                    vm.listServicios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function quitarTar(entity) {
            var response = serconService.remove(entity.idDetalle);
            response.then(
                function (response) {
                    getAllServiciosContratados();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsSerCon = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: true,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'codigoRef',
                    field: 'codigoRef',
                    displayName: 'CódigoRef',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    enableCellEdit: false,
                    width: 120,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Nombre Servicio',
                    headerCellClass: 'bg-header',
                    enableCellEdit: false,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiSerCon = gridApi;
            },
        };

        function guardarTar() {
            var data = [];

            var grid = vm.gridApiSerCon.selection.getSelectedRows();
            for (var i = 0; i < grid.length; i++) {
                data.push({ idServicio: grid[i].idServicio, idConvenio: vm.entity.idConvenio, tarifa: 0 });
            }

            var response = serconService.create(data);
            response.then(
                function (response) {
                    cancelarTar();
                    getAllServiciosContratados();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelarTar() {
            vm.formVisibleTar = false;
        }
    }
})();
