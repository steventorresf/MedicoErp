var IdMedico = 0;
var arFilterFec = '';
var arHor = [];

var obHor = {
    HoraI: '',
    Min: 0,
    Num: 0,
    HoraF: '',
    Fechas: [],
    IdMedico: 0,
    IdCentro: Cookies.IdCentro,
}

function onKeyDownFec(event) {
    var codigo = event.which || event.keyCode;
    if (codigo === 8) {
        $("#Ho_Fec").val('');
        return true;
    }
    else { return false; }
}

$("#txtFechas").multiDatesPicker({});

function GetMedicos() {
    ServiceGet('Usuarios/Med/' + Cookies.IdCentro + '/', function (result) {
        if (result.resp === true) {
            fnLlenarMedicos(result.lista);
        }
        else { console.log(result); }
    });
}
GetMedicos();

function fnLlenarMedicos(Lista) {
    var html = '<option value="0">*Seleccione...*</option>';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<option value="' + ob.idUsuario + '">' + ob.nombreCompleto + '</option>';
    }
    $("#CboMedicos").append(html);
}

$("#btnAceptar").click(function (e) {
    IdMedico = $("#CboMedicos").val();
    if (IdMedico != "0" && IdMedico != null) {
        GetHorariosMed();
    }
});

function GetHorariosMed() {
    ServiceGet('Horarios/HorMed/' + IdMedico + '/', function (result) {
        if (result.resp === true) {
            $("#TextoNombreMedico").html($("#CboMedicos option:selected").text());

            $("#Ho_Fec").val('');
            $("#Ho_Ini").val('');
            $("#Ho_Fin").val('');
            $("#Ho_Est").val('');

            $("#ColMed").attr('hidden', 'hidden');
            $("#ColHor").removeAttr('hidden');

            fnLlenarHorariosMed(result.lista);
            arHor = result.lista;
            fnFilterFec();
        }
        else { console.log(result); }
    });
}

function fnLlenarHorariosMed(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<tr class="text-center">' +
            '<td width="20%">' + ob.fecha.substring(0, 10) + '</td>' +
            '<td width="20%">' + ob.sHoraInicial + '</td>' +
            '<td width="20%">' + ob.sHoraFinal + '</td>' +
            '<td width="20%">' + ob.nombreEstado + '</td>' +
            '<td width="20%">' + '' + '</td>' +
            '</tr>';
    }

    if (html === '') { html = '<tr><td colspan="10"></td></tr>'; }

    $("#BodyHor").html(html);
    $("#BodyHor i").tooltip();
}

function fnFilterFec() {
    $("#Ho_Fec").datepicker({
        dateFormat: 'yy-mm-dd',
        beforeShowDay: function (date) {
            for (var i = 0; i < arHor.length; i++) {
                if (arHor[i].fecha.substring(0, 10) === moment(date).format("YYYY-MM-DD")) {
                    return [true];
                }
            }
            return [false];
        },
        onSelect: function (date) {
            fnBusquedaHor();
        }
    });
}

function fnBusquedaHor() {
    var Ho_Fec = $("#Ho_Fec").val();
    var Ho_Ini = $("#Ho_Ini").val().trim().toUpperCase();
    var Ho_Fin = $("#Ho_Fin").val().trim().toUpperCase();
    var Ho_Est = $("#Ho_Est").val().trim().toUpperCase();

    var Lista = arHor.filter(function (ob) {
        return ob.fecha.substring(0, 10).includes(Ho_Fec) && ob.sHoraInicial.includes(Ho_Ini) && ob.sHoraFinal.includes(Ho_Fin) && ob.nombreEstado.includes(Ho_Est);
    });

    fnLlenarHorariosMed(Lista);
}

$("#btnRegresar").click(function (e) {
    $("#ColHor").attr('hidden', 'hidden');
    $("#ColMed").removeAttr('hidden');
});
$("#btnNuevo").click(function (e) {
    $("#txtFechas").multiDatesPicker('resetDates');

    $("#ColHor").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
});

$("#btnCancelar").click(function (e) {
    $("#ColEditor").attr('hidden', 'hidden');
    $("#ColHor").removeAttr('hidden');
});

function fnValidarHoraFinal() {
    obHor.HoraI = "1900-01-01 " + fnValidarHora($("#txtHoraI").val());
    obHor.Min = parseInt($("#txtMin").val());
    obHor.Num = parseInt($("#txtNum").val());

    if (moment(obHor.HoraI).isValid() && !isNaN(obHor.Min) && !isNaN(obHor.Num)) {
        $("#txtHoraF").val(moment(obHor.HoraI).add(obHor.Min * obHor.Num, "minutes").format("hh:mm a").toUpperCase());
    }
    else { $("#txtHoraF").val(''); }
}

$("#btnCrearHor").click(function (e) {
    obHor.IdMedico = IdMedico;
    obHor.HoraF = $("#txtHoraF").val();
    obHor.Fechas = $("#txtFechas").multiDatesPicker('getDates');

    var NoValido = '';
    if (obHor.HoraF === '') { NoValido += 'Debe calcular la Hora Final.<br>'; }
    if (obHor.Fechas.length === 0) { NoValido += 'Debe seleccionar al menos una fecha.<br>'; }
    if (NoValido === '') {
        obHor.HoraF = "1900-01-01 " + fnValidarHora($("#txtHoraF").val());

        ServicePost('Horarios/', obHor, function (result) {
            if (result.resp === true) {
                if (result.cad === '') {
                    $("#ColEditor").attr('hidden', 'hidden');
                    $("#ColHor").removeAttr('hidden');
                    GetHorariosMed();
                    $.bootstrapGrowl('¡Los horarios han sido creados exitosamente!', {
                        type: 'success',
                        align: 'center',
                        delay: 5000,
                        width: 'auto',
                        offset: { from: 'bottom', amount: 20 },
                    });
                }
                else { AbrirModal('¡No Valido!', result.cad, ''); }
            }
            else { console.log(result); }
        });
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }
});


$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }
});