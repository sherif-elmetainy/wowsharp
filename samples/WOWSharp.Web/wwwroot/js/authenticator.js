/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/authenticator.d.ts" />
$(document).ready(function () {
    $('a.code-btn').click(function (e) {
        e.preventDefault();
        var that = $(this);
        var url = that.attr('href');
        $.get(url, function (data) {
            function setAnimation(codeEl, duration) {
                $(codeEl).children('div')
                    .stop(true)
                    .width((1 - duration / 30000) * 100 + "%")
                    .animate({ width: "100%" }, { duration: duration, easing: "linear" });
            }
            var codeEl = that.siblings('div.code');
            if (codeEl.length === 0) {
                codeEl = $('<div class="code"><div></div><span>' + data.Code + "</span></div>");
                codeEl.appendTo(that.parent());
            }
            else {
                codeEl.children('span').text(data.Code);
            }
            setAnimation(codeEl, data.RemainingMilliseconds);
            //_this.hide();
            function refresh() {
                $.get(url, function (data) {
                    codeEl.children('span').text(data.Code);
                    window.setTimeout(refresh, data.RemainingMilliseconds);
                    setAnimation(codeEl, data.RemainingMilliseconds);
                });
            }
            window.setTimeout(refresh, data.RemainingMilliseconds);
        });
    });
    $('a.sync-btn').click(function (e) {
        e.preventDefault();
        var that = $(this);
        var url = that.attr('href');
        $.post(url, function () {
            if (that.siblings('div.code').length !== 0) {
                that.siblings('a.code-btn').trigger('click');
            }
        });
    });
    $('a.delt-btn').click(function (e) {
        e.preventDefault();
        var that = $(this);
        var url = that.attr('href');
        $.ajax(url, {
            method: "DELETE",
            success: function () {
                that.parents("tr").remove();
            }
        });
    });
});
