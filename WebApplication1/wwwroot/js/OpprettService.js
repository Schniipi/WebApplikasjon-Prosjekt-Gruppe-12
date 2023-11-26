// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

src = "https://code.jquery.com/jquery-3.6.0.min.js" >
  $(document).ready(function () {
    $('.OpprettService').on('click', function () {
      var buttonId = $(this).attr('id');
      //Henter id til kunden som trykkes på
      var kundeID = buttonId.split('_')[1];
      var url = "/InsertData/SaveService?kundeID=" + kundeID;
      //Sender id til controlleren, som fortsetter som vanlig
      window.location.href = url;
    });
  });






