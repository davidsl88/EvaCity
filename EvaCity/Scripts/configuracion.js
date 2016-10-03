/****Inicio****/
$(document).ready(function () {
    $('#idDatosPersonales').show();
    $('#idUsuarios').hide();
    $('#idProyectos').hide();
    $('#idCiudades').hide();
    $('#idUbicaciones').hide();

    $('#filtrosUsuario').hide();
    $('#filtrosProyecto').hide();
    $('#filtrosCiudad').hide();
    $('#filtrosUbicaciones').hide();

    $('#panelFiltros').hide();
});

/****Menu Configuracion****/
$('#idMenuUsuarios').click(function () {
    $('#idUsuarios').show();
    $('#idProyectos').hide();
    $('#idCiudades').hide();
    $('#idDatosPersonales').hide();
    $('#idUbicaciones').hide();

    $('#filtrosUsuario').show();
    $('#filtrosProyecto').hide();
    $('#filtrosCiudad').hide();
    $('#filtrosUbicaciones').hide();

    $('#panelFiltros').show();
});
$('#idMenuProyectos').click(function () {
    $('#idUsuarios').hide();
    $('#idProyectos').show();
    $('#idCiudades').hide();
    $('#idDatosPersonales').hide();
    $('#idUbicaciones').hide();

    $('#filtrosUsuario').hide();
    $('#filtrosProyecto').show();
    $('#filtrosCiudad').hide();
    $('#filtrosUbicaciones').hide();

    $('#panelFiltros').show();
});
$('#idMenuCiudades').click(function () {
    $('#idUsuarios').hide();
    $('#idProyectos').hide();
    $('#idCiudades').show();
    $('#idDatosPersonales').hide();
    $('#idUbicaciones').hide();

    $('#filtrosUsuario').hide();
    $('#filtrosProyecto').hide();
    $('#filtrosCiudad').show();
    $('#filtrosUbicaciones').hide();

    $('#panelFiltros').show();
});
$('#idMenuDatosPersonales').click(function () {
    $('#idUsuarios').hide();
    $('#idProyectos').hide();
    $('#idCiudades').hide();
    $('#idDatosPersonales').show();
    $('#idUbicaciones').hide();

    $('#filtrosUsuario').hide();
    $('#filtrosProyecto').hide();
    $('#filtrosCiudad').hide();
    $('#filtrosUbicaciones').hide();

    $('#panelFiltros').hide();
});
$('#idMenuUbicaciones').click(function () {
    $('#idUsuarios').hide();
    $('#idProyectos').hide();
    $('#idCiudades').hide();
    $('#idDatosPersonales').hide();
    $('#idUbicaciones').show();

    $('#filtrosUsuario').hide();
    $('#filtrosProyecto').hide();
    $('#filtrosCiudad').hide();
    $('#filtrosUbicaciones').show();

    $('#panelFiltros').show();
});

/****Mostrar/ocultar campos editables****/
/*Datos Personales*/
$('.nombreUsuario-hide').hide();
$('.perfil-hide').hide();
$('.fechaNacimiento-hide').hide();
$('.telefono-hide').hide();
$('.email-hide').hide();
$('.contraseña-hide').hide();

//NombreUsuario
$('#rowNombreUsuario').on('click', function () {
    $(this).addClass('selected');
    $('.nombreUsuario-hide').show();
    $('#editarNombreUsuario').hide();
});

$('#cancelarNombreUsuario').on('click', function () {
    $('.nombreUsuario-hide').hide();
    $('#editarNombreUsuario').show();
    $('#txtNombreUsuario').val($('#labelNombreUsuario').text());
});

//Perfil
$('#rowPerfil').on('click', function () {
    $(this).addClass('selected');
    $('.perfil-hide').show();
    $('#editarPerfil').hide();
});

$('#cancelarPerfil').on('click', function () {
    $('.perfil-hide').hide();
    $('#editarPerfil').show();
});

