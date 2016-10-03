$(document).ready(function () {
    $('#contenidoProyectos').show();
    $('#contenidoMapa').hide();
    $('#contenidoMapaContaminacion').hide();
    $('#contenidoEmpresas').hide();
    $('#contenidoRanking').hide();
    $('#urlUbicacion').hide();
    $('#nombreEmpresa').hide();
});

function mostrarUrlEmpresaUbicacion(tipoUbicacion) {
    if (tipoUbicacion == '2' || tipoUbicacion == '3') {
        $('#urlUbicacion').show();
        $('#nombreEmpresa').show();
    }
    else {
        $('#urlUbicacion').hide();
        $('#nombreEmpresa').hide();
    }
}

/****Valoracion****/
function botonPositivos(idProyecto){
    var votosPositivos = parseInt($('#positivos_'+idProyecto).text());
    var votosNegativos = parseInt($('#negativos_'+idProyecto).text());

    var valoracion = {
        ProyectoId: idProyecto,
        Username: $('#hiddenNombreUsuario').val(),
        Voto: 1,
        VotosTotalesPositivos: votosPositivos,
        VotosTotalesNegativos: votosNegativos
    };

    $.ajax({
        type: "POST",
        url: "/Proyecto/InsertarValoracion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(valoracion),
        success: function (data) {
            $('#positivos_'+idProyecto).text(data.VotosTotalesPositivos);
            $('#negativos_'+idProyecto).text(data.VotosTotalesNegativos);
            if (data.Votado == true) {
                toastr.success("Valoracion añadida.");
            }
            else {
                toastr.error("Ya has votado este proyecto.");
            }
            actualizarRanking();
        },
        error: function (data) {
            toastr.error("Debes registrarte para valorar un proyecto.");
        },
    });
};

function botonNegativos(idProyecto){
    var votosNegativos = parseInt($('#negativos' + idProyecto).text());
    var votosPositivos = parseInt($('#positivos' + idProyecto).text());

    var valoracion = {
        ProyectoId: idProyecto,
        Username: $('#hiddenNombreUsuario').val(),
        Voto: 0,
        VotosTotalesPositivos: votosPositivos,
        VotosTotalesNegativos: votosNegativos
    };

    $.ajax({
        type: "POST",
        url: "/Proyecto/InsertarValoracion",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(valoracion),
        success: function (data) {
            $('#positivos_'+idProyecto).text(data.VotosTotalesPositivos);
            $('#negativos_'+idProyecto).text(data.VotosTotalesNegativos);
            if (data.Votado == true) {
                toastr.success("Valoracion añadida.");
            }
            else {
                toastr.error("Ya has votado este proyecto.");
            }
            actualizarRanking();
        },
        error: function (data) {
            toastr.error("Debes registrarte para valorar un proyecto.");
        },
    });
};

function actualizarRanking() {
    var seccionVM = {
        Nombre: $('#hiddenSeccion').val()
    };
    $.ajax({
        type: "POST",
        url: "/Proyecto/ActualizarRanking",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(seccionVM),
        success: function (data) {
            $("#tbodyRanking").empty();
            $("#rankingCiudades th").remove();
            $("#rankingCiudades").prepend("<thead><tr><th>Posición</th><th>Nombre</th><th>País</th><th>Votos Positivos</th><th>Votos Negativos</th><th>Votos Totales</th><th>Valoración</th></tr></thead>");
            
            var contador = 1;
            $.each(data.ciudadesViewModel, function (i, item) {
                var clase = "";

                if (data.usuarioViewModel.CiudadUsuario != null && data.usuarioViewModel.CiudadUsuario == data.ciudadesViewModel[i].Nombre)
                {
                    var clase = "info";
                }

                $("#rankingCiudades").append(
                    "<tr class='" + clase + "'>" +
                    "<td>" + contador + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].Nombre + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].Pais + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].VotosPositivos + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].VotosNegativos + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].VotosTotales + "</td>" +
                    "<td>" + data.ciudadesViewModel[i].Valoracion + "%</td>" +
                    "</tr>");
                contador++;
            })
        },
        error: function (data) {
        },
    });
}

function eliminarProyecto(idProyecto) {
    var model = {
        ProyectoId: idProyecto
    }
    
    $.ajax({
        type: "POST",
        url: "/Proyecto/EliminarProyecto",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function (data) {
            toastr.success("Proyecto eliminado.");
        },
        error: function (data) {
            toastr.error("No se ha podido eliminar el proyecto proyecto.");
        },
    });
};

/****Insertar Ubicacion****/
function insertarUbicacion() {
    var ubicacion = {
        NombreUsuario: $('#hiddenNombreUsuario').val(),
        NombreCiudad: $('#hiddenCiudad').val(),
        Direccion: $('#txtDireccion').val(),
        Url: $('#txtUrl').val(),
        NombreEmpresa: $('#txtNombreEmpresa').val(),
        TipoUbicacionSeleccionada: $('#ubicacionSeleccionada').val(),
        Latitud: 0,
        Longitud: 0
    };

    if (ubicacion.NombreCiudad == ""){
        toastr.error("Selecciona una ciudad.");
    }
    else if (ubicacion.NombreUsuario == "") {
        toastr.error("Debes iniciar sesión antes de enviar una ubicación.");
    }
    else {
        obtenerLocalizacion(ubicacion);
    }
}

