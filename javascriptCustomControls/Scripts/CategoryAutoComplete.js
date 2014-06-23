$(function () {
    $(".autocomplete").click(function () {
        var e = jQuery.Event("keydown");
        e.keyCode = 40;
        $("#city").trigger(e);
    });


    function log(message) {
        $("<div>").text(message).prependTo("#log");
        $("#log").scrollTop(0);
    }
    $(".autocomplete").catcomplete({
        source: function (request, response) {
            console.log($(this).attr('Action-url'));
            $.ajax({
                type: "POST",
                url: "Default.aspx/AllName",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({
                    //    //featureClass: "P",
                    //    //style: "full",
                    maxRows: 10,
                    startsWith: request.term
                }),
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Name,
                            value: item.Name,
                            category: item.category
                        }
                    }));
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            log(ui.item ?
            "Selected: " + ui.item.label :
            "Nothing selected, input was " + this.value);
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });
});

$.widget("custom.catcomplete", $.ui.autocomplete, {
    _renderMenu: function (ul, items) {
        var that = this;
        var currentCategory = "";
        $.each(items, function (index, item) {
            if (item.category != currentCategory) {
                $('<li/>').addClass('ui-autocomplete-category').html(item.category).appendTo(ul);
                currentCategory = item.category;
            }
            that._renderItemData(ul, item);
        });
    }
});