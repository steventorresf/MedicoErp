﻿(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$scope', '$location', '$cookies'];

    function AppController($scope, $location, $cookies) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.entity = {};
        vm.cerrarSesion = cerrarSesion;

        function init() {
            
        }

        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

    }
})();
