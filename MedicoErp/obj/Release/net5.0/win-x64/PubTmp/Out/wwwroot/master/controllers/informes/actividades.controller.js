(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies'];

    function AppController($location, $scope, $cookies) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.generar = generar;
        
        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            
        }

        function generar() {
            var data = {
                fechaInicial: vm.entityBusq.sFechaInicial.DateErp(true),
                fechaFinal: vm.entityBusq.sFechaFinal.DateErp(true),
                idCentro: vm.userApp.idCentro,
            };
            
            window.location.href = url + 'Excel/Actividades?Fi=' + data.fechaInicial + '&Ff=' + data.fechaFinal + '&Ic=' + data.idCentro;
        }
    }
})();
