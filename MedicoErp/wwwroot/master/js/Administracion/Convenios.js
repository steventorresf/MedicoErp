var obConvenio = null;
var obTarifa = null;

function GetConvenios() {
    ServiceGet('Convenios/' + Cookies.IdCentro + '/', function (result) {
        if (result.resp === true) {
            fnLlenarConvenios(result.lista);
        }
        else { console.log(result); }
    });
}
GetConvenios();

function fnLlenarConvenios(Lista) {
    var html = '';
    if (Lista.length > 0) {
        for (var i = 0; i < Lista.length; i++) {
            var ob = Lista[i];
            html += '<tr>' +
                '<td>' + ob.nombreConvenio + '</td>' +
                '<td width="15%" class="text-center">' + ob.tipoFacturacion + '</td>' +
                '<td width="15%" class="text-center">' + (ob.reqAutorizacion === true ? 'Si' : 'No') + '</td>' +
                '<td width="15%" class="text-center">' + (ob.esParticular === true ? 'Si' : 'No') + '</td>' +
                '<td width="15%" class="text-center">' + ob.nombreEstado + '</td>' +
                '<td width="10%" class="text-center">' +
                "<i class='fa fa-edit green' title='Editar' onClick='fnEditarCon(" + JSON.stringify(ob) + ")'></i>" +
                "<i class='fa fa-money blue' title='Tarifas' onClick='fnTarifas(" + JSON.stringify(ob) + ")'></i>" +
                (ob.codEstado === 'AC' ? "<i class='fa fa-ban red' title='Inactivar' onClick='fnInactivarCon(" + JSON.stringify(ob) + ")'></i>" :
                    "<i class='fa fa-ban red' title='Inactivar' onClick='fnActivarCon(" + JSON.stringify(ob) + ")'></i>") +
                '</td>' +
                '</tr>';
        }
    }
    else { html = '<tr><td colspan="9"></td></tr>'; }
    $("#BodyCon").html(html);
    $("#BodyCon i").tooltip();
}

function LlenarTipoFacturacion() {
    ServiceGet('TablasDetalle/' + Tab.TipoFact + '/', function (result) {
        if (result.resp === true) {
            
        }
        else { console.log(result); }
    });
}
LlenarTipoFacturacion();


$("#btnCancelar").click(function (e) {
    $("#ColEditor").attr('hidden', 'hidden');
    $("#ColGrilla").removeAttr('hidden');
});

$("#btnNuevo").click(function (e) {
    $("#txtNomConvenio").val('');
    $("#cboReqAuto").selectpicker('val', 'false');
    $("#cboEsParticular").selectpicker('val', 'false');
    $("#cboTipoFact").selectpicker('val', 'VO');

    $("#btnGuardar2").attr('hidden', 'hidden');
    $("#btnGuardar1").removeAttr('hidden');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
});
function fnEditarCon(ob) {
    obConvenio = ob;

    $("#txtNomConvenio").val(ob.nombreConvenio);
    $("#cboReqAuto").selectpicker('val', ob.reqAutorizacion.toString());
    $("#cboEsParticular").selectpicker('val', ob.esParticular.toString());
    $("#cboTipoFact").selectpicker('val', ob.codTipoFact);

    $("#btnGuardar1").attr('hidden', 'hidden');
    $("#btnGuardar2").removeAttr('hidden');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
}