//Fecha de nacimiento
$('#rowFechaNacimiento').on('click', function () {
    $(this).addClass('selected');
    $('.fechaNacimiento-hide').show();
    $('#editarFechaNacimiento').hide();
});

$('#cancelarFechaNacimiento').on('click', function () {
    $('.fechaNacimiento-hide').hide();
    $('#editarFechaNacimiento').show();
    $('#txtFechaNacimiento').val($('#labelFechaNacimiento').text());
});

//Telefono
$('#rowTelefono').on('click', function () {
    $(this).addClass('selected');
    $('.telefono-hide').show();
    $('#editarTelefono').hide();
});

$('#cancelarTelefono').on('click', function () {
    $('.telefono-hide').hide();
    $('#editarTelefono').show();
    $('#txtTelefono').val($('#labelTelefono').text());
});

//Email
$('#rowEmail').on('click', function () {
    $(this).addClass('selected');
    $('.email-hide').show();
    $('#editarEmail').hide();
});

$('#cancelarEmail').on('click', function () {
    $('.email-hide').hide();
    $('#editarEmail').show();
    $('#txtEmail').val($('#labelEmail').text());
});

//Contraseña
$('#rowContraseña').on('click', function () {
    $(this).addClass('selected');
    $('.contraseña-hide').show();
    $('#editarContraseña').hide();
});

$('#cancelarContraseña').on('click', function () {
    $('.contraseña-hide').hide();
    $('#editarContraseña').show();
    $('#txtActualContraseña').val("");
    $('#txtNuevaContraseña').val("");
    $('#txtConfirmarContraseña').val("");
});

/*Usuarios*/
$('.usuarioNombreUsuario-hide').hide();
$('.usuarioPerfil-hide').hide();
$('.usuarioFechaNacimiento-hide').hide();
$('.usuarioTelefono-hide').hide();
$('.usuarioEmail-hide').hide();

//NombreUsuario
$('#rowUsuarioNombreUsuario').on('click', function () {
    $(this).addClass('selected');
    $('.usuarioNombreUsuario-hide').show();
    $('#editarUsuarioNombreUsuario').hide();
});

$('#cancelarUsuarioNombreUsuario').on('click', function () {
    $('.usuarioNombreUsuario-hide').hide();
    $('#editarUsuarioNombreUsuario').show();
    $('#txtUsuarioNombreUsuario').val($('#labelUsuarioNombreUsuario').text());
});

//Perfil
$('#rowUsuarioPerfil').on('click', function () {
    $(this).addClass('selected');
    $('.usuarioPerfil-hide').show();
    $('#editarUsuarioPerfil').hide();
});

$('#cancelarUsuarioPerfil').on('click', function () {
    $('.usuarioPerfil-hide').hide();
    $('#editarUsuarioPerfil').show();
});

//Fecha de nacimiento
$('#rowUsuarioFechaNacimiento').on('click', function () {
    $(this).addClass('selected');
    $('.usuarioFechaNacimiento-hide').show();
    $('#editarUsuarioFechaNacimiento').hide();
});

$('#cancelarUsuarioFechaNacimiento').on('click', function () {
    $('.usuarioFechaNacimiento-hide').hide();
    $('#editarUsuarioFechaNacimiento').show();
    $('#txtUsuarioFechaNacimiento').val($('#labelUsuarioFechaNacimiento').text());
});

//Telefono
$('#rowUsuarioTelefono').on('click', function () {
    $(this).addClass('selected');
    $('.usuarioTelefono-hide').show();
    $('#editarUsuarioTelefono').hide();
});

$('#cancelarUsuarioTelefono').on('click', function () {
    $('.usuarioTelefono-hide').hide();
    $('#editarUsuarioTelefono').show();
    $('#txtUsuarioTelefono').val($('#labelUsuarioTelefono').text());
});

//Email
$('#rowUsuarioEmail').on('click', function () {
    $(this).addClass('selected');
    $('.usuarioEmail-hide').show();
    $('#editarUsuarioEmail').hide();
});

