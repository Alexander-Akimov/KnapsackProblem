// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(document).on('click', 'input#removeitem', function () {
        $(this).closest('.row').prev().remove();
        $(this).closest('.row').remove();
    });
});
