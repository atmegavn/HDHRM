$(function () {
    $('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }

        var $subMenu = $(this).next(".dropdown-menu");
        $subMenu.toggleClass('show');

        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });

        return false;
    });
});

function openStandardModal(element) {
    var url = $(element).attr("url");
    $("#standard-modal-content").load(url, function () {
        $("#standard-modal-trigger").click();
    });
}

function openlangerModal(element) {
    var url = $(element).attr("url");
    $("#langer-modal-content").load(url, function () {
        $("#langer-modal-trigger").click();
    });
}


function openDangerModal(element) {
    var url = $(element).attr("url");
    $("#danger-alert-modal-content").load(url, function () {
        $("#danger-alert-modal-trigger").click();
    });
}