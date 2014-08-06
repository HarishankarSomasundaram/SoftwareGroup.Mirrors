$('#ribbon')
    .append(
        '<div class="demo"><span id="demo-setting"><i class="fa fa-cog txt-color-blueDark"></i></span> <form><legend class="no-padding margin-bottom-10">Settings</legend><h6 class="margin-top-10 semi-bold margin-bottom-5">Mirrors V3 Skins</h6><section id="smart-styles"><a href="javascript:void(0);" id="smart-style-0" data-skinlogo="~/Content/img/logo.png" class="btn btn-block btn-xs txt-color-white margin-right-5" style="background-color:#4E463F;"><i class="fa fa-check fa-fw" id="skin-checked"></i>Smart Default</a><a href="javascript:void(0);" id="smart-style-1" data-skinlogo="~/Content/img/logo-white.png" class="btn btn-block btn-xs txt-color-white" style="background:#3A4558;">Dark Elegance</a><a href="javascript:void(0);" id="smart-style-2" data-skinlogo="~/Content/img/logo-blue.png" class="btn btn-xs btn-block txt-color-darken margin-top-5" style="background:#fff;">Ultra Light</a><a href="javascript:void(0);" id="smart-style-3" data-skinlogo="~/Content/img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background:#f78c40">Google Skin</a></section></form> </div>'
)

$('#demo-setting')
    .click(function () {
        //console.log('setting');
        $('#ribbon .demo')
            .toggleClass('activate');
    })


/*
 * STYLES
 */
$("#smart-styles > a")
    .bind("click", function () {
        var $this = $(this);
        //var $logo = $("#logo img");
        $('body').removeClassPrefix('smart-style')
            .addClass($this.attr("id"));
        ///$logo.attr('src', $this.data("skinlogo"));
        $("#smart-styles > a #skin-checked")
            .remove();
        $this.prepend(
            "<i class='fa fa-check fa-fw' id='skin-checked'></i>"
        );
    });

(function ($) {

    $.fn.removeClassPrefix = function (prefix) {
        this.each(function (i, it) {
            var classes = it.className.split(" ").map(function (item) {
                return item.indexOf(prefix) === 0 ? "" : item;
            });
            it.className = classes.join(" ");
        });

        return this;
    }

})(jQuery);