var obServicio = null;

function GetServicios() {
    ServiceGet('Servicios/' + Cookies.IdCentro + '/', function (result) {
        if (result.resp === true) {
            fnLlenarServicios(result.lista);
        }
        else { console.log(result); }
    });
}
GetServicios();

function fnLlenarServicios(Lista) {
    var html = '';
    if (Lista.length > 0) {
        for (var i = 0; i < Lista.length; i++) {
            var ob = Lista[i];
            html += '<tr>' +
                '<td width="15%" class="text-center">' + ob.codigoRef + '</td>' +
                '<td>' + ob.nombreServicio + '</td>' +
                '<td width="15%" class="text-center">' + ob.especialidad.nombreEspecialidad + '</td>' +
                '<td width="15%" class="text-center">' + ob.claseServicio.claseServicio + '</td>' +
                '<td width="15%" class="text-center">' + ob.tipoCobro + '</td>' +
                '<td width="10%" class="text-center">' +
                "<i class='fa fa-edit green' title='Editar' onClick='fnEditarSer(" + JSON.stringify(ob) + ")'></i>" +
                "<i class='fa fa-ban red' title='Inactivar' onClick='fnInactivarSer(" + JSON.stringify(ob) + ")'></i>" +
                '</td>' +
                '</tr>';
        }
    }
    else { html = '<tr><td colspan="9"></td></tr>'; }
    $("#BodySer").html(html);
    $("#BodySer i").tooltip();
}

function GetEspecialidades() {
    ServiceGet('Especialidades/', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idEspecialidad + '">' + ob.nombreEspecialidad + '</option>';
            }
            $("#cboEsp").append(html);
        }
        else { console.log(result); }
    });
}
GetEspecialidades();

function GetClasesServicio() {
    ServiceGet('ClasesServicio/', function (result) {
        if (result.resp === true) {
            var html = '<option value="0">*Seleccione...*</option>';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idClaseServicio + '">' + ob.claseServicio + '</option>';
            }
            $("#cboClaseSer").append(html);
        }
        else { console.log(result); }
    });
}
GetClasesServicio();


$("#btnCancelar").click(function (e) {
    $("#ColEditor").attr('hidden', 'hidden');
    $("#ColGrilla").removeAttr('hidden');
});

$("#btnNuevo").click(function (e) {
    $("#txtCodigoRef").val('');
    $("#cboEsp").selectpicker('val', '0');
    $("#txtNomServicio").val('');
    $("#cboClaseSer").selectpicker('val', '0');
    $("#cboTipoCobro").selectpicker('val', 'MO');

    $("#btnGuardar2").attr('hidden', 'hidden');
    $("#btnGuardar1").removeAttr('hidden');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
});
function fnEditarSer(ob) {
    obServicio = ob;

    $("#txtCodigoRef").val(ob.codigoRef);
    $("#cboEsp").selectpicker('val', ob.idEspecialidad.toString());
    $("#txtNomServicio").val(ob.nombreServicio);
    $("#cboClaseSer").selectpicker('val', ob.idClaseServicio.toString());
    $("#cboTipoCobro").selectpicker('val', ob.tipoCobro);

    $("#btnGuardar1").attr('hidden', 'hidden');
    $("#btnGuardar2").removeAttr('hidden');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
}


$("#btnGuardar1").click(function (e) {
    var ob = {
        codigoRef: $("#txtCodigoRef").val().trim(),
        idEspecialidad: $("#cboEsp").val(),
        nombreServicio: $("#txtNomServicio").val().trim(),
        idClaseServicio: $("#cboClaseSer").val(),
        tipoCobro: $("#cboTipoCobro").val(),
        activo: true,
        idCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (ob.codigoRef === '') { NoValido += 'Digite el c&oacute;digo ref del servicio.<br>'; }
    if (ob.idEspecialidad === null) { NoValido += 'Seleccione una especialidad.<br>'; }
    if (ob.nombreServicio === '') { NoValido += 'Digite el nombre del servicio.<br>'; }
    if (ob.idClaseServicio === null) { NoValido += 'Seleccione una clase de servicio.<br>'; }
    if (ob.tipoCobro === null) { NoValido += 'Seleccione un tipo de cobro.<br>'; }
    if (NoValido === '') {
        ServicePost('Servicios/', ob, function (result) {
            if (result.resp === true) {
                $("#btnCancelar").click();
                GetServicios();
            }
            else { console.log(result); }
        });
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }
});

$("#btnGuardar2").click(function (e) {
    var ob = {
        codigoRef: $("#txtCodigoRef").val().trim(),
        idEspecialidad: $("#cboEsp").val(),
        nombreServicio: $("#txtNomServicio").val().trim(),
        idClaseServicio: $("#cboClaseSer").val(),
        tipoCobro: $("#cboTipoCobro").val(),
        activo: true,
        idCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (ob.codigoRef === '') { NoValido += 'Digite el c&oacute;digo ref del servicio.<br>'; }
    if (ob.idEspecialidad === null) { NoValido += 'Seleccione una especialidad.<br>'; }
    if (ob.nombreServicio === '') { NoValido += 'Digite el nombre del servicio.<br>'; }
    if (ob.idClaseServicio === null) { NoValido += 'Seleccione una clase de servicio.<br>'; }
    if (ob.tipoCobro === null) { NoValido += 'Seleccione un tipo de cobro.<br>'; }
    if (NoValido === '') {
        ServicePut('Servicios/' + obServicio.idServicio + '/', ob, function (result) {
            if (result.resp === true) {
                $("#btnCancelar").click();
                GetServicios();
            }
            else { console.log(result); }
        });
    }
    else { AbrirModal('¡No Valido!', NoValido, ''); }
});


function fnInactivarSer(ob) {
    obServicio = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea Inactivar este servicio?', 'InactSer');
}



$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }

    if (ModalAccion === 'InactSer') {
        ServicePut('Servicios/Inact/' + obServicio.idServicio, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetServicios();
            }
            else { console.log(result); }
        });
    }
});