$('#cancelarUsuarioEmail').on('click', function () {
    $('.usuarioEmail-hide').hide();
    $('#editarUsuarioEmail').show();
    $('#txtUsuarioEmail').val($('#labelUsuarioEmail').text());
});

/****Guardar campos editables Datos Personales****/
//Nombre de usuario
function editarNombreUsuario() {
    var model = {
        IdUsuario: $('#hiddenIdUsuario').val(),
        NombreUsuario: $('#txtNombreUsuario').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            $('.nombreUsuario-hide').hide();
            $('#editarNombreUsuario').show();
            $('#labelNombreUsuario').text(data.NombreUsuario);
            $('#txtNombreUsuario').val(data.NombreUsuario);
            $('#rowNombreUsuario').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowEmail').hasClass('selected')) {
                $('#rowEmail').removeClass('selected');
                $('.email-hide').hide();
                $('#editarEmail').show();
            }
            if ($('#rowPerfil').hasClass('selected')) {
                $('#rowPerfil').removeClass('selected');
                $('.perfil-hide').hide();
                $('#editarPerfil').show();
            }
            if ($('#rowFechaNacimiento').hasClass('selected')) {
                $('#rowFechaNacimiento').removeClass('selected');
                $('.fechaNacimiento-hide').hide();
                $('#editarFechaNacimiento').show();
            }
            if ($('#rowTelefono').hasClass('selected')) {
                $('#rowTelefono').removeClass('selected');
                $('.telefono-hide').hide();
                $('#editarTelefono').show();
            }
            if ($('#rowContraseña').hasClass('selected')) {
                $('#rowContraseña').removeClass('selected');
                $('.contraseña-hide').hide();
                $('#editarContraseña').show();
            }

            toastr.success("Nombre de usuario guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el nombre de usuario.");
        },
    });
};

function editarPerfil() {
    var model = {
        IdUsuario: $('#hiddenIdUsuario').val(),
        Perfil: $('#perfilSeleccionado').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            $('.perfil-hide').hide();
            $('#editarPerfil').show();
            $('#labelPerfil').text(data.Perfil);
            $('#perfilSeleccionado').val(data.Perfil);
            $('#rowPerfil').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowEmail').hasClass('selected')) {
                $('#rowEmail').removeClass('selected');
                $('.email-hide').hide();
                $('#editarEmail').show();
            }
            if ($('#rowFechaNacimiento').hasClass('selected')) {
                $('#rowFechaNacimiento').removeClass('selected');
                $('.fechaNacimiento-hide').hide();
                $('#editarFechaNacimiento').show();
            }
            if ($('#rowTelefono').hasClass('selected')) {
                $('#rowTelefono').removeClass('selected');
                $('.telefono-hide').hide();
                $('#editarTelefono').show();
            }
            if ($('#rowContraseña').hasClass('selected')) {
                $('#rowContraseña').removeClass('selected');
                $('.contraseña-hide').hide();
                $('#editarContraseña').show();
            }

            toastr.success("Perfil actualizado.");
        },
        error: function (data) {
            toastr.error("No se pudo actualizar el perfil.");
        },
    });
};

function editarEmail() {
    var usuario = {
        IdUsuario: $('#hiddenIdUsuario').val(),
        Email: $('#txtEmail').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.email-hide').hide();
            $('#editarEmail').show();
            $('#labelEmail').text(data.Email);
            $('#txtEmail').val(data.Email);
            $('#rowEmail').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowNombreUsuario').hasClass('selected')) {
                $('#rowNombreUsuario').removeClass('selected');
                $('.nombreUsuario-hide').hide();
                $('#editarNombreUsuario').show();
            }
            if ($('#rowFechaNacimiento').hasClass('selected')) {
                $('#rowFechaNacimiento').removeClass('selected');
                $('.fechaNacimiento-hide').hide();
                $('#editarFechaNacimiento').show();
            }
            if ($('#rowTelefono').hasClass('selected')) {
                $('#rowTelefono').removeClass('selected');
                $('.telefono-hide').hide();
                $('#editarTelefono').show();
            }
            if ($('#rowContraseña').hasClass('selected')) {
                $('#rowContraseña').removeClass('selected');
                $('.contraseña-hide').hide();
                $('#editarContraseña').show();
            }
            toastr.success("Email guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el email.");
        },
    });
};