/****Insertar Mapa****/
function initMap() {
    var mapOptions = {
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoom: 5,
        center: { lat: 40.43807216375375, lng: -3.6795366999999715 }
    };
    var mapa = new google.maps.Map(document.getElementById("mapa"), mapOptions);

    if ($('#hiddenCiudad').val() != "") {
        var nombreCiudad = $('#hiddenCiudad').val();

        var model = {
            NombreCiudad: nombreCiudad
        };

        obtenerUbicaciones(nombreCiudad, mapa, model);
    }
}

/****Insertar Mapa de contaminacion****/
function initMapContaminacion() {
    var mapOptions = {
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        zoom: 5,
        center: { lat: 40.43807216375375, lng: -3.6795366999999715 }
    };
    var mapaContaminacion = new google.maps.Map(document.getElementById("mapaContaminacion"), mapOptions);

    if ($('#hiddenCiudad').val() != "") {
        var nombreCiudad = $('#hiddenCiudad').val();

        var model = {
            NombreCiudad: nombreCiudad
        };

        obtenerEstaciones(nombreCiudad, mapaContaminacion, model);
    }
}

function obtenerLocalizacion(ubicacion) {
    var latLong = "";

    var geocoder = new google.maps.Geocoder();
    var result = "";
    geocoder.geocode({ 'address': ubicacion.Direccion + ',' + ubicacion.NombreCiudad }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            ubicacion.Latitud = results[0].geometry.location.lat();
            ubicacion.Longitud = results[0].geometry.location.lng();

            $.ajax({
                type: "POST",
                url: "/Ubicacion/InsertarUbicacion",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(ubicacion),
                success: function (data) {
                    $('#txtDireccion').val("");
                    $('#txtNombreEmpresa').val("");
                    $('#txtUrl').val("");
                    $('#ubicacionSeleccionada').val("1");
                    $('#urlUbicacion').hide();
                    $('#nombreEmpresa').hide();
                    initMap();
                    toastr.success("Ubicación enviada.");
                },
                error: function (data) {
                    toastr.error("Error al enviar la ubicación.");
                },
            });
        }
        else
            alert("No se pudo obtener la localización " + status);
    });
}

function obtenerUbicaciones(ciudad, mapa, model) {
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': ciudad }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            latLong = results[0].geometry.location;

            $.ajax({
                type: "POST",
                url: "/Ubicacion/ObtenerUbicaciones",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(model),
                success: function (data) {
                    $.each(data, function (i, item) {
                        setTimeout(function(){
                            var latLngMarker = new google.maps.LatLng(data[i].Latitud, data[i].Longitud);
                            var customIcon = "";
                            if (data[i].TipoUbicacion == "Alquiler de Vehículos Sostenibles") {
                                customIcon = "/Content/images/movilidadSostenible.png";
                            }
                            else if (data[i].TipoUbicacion == "Punto de Reciclaje") {
                                customIcon = "/Content/images/reciclaje.png";
                            }
                            else if (data[i].TipoUbicacion == "Empresa Sostenible") {
                                customIcon = "/Content/images/negocioSostenible.png";
                            }
                            var marker = new google.maps.Marker({
                                map: mapa,
                                icon: customIcon,
                                position: latLngMarker,
                                clickable: true
                            });
                            var direccion = '<b>Dirección: </b>' + data[i].Direccion;
                            var tipoUbicacion = '<br><b>Tipo:</b> ' + data[i].TipoUbicacion;
                            var usuario = '<br><b>Usuario: </b>' + data[i].NombreUsuario;
                            var empresa = "";
                            if(data[i].NombreEmpresa != null)
                                empresa = '<br><b>Nombre de la empresa: </b>' + data[i].NombreEmpresa;
                            var url = "";
                            if (data[i].Url != null)
                                url = '<br><b>URL: </b>' + data[i].Url;

                            marker.info = new google.maps.InfoWindow({
                                content: direccion + tipoUbicacion + usuario + empresa  + url
                            });
                            google.maps.event.addListener(marker, 'click', function () {
                                marker.info.open(mapa, marker);
                            });
                        }, 2000);
                    })

                },
                error: function (data) {
                    toastr.error("Error al obtener las ubicaciones.");
                },
            });

            mapa.setCenter(latLong);
            mapa.setZoom(12);
        }
        else
            alert("No se pudo obtener la localización. " + status);
    });
}

/****Menu Informacion****/
$('#menuProyectos').click(function () {
    $('#contenidoProyectos').show();
    $('#contenidoMapa').hide();
    $('#contenidoEmpresas').hide();
    $('#contenidoRanking').hide();
});

$('#menuMapa').click(function () {
    $('#contenidoProyectos').hide();
    $('#contenidoMapa').show();
    $('#contenidoEmpresas').hide();
    $('#contenidoRanking').hide();
    initMap();
});

$('#menuMapaContaminacion').click(function () {
    $('#contenidoProyectos').hide();
    $('#contenidoMapa').hide();
    $('#contenidoEmpresas').hide();
    $('#contenidoRanking').hide();
    initMapContaminacion();
});

$('#menuEmpresas').click(function () {
    $('#contenidoProyectos').hide();
    $('#contenidoMapa').hide();
    $('#contenidoEmpresas').show();
    $('#contenidoRanking').hide();
});

$('#menuRanking').click(function () {
    $('#contenidoProyectos').hide();
    $('#contenidoMapa').hide();
    $('#contenidoEmpresas').hide();
    $('#contenidoRanking').show();
});