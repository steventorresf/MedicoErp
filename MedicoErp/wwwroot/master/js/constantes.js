const Tab = {
    TiposIden: 'TabTiposIden',
    EstadosCivil: 'TabEstadosCivil',
    ClaseDoc: 'GENCDOC',
    ViasAdmon: 'TabViasAdmon',
    TiposUsuario: 'TabTipoUsuario',
}

const Estados = {
    Agendado: 'AG',
    Libre: 'LI',
    Confirmado: 'CO',
    Atendido: 'AT',
    Activo: 'AC',
    Pendiente: 'PE',
    Guardado: 'GU',
    Finalizado: 'FI',
}

const Campos = {
    Evolucion: 'EV',
    Biopsia: 'BO',
    AyudaDx: 'AD',
    Anexos: 'AX',
    DiagPal: 'DP',
    DiagRel1: 'DR1',
    DiagRel2: 'DR2',
    DiagRel3: 'DR3',
}

const Docs = {
    CodigoConsentimiento: 'CONSEN',
};

const arNumeros = "0123456789";

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

function datepicker(id, datesOff, onChangeFecha) {
    $("#" + id).datepicker('destroy');
    $("#" + id).datepicker({
        dateFormat: 'dd/mm/yy',
        beforeShowDay: function (date) {
            var currentDate = date.toISOString().substring(0, 10);
            for (var i = 0; i < datesOff.length; i++) {
                if (currentDate === datesOff[i].toString()) {
                    return [true];
                }
            }
            return [false];
        },
        onSelect: onChangeFecha,
    }).on('changeDate', onChangeFecha);
}

function multiDatesPicker(id, datesOff) {
    $("#" + id).multiDatesPicker('destroy');
    $("#" + id).multiDatesPicker({
        dateFormat: 'yy-mm-dd',
        beforeShowDay: function (date) {
            if (date.getUTCDay() > 0) {
                var currentDate = date.toISOString().substring(0, 10);
                for (var i = 0; i < datesOff.length; i++) {
                    if (currentDate === datesOff[i]) {
                        return [false, '', 'Esta fecha ya se encuentra Inhabilitada'];
                    }
                }
                return [true];
            }
            else { return [false, '', 'Esta fecha ya se encuentra Inhabilitada']; }
        },

    });
}

function FormatDate(date) {
    var DateFormatted = date.substring(6) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
    return DateFormatted;
}
function FormatearFecha(sDate) {
    var date = new Date(sDate);

    var dia = date.getDay();
    var mes = date.getMonth() + 1;
    var anio = date.getFullYear();

    var DateFormatted = anio + '-' + (mes < 10 ? '0' + mes : mes) + '-' + (dia > 9 ? dia : '0' + dia);
    return DateFormatted;
}

function PonerPuntosDouble(valor) {
    var cadena = valor.toString().replace(".", ",");
    var rescadena = "";

    var i = cadena.indexOf(',');
    if (i > 0) {
        rescadena = cadena.substring(i);
        cadena = cadena.substring(0, i);
    }


    var lon = cadena.length - 3;
    while (lon > 0) {
        cadena = cadena.substring(0, lon) + "." + cadena.substring(lon);
        lon -= 3;
    }
    return cadena + rescadena;
}

Date.prototype.DateErp = function (sep) {
    var date = new Date(this.valueOf());

    var year = date.getFullYear();
    var month = (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1);
    var day = (date.getDate() >= 10 ? '' : '0') + date.getDate();
    var dateFormatted = '';

    if (sep) { dateFormatted = year + '-' + month + '-' + day; }
    else { dateFormatted = year + '' + month + '' + day; }
    return dateFormatted;
}

Date.prototype.SetDateErp = function (tipo) {
    var date = new Date(this.valueOf());

    var year = date.getFullYear();
    var month = (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1);
    var day = (date.getDate() >= 10 ? '' : '0') + date.getDate();
    var dateFormatted = '';

    switch (tipo) {
        case '1':
            dateFormatted = year + '-' + month + '-' + day;
            break;
        case '2':
            dateFormatted = month + '/' + day + '/' + year;
            break;
    }
    
    return dateFormatted;
}

function fnQuitarEspaciosEnBlanco(variable) {
    cadena = variable;
    while (cadena.indexOf(' ') > 0) {
        cadena = cadena.replace(" ", "");
    }
    return cadena;
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

function esNumero(numero) {
    if (arNumeros.indexOf(numero) >= 0) {
        return true;
    }
    else {
        return false;
    }
}