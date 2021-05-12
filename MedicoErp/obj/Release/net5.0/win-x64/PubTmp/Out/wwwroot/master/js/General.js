function ServiceGet(ruta, fnSuccess) {
    $.ajax({
        type: "GET",
        url: url + 'api/' + ruta,
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: fnSuccess,
        error: function (result) {
            console.log("Error");
            console.log(result);
        }
    });
}

function ServicePost(ruta, data, fnSuccess) {
    $.ajax({
        type: "POST",
        url: url + 'api/' + ruta,
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: fnSuccess,
        error: function (result) {
            console.log("Error");
            console.log(result);
        }
    });
}

function ServicePostMvc(ruta, data, fnSuccess) {
    $.ajax({
        type: "POST",
        url: url + ruta,
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: fnSuccess,
        error: function (result) {
            console.log("Error");
            console.log(result);
        }
    });
}

function ServicePut(ruta, data, fnSuccess) {
    $.ajax({
        type: "PUT",
        url: url + 'api/' + ruta,
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: fnSuccess,
        error: function (result) {
            console.log("Error");
            console.log(result);
        }
    });
}

function ServiceDelete(ruta, fnSuccess) {
    $.ajax({
        type: "DELETE",
        url: url + 'api/' + ruta,
        contentType: "application/json",
        dataType: "json",
        async: false,
        success: fnSuccess,
        error: function (result) {
            console.log("Error");
            console.log(result);
        }
    });
}


function PonerPuntos(valor) {
    var cadena = valor.toString();
    var lon = cadena.length - 3;
    while (lon > 0) {
        cadena = cadena.substring(0, lon) + "." + cadena.substring(lon);
        lon -= 3;
    }
    return cadena;
}

var Cookies = {};
function GetCookies() {
    ServiceGet("General/GetCookies/", function (result) {
        if (result.resp === true) {
            if (result.esValido === true) {
                Cookies = result.obCookies;
                $("#ImgDelUsuario").attr('src', url + 'img/' + Cookies.Imagen);
                $("#TxtNombreDelUsuario").html(Cookies.NombreUsuario);
            }
        }
        else { console.log(result); }
    });
}
GetCookies();

function fnCerrarSesion() {
    ServicePost("General/LogOut/", Cookies, function (result) {
        if (result.resp === true) {
            window.location.href = url + 'Login';
        }
        else { console.log(result); }
    });
}


var ModalAccion = "";
function AbrirModal(TxtEnca, TxtDetalle, Accion) {
    if (Accion == "") { $("#btnModalGenCan").hide(); }
    else { $("#btnModalGenCan").show(); }

    $("#TxtMensajeModalGen").html('');
    $("#ModalGeneral").modal('show');
    $("#TxtModalEnca").html(TxtEnca);
    $("#TxtModalDetalle").html(TxtDetalle);

    ModalAccion = Accion;
}


$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '< Ant',
    nextText: 'Sig >',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'yy-mm-dd',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: '',
    changeMonth: true,
    changeYear: true,
};
$.datepicker.setDefaults($.datepicker.regional['es']);


const Tab = {
    Estados: "TabEstados",
    EstadosCivil: "TabEstadosCivil",
    CausasExterna: "TabCausasExterna",
    FinalidadConsulta: "TabFinalidadConsulta",
    TiposDiag: "TabTiposDiag",
    Rips: "TabRips",
    TiposIden: "TabTiposIden",
    TiposDato: "TabTiposDato",
    TipoFact: "TabTipoFact",
}


function fnQuitarEspaciosEnBlanco(variable) {
    cadena = variable;
    while (cadena.indexOf(' ') > 0) {
        cadena = cadena.replace(" ", "");
    }
    return cadena;
}

var arNumeros = "0123456789";
function esNumero(numero) {
    if (arNumeros.indexOf(numero) >= 0) {
        return true;
    }
    else {
        return false;
    }
}

function fnValidarHora(hora) {
    if (hora.length <= 8) {
        if (esNumero(hora.substring(0, 1)) && esNumero(hora.substring(1, 2)) && esNumero(hora.substring(3, 4)) && esNumero(hora.substring(4, 5))) {
            hora = fnQuitarEspaciosEnBlanco(hora);
            if (hora.substring(2, 3) == ':') {
                hora = hora.toUpperCase();

                if (hora.substring(5, 7) == 'AM') {
                    hora = hora.replace("AM", "");
                    var num = parseInt(hora.substring(0, 2));
                    if (num <= 12) {
                        return hora + hora.substring(5, 7);
                    }
                    else {
                        return "error";
                    }
                }

                if (hora.substring(5, 7) == 'PM') {
                    hora = hora.replace("PM", "");
                    var num = parseInt(hora.substring(0, 2));
                    if (num <= 12) {
                        if (num < 12) { hora = (num + 12).toString() + hora.substring(2, 5); }
                        return hora;
                    }
                    else {
                        return "error";
                    }
                }
            }
        }
    }
    return "error";
}