(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'ngDialog', 'EventoService', 'FolioService', 'FolioDetalleService'];

    function AppController($location, $scope, $cookies, ngDialog, eveService, foService, fodetService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));

        vm.init = init;
        vm.imprimirFolio = imprimirFolio;
        vm.guardarFolio = guardarFolio;
        vm.regresarEvento = regresarEvento;

        vm.onChangeRespuesta = onChangeRespuesta;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }
        
        function init() {
            getEvento();
            getFolio();
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

        function getFolio() {
            var response = foService.getAllByIdFolio(IdFolio);
            response.then(
                function (response) {
                    vm.entityFol = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeRespuesta($item, $model, entity) {
            var data = angular.copy(entity);
            data.modificadoPor = vm.userApp.nombreUsuario;
            data.respuesta = entity.valor;

            if (data.tipoDato === 'CO') {
                data.respuesta = $item.nombreRespuesta;
            }
            if (data.tipoDato === 'FE') {

            }

            var response = fodetService.update(entity.idDetalle, data);
            response.then(
                function (response) {
                    
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardarFolio() {
            window.location.href = url + 'HistoriaClinica/Menu/Evento?ide=' + vm.entity.idEvento;
        }

        function imprimirFolio() {
            eveService.imprimirEvento(IdEvento, IdFolio);
        }

        function regresarEvento() {
            window.location.href = url + 'HistoriaClinica/Menu/Evento?ide=' + IdEvento;
        }

    }
})();
