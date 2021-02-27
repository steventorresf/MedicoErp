(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'AdminUsuariosService', 'AdmisionCitasService'];

    function AppController($location, $scope, $cookies, usuService, citService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.onChangeMedico = onChangeMedico;
        vm.consultarAg = consultarAg;
        vm.descargarExcel = descargarExcel;
        
        vm.entity = {};
        vm.data = {};

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getMedicos();
        }

        function getMedicos() {
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

        function onChangeMedico($item, $model) {
            vm.entityMed = $item;
        }

        function consultarAg() {
            vm.gridOptions.data = [];

            vm.data = {
                fechaInicio: vm.entity.fechaInicio.toDateString(),
                fechaFin: vm.entity.fechaFin.toDateString(),
                idMedico: vm.entity.idMedico,
                medico: vm.entityMed.nombreCompleto,
            };

            var response = citService.getAgendaMed(vm.data);
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
                    name: 'sFecha',
                    field: 'sFecha',
                    displayName: 'Fecha',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'hora',
                    field: 'hora',
                    displayName: 'Hora',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'nombrePaciente',
                    field: 'nombrePaciente',
                    displayName: 'Paciente',
                    headerCellClass: 'bg-header',
                    width: 280,
                },
                {
                    name: 'identificacion',
                    field: 'identificacion',
                    displayName: 'Identificación',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'telefono',
                    field: 'telefono',
                    displayName: 'Teléfono',
                    headerCellClass: 'bg-header',
                    width: 150,
                },
                {
                    name: 'nombreConvenio',
                    field: 'nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'bg-header',
                    width: 250,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    width: 400,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function descargarExcel() {
            serviciosAjax.getAgendaMedica(vm.data);
        }
    }
})();
