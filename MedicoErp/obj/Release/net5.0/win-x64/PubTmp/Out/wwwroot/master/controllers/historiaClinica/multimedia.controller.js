(function () {
    'use-strict';

    angular
        .module('app')
        .controller('AppController', AppController);

    AppController.$inject = ['$location', '$scope', '$cookies', 'PacienteService', 'MultimediaService', 'TablaDetalleService', 'EventoService'];

    function AppController($location, $scope, $cookies, pacService, mulService, tabdetService, eveService) {
        var vm = this;

        vm.col1 = true;
        vm.col2 = false;
        vm.formPac = false;

        vm.title = 'Home Page';
        vm.userApp = angular.copy($cookies.getObject('UsuApp'));
        vm.init = init;
        
        vm.entity = {};
        vm.entityPac = {};
        vm.entityMul = {
            idCentro: vm.userApp.idCentro,
            idUsu: vm.userApp.idUsuario,
            orden: 1,
            nombreImg: '',
            img: '',
            idEvento: null,
        };
        
        vm.getPacienteByIden = getPacienteByIden;
        vm.imprimirMultimedia = imprimirMultimedia;
        vm.uploadFileTemp = uploadFileTemp;
        $scope.uploadFileTemp = uploadFileTemp;
        vm.subirImgTemp = subirImgTemp;
        vm.eliminarImgTemporal = eliminarImgTemporal;
        vm.multimediaPdfVistaPrevia = multimediaPdfVistaPrevia;
        vm.multimediaPdfReal = multimediaPdfReal;

        vm.subirArch = subirArch;
        vm.uploadFile = uploadFile;
        $scope.uploadFile = uploadFile;
        vm.subirArchivo = subirArchivo;

        vm.armarPdf = armarPdf;
        vm.regresar = regresar;

        vm.cerrarSesion = cerrarSesion;
        function cerrarSesion() {
            $cookies.remove();
            window.location.href = url + 'Login';
        }

        function init() {            
            vm.gridVisible = true;
            getTiposIden();
            removeAllTemporales();
        }

        function removeAllTemporales() {
            var response = mulService.removeAllTemporal(vm.userApp.idUsuario, vm.userApp.idCentro);
            response.then(
                function (response) {
                    
                },
                function (response) {
                    console.log(response);
                }
            );
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
            vm.gridOptions.data = [];

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
                            getDescripcionEventos();
                            getMultimedia();
                        }
                        else { vm.entityPac.nombrePaciente = 'No existe un paciente con ese documento de identidad'; }
                    },
                    function (response) {
                        console.log(response);
                    }
                );
            }
        }

        function getDescripcionEventos() {
            var response = eveService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.listEventos = [{ idEvento: 0, descripcionEvento: '--' }];

                    var data = response.data;
                    for (var i = 0; i < data.length; i++) {
                        vm.listEventos.push(data[i]);
                    }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function getMultimedia() {
            var response = mulService.getAllByIdPaciente(vm.entityPac.idPaciente);
            response.then(
                function (response) {
                    vm.gridOptions.data = response.data;
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
                    name: 'sFechaCreacion',
                    field: 'sFechaCreacion',
                    displayName: 'Fecha Creación',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 200,
                },
                {
                    name: 'noEvento',
                    field: 'noEvento',
                    displayName: 'NoEvento',
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    width: 100,
                },
                {
                    name: 'nombreArchivo',
                    field: 'nombreArchivo',
                    displayName: 'NombreArchivo',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'creadoPor',
                    field: 'creadoPor',
                    displayName: 'CreadoPor',
                    headerCellClass: 'text-center',
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.imprimirMultimedia(row.entity)' tooltip='Imprimir' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-download text-success'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            },
        };

        function imprimirMultimedia(entity) {
            window.open(url + 'Visor/Archivo?idm=' + entity.idMultimedia);
        }



        function regresar() {
            vm.formSubirVisible = false;
            vm.formArmarVisible = false;
            vm.gridVisible = true;
        }

        // Subir Archivo
        function subirArch() {
            vm.gridVisible = false;
            vm.formSubirVisible = true;
            vm.entityMul = {
                idCentro: vm.userApp.idCentro,
                idPaciente: vm.entityPac.idPaciente,
                nombreRuta: '-',
                extension: '.',
                idUsu: vm.userApp.idUsuario,
                creadoPor: vm.userApp.nombreUsuario,
                idEvento: 0,
            };
        }

        function uploadFile(input) {
            $scope.$apply(function () {
                var file = input.files && input.files[0];
                if (file) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        vm.entityMul.nombreOriginal = input.files[0].name;
                        vm.entityMul.archivo = e.target.result.replace(/data:image\/jpeg;base64,/g, '').replace(/data:image\/png;base64,/g, '').replace(/data:application\/pdf;base64,/g, '');
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            });
        }

        function subirArchivo() {
            var response = mulService.subirArchivo(vm.entityMul);
            response.then(
                function (response) {
                    getMultimedia();
                    regresar();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        // Armar PDF
        function armarPdf() {
            vm.gridVisible = false;
            vm.formArmarVisible = true;
            vm.entity.idEvento = 0;
            vm.entity.idUsu = vm.userApp.idUsuario;

            getImagenesTemporales();
        }

        function getImagenesTemporales() {
            vm.gridOptionsImgs.data = [];
            var response = mulService.getAllTemporalesByIdUsuario(vm.userApp.idUsuario);
            response.then(
                function (response) {
                    vm.gridOptionsImgs.data = response.data;
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        vm.gridOptionsImgs = {
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
                    name: 'nombreImg',
                    field: 'nombreImg',
                    displayName: 'NombreImagen',
                    headerCellClass: 'text-center',
                    width: 350,
                },
                {
                    name: 'tool',
                    field: '',
                    displayName: '',
                    enableColumnMenu: false,
                    enableFiltering: false,
                    enableSorting: false,
                    headerCellClass: 'text-center',
                    cellClass: 'text-center',
                    cellTemplate:
                        "<span><a href='' ng-click='grid.appScope.vm.eliminarImgTemporal(row.entity)' tooltip='Eliminar' tooltip-trigger='mouseenter' tooltip-placeholder='top'>" +
                        "<i class='fa fa-remove text-danger'></i></a></span>",
                    width: 80,
                }
            ],
            onRegisterApi: function (gridApi) {
                vm.gridApiImgs = gridApi;
            },
        };

        function eliminarImgTemporal(entity) {
            var response = mulService.removeImagenTemporal(entity.idDetalle, vm.userApp.idCentro);
            response.then(
                function (response) {
                    getImagenesTemporales();
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function uploadFileTemp(input) {
            $scope.$apply(function () {
                var file = input.files && input.files[0];
                if (file) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        vm.entityMul.nombreImg = input.files[0].name;
                        vm.entityMul.img = e.target.result.replace(/data:image\/jpeg;base64,/g, '').replace(/data:image\/png;base64,/g, '');
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            });
        }

        function subirImgTemp() {
            var response = mulService.subirImgTemp(vm.entityMul);
            response.then(
                function (response) {
                    vm.entityMul.orden++;
                    getImagenesTemporales();
                },
                function (response) {
                    console.log(response);
                }
            );
        }


        function multimediaPdfVistaPrevia() {
            var data = {
                tip: '1',
                nombreArch: vm.userApp.nombreUsuario.replace('.', '') + '.pdf',
                entityPac: vm.entityPac,
                listaImgs: vm.gridOptionsImgs.data,
                idCentro: vm.userApp.idCentro,
                idUsuario: vm.userApp.idUsuario,
                obs: vm.entity.obs != undefined ? vm.entity.obs : '',
                nombreUsuario: vm.userApp.nombreUsuario,
                idEvento: vm.entity.idEvento,
            };

            var response = mulService.multimediaPdf(data.tip, data);
            response.then(
                function (response) {
                    var resp = response.data;
                    if (resp) {
                        window.open(url + 'Visor/PdfPrevio?idu=' + vm.userApp.idUsuario);
                    }
                    else { console.log(response); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }

        function multimediaPdfReal() {
            var data = {
                tip: '2',
                nombreArch: vm.entity.nombreArchivo.replace('.', '') + '.pdf',
                entityPac: vm.entityPac,
                listaImgs: vm.gridOptionsImgs.data,
                idCentro: vm.userApp.idCentro,
                idUsuario: vm.userApp.idUsuario,
                obs: vm.entity.obs != undefined ? vm.entity.obs : '',
                nombreUsuario: vm.userApp.nombreUsuario,
                idEvento: vm.entity.idEvento,
            };

            var response = mulService.multimediaPdf(data.tip, data);
            response.then(
                function (response) {
                    var resp = response.data;
                    if (resp) {
                        getMultimedia();

                        removeAllTemporales();
                        regresar();
                    }
                    else { console.log(response); }
                },
                function (response) {
                    console.log(response);
                }
            );
        }
    }
})();
