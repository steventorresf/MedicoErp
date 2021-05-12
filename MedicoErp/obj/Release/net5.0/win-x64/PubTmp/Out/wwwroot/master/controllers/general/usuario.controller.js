(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'MenuUsuarioService', 'UsuarioService', 'TablaDetalleService'];

    function AppController($location, $scope, $cookies, menusuService, usuService, tabdetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        vm.upEstado = upEstado;
        vm.getMenuUsuario = getMenuUsuario;
        vm.agregarMenuUsuario = agregarMenuUsuario;
        vm.regresarMenuUsu = regresarMenuUsu;
        vm.quitarMenuUsu = quitarMenuUsu;
        vm.entity = {};


        vm.listSexo = [
            { codigo: 'M', descripcion: 'MASCULINO' },
            { codigo: 'F', descripcion: 'FEMENINO' },
        ];

        vm.listBool = [
            { codigo: 'false', descripcion: 'NO' },
            { codigo: 'true', descripcion: 'SI' }
        ];

        vm.listAvatar = [
            { codigo: 'not-image-usuario.jpg', descripcion: 'Sin Avatar' },
            { codigo: 'avatar-0.jpg', descripcion: 'avatar-0' },
            { codigo: 'avatar-1.jpg', descripcion: 'avatar-1' },
            { codigo: 'avatar-2.jpg', descripcion: 'avatar-2' },
            { codigo: 'avatar-3.jpg', descripcion: 'avatar-3' },
            { codigo: 'avatar-4.jpg', descripcion: 'avatar-4' },
            { codigo: 'avatar-5.jpg', descripcion: 'avatar-5' },
            { codigo: 'avatar-6.jpg', descripcion: 'avatar-6' },
            { codigo: 'avatar-7.jpg', descripcion: 'avatar-7' },
            { codigo: 'avatar-8.jpg', descripcion: 'avatar-8' },
            { codigo: 'avatar-9.jpg', descripcion: 'avatar-9' },
            { codigo: 'avatar-10.jpg', descripcion: 'avatar-10' },
            { codigo: 'avatar-11.jpg', descripcion: 'avatar-11' },
        ];

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getAll();
            getTiposIden();

            vm.gridVisible = true;
        }

        function getAll() {
            var response = usuService.getAll(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
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


        function nuevo() {
            vm.entity = {
                idCentro: vm.userApp.idCentro,
                avatar: 'not-image-usuario.jpg',
                codEstado: 'AC',
                clave: '-',
                creadoPor: vm.userApp.nombreUsuario,
            };

            vm.gridVisible = false;
            vm.formModify = false;
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.entity.esMedico = angular.copy(entity.esMedico).toString();
            vm.entity.sFechaNacimiento = new Date(angular.copy(entity.sFechaNacimiento).toString());

            vm.gridVisible = false;
            vm.formModify = true;
            vm.formVisible = true;
        }

        function guardar() {
            vm.entity.fechaNacimiento = vm.entity.sFechaNacimiento.DateErp(true);

            var response = null;
            if (vm.formModify) { response = usuService.update(vm.entity.idUsuario, vm.entity); }
            else { response = usuService.create(vm.entity); }

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
                    name: 'docIdentidad',
                    field: 'docIdentidad',
                    displayName: 'Doc. Identidad',
                    headerCellClass: 'bg-header',
                    width: 130,
                },
                {
                    name: 'nombreCompleto',
                    field: 'nombreCompleto',
                    displayName: 'Nombre Completo',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'codSexo',
                    field: 'codSexo',
                    displayName: 'Sexo',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nomUsuario',
                    field: 'nomUsuario',
                    displayName: 'Nom Usuario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 150,
                },
                {
                    name: 'esMedicoDesc',
                    field: 'esMedicoDesc',
                    displayName: '¿Es Medico?',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
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
                    name: 'toolEd',
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
                },
                {
                    name: 'toolEs',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span ng-if='row.entity.codEstado === \"AC\"' class='ml-1'><a href='' ng-click='grid.appScope.vm.upEstado(row.entity.idServicio, false)' tooltip='Inactivar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-ban text-danger'></i></a></span>" +
                        "<span ng-if='row.entity.codEstado === \"IN\"' class='ml-1'><a href='' ng-click='grid.appScope.vm.upEstado(row.entity.idServicio, true)' tooltip='Inactivar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-ban text-info'></i></a></span>",
                    width: 100,
                },
                {
                    name: 'toolMen',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.getMenuUsuario(row.entity)' tooltip='Menú' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-bars text-success'></i></a></span>",
                    width: 100,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function getMenuUsuario(entity) {
            vm.entityUsu = angular.copy(entity);

            getAllByIdUsuario();
            getNotAllByIdUsuario();

            vm.gridVisible = false;
            vm.gridMenuUsuVisible = true;
        }

        function getAllByIdUsuario() {
            vm.gridOptionsMenu.data = [];

            var response = menusuService.getAllByIdUsuario(vm.entityUsu.idUsuario);
            response.then(
                function (response) {
                    vm.gridOptionsMenu.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getNotAllByIdUsuario() {
            vm.listMenu = [];

            var response = menusuService.getNotAllByIdUsuario(vm.entityUsu.idUsuario);
            response.then(
                function (response) {
                    vm.listMenu = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresarMenuUsu() {
            vm.gridMenuUsuVisible = false;
            vm.gridVisible = true;
        }

        function agregarMenuUsuario() {
            var data = {
                idMenu: vm.idMenu,
                idUsuario: vm.entityUsu.idUsuario,
            };

            var response = menusuService.create(data);
            response.then(
                function (response) {
                    vm.idMenu = null;
                    getAllByIdUsuario();
                    getNotAllByIdUsuario();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsMenu = {
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
                    name: 'menu.descripcion',
                    field: 'menu.descripcion',
                    displayName: 'Descripción',
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
                        "<span><a href='' ng-click='grid.appScope.vm.quitarMenuUsu(row.entity)' tooltip='Quitar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiMenu = gridApi;
            },
        };

        function quitarMenuUsu(entity) {
            var response = menusuService.remove(entity.idMenuUsuario);
            response.then(
                function (response) {
                    getAllByIdUsuario();
                    getNotAllByIdUsuario();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