function editarFechaNacimiento() {
    var usuario = {
        IdUsuario: $('#hiddenIdUsuario').val(),
        FechaNacimiento: $('#txtFechaNacimiento').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.fechaNacimiento-hide').hide();
            $('#editarFechaNacimiento').show();
            $('#labelFechaNacimiento').text(data.FechaNacimiento);
            $('#txtFechaNacimiento').val(data.FechaNacimiento);
            $('#rowFechaNacimiento').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowNombreUsuario').hasClass('selected')) {
                $('#rowNombreUsuario').removeClass('selected');
                $('.nombreUsuario-hide').hide();
                $('#editarNombreUsuario').show();
            }
            if ($('#rowEmail').hasClass('selected')) {
                $('#rowEmail').removeClass('selected');
                $('.email-hide').hide();
                $('#editarEmail').show();
            }
            if ($('#rowTelefono').hasClass('selected')) {
                $('#rowTelefono').removeClass('selected');
                $('.telefono-hide').hide();
                $('#editarTelefono').show();
            }
            if ($('#rowContraseña').hasClass('selected')) {
                $('#rowContraseña').removeClass('selected');
                $('.contraseña-hide').hide();
                $('#editarContraseña').show();
            }

            toastr.success("Fecha de nacimiento guardada.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar la fecha de nacimiento.");
        },
    });
};

function editarTelefono() {
    var usuario = {
        IdUsuario: $('#hiddenIdUsuario').val(),
        Telefono: $('#txtTelefono').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.telefono-hide').hide();
            $('#editarTelefono').show();
            $('#labelTelefono').text(data.Telefono);
            $('#txtTelefono').val(data.Telefono);
            $('#rowTelefono').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowNombreUsuario').hasClass('selected')) {
                $('#rowNombreUsuario').removeClass('selected');
                $('.nombreUsuario-hide').hide();
                $('#editarNombreUsuario').show();
            }
            if ($('#rowFechaNacimiento').hasClass('selected')) {
                $('#rowFechaNacimiento').removeClass('selected');
                $('.fechaNacimiento-hide').hide();
                $('#editarFechaNacimiento').show();
            }
            if ($('#rowEmail').hasClass('selected')) {
                $('#rowEmail').removeClass('selected');
                $('.email-hide').hide();
                $('#editarEmail').show();
            }
            if ($('#rowContraseña').hasClass('selected')) {
                $('#rowContraseña').removeClass('selected');
                $('.contraseña-hide').hide();
                $('#editarContraseña').show();
            }

            toastr.success("Telefono guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el teléfono.");
        },
    });
};

function editarContraseña() {
    var model = {
        ActualPassword: $('#txtActualContraseña').val(),
        NuevaPassword: $('#txtNuevaContraseña').val(),
        ConfirmarPassword: $('#txtConfirmarContraseña').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/CambiarPassword",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            //$('.telefono-hide').hide();
            //$('#editarTelefono').show();
            //$('#labelTelefono').text(data.PhoneNumber);
            //$('#txtTelefono').val(data.PhoneNumber);
            //$('#rowTelefono').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowNombreUsuario').hasClass('selected')) {
                $('#rowNombreUsuario').removeClass('selected');
                $('.nombreUsuario-hide').hide();
                $('#editarNombreUsuario').show();
            }
            if ($('#rowFechaNacimiento').hasClass('selected')) {
                $('#rowFechaNacimiento').removeClass('selected');
                $('.fechaNacimiento-hide').hide();
                $('#editarFechaNacimiento').show();
            }
            if ($('#rowEmail').hasClass('selected')) {
                $('#rowEmail').removeClass('selected');
                $('.email-hide').hide();
                $('#editarEmail').show();
            }
            if ($('#rowTelefono').hasClass('selected')) {
                $('#rowTelefono').removeClass('selected');
                $('.telefono-hide').hide();
                $('#editarTelefono').show();
            }

            toastr.success("Contraseña actualizada.");
        },
        error: function (data) {
            toastr.error(data.errors);
            toastr.error("No se pudo actualizar la contraseña.");
        },
    });
};

