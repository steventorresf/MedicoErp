(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'CentroAtencionService', 'DepartamentoService', 'MunicipioService'];

    function AppController($location, $scope, $cookies, cenService, depService, munService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.guardar = guardar;
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
            getByIdCentro();
            getDepartamentos();
        }

        function getByIdCentro() {
            var response = cenService.get(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.entity = response.data;
                    getMunicipios();
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

        function guardar() {
            var response = response = cenService.update(vm.entity.idCentro, vm.entity);
            response.then(
                function (response) {
                    alert("Los datos de su centro han sido actualizados correctamente.");
                    window.location.reload();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
