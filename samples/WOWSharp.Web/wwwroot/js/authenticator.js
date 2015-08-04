/// <reference path="../../typings/jquery/jquery.d.ts" />
/// <reference path="../../typings/authenticator.d.ts" />
$(document).ready(function () {
    $('a.code-btn').click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var url = _this.attr('href');
        $.get(url, function (data) {
            function setAnimation(codeEl, duration) {
                var div = $(codeEl).children('div')
                    .stop(true)
                    .width((1 - duration / 30000) * 100 + "%")
                    .animate({ width: "100%" }, { duration: duration, easing: "linear" });
            }
            var codeEl = _this.siblings('div.code');
            if (codeEl.length == 0) {
                codeEl = $('<div class="code"><div></div><span>' + data.Code + "</span></div>");
                codeEl.appendTo(_this.parent());
            }
            else {
                codeEl.children('span').text(data.Code);
            }
            setAnimation(codeEl, data.RemainingMilliseconds);
            //_this.hide();
            function refresh() {
                $.get(url, function (data) {
                    codeEl.children('span').text(data.Code);
                    setTimeout(refresh, data.RemainingMilliseconds);
                    setAnimation(codeEl, data.RemainingMilliseconds);
                });
            }
            setTimeout(refresh, data.RemainingMilliseconds);
        });
    });
    $('a.sync-btn').click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var url = _this.attr('href');
        $.post(url, function () {
            if (_this.siblings('div.code').length != 0) {
                _this.siblings('a.code-btn').trigger('click');
            }
        });
    });
    $('a.delt-btn').click(function (e) {
        e.preventDefault();
        var _this = $(this);
        var url = _this.attr('href');
        $.ajax(url, {
            method: "DELETE",
            success: function () {
                _this.parents("tr").remove();
            }
        });
    });
});