/****Guardar campos editables Usuarios****/
//Nombre de usuario
function editarUsuarioNombreUsuario(idUsuario) {
    var model = {
        IdUsuario: $('#hiddenUsuarioIdUsuario_' + idUsuario).val(),
        NombreUsuario: $('#txtUsuarioNombreUsuario').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            $('.usuarioNombreUsuario-hide').hide();
            $('#editarUsuarioNombreUsuario').show();
            $('#labelUsuarioNombreUsuario').text(data.NombreUsuario);
            $('#txtUsuarioNombreUsuario').val(data.NombreUsuario);
            $('#rowUsuarioNombreUsuario').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowUsuarioEmail').hasClass('selected')) {
                $('#rowUsuarioEmail').removeClass('selected');
                $('.usuarioEmail-hide').hide();
                $('#editarUsuarioEmail').show();
            }
            if ($('#rowUsuarioPerfil').hasClass('selected')) {
                $('#rowUsuarioPerfil').removeClass('selected');
                $('.usuarioPerfil-hide').hide();
                $('#editarUsuarioPerfil').show();
            }
            if ($('#rowUsuarioFechaNacimiento').hasClass('selected')) {
                $('#rowUsuarioFechaNacimiento').removeClass('selected');
                $('.usuarioFechaNacimiento-hide').hide();
                $('#editarUsuarioFechaNacimiento').show();
            }
            if ($('#rowUsuarioTelefono').hasClass('selected')) {
                $('#rowUsuarioTelefono').removeClass('selected');
                $('.usuarioTelefono-hide').hide();
                $('#editarUsuarioTelefono').show();
            }

            toastr.success("Nombre de usuario guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el nombre de usuario.");
        },
    });
};

function editarUsuarioPerfil(idUsuario) {
    var model = {
        IdUsuario: $('#hiddenUsuarioIdUsuario_' + idUsuario).val(),
        Perfil: $('#usuarioPerfilSeleccionado').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            $('.usuarioPerfil-hide').hide();
            $('#editarUsuarioPerfil').show();
            $('#labelUsuarioPerfil').text(data.Perfil);
            $('#usuarioPerfilSeleccionado').val(data.Perfil);
            $('#rowUsuarioPerfil').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowUsuarioEmail').hasClass('selected')) {
                $('#rowUsuarioEmail').removeClass('selected');
                $('.usuarioEmail-hide').hide();
                $('#editarUsuarioEmail').show();
            }
            if ($('#rowUsuarioFechaNacimiento').hasClass('selected')) {
                $('#rowUsuarioFechaNacimiento').removeClass('selected');
                $('.usuarioFechaNacimiento-hide').hide();
                $('#editarUsuarioFechaNacimiento').show();
            }
            if ($('#rowUsuarioTelefono').hasClass('selected')) {
                $('#rowUsuarioTelefono').removeClass('selected');
                $('.usuarioTelefono-hide').hide();
                $('#editarUsuarioTelefono').show();
            }

            toastr.success("Perfil actualizado.");
        },
        error: function (data) {
            toastr.error("No se pudo actualizar el perfil.");
        },
    });
};

