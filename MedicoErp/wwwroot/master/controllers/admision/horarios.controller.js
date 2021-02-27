(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'AdmisionHorariosService', 'AdminUsuariosService'];

    function AppController($location, $scope, $cookies, horService, usuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.nuevo = nuevo;
        vm.editar = editar;
        vm.guardar = guardar;
        vm.cancelar = cancelar;
        $scope.editar = editar;
        vm.entity = {};
        vm.getHorarios = getHorarios;
        vm.validarHoraFinal = validarHoraFinal;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getAllMedicos();
        }

        function getAllMedicos() {
            var response = usuService.getAllMed(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listMedicos = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getHorarios() {
            var response = horService.getAllHor(vm.idMedico);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }



        function validarHoraFinal() {
            var HoraInicial = "1900-01-01 " + fnValidarHora(vm.entity.horaInicial);

            if (moment(HoraInicial).isValid() && vm.entity.numPac > 0 && vm.entity.minPac >= 15) {
                var HoraFinal = moment(HoraInicial).add(vm.entity.numPac * vm.entity.minPac, "minutes");
                vm.entity.horaFinal = moment(HoraFinal).format("hh:mm a");
            }
            else { vm.entity.horaFinal = ''; }
        }

        function nuevo() {
            vm.entity = {};
            vm.entity.idCentro = vm.userApp.idCentro;
            multiDatesPicker("txtFechas", []);
            vm.formVisible = true;
        }

        function editar(entity) {
            vm.entity = angular.copy(entity);
            vm.formVisible = true;
        }

        function guardar() {
            vm.entity.fechas = $("#txtFechas").multiDatesPicker('getDates');
            if (vm.entity.fechas.length > 0) {
                vm.entity.idMedico = angular.copy(vm.idMedico);
                vm.entity.idCentro = vm.userApp.idCentro;
                var response = horService.create(vm.entity);
                response.then(
                    function (response) {
                        if (response.data === "") {
                            cancelar();
                            getHorarios();
                        }
                        else { alert(response.data); }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
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
                    name: 'fecha',
                    field: 'fecha',
                    displayName: 'Fecha',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    cellFilter: 'date:\'yyyy-MM-dd\'',
                },
                {
                    name: 'sHoraInicial',
                    field: 'sHoraInicial',
                    displayName: 'HoraInicial',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                },
                {
                    name: 'sHoraFinal',
                    field: 'sHoraFinal',
                    displayName: 'HoraFinal',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                },
                {
                    name: 'nombreEstado',
                    field: 'nombreEstado',
                    displayName: 'Estado',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
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
                        "<i class='fa fa-edit text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

    }
})();