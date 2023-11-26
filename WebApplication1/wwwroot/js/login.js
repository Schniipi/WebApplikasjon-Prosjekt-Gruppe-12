src = "https://code.jquery.com/jquery-3.6.0.min.js" >
    $(document).ready(function () {
        $('.OpprettService').on('click', function () {
            var buttonId = $(this).attr('id');

            //Henter rollen til brukeren som logger inn
            var Rolle = buttonId.split('_')[1];
            var url = "/InsertData/SaveService?Rolle=" + Rolle;
            //Sender id til controlleren, som fortsetter som vanlig
            window.location.href = url;
        });
    });