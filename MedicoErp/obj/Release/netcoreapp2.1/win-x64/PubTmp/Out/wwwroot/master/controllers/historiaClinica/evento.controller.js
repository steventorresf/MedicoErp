var nombreUsuario = '';

(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'EventoService', 'FolioService', 'FormatoService', 'FormulacionService', 'OrdenService', 'DiagnosticoService'];

    function AppController($location, $scope, $cookies, eveService, foService, formService, forService, ordService, diagService) {
        var vm = this;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        nombreUsuario = vm.userApp.nombreUsuario;

        vm.init = init;
        vm.entity = {};
        vm.entityViaAdmon = {};
        vm.entitySer = {};

        vm.abrirFolio = abrirFolio;
        vm.imprimirFolio = imprimirFolio;
        vm.crearFolio = crearFolio;

        vm.nuevaOrden = nuevaOrden;
        vm.nuevaFormula = nuevaFormula;

        vm.finalizarEvento = finalizarEvento;

        vm.imprimirEvento = imprimirEvento;
        vm.imprimirFormulacion = imprimirFormulacion;
        vm.imprimirOrden = imprimirOrden;

        vm.anularFolio = anularFolio;
        vm.anularFormulacion = anularFormulacion;
        vm.anularOrden = anularOrden;

        vm.refreshDiagPal = refreshDiagPal;
        vm.onChangeDiagPal = onChangeDiagPal;
        vm.refreshDiagRel1 = refreshDiagRel1;
        vm.onChangeDiagRel1 = onChangeDiagRel1;
        vm.refreshDiagRel2 = refreshDiagRel2;
        vm.onChangeDiagRel2 = onChangeDiagRel2;
        vm.refreshDiagRel3 = refreshDiagRel3;
        vm.onChangeDiagRel3 = onChangeDiagRel3;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }
        
        function init() {
            getEvento();
        }


        function getEvento() {
            vm.listDiagsPal = [];
            vm.listDiagsRel1 = [];
            vm.listDiagsRel2 = [];
            vm.listDiagsRel3 = [];

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

                    if (vm.entity.diagnosticoRel2 != null) {
                        vm.listDiagsRel2.push(vm.entity.diagnosticoRel2);
                    }

                    if (vm.entity.diagnosticoRel3 != null) {
                        vm.listDiagsRel3.push(vm.entity.diagnosticoRel3);
                    }

                    getFolios();
                    getFormatos();
                    getFormulaciones();
                    getOrdenes();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function imprimirEvento() {
            eveService.imprimirEvento(IdEvento, 0);
        }

        function getFolios() {
            var response = foService.getAllByIdEvento(vm.entity.idEvento);
            response.then(
                function (response) {
                    vm.gridOptionsFo.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsFo = {
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
                    name: 'noFolio',
                    field: 'noFolio',
                    displayName: '#',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'formato.nombreFormato',
                    field: 'formato.nombreFormato',
                    displayName: 'Folio',
                    headerCellClass: 'bg-header',
                },
                {
                    name: 'sFechaFolio',
                    field: 'sFechaFolio',
                    displayName: 'FechaFolio',
                    headerCellClass: 'bg-header',
                    width: 150,
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
                        "<span><a href='' ng-click='grid.appScope.vm.abrirFolio(row.entity)' tooltip='Abrir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-folder-open text-primary'></i></a></span>" +
                        "<span class='ml-1'><a href='' ng-click='grid.appScope.vm.imprimirFolio(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-print text-success'></i></a></span>" +
                        "<span class='ml-2'><a href='' ng-click='grid.appScope.vm.anularFolio(row.entity)' tooltip='Anular' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-trash text-danger'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFo = gridApi;
            },
        };

        function abrirFolio(entity) {
            window.location.href = url + 'HistoriaClinica/Menu/EventoFolio?ide=' + vm.entity.idEvento + '&idf=' + entity.idFolio;
        }

        function imprimirFolio(entity) {
            eveService.imprimirEvento(vm.entity.idEvento, entity.idFolio);
        }

        function anularFolio(entity) {
            var data = {
                idFolio: entity.idFolio,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            var response = foService.anular(data);
            response.then(
                function (response) {
                    getFolios();
                    getFormatos();
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        // Formatos
        function getFormatos() {
            var response = formService.getAllNotEvento(vm.entity.idCentro, vm.entity.idEvento);
            response.then(
                function (response) {
                    vm.gridOptionsForm.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsForm = {
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
                    name: 'nombreFormato',
                    field: 'nombreFormato',
                    displayName: 'Formato',
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
                        "<span ng-if='!row.entity.yaExiste'><a href='' ng-click='grid.appScope.vm.crearFolio(row.entity)' tooltip='Crear' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-plus text-success'></i></a></span>",
                    width: 100,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiForm = gridApi;
            },
        };

        function crearFolio(entity) {
            var data = {
                idEvento: vm.entity.idEvento,
                idCentro: vm.entity.idCentro,
                idFormato: entity.idFormato,
                codEstado: Estados.Pendiente,
                creadoPor: vm.userApp.nombreUsuario,
            };

            var response = foService.create(data);
            response.then(
                function (response) {
                    var idFolio = response.data;
                    if (idFolio > 0) {
                        window.location.href = url + 'HistoriaClinica/Menu/EventoFolio?ide=' + vm.entity.idEvento + '&idf=' + idFolio;
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        // Diagnosticos
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
                campo: Campos.DiagRel1,
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

        function refreshDiagRel2(prefix) {
            if (prefix.length > 2) {
                var data = {
                    prefix: prefix,
                };

                var response = diagService.getByPrefix(data);
                response.then(
                    function (response) {
                        vm.listDiagsRel2 = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeDiagRel2($item, $model) {
            vm.entity.diagnosticoRel2 = $item;

            var data = {
                campo: Campos.DiagRel2,
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

        function refreshDiagRel3(prefix) {
            if (prefix.length > 2) {
                var data = {
                    prefix: prefix,
                };

                var response = diagService.getByPrefix(data);
                response.then(
                    function (response) {
                        vm.listDiagsRel3 = response.data;
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function onChangeDiagRel3($item, $model) {
            vm.entity.diagnosticoRel3 = $item;

            var data = {
                campo: Campos.DiagRel3,
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
                        "<i class='fa fa-print text-success'></i></a></span>" +
                        "<span class='ml-2'><a href='' ng-click='grid.appScope.vm.anularFormulacion(row.entity)' tooltip='Anular' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-trash text-danger'></i></a></span>",
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

        function anularFormulacion(entity) {
            var data = {
                idFormulacion: entity.idFormulacion,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            var response = forService.anular(data);
            response.then(
                function (response) {
                    getFormulaciones();
                },
                function (response) {
                    console.log(response);
                }
            );
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
                        "<i class='fa fa-print text-success'></i></a></span>" +
                        "<span class='ml-2'><a href='' ng-click='grid.appScope.vm.anularOrden(row.entity)' tooltip='Anular' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-trash text-danger'></i></a></span>",
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

        function anularOrden(entity) {
            var data = {
                idOrden: entity.idOrden,
                modificadoPor: vm.userApp.nombreUsuario,
            };

            var response = ordService.anular(data);
            response.then(
                function (response) {
                    var val = response.data;
                    if (val > 0) {
                        getOrdenes();
                    }
                    else { alert("La orden tiene servicios facturados."); }
                },
                function (response) {
                    console.log(response);
                }
            );
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
