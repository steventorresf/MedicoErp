var IdUsuario = 0;
var obUsuario = null;


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


function GetUsuarios() {
    ServiceGet('Usuarios/' + Cookies.IdCentro + '/', function (result) {
        if (result.resp === true) {
            fnLlenarUsuarios(result.lista);
        }
        else { console.log(result); }
    });
}
GetUsuarios();

function fnLlenarUsuarios(Lista) {
    var html = '';
    if (Lista.length > 0) {
        for (var i = 0; i < Lista.length; i++) {
            var ob = Lista[i];
            html += '<tr>' +
                '<td width="15%" class="text-center">' + ob.tipoIden + ' ' + ob.numIden + '</td>' +
                '<td>' + ob.nombreCompleto + '</td>' +
                '<td width="10%" class="text-center">' + ob.codSexo + '</td>' +
                '<td width="15%" class="text-center">' + ob.esMedicoDesc + '</td>' +
                '<td width="15%" class="text-center">' + ob.nombreEstado + '</td>' +
                '<td width="10%" class="text-center">';
            if (ob.codEstado === 'AC') {
                html += "<i class='fa fa-edit blue' title='Editar' onClick='fnEditarUsu(" + JSON.stringify(ob) + ")'></i>" +
                    "<i class='fa fa-lock' title='Resetear Clave' onClick='fnResetearClave(" + JSON.stringify(ob) + ")'></i>" +
                    "<i class='fa fa-user-times red' title='Inactivar' onClick='fnInactivarUsu(" + JSON.stringify(ob) + ")'></i>";
            }
            else {
                html += "<i class='fa fa-user-plus green' title='Activar' onClick='fnActivarUsu(" + JSON.stringify(ob) + ")'></i>";
            }
            html += '</td>' +
                '</tr>';
        }
    }
    else { html = '<tr><td colspan="9"></td></tr>'; }
    $("#BodyUsu").html(html);
    $("#BodyUsu i").tooltip();
}

function fnInactivarUsu(ob) {
    IdUsuario = ob.idUsuario;
    obUsuario = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea INACTIVAR el usuario: <b>"' + ob.nombreCompleto + '"</b>?', 'InactUsu');
}
function fnActivarUsu(ob) {
    IdUsuario = ob.idUsuario;
    obUsuario = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea ACTIVAR el usuario: <b>"' + ob.nombreCompleto + '"</b>?', 'ActUsu');
}
function fnResetearClave(ob) {
    IdUsuario = ob.idUsuario;
    obUsuario = ob;
    AbrirModal('¡Confirmaci&oacute;n!', '¿Desea RESETEAR la clave del usuario: <b>"' + ob.nombreCompleto + '"</b>?', 'ResetClave');
}

function fnOnSelectEsMedico() {
    var value = $("#CboEsMedico").val();

    if (value === 'true') {
        $("#TxtRegistro").val('');
        $("#TxtRegistro").removeAttr('disabled');
    }
    else {
        $("#TxtRegistro").val('.');
        $("#TxtRegistro").attr('disabled', 'disabled');
    }
}

$("#btnCancelar").click(function (e) {
    $("#ColEditor").attr('hidden', 'hidden');
    $("#ColGrilla").removeAttr('hidden');
});

$("#btnNuevo").click(function (e) {
    IdUsuario = 0;
    $("#TextUsuEditor").html('Nuevo Usuario');

    $("#CboTipoIden").selectpicker('val', '0');
    $("#TxtNumIden").val('');
    $("#TxtNombreCompleto").val('');
    $("#CboSexo").selectpicker('val', '0');
    $("#TxtDireccion").val('');
    $("#TxtTelefono").val('');
    $("#TxtFechaNac").val('');
    $("#CboEsMedico").selectpicker('val', '0');
    $("#TxtRegistro").val('');
    $("#TxtRegistro").attr('disabled', 'disabled');
    $("#TxtEstado").val('ACTIVO');
    $("#TxtFechaIngreso").val(new Date());
    $("#TxtNomUsuario").val('');
    $("#TxtNomUsuario").removeAttr('disabled');

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
});

