function getValidateCode() {
    var num = Math.random();
    var validateCode = document.getElementById("validateCode");
    validateCode.src = "/Unauthorized/GetValidateCode?v=" + num;
}

function sendParam() {
    var data  = { UserName: $.trim($("#user").val()), Password: $.trim($("#pwd").val()), ValidateCode: $.trim($("#code").val()) };
    var parameter = JSON.stringify(data);
    $.ajaxExtend({
        data: parameter,
        async: false,
        url: "/Unauthorized/Login",
        success: function (d) {
            if (d.IsSucceed) {
                window.location.href = "/Home/Index";
            } else {
                getValidateCode();
                $.layerAlert(d.Message, { icon: 2 });
            }
        }
    });
}

$(function () {
    $("#btnLogin").click(function () {
        if ($.trim($("#user").val()).length <= 0) {
            $.layerTips("请输入账号", "#user");
            return false;
        }
        if ($.trim($("#pwd").val()).length <= 0) {
            $.layerTips("请输入密码", "#user");
            return false;
        }
        if ($.trim($("#code").val()).length <= 0) {
            $.layerTips("请输入验证码", "#user");
            return false;
        }
        sendParam();
        return false;
    });
});