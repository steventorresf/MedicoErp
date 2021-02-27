(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$cookies', 'AdminUsuariosService'];

    function AppController($location, $cookies, usuService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.init = init;
        vm.loginUsu = loginUsu;
        vm.entity = {};

        function init() {
            
        }

        function loginUsu() {
            var response = usuService.Login(vm.entity);
            response.then(
                function (response) {
                    var data = response.data;
                    if (data.respuesta === 'TodoOkey') {
                        $cookies.putObject('UsuApp', data);
                        window.location.href = url + 'Home';
                    }
                    else { fnMessenger(data.respuesta, 'error'); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();