function editarUsuarioEmail(idUsuario) {
    var usuario = {
        IdUsuario: $('#hiddenUsuarioIdUsuario_' + idUsuario).val(),
        Email: $('#txtUsuarioEmail').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.usuarioEmail-hide').hide();
            $('#editarUsuarioEmail').show();
            $('#labelUsuarioEmail').text(data.Email);
            $('#txtUsuarioEmail').val(data.Email);
            $('#rowUsuarioEmail').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowUsuarioNombreUsuario').hasClass('selected')) {
                $('#rowUsuarioNombreUsuario').removeClass('selected');
                $('.usuarioNombreUsuario-hide').hide();
                $('#editarUsuarioNombreUsuario').show();
            }
            if ($('#rowUsuarioFechaNacimiento').hasClass('selected')) {
                $('#rowUsuarioFechaNacimiento').removeClass('selected');
                $('.usuarioFechaNacimiento-hide').hide();
                $('#editarUsuarioFechaNacimiento').show();
            }
            if ($('#rowUsuarioTelefono').hasClass('selected')) {
                $('#rowUsuarioTelefono').removeClass('selected');
                $('.usuarioTelefono-hide').hide();
                $('#editarUsuarioTelefono').show();
            }

            toastr.success("Email guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el email.");
        },
    });
};

function editarUsuarioFechaNacimiento(idUsuario) {
    var usuario = {
        IdUsuario: $('#hiddenUsuarioIdUsuario_' + idUsuario).val(),
        FechaNacimiento: $('#txtUsuarioFechaNacimiento').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.usuarioFechaNacimiento-hide').hide();
            $('#editarUsuarioFechaNacimiento').show();
            $('#labelUsuarioFechaNacimiento').text(data.FechaNacimiento);
            $('#txtUsuarioFechaNacimiento').val(data.FechaNacimiento);
            $('#rowUsuarioFechaNacimiento').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowUsuarioNombreUsuario').hasClass('selected')) {
                $('#rowUsuarioNombreUsuario').removeClass('selected');
                $('.usuarioNombreUsuario-hide').hide();
                $('#editarUsuarioNombreUsuario').show();
            }
            if ($('#rowUsuarioEmail').hasClass('selected')) {
                $('#rowUsuarioEmail').removeClass('selected');
                $('.usuarioEmail-hide').hide();
                $('#editarUsuarioEmail').show();
            }
            if ($('#rowUsuarioTelefono').hasClass('selected')) {
                $('#rowUsuarioTelefono').removeClass('selected');
                $('.usuarioTelefono-hide').hide();
                $('#editarUsuarioTelefono').show();
            }

            toastr.success("Fecha de nacimiento guardada.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar la fecha de nacimiento.");
        },
    });
};

function editarUsuarioTelefono(idUsuario) {
    var usuario = {
        IdUsuario: $('#hiddenUsuarioIdUsuario_' + idUsuario).val(),
        Telefono: $('#txtUsuarioTelefono').val()
    };

    $.ajax({
        type: "POST",
        url: "/Configuracion/EditarUsuario",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(usuario),
        success: function (data) {
            $('.usuarioTelefono-hide').hide();
            $('#editarUsuarioTelefono').show();
            $('#labelUsuarioTelefono').text(data.Telefono);
            $('#txtUsuarioTelefono').val(data.Telefono);
            $('#rowUsuarioTelefono').removeClass('selected');

            //Ocultar los demas campos
            if ($('#rowUsuarioNombreUsuario').hasClass('selected')) {
                $('#rowUsuarioNombreUsuario').removeClass('selected');
                $('.usuarioNombreUsuario-hide').hide();
                $('#editarUsuarioNombreUsuario').show();
            }
            if ($('#rowUsuarioFechaNacimiento').hasClass('selected')) {
                $('#rowUsuarioFechaNacimiento').removeClass('selected');
                $('.usuarioFechaNacimiento-hide').hide();
                $('#editarUsuarioFechaNacimiento').show();
            }
            if ($('#rowUsuarioEmail').hasClass('selected')) {
                $('#rowUsuarioEmail').removeClass('selected');
                $('.usuarioEmail-hide').hide();
                $('#editarUsuarioEmail').show();
            }

            toastr.success("Telefono guardado.");
        },
        error: function (data) {
            toastr.error("No se pudo guardar el teléfono.");
        },
    });
};