function fnEditarUsu(ob) {
    IdUsuario = ob.idUsuario;
    $("#TextUsuEditor").html('Editar Usuario');

    $("#CboTipoIden").selectpicker('val', ob.tipoIden);
    $("#TxtNumIden").val(ob.numIden);
    $("#TxtNombreCompleto").val(ob.nombreCompleto);
    $("#CboSexo").selectpicker('val', ob.codSexo);
    $("#TxtDireccion").val(ob.direccion);
    $("#TxtTelefono").val(ob.telefono);
    $("#TxtFechaNac").val(ob.fechaNacimiento.substring(0, 10));
    $("#CboEsMedico").selectpicker('val', ob.esMedico.toString());
    $("#TxtRegistro").val(ob.registro);
    $("#TxtEstado").val(ob.nombreEstado);
    $("#TxtFechaIngreso").val(ob.fechaIngreso);
    $("#TxtNomUsuario").val(ob.nomUsuario);
    $("#TxtNomUsuario").attr('disabled', 'disabled');

    if (ob.esMedico === false) {
        $("#TxtRegistro").val('.');
        $("#TxtRegistro").attr('disabled', 'disabled');
    }
    else { $("#TxtRegistro").removeAttr('disabled'); }

    $("#ColGrilla").attr('hidden', 'hidden');
    $("#ColEditor").removeAttr('hidden');
}

function fnGuardar() {
    var ob = {
        tipoIden: $("#CboTipoIden").val(),
        numIden: $("#TxtNumIden").val().trim(),
        nombreCompleto: $("#TxtNombreCompleto").val().trim(),
        codSexo: $("#CboSexo").val(),
        direccion: $("#TxtDireccion").val().trim(),
        telefono: $("#TxtTelefono").val().trim(),
        fechaNacimiento: $("#TxtFechaNac").val(),
        esMedico: $("#CboEsMedico").val(),
        registro: $("#TxtRegistro").val().trim(),
        codEstado: 'AC',
        nomUsuario: $("#TxtNomUsuario").val().trim(),
        clave: '----',
        idCentro: Cookies.IdCentro,
    }

    var NoValido = '';
    if (ob.tipoIden === null || ob.tipoIden === '0') { NoValido += "Seleccione el tipo de identificaci&oacute;n.<br>"; }
    if (ob.numIden === '') { NoValido += "Digite el n&uacute;mero de identificaci&oacute;n.<br>"; }
    if (ob.nombreCompleto === '') { NoValido += "Digite el nombre completo.<br>"; }
    if (ob.codSexo === '0') { NoValido += "Seleccione el sexo.<br>"; }
    if (ob.direccion === '') { NoValido += "Digite la direcci&oacute;n.<br>"; }
    if (ob.telefono === '') { NoValido += "Digite el tel&eacute;fono.<br>"; }
    if (ob.fechaNacimiento === '') { NoValido += "Seleccione la fecha de nacimiento.<br>"; }
    if (ob.esMedico === '0') { NoValido += "Seleccione si es o no m&eacute;dico.<br>"; }
    else {
        if (ob.esMedico === 'true' && ob.registro === '') { NoValido += "Digite el registro m&eacute;dico.<br>"; }
    }
    if (ob.nomUsuario === '') { NoValido += "Digite el nombre de usuario.<br>"; }

    if (NoValido != '') {
        ob = null;
        AbrirModal('¡No Valido!', NoValido, '');
    }

    return ob;
}


$("#btnGuardar").click(function (e) {
    obUsuario = fnGuardar();
    if (obUsuario != null) {
        if (IdUsuario === 0) {
            ServicePost('Usuarios/', obUsuario, function (result) {
                if (result.resp === true) {
                    $("#btnCancelar").click();
                    GetUsuarios();
                    $.bootstrapGrowl('¡El usuario se ha creado exitosamente!', {
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

        if (IdUsuario > 0) {
            ServicePut('Usuarios/' + IdUsuario, obUsuario, function (result) {
                if (result.resp === true) {
                    $("#btnCancelar").click();
                    GetUsuarios();
                    $.bootstrapGrowl('¡Los datos del usuario han sido actualizados exitosamente!', {
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
});

$("#btnModalGenSi").click(function (e) {
    $("#TxtMensajeModalGen").html('');

    if (ModalAccion === '') {
        $("#ModalGeneral").modal('hide');
    }

    if (ModalAccion === 'InactUsu') {
        ServicePut('Usuarios/Inact/' + IdUsuario, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetUsuarios();
            }
            else { console.log(result); }
        });
    }

    if (ModalAccion === 'ActUsu') {
        ServicePut('Usuarios/Act/' + IdUsuario, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                GetUsuarios();
            }
            else { console.log(result); }
        });
    }

    if (ModalAccion === 'ResetClave') {
        ServicePut('Usuarios/RClave/' + IdUsuario, {}, function (result) {
            if (result.resp === true) {
                $("#ModalGeneral").modal('hide');
                $.bootstrapGrowl('¡La clave del usuario <b>"' + obUsuario.nombreCompleto + '</b>" ha sido reseteada exitosamente!', {
                    type: 'success',
                    align: 'center',
                    delay: 6000,
                    width: 'auto',
                    offset: { from: 'bottom', amount: 20 },
                });
            }
            else { console.log(result); }
        });
    }
});