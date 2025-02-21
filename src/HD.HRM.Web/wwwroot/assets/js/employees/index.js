$(document).ready(function () {
    $("#jstree-1").jstree({
        core: {
            themes: {
                responsive: !1
            },
            data: {
                url: function (node) {
                    return '/organization/getChildNode?id=' + node.id;
                },
                data: function (node) {
                    return { 'id': node.id };
                }
            }
        },
        types: {
            default: {
                icon: "ri-folder-line"
            },
            file: {
                icon: "ri-article-line"
            }
        },
        plugins: ["types"]
    }).bind("loaded.jstree", function (event, data) {
        $(this).jstree("open_all");
    });
});