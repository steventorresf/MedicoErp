const serviciosAjax = {
    getAgendaMedica: getAgendaMedica
}

function getAgendaMedica(data) {
    window.location.href = url + 'Excel/GetAgendaMedica?Fi=' + data.fechaInicio + '&Ff=' + data.fechaFin + '&Im=' + data.idMedico + '&Nm=' + data.medico;
}