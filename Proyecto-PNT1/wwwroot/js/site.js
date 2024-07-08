$(document).ready(function () {
    // Tooltip para los botones de redes sociales
    $('[data-toggle="tooltip"]').tooltip();

    // Efecto de transición para las tarjetas de propuestas
    $('.card-custom').each(function (i) {
        $(this).delay(i * 150).fadeIn(500);
    });

    // Inicializar el carrusel
    $('#testimonialCarousel').carousel();
});
