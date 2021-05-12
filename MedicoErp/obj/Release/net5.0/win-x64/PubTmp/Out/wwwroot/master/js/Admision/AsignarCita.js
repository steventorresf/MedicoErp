var obPaciente = null;
var obPacienteNew = null;
var obCita = null;
var arSer = [];
var obServicio = null;
var obHor = null;

function GetTiposIden() {
    ServiceGet('TablasDetalle/TabTiposIden', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.codValor + '">' + ob.descripcion + '</option>';
            }
            $("#CboTipoIden").append(html);
            $("#CboTipoIdenE").append(html);
        }
        else { console.log(result); }
    });
}
GetTiposIden();

function GetPacienteByIden() {
    $("#TxtNombrePaciente").val('');

    var ob = {
        TipoIden: $("#CboTipoIden").val(),
        NumIden: $("#TxtNumIden").val().trim(),
        IdCentro: Cookies.IdCentro,
    }

    if (ob.TipoIden != null && ob.TipoIden != "0" && ob.NumIden != "") {
        ServicePost('Pacientes/Get/', ob, function (result) {
            if (result.resp === true) {
                obPaciente = result.obj;
                if (obPaciente != null) {
                    $("#TxtNombrePaciente").val(obPaciente.nombrePaciente);
                }
                else {
                    $.bootstrapGrowl('¡No existe un paciente con esa identidad!', {
                        type: 'danger',
                        align: 'center',
                        delay: 5000,
                        width: 'auto',
                        offset: { from: 'bottom', amount: 20 },
                    });
                }
            }
            else { console.log(result); }
        });
    }
}

function GetConveniosActivos() {
    ServiceGet('Convenios/Act/' + Cookies.IdCentro, function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idConvenio + '">' + ob.nombreConvenio + '</option>';
            }
            $("#CboConvenio").append(html);
        }
        else { console.log(result); }
    });
}
GetConveniosActivos();

function GetServicios() {
    $("#CboServicio option").remove();

    var IdCon = $("#CboConvenio").val();
    if (IdCon != "0") {
        ServiceGet('ServiciosContratados/' + IdCon, function (result) {
            if (result.resp === true) {
                var html = '<option value="0">*Seleccione...*</option>';
                for (var i = 0; i < result.lista.length; i++) {
                    var ob = result.lista[i];
                    html += '<option value="' + ob.idServicio + '">' + ob.servicio.nombreServicio + '</option>';
                }
                $("#CboServicio").append(html);
                $("#CboServicio").selectpicker('refresh');
                $("#CboServicio").selectpicker('val', '0');

                arSer = result.lista;
            }
            else { console.log(result); }
        });
    }
}

function fnOnChangeSer() {
    obServicio = null;
    var idSer = parseInt($("#CboServicio").val());
    if (idSer > 0) {
        for (var i = 0; i < arSer.length; i++) {
            if (arSer[i].idServicio === idSer) {
                obServicio = arSer[i];
                break;
            }
        }
    }
}

function GetMedicos() {
    ServiceGet('Usuarios/Med/' + Cookies.IdCentro, function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idUsuario + '">' + ob.nombreCompleto + '</option>';
            }
            $("#CboMedico").append(html);
        }
        else { console.log(result); }
    });
}
GetMedicos();

function fnOnChangeMed() {
    $("#TxtFechaCita").val('');
    $("#TxtFechaCita").datepicker('destroy');

    var IdMed = $("#CboMedico").val();
    if (IdMed != "0") {
        ServiceGet('Horarios/FecMed/' + IdMed, function (result) {
            if (result.resp === true) {

                var arLista = result.arLista;
                $("#TxtFechaCita").datepicker({
                    dateFormat: 'yy-mm-dd',
                    beforeShowDay: function (date) {
                        if (arLista.includes(moment(date).format("YYYY-MM-DD"))) {
                            return [true];
                        }
                        else { return [false]; }
                    },
                    onSelect: function (date) {
                        GetFechaHorasMed(date, IdMed);
                    }
                });
                fnLlenarFechaHorasMed([]);
            }
            else { console.log(result); }
        });
    }
}

function GetFechaHorasMed(Fecha, IdMed) {
    $("#BodyHoras").html('');
    ServicePost('Horarios/FecMed/', { IdMedico: IdMed, Fecha: Fecha }, function (result) {
        if (result.resp === true) {
            fnLlenarFechaHorasMed(result.lista);
        }
        else { console.log(result); }
    });
}

function fnLlenarFechaHorasMed(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<tr>' +
            '<td class="text-center">' + ob.sHoraInicial + ' - ' + ob.sHoraFinal + '</td>' +
            '<td width="18%" class="text-center">' +
            "<i class='fa fa-sign-in green' title='Asignar Cita' onClick='fnAsignarCita(" + JSON.stringify(ob) + ")'></i>" +
            '</td>' +
            '</tr>';
    }

    if (html === '') { html = '<tr><td colspan="5"></td></tr>'; }

    $("#BodyHoras").html(html);
    $("#BodyHoras i").tooltip();
}

