(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'PacienteService', 'ConvenioService', 'ConvenioServicioService', 'ServicioOrdenadoService', 'TablaDetalleService', 'CentroAtencionService', 'FacturacionService', 'UsuarioService', 'DepartamentoService', 'MunicipioService'];

    function AppController($location, $scope, $cookies, pacService, conService, serconService, serordService, tabdetService, cenService, factService, usuService, depService, munService) {
        var vm = this;

        vm.col1 = true;
        vm.col2 = false;
        vm.formPac = false;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        
        vm.entity = {};
        vm.entityPac = {};
        vm.entityCon = {};
        vm.entityFact = {};

        vm.getPacienteByIden = getPacienteByIden;
        vm.onChangeConvenio = onChangeConvenio;

        vm.onChangeServicio = onChangeServicio;
        vm.agregar = agregar;
        vm.agregarServicio = agregarServicio;
        vm.cancelar = cancelar;
        vm.eliminarServicio = eliminarServicio;
        vm.facturar = facturar;
        vm.facturarSinCita = facturarSinCita;
        vm.regresar = regresar;

        vm.imprimirVolFact = imprimirVolFact;
        vm.terminar = terminar;

        vm.nuevoPac = nuevoPac;
        vm.getMunicipios = getMunicipios;
        vm.guardarPac1 = guardarPac1;
        vm.cancelarPac = cancelarPac;


        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {
            getTiposIden();
            getCentros();
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
            vm.entity.idConvenio = null;

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

        function getCentros() {
            var response = cenService.getAll(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listCentros = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
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
            getServiciosOrdenados();
        }

        function getServiciosOrdenados() {
            var response = serordService.getAllByIdPacAndIdCon(vm.userApp.idCentro, vm.entityPac.idPaciente, vm.entity.idConvenio);
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
            var response = serconService.getAll(vm.entity.idConvenio);
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
            vm.entitySerOrd.cantidad = 1;
            vm.entitySerOrd.tarifa = $item.tarifa;
        }

        function getAllMedicos() {
            var response = usuService.getAllMed(vm.userApp.idCentro);
            response.then(
                function (response) {
                    vm.listMedicos = response.data;
                    vm.listMedicos.push({ idUsuario: 0, nombreCompleto: '*No Aplica*' });
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function agregar() {
            vm.entitySerOrd = {
                idCentro: vm.userApp.idCentro,
                idPaciente: vm.entityPac.idPaciente,
                idConvenio: vm.entity.idConvenio,
                creadoPor: vm.userApp.nombreUsuario,
                idMedico: 0,
            };

            getServicios();

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowAgregar").removeAttr('hidden');
        }

        function agregarServicio() {
            if (vm.entitySerOrd.idMedico === 0) {
                vm.entitySerOrd.idMedico = null;
            }

            var response = serordService.create(vm.entitySerOrd);
            response.then(
                function (response) {
                    cancelar();
                    getServiciosOrdenados();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function cancelar() {
            $("#RowAgregar").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
        }

        vm.gridOptions = {
            data: [],
            enableSorting: true,
            enableRowSelection: true,
            enableFullRowSelection: true,
            multiSelect: true,
            enableRowHeaderSelection: true,
            enableColumnMenus: false,
            enableFiltering: true,
            columnDefs: [
                {
                    name: 'noOrden',
                    field: 'noOrden',
                    displayName: 'NoOrden',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    enableCellEdit: false,
                },
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
                    name: 'servicio.nombreServicio',
                    field: 'servicio.nombreServicio',
                    displayName: 'Servicio',
                    headerCellClass: 'bg-header',
                    width: 350,
                    enableCellEdit: false,
                },
                {
                    name: 'nombreMedico',
                    field: 'nombreMedico',
                    displayName: 'Médico',
                    headerCellClass: 'bg-header',
                    width: 250,
                    enableCellEdit: false,
                },
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cantidad',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
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
                },
                {
                    name: 'descuento',
                    field: 'descuento',
                    displayName: 'Descuento',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
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
                        "<span ng-if='row.entity.idOrden === null || row.entity.idOrden === 0'><a href='' ng-click='grid.appScope.vm.eliminarServicio(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 100,
                },
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
                gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                    if (colDef.name === 'tarifa' || colDef.name === 'descuento') {
                        var data = {
                            idServicioOrdenado: rowEntity.idServicioOrdenado,
                            tarifa: rowEntity.tarifa,
                            descuento: rowEntity.descuento,
                        };
                        updateTarifaDescuento(data);
                    }
                });
            },
        };

        function eliminarServicio(entity) {
            var response = serordService.remove(entity.idServicioOrdenado);
            response.then(
                function (response) {
                    getServiciosOrdenados();
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function facturar() {
            var data = vm.gridApi.selection.getSelectedRows();
            vm.gridOptionsFact.data = data;

            vm.entityFact.valorTotal = 0;
            for (var i = 0; i < data.length; i++) {
                vm.entityFact.valorTotal += data[i].tarifa - data[i].descuento;
            }

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowFacturacion").removeAttr('hidden');
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
                    name: 'servicio.codigoRef',
                    field: 'servicio.codigoRef',
                    displayName: 'Cups',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    width: 100,
                    enableCellEdit: false,
                },
                {
                    name: 'servicio.nombreServicio',
                    field: 'servicio.nombreServicio',
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
                    enableCellEdit: false,
                },
                {
                    name: 'cantidad',
                    field: 'cantidad',
                    displayName: 'Cantidad',
                    headerCellClass: 'bg-header',
                    cellClass: 'text-center',
                    type: 'number',
                    cellFilter: 'number: 0',
                    width: 100,
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
                {
                    name: 'descuento',
                    field: 'descuento',
                    displayName: 'Descuento',
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

        function updateTarifaDescuento(data) {
            var response = serordService.updateTarifaDescuento(data);
            response.then(
                function (response) {

                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function regresar() {
            $("#RowFacturacion").attr('hidden', 'hidden');
            $("#RowPrincipal").removeAttr('hidden');
        }

        function facturarSinCita() {
            var dataEnc = {
                idCentro: vm.userApp.idCentro,
                idCentroRemision: vm.entity.idCentroRemision,
                tipo: vm.entityCon.codTipoFact,
                tipoDocumento: '-',
                idPaciente: vm.entityPac.idPaciente,
                idConvenio: vm.entity.idConvenio,
                nombreAcomp: vm.entity.nombreAcomp,
                telefonoAcomp: vm.entity.telefonoAcomp,
                codEstado: Estados.Activo,
                creadoPor: vm.userApp.nombreUsuario,
            };

            var dataDet = [];
            for (var i = 0; i < vm.gridOptionsFact.data.length; i++) {
                var d = vm.gridOptionsFact.data[i];

                dataDet.push({
                    fecha: d.sFechaFormato,
                    hora: '.',
                    idPaciente: vm.entityPac.idPaciente,
                    idCentro: vm.userApp.idCentro,
                    idCentroRemision: vm.entity.idCentroRemision,
                    idMedico: d.idMedico === null ? 0 : d.idMedico,
                    idConvenio: d.idConvenio,
                    idServicio: d.idServicio,
                    cantidad: d.cantidad,
                    tarifa: d.tarifa,
                    descuento: d.descuento,
                    codEstado: Estados.Confirmado,
                    creadoPor: vm.userApp.nombreUsuario,
                    idServicioOrdenado: d.idServicioOrdenado,
                });
            }

            var data = {
                dataEnc: dataEnc,
                dataDet: dataDet,
            };

            var response = factService.createFacturacionSinCita(data);
            response.then(
                function (response) {
                    vm.idFacturacion = response.data;
                    $("#RowFacturacion").attr('hidden', 'hidden');
                    $("#RowFacturacionPost").removeAttr('hidden');
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function imprimirVolFact() {
            factService.imprimirVol(vm.idFacturacion);
        }

        function terminar() {
            window.location.reload();
        }



        // Creación de Paciente
        vm.listSexos = [
            { codigo: 'M', descripcion: 'MASCULINO' },
            { codigo: 'F', descripcion: 'FEMENINO' },
        ];

        vm.listZonas = [
            { codigo: 'U', descripcion: 'URBANA' },
            { codigo: 'R', descripcion: 'RURAL' },
        ];


        function nuevoPac() {
            vm.entityPac = {
                idCentro: vm.userApp.idCentro,
                nombrePaciente: '.',
            };

            $("#RowPrincipal").attr('hidden', 'hidden');
            $("#RowDatosPac").removeAttr('hidden');
        }


        function guardarPac1() {
            var response = pacService.create(vm.entityPac);
            response.then(
                function (response) {
                    cancelarPac();
                    vm.entityPac = response.data;
                    vm.entityPac.identificacion = vm.entityPac.tipoIden + ' ' + vm.entityPac.numIden;
                    vm.entityPac.fechaNacimiento = new Date(angular.copy(vm.entityPac.fechaNacimiento));

                    vm.entity.tipoIden = angular.copy(vm.entityPac.tipoIden);
                    vm.entity.numIden = angular.copy(vm.entityPac.numIden);
                    vm.entity.idConvenio = null;
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


    }
})();
