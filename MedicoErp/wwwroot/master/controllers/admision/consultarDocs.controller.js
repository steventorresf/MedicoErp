(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'TablaDetalleService', 'PacienteService', 'FacturacionService'];

    function AppController($location, $scope, $cookies, tabdetService, pacService, factService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.consultarByDoc = consultarByDoc;
        vm.consultarByPac = consultarByPac;
        vm.imprimirDoc = imprimirDoc;
        vm.regresar = regresar;
        
        vm.entityBusq = {};
        vm.entityPac = {};

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getTiposIden();
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

        function consultarByDoc() {
            var data = {
                tipoDoc: vm.entityBusq.tipoDoc,
                numDoc: vm.entityBusq.numDoc,
                idCentro: vm.userApp.idCentro,
            };

            var response = factService.getIdDocumento(data);
            response.then(
                function (response) {
                    if (response.data > 0) {
                        factService.imprimirVol(response.data);
                    }
                    else { alert('No existe documento.'); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function consultarByPac() {
            var data = {
                TipoIden: vm.entityBusq.tipoDocPac,
                NumIden: vm.entityBusq.numDocPac,
                IdCentro: vm.userApp.idCentro,
            };

            var response = pacService.getByIden(data);
            response.then(
                function (response) {
                    vm.entityPac = response.data;
                    if (vm.entityPac != null && vm.entityPac != undefined && vm.entityPac != '') {
                        getAllByIdPaciente();
                    }
                    else { alert('No existe paciente.'); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getAllByIdPaciente() {
            vm.gridOptions.data = [];
            var response = factService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;

                    $("#RowBusqueda").attr('hidden', 'hidden');
                    $("#RowPaciente").removeAttr('hidden');
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
                    name: 'tipoDocumento',
                    field: 'tipoDocumento',
                    displayName: 'Tipo Doc',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'numDocumento',
                    field: 'numDocumento',
                    displayName: '#',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'sFechaPago',
                    field: 'sFechaPago',
                    displayName: 'Fecha',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                },
                {
                    name: 'convenio.nombreConvenio',
                    field: 'convenio.nombreConvenio',
                    displayName: 'Convenio',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'creadoPor',
                    field: 'creadoPor',
                    displayName: 'Usuario',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 200,
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
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirDoc(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function imprimirDoc(entity) {
            factService.imprimirVol(entity.idFacturacion);
        }

        function regresar() {
            $("#RowPaciente").attr('hidden', 'hidden');
            $("#RowBusqueda").removeAttr('hidden');
        }
    }
})();
