(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'AdminPacientesService', 'AdminConveniosService', 'AdminServiciosContratadosService', 'AdminUsuariosService', 'GenTablasDetalleService', 'AdmisionCitasService', 'AdmisionFacturacionService', 'AdmisionHorariosService', 'GenDepartamentosService', 'GenMunicipiosService'];

    function AppController($location, $scope, $cookies, pacService, conService, serconService, usuService, tabdetService, citService, factService, horService, depService, munService) {
        var vm = this;

        vm.col1 = true;
        vm.col2 = false;
        vm.formPac = false;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        vm.nuevoPac = nuevoPac;
        vm.guardarPac1 = guardarPac1;
        vm.guardarPac2 = guardarPac2;
        vm.cancelarPac = cancelarPac;
        
        vm.entity = {};
        vm.entityPac = {};
        vm.entityCon = {};
        vm.entitySer = {};
        vm.entityMed = {};
        vm.entityHor = {};

        vm.getPacienteByIden = getPacienteByIden;
        vm.onChangeConvenio = onChangeConvenio;
        vm.onChangeServicio = onChangeServicio;
        vm.onChangeMedico = onChangeMedico;
        vm.getDepartamentos = getDepartamentos;
        vm.getMunicipios = getMunicipios;
        vm.terminar = terminar;
        vm.imprimir = imprimir;

        vm.asignarCit = asignarCit;
        vm.trasladarCit = trasladarCit;
        vm.facturarCit = facturarCit;
        vm.eliminarCit = eliminarCit;
        vm.cancelar = cancelar;
        vm.cancelar2 = cancelar2;
        vm.asignCita = asignCita;
        vm.traslCita = traslCita;
        vm.elimiCita = elimiCita;
        vm.factCita = factCita;
        vm.factCitaCancelar = factCitaCancelar;

        vm.asign = false;
        vm.trasl = false;
        vm.elimi = false;

        vm.listSexos = [
            { codigo: 'M', descripcion: 'MASCULINO' },
            { codigo: 'F', descripcion: 'FEMENINO' },
        ];

        vm.listZonas = [
            { codigo: 'U', descripcion: 'URBANA' },
            { codigo: 'R', descripcion: 'RURAL' },
        ];

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getTiposIden();
            getAllConvenios();
            getAllMedicos();
            getDepartamentos();
            getEstadosCivil();
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

        function getPacienteByIden() {
            vm.entityPac = {};

            if (vm.entity.tipoIden != null && vm.entity.tipoIden != undefined && vm.entity.numIden != '' && vm.entity.numIden != undefined) {
                var data = {
                    IdCentro: vm.userApp.idCentro,
                    TipoIden: vm.entity.tipoIden,
                    NumIden: vm.entity.numIden,
                };

                var response = pacService.getByIden(data);
                response.then(
                    function (response) {
                        if (response.data != null) {
                            vm.entityPac = response.data;
                            vm.entityPac.identificacion = vm.entityPac.tipoIden + ' ' + vm.entityPac.numIden;
                            vm.entityPac.fechaNacimiento = new Date(angular.copy(vm.entityPac.fechaNacimiento));
                        }
                        else { vm.entityPac.nombrePaciente = 'No existe un paciente con ese documento de identidad'; }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function getAllConvenios() {
            var response = conService.getAllAct(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listConvenios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeConvenio($item, $model) {
            vm.entityCon = angular.copy($item);
            getCitasPendientesPac();
        }

        function getCitasPendientesPac() {
            var response = citService.getAsigsConvenio(vm.entityPac.idPaciente, vm.entity.idConvenio);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getServicios() {
            var response = serconService.getAll(vm.entityCit.idConvenio);
            response.then(
                function (response) {
                    vm.listServicios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function onChangeServicio($item, $model) {
            vm.entitySer = angular.copy($item);
            vm.entityCit.nombreServicio = $item.servicio.nombreServicio;
        }

        function asignarCit() {
            vm.entityCit = {};
            vm.entityCit.idConvenio = angular.copy(vm.entity.idConvenio);
            getServicios();

            $("#TxtFechaCita").datepicker('destroy');
            vm.gridOptionsHor.data = [];
            vm.asign = true;

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowDatosCita").removeAttr('hidden');
        }

        function trasladarCit() {
            vm.entityCit = angular.copy(vm.gridApi.selection.getSelectedRows()[0]);
            vm.entityCit.sFechaHora = vm.entityCit.sFecha + ' - ' + vm.entityCit.hora;
            vm.entityCit.idMedico = null;
            vm.entityCit.fecha = null;

            $("#TxtFechaCita").datepicker('destroy');
            vm.gridOptionsHor.data = [];

            vm.trasl = true;

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowDatosCita").removeAttr('hidden');
        }

        function eliminarCit() {
            vm.entityCit = angular.copy(vm.gridApi.selection.getSelectedRows()[0]);
            vm.elimi = true;

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowRecordatorio").removeAttr('hidden');
        }

        function cancelar() {
            vm.asign = false;
            vm.trasl = false;

            $("#RowDatosCita").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
        }

        function cancelar2() {
            vm.elimi = false;

            $("#RowRecordatorio").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
        }

        function getAllMedicos() {
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
            vm.entityMed = angular.copy($item);
            getFechasDisponibles();
        }

        function getFechasDisponibles() {
            $("#TxtFechaCita").datepicker('destroy');
            vm.gridOptionsHor.data = [];

            var response = horService.getAllFec(vm.entityCit.idMedico);
            response.then(
                function (response) {
                    datepicker("TxtFechaCita", response.data, onChangeFechaCita);
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsHor = {
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
                    name: 'sHoraInicial',
                    field: 'sHoraInicial',
                    displayName: 'HoraCita',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
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
                        "<span ng-if='grid.appScope.vm.asign'><a href='' ng-if='grid.appScope.formApp.$valid' ng-click='grid.appScope.vm.asignCita(row.entity)' tooltip='Asignar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-sign-in text-success'></i></a></span>" +
                        "<span ng-if='grid.appScope.vm.trasl'><a href='' ng-if='grid.appScope.formApp.$valid' ng-click='grid.appScope.vm.traslCita(row.entity)' tooltip='Trasladar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-sign-in text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiHor = gridApi;
            },
        };

        function onChangeFechaCita(date) {
            vm.gridOptionsHor.data = [];
            vm.entityCit.fecha = FormatDate(date);

            var data = {
                Fecha: vm.entityCit.fecha,
                IdMedico: vm.entityCit.idMedico,
            };

            var response = horService.getAllFecMed(data);
            response.then(
                function (response) {
                    vm.gridOptionsHor.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function asignCita(entity) {
            vm.entityHor = angular.copy(entity);
            vm.entityCit.idReserva = angular.copy(entity.idHorario);
            vm.entityCit.idPaciente = angular.copy(vm.entityPac.idPaciente);
            vm.entityCit.idCentro = vm.userApp.idCentro;
            vm.entityCit.cantidad = 1;
            vm.entityCit.tarifa = angular.copy(vm.entitySer.tarifa);
            vm.entityCit.codEstado = Estados.Agendado;
            vm.entityCit.nombreMedico = vm.entityMed.nombreCompleto;
            vm.entityCit.creadoPor = vm.userApp.nombreUsuario;
            vm.entityCit.hora = vm.entityHor.sHoraInicial;

            var response = citService.create(vm.entityCit);
            response.then(
                function (response) {
                    var resp = response.data;
                    if (resp === true) {
                        getMunicipios();
                        vm.modifyPac = true;

                        $("#RowDatosCita").attr('hidden', 'hidden');
                        $("#RowDatosPac").removeAttr('hidden');
                    }
                    else { alert(resp); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function traslCita(entity) {
            vm.entityHor = angular.copy(entity);
            vm.entityCit.idReserva = angular.copy(entity.idHorario);
            vm.entityCit.codEstado = Estados.Agendado;
            vm.entityCit.creadoPor = vm.userApp.nombreUsuario;
            vm.entityCit.modificadoPor = vm.userApp.nombreUsuario;
            vm.entityCit.nombreMedico = vm.entityMed.nombreCompleto;
            vm.entityCit.hora = vm.entityHor.sHoraInicial;

            var response = citService.update(vm.entityCit.idCita, vm.entityCit);
            response.then(
                function (response) {
                    var resp = response.data;
                    if (resp === true) {
                        getMunicipios();
                        vm.modifyPac = true;

                        $("#RowDatosCita").attr('hidden', 'hidden');
                        $("#RowDatosPac").removeAttr('hidden');
                    }
                    else { alert(resp); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function elimiCita() {
            var data = {
                IdCita: vm.entityCit.idCita,
                NomUsu: vm.userApp.nombreUsuario,
            };

            var response = citService.remove(data);
            response.then(
                function (response) {
                    var resp = response.data;
                    if (resp === true) {
                        $("#RowRecordatorio").attr('hidden', 'hidden');
                        $("#RowPrincipal").removeAttr('hidden');

                        getCitasPendientesPac();

                        vm.elimi = false;
                    }
                    else { alert(resp); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function nuevoPac() {
            vm.entityPac = {};
            vm.entityPac.idCentro = vm.userApp.idCentro;
            vm.modifyPac = false;

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowDatosPac").removeAttr('hidden');
        }

        function guardarPac1() {
            var response = pacService.create(vm.entityPac);
            response.then(
                function (response) {
                    cancelarPac();
                    vm.entityPac = response.data;
                    vm.formPac = false;
                    vm.col1 = true;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function guardarPac2() {
            var response = pacService.update(vm.entityPac.idPaciente, vm.entityPac);
            response.then(
                function (response) {
                    $("#RowDatosPac").attr('hidden', 'hidden');
                    $("#RowRecordatorio").removeAttr('hidden');
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelarPac() {
            $("#RowDatosPac").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
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

        function getMunicipios() {
            var response = munService.getAll(vm.entityPac.codDepartamento);
            response.then(
                function (response) {
                    vm.listMunicipios = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getEstadosCivil() {
            var response = tabdetService.getAll(Tab.EstadosCivil);
            response.then(
                function (response) {
                    vm.listEstadosCivil = response.data;
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
                    enableCellEdit: false,
                },
                {
                    name: 'hora',
                    field: 'hora',
                    displayName: 'Hora',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    enableCellEdit: false,
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 200,
                    enableCellEdit: false,
                },
                {
                    name: 'tarifa',
                    field: 'tarifa',
                    displayName: 'Tarifa',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
                    enableCellEdit: false,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };


        vm.listSexos = [
            { codigo: 'M', descripcion: 'MASCULINO' },
            { codigo: 'F', descripcion: 'FEMENINO' },
        ];

        vm.listZonas = [
            { codigo: 'U', descripcion: 'URBANA' },
            { codigo: 'R', descripcion: 'RURAL' },
        ];

        function terminar() {
            window.location.reload();
        }

        function imprimir() {
            window.location.href = url + 'Home';
        }



        function facturarCit() {
            vm.entityFact = {
                idCentro: vm.userApp.idCentro,
                tipo: vm.entityCon.codTipoFact,
                tipoDocumento: '?',
                idPaciente: vm.entityPac.idPaciente,
                idConvenio: vm.entityCon.idConvenio,
                codEstado: Estados.Activo,
                creadoPor: vm.userApp.nombreUsuario,
                valorTotal: 0,
            };

            var data = vm.gridApi.selection.getSelectedRows();
            vm.gridOptionsFact.data = data;
            for (var i = 0; i < data.length; i++) {
                vm.entityFact.valorTotal += data[i].tarifa;
            }

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowFacturacion").removeAttr('hidden');
        }

        function factCitaCancelar() {
            $("#RowFacturacion").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
        }

        vm.gridOptionsFact = {
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
                    enableCellEdit: false,
                },
                {
                    name: 'hora',
                    field: 'hora',
                    displayName: 'Hora',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 120,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreServicio',
                    field: 'nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    enableCellEdit: false,
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 200,
                    enableCellEdit: false,
                },
                {
                    name: 'tarifa',
                    field: 'tarifa',
                    displayName: 'Tarifa',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
                    enableCellEdit: false,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiFact = gridApi;
            },
        };

        function factCita() {
            var data = {
                entity: vm.entityFact,
                listaCitas: vm.gridOptionsFact.data,
            };
            var response = factService.createFacturacion(data);
            response.then(
                function (response) {
                    $("#RowFacturacion").attr('hidden', 'hidden');
                    $("#RowFacturacionPost").removeAttr('hidden');
                },
                function (response) {
                    console.log(response);
                }
            );
        }

    }
})();
