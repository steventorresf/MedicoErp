function GetMedicos() {
    ServiceGet('Usuarios/Med/' + Cookies.IdCentro, function (result) {
        if (result.resp === true) {
            var html = '';
            for (var i = 0; i < result.lista.length; i++) {
                var ob = result.lista[i];
                html += '<option value="' + ob.idUsuario + '">' + ob.nombreCompleto + '</option>';
            }
            if (html != '') { html = '<option value="0">*Todos*</option>' + html; }
            $("#CboMedico").append(html);
        }
        else { console.log(result); }
    });
}
GetMedicos();

$("#btnConsultar").click(function (e) {
    var ob = {
        FechaIni: $("#TxtFechaIni").val(),
        FechaFin: $("#TxtFechaFin").val(),
        IdMedico: $("#CboMedico").val(),
        TipoArch: $("#CboTipoArchivo").val(),
        NomUsu: Cookies.NombreUsu,
    }

    var NoValido = '';
    if (ob.FechaIni === '') { NoValido += 'Seleccione la fecha inicial.<br>'; }
    if (ob.FechaFin === '') { NoValido += 'Seleccione la fecha final.<br>'; }
    if (NoValido === '') {
        ServicePost('Citas/CAg/', ob, function (result) {
            if (result.resp === true) {
                window.location.href = url + 'Home/Excel?sContent=' + 's' + '&fileName=' + 'Agenda.xlsx';
                //window.location = url + 'Home/Download?IdUsu=' + Cookies.IdUsu + '&FileName=Agenda';
            }
        });
    }
});

//window.location.href = url + 'Home/Excel';