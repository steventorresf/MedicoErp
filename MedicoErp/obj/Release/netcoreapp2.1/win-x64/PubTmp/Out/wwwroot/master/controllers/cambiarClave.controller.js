(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', 'UsuarioService'];

    function AppController($location, $cookies, usuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.entity = {};
        vm.cerrarSesion = cerrarSesion;

        vm.entity = {
            idUsuario: vm.userApp.idUsuario,
            modificadoPor: vm.userApp.nombreUsuario,
        };

        vm.cambiarClave = cambiarClave;

        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            
        }

        function cambiarClave() {
            var response = usuService.updateContraseña(vm.entity);
            response.then(
                function (response) {
                    var Resp = response.data;
                    switch (Resp) {
                        case 1: {
                            alert("La contraseña ha sido actualizada correctamente.");
                            window.location.href = url + 'Home';
                            break;
                        }
                        case -1: alert("La contraseña actual es incorrecta."); break;
                        case -2: alert("La nueva contraseña no coincide."); break;
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        
    }
})();
