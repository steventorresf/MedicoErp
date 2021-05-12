var obPaciente = null;
var obConvenio = null;
var obFactura = null;
var idFacturacion = 0;
var arCon = [];
var arCitas = [];
var arIdCitas = [];

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
    $("#ColCitas").attr('hidden', 'hidden');
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
                    $("#CboConvenio").selectpicker('val', '0');
                    $("#BodyCitas").html('');
                    $("#ColCitas").removeAttr('hidden');
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
            var html = '<option value="0">*Seleccione Convenio...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idConvenio + '">' + ob.nombreConvenio + '</option>';
            }
            $("#CboConvenio").append(html);
            arCon = result.lista;
        }
        else { console.log(result); }
    });
}
GetConveniosActivos();


function onChangeCon() {
    $("#BodyCitas").html('');
    $("#LblTotalPagar").html('');

    var idCon = parseInt($("#CboConvenio").val());
    if (idCon > 0) {
        for (var i = 0; i < arCon.length; i++) {
            if (arCon[i].idConvenio === idCon) {
                obConvenio = arCon[i];
                break;
            }
        }
        GetCitasConvenio();
    }
}


function GetCitasConvenio() {
    ServiceGet('Citas/' + obPaciente.idPaciente + '/' + obConvenio.idConvenio, function (result) {
        if (result.resp === true) {
            LlenarCitasConvenio(result.lista);
            arCitas = result.lista;
        }
        else { console.log(result); }
    });
}

function LlenarCitasConvenio(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<tr id="Tr' + ob.idCita + '">' +
            '<td width="50px" class="text-center">' + '<input type="checkbox" id="Ck' + ob.idCita + '" onchange="onChangeCk(' + ob.idCita + ', this.checked)" />' + '</td>' +
            '<td width="120px" class="text-center">' + ob.sFecha + '</td>' +
            '<td width="100px" class="text-center">' + ob.hora + '</td>' +
            '<td>' + ob.nombreServicio + '</td>' +
            '<td width="250px">' + ob.nombreMedico + '</td>' +
            '<td width="100px">' +
            "<input style='width:100%' id='TxtTarifa" + ob.idCita + "' type='text' onblur='onBlurTarifa(" + JSON.stringify(ob) + ")' value='" + PonerPuntos(ob.tarifa) + "' />" +
            '</td>' +
            '</tr>';
    }

    if (html === '') { html = '<tr><td colspan="10"></td></tr>'; }

    $("#BodyCitas").html(html);
}

function SumarTotalPagar() {
    var Total = 0;
    for (var i = 0; i < arCitas.length; i++) {
        var id = arCitas[i].idCita;
        if ($("#Ck" + id).prop('checked') === true) {
            Total += parseFloat($("#TxtTarifa" + id).val().split('.').join(''));
        }
    }
    $("#LblTotalPagar").html('$ ' + PonerPuntos(Total));
}

function onChangeCk(idCita, checked) {
    if (checked) {
        $("#Tr" + idCita).addClass('Sel');
    }
    else { $("#Tr" + idCita).removeClass('Sel'); }

    if (obConvenio.esParticular === true) {
        SumarTotalPagar();
    }
}

function onBlurTarifa(ob) {
    var valTarifa = parseFloat($("#TxtTarifa" + ob.idCita).val().split('.').join(''));

    if (isNaN(valTarifa)) {
        valTarifa = 0;
    }

    ServicePost('Citas/UpTar/', { IdCita: ob.idCita, Tarifa: valTarifa }, function (result) {
        if (result.resp === true) {
            $("#TxtTarifa" + ob.idCita).val(PonerPuntos(valTarifa));
        }
        else { console.log(result); }
    });
}


$("#btnFacturar").click(function (e) {
    arIdCitas = [];
    for (var i = 0; i < arCitas.length; i++) {
        var id = arCitas[i].idCita;
        if ($("#Ck" + id).prop('checked') === true) {
            arIdCitas.push(id);
        }
    }

    if (arIdCitas.length > 0) {
        obFactura = {
            idCentro: Cookies.IdCentro,
            tipo: obConvenio.codTipoFact,
            tipoDocumento: obConvenio.codTipoFact,
            numDocumento: 0,
            idPaciente: obPaciente.idPaciente,
            idConvenio: obConvenio.idConvenio,
            idResolucion: 0,
            idUsuario: Cookies.IdUsu,
            codEstado: 'VI',
        }
        AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Facturar los servicios seleccionados?', 'FacturarSer');
    }
});

$("#btnAsignar").click(function (e) {
    window.location.href = url + 'Admision/AsignarCita';
});
$("#btnReiniciar").click(function (e) {
    window.location.href = url + 'Admision/Facturar';
});
$("#btnSalir").click(function (e) {
    window.location.href = url + 'Home';
});



$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }

    if (ModalAccion === 'FacturarSer') {
        ServicePost('Facturacion/', { obFact: obFactura, arIdCitas: arIdCitas }, function (result) {
            if (result.resp === true) {
                idFacturacion = result.idFacturacion;
                $("#ColGrilla").attr('hidden', 'hidden');
                $("#ColExito").removeAttr('hidden');
            }
            else { console.log(result); }
        });
    }
});