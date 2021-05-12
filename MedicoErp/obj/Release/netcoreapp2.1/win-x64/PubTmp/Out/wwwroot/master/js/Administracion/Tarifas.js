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
                '<td width="15%" class="text-center">' + (ob.reqAutorizacion == true ? 'Si' : 'No') + '</td>' +
                '<td width="15%" class="text-center">' + ob.nombreEstado + '</td>' +
                '<td width="10%" class="text-center">' +
                "<i class='fa fa-money green' title='Editar' onClick='fnTarifas(" + JSON.stringify(ob) + ")'></i>" +
                '</td>' +
                '</tr>';
        }
    }
    else { html = '<tr><td colspan="9"></td></tr>'; }
    $("#BodyCon").html(html);
    $("#BodyCon i").tooltip();
}