function GetDepartamentos() {
    ServiceGet('Departamentos/', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.codDepartamento + '">' + ob.nomDepartamento + '</option>';
            }
            $("#CboDptoE").append(html);
        }
        else { console.log(result); }
    });
}
GetDepartamentos();

function GetMunicipios() {
    $("#CboMunicipioE option").remove();

    var codDpto = $("#CboDptoE").val();
    ServiceGet('Municipios/' + codDpto + '/', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.codMunicipio + '">' + ob.nomMunicipio + '</option>';
            }
            $("#CboMunicipioE").append(html);
            $("#CboMunicipioE").selectpicker('refresh');
            $("#CboMunicipioE").selectpicker('val', '0');
        }
        else { console.log(result); }
    });
}

function fnAsignarCita(ob) {
    obHor = ob;
    var idCon = $("#CboConvenio").val();

    var NoValido = '';
    if (obPaciente === null) { NoValido += 'Digite un paciente.<br>'; }
    if (idCon === null || idCon === '0') { NoValido += 'Selecciona un convenio.<br>'; }
    if (obServicio === null) { NoValido += 'Selecciona un servicio.<br>'; }

    if (NoValido === '') {
        obCita = {
            idFacturacion: 0,
            fecha: $("#TxtFechaCita").val(),
            idReserva: ob.idHorario,
            idPaciente: obPaciente.idPaciente,
            idCentro: Cookies.IdCentro,
            idMedico: $("#CboMedico").val(),
            idConvenio: $("#CboConvenio").val(),
            idServicio: obServicio.idServicio,
            cantidad: 1,
            tarifa: obServicio.tarifa,
            codEstado: 'AG',
            idUsuario: Cookies.IdUsu,
        }

        var datos = '<table>' +
            '<tr><td width="30%"><b>Identificaci&oacute;n:</b></td>' + '<td>' + obPaciente.tipoIden + ' ' + obPaciente.numIden + '</tr>' +
            '<tr><td><b>Paciente:</b></td>' + '<td>' + obPaciente.nombrePaciente + '</tr>' +
            '<tr><td><b>Convenio:</b></td>' + '<td>' + $("#CboConvenio option:selected").text() + '</tr>' +
            '<tr><td class="align-top"><b>Servicio:</b></td>' + '<td>' + obServicio.servicio.nombreServicio + '</tr>' +
            '<tr><td><b>M&eacute;dico:</b></td>' + '<td>' + $("#CboMedico option:selected").text() + '</tr>' +
            '<tr><td><b>Fecha:</b></td>' + '<td>' + obCita.fecha + '</tr>' +
            '<tr><td><b>Hora:</b></td>' + '<td>' + ob.sHoraInicial + '</tr>' +
            '</table>';
        AbrirModal('¡Confirmaci&oacute;n!', '¿Desea asignar una cita con los siguientes datos?<br><br>' + datos, 'AsigCita');
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }    
}


$("#btnNuevoPac").click(function (e) {
    $("#PacHeader").attr('hidden', 'hidden');
    $("#btnGuardarPac2").attr('hidden', 'hidden');
    $("#btnGuardarPac1").removeAttr('hidden');

    $("#ColCita").attr('hidden', 'hidden');
    $("#ColPac").removeAttr('hidden');
});
$("#btnCancelarPac").click(function (e) {
    $("#ColPac").attr('hidden', 'hidden');
    $("#ColCita").removeAttr('hidden');

    $("#PacHeader").attr('hidden', 'hidden');
    $("#btnGuardarPac1").attr('hidden', 'hidden');
    $("#btnGuardarPac2").removeAttr('hidden');
    obPacienteNew = null;
});

