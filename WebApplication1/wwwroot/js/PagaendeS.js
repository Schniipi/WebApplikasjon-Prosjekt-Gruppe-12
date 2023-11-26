

// her lages en modal, den skal sende dataen fra det spesifikke service kortet over til service skjemaet. 
var title, info;

$(document).ready(function () {
    $('.kort').click(function () {
        // Fjerner andre modals
        $('.modal').remove();

        // Henter tittel og beskrivelse
        title = $(this).find('.navn').text();
        info = $(this).find('.info').text();

        // Lage modal
        var modalContent = '<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">';
        modalContent += '<div class="modal-dialog" role="document">';
        modalContent += '<div class="modal-content">';
        modalContent += '<div class="modal-header">';
        modalContent += '<h5 class="modal-title" id="exampleModalLabel">' + title + '</h5>';
        modalContent += '<button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">';
        modalContent += '<span aria-hidden="true">&times;</span>';
        modalContent += '</button>';
        modalContent += '</div>';
        modalContent += '<div class="modal-body">';
        modalContent += '<p>' + info + '</p>';
        modalContent += '</div>';
        modalContent += '<div class="modal-footer">';
        modalContent += '<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Lukk</button>';
        modalContent += '<button type="button" class="btn btn-primary" onclick="ferdiggjorOrdre()">Fortsett til service skjema</button>';
        modalContent += '</div>';
        modalContent += '</div>';
        modalContent += '</div>';
        modalContent += '</div>';

        $('body').append(modalContent);

        $('#exampleModal').modal('show');
    });
});

function ferdiggjorOrdre() {

    var title = encodeURIComponent("your_title_value");
    var info = encodeURIComponent("your_info_value");

    window.location.href = '/Home/ServiceSkjema'
}
