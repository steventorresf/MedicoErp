var nombreUsuario = '';

(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'HistClinicaEventosService', 'HistClinicaFormulacionesService', 'HistClinicaOrdenesService', 'HistClinicaDiagnosticosService'];

    function AppController($location, $scope, $cookies, eveService, forService, ordService, diagService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        nombreUsuario = vm.userApp.nombreUsuario;

        vm.init = init;
        vm.entity = {};
        vm.entityViaAdmon = {};
        vm.entitySer = {};

        vm.nuevaOrden = nuevaOrden;
        vm.nuevaFormula = nuevaFormula;

        vm.onChangeEvolucion = onChangeEvolucion;
        vm.onChangeBiopsia = onChangeBiopsia;
        vm.onChangeAyudasDx = onChangeAyudasDx;
        vm.onChangeAnexos = onChangeAnexos;
        vm.finalizarEvento = finalizarEvento;

        vm.imprimirEvento = imprimirEvento;
        vm.imprimirFormulacion = imprimirFormulacion;
        vm.imprimirOrden = imprimirOrden;

        vm.refreshDiagPal = refreshDiagPal;
        vm.onChangeDiagPal = onChangeDiagPal;
        vm.refreshDiagRel1 = refreshDiagRel1;
        vm.onChangeDiagRel1 = onChangeDiagRel1;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }
        
        function init() {
            getEvento();
            getFormulaciones();
            getOrdenes();
        }


        function getEvento() {
            vm.listDiagsPal = [];
            vm.listDiagsRel1 = [];

            var response = eveService.getByIdEvento(IdEvento);
            response.then(
                function (response) {
                    vm.entity = response.data;

                    if (vm.entity.diagnosticoPal != null) {
                        vm.listDiagsPal.push(vm.entity.diagnosticoPal);
                    }

                    if (vm.entity.diagnosticoRel1 != null) {
                        vm.listDiagsRel1.push(vm.entity.diagnosticoRel1);
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function imprimirEvento() {
            eveService.imprimirEvento(vm.entity.idEvento);
        }

        function onChangeEvolucion() {
            var data = {
                campo: Campos.Evolucion,
                dato: vm.entity.evolucion === undefined ? '' : vm.entity.evolucion,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeBiopsia() {
            var data = {
                campo: Campos.Biopsia,
                dato: vm.entity.biopsiaAnterior === undefined ? '' : vm.entity.biopsiaAnterior,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshDiagPal(prefix) {
            if (prefix.length > 2) {
                var data = {
                    prefix: prefix,
                };

                var response = diagService.getByPrefix(data);
                response.then(
                    function (response) {
                        vm.listDiagsPal = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeDiagPal($item, $model) {
            vm.entity.diagnosticoPal = $item;

            var data = {
                campo: Campos.DiagPal,
                dato: $item.codigo,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function refreshDiagRel1(prefix) {
            if (prefix.length > 2) {
                var data = {
                    prefix: prefix,
                };

                var response = diagService.getByPrefix(data);
                response.then(
                    function (response) {
                        vm.listDiagsRel1 = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeDiagRel1($item, $model) {
            vm.entity.diagnosticoRel1 = $item;

            var data = {
                campo: Campos.DiagRel,
                dato: $item.codigo,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeAyudasDx() {
            var data = {
                campo: Campos.AyudaDx,
                dato: vm.entity.ayudasDiagnosticas === undefined ? '' : vm.entity.ayudasDiagnosticas,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeAnexos() {
            var data = {
                campo: Campos.Anexos,
                dato: vm.entity.anexos === undefined ? '' : vm.entity.anexos,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.update(vm.entity.idEvento, data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function getFormulaciones() {
            vm.gridOptionsFor.data = [];

            var response = forService.getAllByIdEvento(IdEvento);
            response.then(
                function (response) {
                    vm.gridOptionsFor.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsFor = {
            data: [],
            enableSorting: false,
            enableRowSelection: false,
            enableFullRowSelection: false,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: false,
            columnDefs: [
                {
                    name: 'noFormulacion',
                    field: 'noFormulacion',
                    displayName: '#',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'sFechaFormulacion',
                    field: 'sFechaFormulacion',
                    displayName: 'Fecha',
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
                    cellClass:'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirFormulacion(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFor = gridApi;
            },
        };

        function imprimirFormulacion(entity) {
            forService.imprimirFormulacion(entity.idFormulacion);
        }

        function nuevaFormula() {
            window.location.href = url + 'HistoriaClinica/Menu/EventoFormulacion?ide=' + vm.entity.idEvento;
        }

        


        function getOrdenes() {
            vm.gridOptionsOrd.data = [];

            var response = ordService.getAllByIdEvento(IdEvento);
            response.then(
                function (response) {
                    vm.gridOptionsOrd.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsOrd = {
            data: [],
            enableSorting: false,
            enableRowSelection: false,
            enableFullRowSelection: false,
            multiSelect: false,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: false,
            columnDefs: [
                {
                    name: 'noOrden',
                    field: 'noOrden',
                    displayName: '#',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'sFechaOrden',
                    field: 'sFechaOrden',
                    displayName: 'Fecha',
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
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirOrden(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiOrd = gridApi;
            },
        };

        function imprimirOrden(entity) {
            ordService.imprimirOrden(entity.idOrden);
        }

        function nuevaOrden() {
            window.location.href = url + 'HistoriaClinica/Menu/EventoOrdenMedica?ide=' + vm.entity.idEvento;
        }



        function finalizarEvento() {
            var data = {
                idEvento: vm.entity.idEvento,
                nombreUsuario: vm.userApp.nombreUsuario,
            };

            var response = eveService.finalizarEvento(vm.entity.idEvento, data);
            response.then(
                function (response) {
                    window.location.href = url + 'HistoriaClinica/Menu/Atender';
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