function fnValPac() {
    var resp = false;

    obPacienteNew = {
        tipoIden: $("#CboTipoIdenE").val(),
        numIden: $("#TxtNumIdenE").val().trim(),
        primerNombre: $("#TxtPrimerNombreE").val().trim(),
        SegundoNombre: $("#TxtSegundoNombreE").val().trim(),
        primerApellido: $("#TxtPrimerApellidoE").val().trim(),
        segundoApellido: $("#TxtSegundoApellidoE").val().trim(),
        nombrePaciente: '.',
        codSexo: $("#CboSexoE").val(),
        fechaNacimiento: $("#TxtFechaNacimientoE").val(),
        codDepartamento: $("#CboDptoE").val(),
        codMunicipio: $("#CboMunicipioE").val(),
        direccion: $("#TxtDireccion").val().trim(),
        codZona: $("#CboZona").val(),
        telefono: $("#TxtTelefono").val().trim(),
        correo: $("#TxtCorreo").val().trim(),
        IdCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (obPacienteNew.tipoIden === null || obPacienteNew.tipoIden === '0') { NoValido += 'Seleccione un tipo de identificaci&oacute;n.<br>'; }
    if (obPacienteNew.numIden === '') { NoValido += 'Digite el n&uacute;mero de identificaci&oacute;n.<br>'; }
    if (obPacienteNew.primerNombre === '') { NoValido += 'Digite el primer nombre.<br>'; }
    if (obPacienteNew.primerApellido === '') { NoValido += 'Digite el primer apellido.<br>'; }
    if (obPacienteNew.sexo === '0') { NoValido += 'Seleccione un sexo.<br>'; }
    if (obPacienteNew.fechaNacimiento === '') { NoValido += 'Seleccione la fecha de nacimiento.<br>'; }
    if (obPacienteNew.codDepartamento === null || obPacienteNew.codDepartamento === '0') { NoValido += 'Seleccione un departamento.<br>'; }
    if (obPacienteNew.codMunicipio === null || obPacienteNew.codMunicipio === '0') { NoValido += 'Seleccione un municipio.<br>'; }
    if (obPacienteNew.direccion === '') { NoValido += 'Digite la direcci&oacute;n.<br>'; }
    if (obPacienteNew.telefono === '') { NoValido += 'Digite un tel&eacute;fono.<br>'; }

    if (NoValido === '') {
        resp = true;
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }

    return resp;
}

$("#btnGuardarPac1").click(function (e) {
    var resp = fnValPac();
    if (resp === true) {
        ServicePost('Pacientes/', obPacienteNew, function (result) {
            if (result.resp === true) {
                obPaciente = result.obPac;
                $("#btnCancelarPac").click();

                $("#CboTipoIden").selectpicker('val', obPaciente.tipoIden);
                $("#TxtNumIden").val(obPaciente.numIden);
                $("#TxtNombrePaciente").val(obPaciente.nombrePaciente);
            }
            else { console.log(result); }
        });
    }
});

$("#btnGuardarPac2").click(function (e) {
    var resp = fnValPac();
    if (resp === true) {
        ServicePut('Pacientes/' + obPaciente.idPaciente, obPacienteNew, function (result) {
            if (result.resp === true) {
                window.location.href = url + 'Admision/AsignarCita';
            }
            else { console.log(result); }
        });
    }
});



$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }

    if (ModalAccion === 'AsigCita') {
        ServicePost('Citas/', obCita, function (result) {
            if (result.resp === true) {
                if (result.val === true) {
                    $("#ModalGeneral").modal('hide');

                    $("#TextoIden").html(obPaciente.tipoIden + ' ' + obPaciente.numIden);
                    $("#TextoPac").html(obPaciente.nombrePaciente);
                    $("#TextoCon").html($("#CboConvenio option:selected").text());
                    $("#TextoSer").html(obServicio.servicio.nombreServicio);
                    $("#TextoMed").html($("#CboMedico option:selected").text());
                    $("#TextoFec").html(obCita.fecha + ' ' + obHor.sHoraInicial);

                    $("#CboTipoIdenE").selectpicker('val', obPaciente.tipoIden);
                    $("#TxtNumIdenE").val(obPaciente.numIden);
                    $("#TxtPrimerNombreE").val(obPaciente.primerNombre);
                    $("#TxtSegundoNombreE").val(obPaciente.SegundoNombre);
                    $("#TxtPrimerApellidoE").val(obPaciente.primerApellido);
                    $("#TxtSegundoApellidoE").val(obPaciente.segundoApellido);
                    $("#CboSexoE").selectpicker('val', obPaciente.codSexo);
                    $("#TxtFechaNacimientoE").val(moment(obPaciente.fechaNacimiento).format('YYYY-MM-DD'));
                    $("#CboDptoE").selectpicker('val', obPaciente.codDepartamento);
                    GetMunicipios();
                    $("#CboMunicipioE").selectpicker('val', obPaciente.codMunicipio);
                    $("#TxtDireccion").val(obPaciente.direccion);
                    $("#CboZona").selectpicker('val', obPaciente.codZona);
                    $("#TxtTelefono").val(obPaciente.telefono);
                    $("#TxtCorreo").val(obPaciente.correo);

                    //$("#PacHeader").remove();
                    $("#btnCancelarPac").attr('hidden', 'hidden');
                    $("#btnGuardarPac1").attr('hidden', 'hidden');
                    $("#btnGuardarPac2").removeAttr('hidden');

                    $("#ColCita").attr('hidden', 'hidden');
                    $("#TextoPacGrid").html('Datos del paciente');
                    //$("#ColCitaOk").removeAttr('hidden');
                    $("#ColPac").removeAttr('hidden');

                    $.bootstrapGrowl('¡La cita ha sido asignada exitosamente!', {
                        type: 'success',
                        align: 'center',
                        delay: 5000,
                        width: 'auto',
                        offset: { from: 'bottom', amount: 20 },
                    });
                }
                else {
                    $.bootstrapGrowl('¡Esta hora ya NO se encuentra disponible!', {
                        type: 'danger',
                        align: 'center',
                        delay: 10000,
                        width: 'auto',
                        offset: { from: 'bottom', amount: 20 },
                    });
                }
            }
            else { console.log(result); }
        });
    }
});