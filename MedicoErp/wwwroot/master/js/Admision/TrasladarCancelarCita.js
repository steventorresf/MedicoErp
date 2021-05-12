var obCita = null;
var obPaciente = null;
var obHorario = null;


function GetTiposIden() {
    ServiceGet('TablasDetalle/TabTiposIden', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.codValor + '">' + ob.descripcion + '</option>';
            }
            $("#CboTipoIden").append(html);
        }
        else { console.log(result); }
    });
}
GetTiposIden();

function GetPacienteByIden() {
    $("#LblNombrePaciente").html('');

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
                    $("#LblNombrePaciente").html(obPaciente.nombrePaciente);
                    GetCitasAsignadas();
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

function GetCitasAsignadas() {
    ServiceGet('Citas/' + obPaciente.idPaciente, function (result) {
        if (result.resp === true) {
            LlenarCitas(result.lista);
        }
        else { console.log(result); }
    });
}

function LlenarCitas(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<tr>' +
            '<td width="1020px" class="text-center">' + ob.fecha.substring(0, 10) + '</td>' +
            '<td width="100px" class="text-center">' + ob.hora + '</td>' +
            '<td width="250px">' + ob.nombreConvenio + '</td>' +
            '<td width="250px">' + ob.nombreMedico + '</td>' +
            '<td class="text-center">' + ob.nombreServicio + '</td>' +
            '<td width="110px" class="text-center">' +
            "<i class='fa fa-edit green' title='Trasladar' onClick='fnTrasladarCita(" + JSON.stringify(ob) + ")'></i>" +
            "<i class='fa fa-remove red' title='Cancelar' onClick='fnCancelarCita(" + JSON.stringify(ob) + ")'></i>" +
            '</td>' +
            '</tr>';
    }

    if (html === '') {
        html = '<tr><td colspan="10"></td></tr>';
    }

    $("#BodyCitas").html(html);
    $("#BodyCitas i").tooltip();
}

function fnTrasladarCita(ob) {
    obCita = ob;
    $("#LblIden").html(obPaciente.tipoIden + ' ' + obPaciente.numIden);
    $("#LblNomPac").html(obPaciente.nombrePaciente);
    $("#LblConv").html(ob.nombreConvenio);
    $("#LblServ").html(ob.nombreServicio);
    $("#LblMedi").html(ob.nombreMedico);
    $("#LblFech").html(ob.fecha.substring(0, 10) + ' ' + ob.hora);

    $("#CboMedico").selectpicker('val', '0');
    $("#TxtFechaCita").val('');
    $("#BodyHoras").html('');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
    alert($("#Card").height());
}

function fnCancelarCita(ob) {
    obCita = ob;
    var Cad = '¿Desea CANCELAR esta cita?:<br><br>';
    Cad += '<table>' +
        '<tr class="borderbottom"><td width="35%"><b>Identificaci&oacute;n:</b></th><td>' + obPaciente.tipoIden + ' ' + obPaciente.numIden + '</td></tr>' +
        '<tr class="borderbottom"><td><b>Paciente:</b></th><td>' + obPaciente.nombrePaciente + '</td></tr>' +
        '<tr class="borderbottom"><td><b>Convenio:</b></th><td>' + ob.nombreConvenio + '</td></tr>' +
        '<tr class="borderbottom"><td class="align-top"><b>Servicio:</b></th><td>' + ob.nombreServicio + '</td></tr>' +
        '<tr class="borderbottom"><td><b>M&eacute;dico:</b></th><td>' + ob.nombreMedico + '</td></tr>' +
        '<tr><td><b>Fecha y Hora:</b></th><td>' + ob.fecha.substring(0, 10) + ' ' + ob.hora + '</td></tr>' +
        '</table>';

    AbrirModal('¡Confirmaci&oacute;n!', Cad, 'CancelCita');
}

$("#btnRegresar").click(function (e) {
    $("#ColEditor").attr('hidden', 'hidden');
    $("#ColGrilla").removeAttr('hidden');
});

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
            "<i class='fa fa-sign-in green' title='Trasladar Cita' onClick='fnTrasladarC(" + JSON.stringify(ob) + ")'></i>" +
            '</td>' +
            '</tr>';
    }

    if (html === '') { html = '<tr><td colspan="5"></td></tr>'; }

    $("#BodyHoras").html(html);
    $("#BodyHoras i").tooltip();
}

function fnTrasladarC(ob) {
    obHorario = ob;

    var datos = '<table>' +
        '<tr><td width="30%"><b>Identificaci&oacute;n:</b></td>' + '<td>' + obPaciente.tipoIden + ' ' + obPaciente.numIden + '</tr>' +
        '<tr><td><b>Paciente:</b></td>' + '<td>' + obPaciente.nombrePaciente + '</tr>' +
        '<tr><td><b>Convenio:</b></td>' + '<td>' + obCita.nombreConvenio + '</tr>' +
        '<tr><td class="align-top"><b>Servicio:</b></td>' + '<td>' + obCita.nombreServicio + '</tr>' +
        '<tr><td><b>M&eacute;dico:</b></td>' + '<td>' + $("#CboMedico option:selected").text() + '</tr>' +
        '<tr><td><b>Fecha:</b></td>' + '<td>' + ob.fecha.substring(0, 10) + '</tr>' +
        '<tr><td><b>Hora:</b></td>' + '<td>' + ob.sHoraInicial + '</tr>' +
        '</table>';
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Trasladar la cita con los siguientes datos?<br><br>' + datos, 'TraslCita');
}


$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }

    if (ModalAccion === 'TraslCita') {
        $("#ModalGeneral").modal('hide');
        ServicePost('Citas/Trasl/', { IdCita: obCita.idCita, IdHorarioNew: obHorario.idHorario, IdHorarioOld: obCita.idReserva, IdUsu: Cookies.IdCentro }, function (result) {
            if (result.resp === true) {
                $("#btnRegresar").click();
                $("#ModalGeneral").modal('hide');
                GetCitasAsignadas();
                $.bootstrapGrowl('¡La cita ha sido Reprogramada!', {
                    type: 'success',
                    align: 'center',
                    delay: 5000,
                    width: 'auto',
                    offset: { from: 'bottom', amount: 20 },
                });
            }
            else { console.log(result); }
        });
    }

    if (ModalAccion === 'CancelCita') {
        $("#ModalGeneral").modal('hide');
        ServicePost('Citas/Cancel/', { IdCita: obCita.idCita, IdUsu: Cookies.IdCentro }, function (result) {
            if (result.resp === true) {
                if (result.val === true) {
                    $("#ModalGeneral").modal('hide');
                    GetCitasAsignadas();
                    $.bootstrapGrowl('¡La cita ha sido Cancelada!', {
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