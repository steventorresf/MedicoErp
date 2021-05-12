function fnPresionaEnter(e) {
    var tecla = document.all ? e.keyCode : e.which;
    if (tecla == 13) {
        $("#btnIngresar").click();
    }

    if (tecla == 32) {
        return false;
    }
}



$("#btnLogin").click(function (e) {
    $("#GrMenError").attr('hidden', 'hidden');

    var ob = {
        Usu: $("#login-username").val().trim(),
        Con: $("#login-password").val(),
    };

    if (ob.Usu != null && ob.Usu != "" && ob.Con != null && ob.Con != "") {
        ServicePost("General/LogIn/", ob, function (result) {
            switch (result.resp) {
                case "TodoOkey": {
                    window.location.href = url + 'Home';
                    break;
                }
                case "Error": {
                    $("#LblMenError").html('Ha ocurrido un error inesperado');
                    $("#GrMenError").removeAttr('hidden');
                    break;
                }
                case "Hacker": {
                    $("#LblMenError").html('Usted va a ir a la carcel PUTO DE MIERDA');
                    $("#GrMenError").removeAttr('hidden');
                    break;
                }
                default: {
                    $("#LblMenError").html(result.resp);
                    $("#GrMenError").removeAttr('hidden');
                    break;
                }
            }
        });
    }
    else {
        $("#LblMenError").html('Ingrese su usuario y su contraseña.');
        $("#GrMenError").removeAttr('hidden');
    }
});