$("#btnGuardar1").click(function (e) {
    var ob = {
        nombreConvenio: $("#txtNomConvenio").val(),
        reqAutorizacion: $("#cboReqAuto").val(),
        codTipoFact: $("#cboTipoFact").val(),
        codEstado: 'AC',
        esParticular: $("#cboEsParticular").val(),
        idCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (ob.nombreConvenio === '') { NoValido += 'Digite el nombre del convenio.<br>'; }
    if (ob.reqAutorizacion === null) { NoValido += 'Seleccione si requiere autorizaci&oacute;n.<br>'; }
    if (ob.tipoFact === null) { NoValido += 'Seleccione un tipo de facturaci&oacute;n.<br>'; }
    if (NoValido === '') {
        ServicePost('Convenios/', ob, function (result) {
            if (result.resp === true) {
                $("#btnCancelar").click();
                GetConvenios();
            }
            else { console.log(result); }
        });
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }
});

$("#btnGuardar2").click(function (e) {
    var ob = {
        nombreConvenio: $("#txtNomConvenio").val(),
        reqAutorizacion: $("#cboReqAuto").val(),
        codTipoFact: $("#cboTipoFact").val(),
        codEstado: 'AC',
        esParticular: $("#cboEsParticular").val(),
        idCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (ob.nombreConvenio === '') { NoValido += 'Digite el nombre del convenio.<br>'; }
    if (ob.reqAutorizacion === null) { NoValido += 'Seleccione si requiere autorizaci&oacute;n.<br>'; }
    if (ob.tipoFact === null) { NoValido += 'Seleccione un tipo de facturaci&oacute;n.<br>'; }
    if (NoValido === '') {
        ServicePut('Convenios/' + obConvenio.idConvenio, ob, function (result) {
            if (result.resp === true) {
                $("#btnCancelar").click();
                GetConvenios();
            }
            else { console.log(result); }
        });
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }
});


function fnInactivarCon(ob) {
    obConvenio = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Inactivar este convenio?', 'InactCon');
}
function fnActivarCon(ob) {
    obConvenio = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Activar este convenio?', 'ActCon');
}


function fnTarifas(ob) {
    obConvenio = ob;
    GetTarifas();

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColTarifas").removeAttr('hidden');
}

$("#btnRegresar").click(function (e) {
    $("#ColTarifas").attr('hidden', 'hidden');
    $("#ColGrilla").removeAttr('hidden');
});

function GetTarifas() {
    ServiceGet('ServiciosContratados/' + obConvenio.idConvenio + '/', function (result) {
        if (result.resp === true) {
            fnLlenarServiciosContratados(result.lista);
        }
        else { console.log(result); }
    });
}

function fnLlenarServiciosContratados(Lista) {
    var html = '';
    if (Lista.length > 0) {
        for (var i = 0; i < Lista.length; i++) {
            var ob = Lista[i];
            html += '<tr>' +
                '<td width="150px" class="text-center">' + ob.servicio.codigoRef + '</td>' +
                '<td>' + ob.servicio.nombreServicio + '</td>' +
                '<td width="150px">' + "<input type='text' value='" + PonerPuntos(ob.tarifa) + "' onblur='fnOnBlurTar(this.value, " + JSON.stringify(ob) + ")' />" + "</td>" +
                '<td width="100px" class="text-center">' +
                "<i class='fa fa-remove red' title='Quitar' onClick='fnQuitarSer(" + JSON.stringify(ob) + ")'></i>" +
                '</td>' +
                '</tr>';
        }
    }
    else { html = '<tr><td colspan="9"></td></tr>'; }
    $("#BodyTar").html(html);
    $("#BodyTar i").tooltip();
}

function fnOnBlurTar(value, ob) {
    var obTar = {
        VTarifa: parseFloat(value.split('.').join('')),
        IdDetalle: ob.idDetalle,
    }

    if (!isNaN(obTar.VTarifa)) {
        ServicePost('ServiciosContratados/ModTarifa/', obTar, function (result) {
            if (result.resp === true) {
                $.bootstrapGrowl("¡La tarifa ha sido actualizada correctamente!", {
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
}

function fnQuitarSer(ob) {
    obTarifa = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Quitar la tarifa del Servicio:<br><b>"' + ob.servicio.nombreServicio + '"</b>?', 'QuitarSer');
}

$("#btnAgregar").click(function (e) {
    ServiceGet('ServiciosContratados/GetNo/' + Cookies.IdCentro + '/' + obConvenio.idConvenio + '/', function (result) {
        if (result.resp === true) {
            fnLlenarServiciosNoContratados(result.lista);
            $("#ModalSerNo").modal('show');
        }
        else { console.log(result); }
    });
});

function fnLlenarServiciosNoContratados(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<option value="' + ob.idServicio + '">' + ob.nombreServicio + '</option>';
    }
    $("#cboSerNo").append(html);
    $("#cboSerNo").selectpicker('refresh');
}

$("#btnAgregarSerNo").click(function (e) {
    var lista = $("#cboSerNo").val();
    var obLista = [];
    for (var i = 0; i < lista.length; i++) {
        obLista.push({
            idServicio: lista[i],
            idConvenio: obConvenio.idConvenio,
            tarifa: 0,
        });
    }

    if (obLista.length > 0) {
        ServicePost('ServiciosContratados/', obLista, function (result) {
            if (result.resp === true) {
                $("#ModalSerNo").modal('hide');
                GetTarifas();
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

    if (ModalAccion === 'InactCon') {
        ServicePut('Convenios/Inact/' + obConvenio.idConvenio, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetConvenios();
            }
            else { console.log(result); }
        });
    }

    if (ModalAccion === 'ActCon') {
        ServicePut('Convenios/Act/' + obConvenio.idConvenio, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetConvenios();
            }
            else { console.log(result); }
        });
    }

    if (ModalAccion === 'QuitarSer') {
        ServiceDelete('ServiciosContratados/' + obTarifa.idDetalle + '/', function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetTarifas();
            }
            else { console.log(result); }
        });
    }
});