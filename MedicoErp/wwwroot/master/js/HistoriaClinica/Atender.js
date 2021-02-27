$("#TxtFecha").datepicker({
    dateFormat: 'yy-mm-dd',
    onSelect: function (date) {
        $("#BodyCitas").html('');
        GetMiAgenda(date);
    }
});


function GetMiAgenda(Fecha) {
    $("#BodyHoras").html('');
    ServicePost('Citas/CAgMed/', { IdMed: Cookies.IdUsu, Fecha: Fecha }, function (result) {
        if (result.resp === true) {
            fnLlenarAgenda(result.lista);
        }
        else { console.log(result); }
    });
}

function fnLlenarAgenda(Lista) {
    var html = '';
    for (var i = 0; i < Lista.length; i++) {
        var ob = Lista[i];
        html += '<tr>' +
            '<td width="10%" class="text-center">' + ob.hora + '</td>' +
            '<td width="15%" class="text-center">' + ob.identificacion + '</td>' +
            '<td>' + ob.nombrePaciente + '</td>' +
            '<td width="33%">' + ob.nombreConvenio + '</td>' +
            '<td width="5%" class="text-center">' +
            "<i class='fa fa-sign-in green' title='Atender' onClick='fnAtender(" + JSON.stringify(ob) + ")'></i>" +
            '</td>' +
            '</tr>';
    }

    if (html === '') { html = '<tr><td colspan="5"></td></tr>'; }

    $("#BodyCitas").html(html);
    $("#BodyCitas i").tooltip();
}

function fnAtender(ob) {

}