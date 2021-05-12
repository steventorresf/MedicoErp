(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'CentroAtencionService', 'DepartamentoService', 'MunicipioService'];

    function AppController($location, $scope, $cookies, extService, depService, munService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.onChangeDepartamento = onChangeDepartamento;
        vm.entity = {};

        vm.listEstados = [
            { codigo: 'AC', descripcion: 'ACTIVO', },
            { codigo: 'IN', descripcion: 'INACTIVO', }
        ];

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            vm.gridVisible = true;
            getAll();
            getDepartamentos();
        }

        function getAll() {
            var response = extService.getAllExternos(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getDepartamentos() {
            var response = depService.getAll();
            response.then(
                function (response) {
                    vm.listDepartamentos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeDepartamento($item, $model) {
            vm.entity.codMunicipio = null;
            getMunicipios();
        }

        function getMunicipios() {
            var response = munService.getAll(vm.entity.codDepartamento);
            response.then(
                function (response) {
                    vm.listMunicipios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function nuevo() {
            vm.entity = {
                idPadre: vm.userApp.idCentro,
                externo: true,
                codEstado: Estados.Activo,
            };

            vm.formModify = false;
            vm.gridVisible = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            getMunicipios();
            vm.formModify = true;
            vm.gridVisible = false;
            vm.formVisible = true;
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
                    name: 'nitCentro',
                    field: 'nitCentro',
                    displayName: 'NIT',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreCentro',
                    field: 'nombreCentro',
                    displayName: 'Nombre Centro',
                    headerCellClass: 'bg-header',
                    width: 300,
                },
                {
                    name: 'codPrestador',
                    field: 'codPrestador',
                    displayName: 'Cod. Prestador',
                    headerCellClass: 'bg-header',
                    width: 120,
                },
                {
                    name: 'nomDepartamento',
                    field: 'nomDepartamento',
                    displayName: 'Departamento',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'nomMunicipio',
                    field: 'nomMunicipio',
                    displayName: 'Municipio',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'direccion',
                    field: 'direccion',
                    displayName: 'Dirección',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'Teléfono',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'nombreEstado',
                    field: 'nombreEstado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    width: 150,
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
                        "<span><a href='' ng-click='grid.appScope.vm.editar(row.entity)' tooltip='Editar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-edit text-success'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function guardar() {
            var response = null;
            if (vm.formModify) { response = extService.updateExterno(vm.entity.idCentro, vm.entity); }
            else { response = extService.create(vm.entity); }

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
            vm.gridVisible = true;
        }

    }
})();
