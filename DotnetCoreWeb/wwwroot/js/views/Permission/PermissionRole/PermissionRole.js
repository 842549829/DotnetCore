$(function() {
    $("#btnSave").on("click", function () {
        var roles = new Array();
        $("#divRole p input[type='checkbox']:checked").each(function () {
            roles.push($.trim($(this).val()));
        });
        var accountId = $.trim($("#hidAccountId").val());
        var parameter = { AccountId: accountId, Roles: roles };
        var data = JSON.stringify(parameter);
        $.ajaxExtend({
            data: data,
            url: "/PermissionRole/SaveAccountRole",
            success: function (d) {
                if (d.IsSucceed) {
                    $.layerAlert(d.Message, { icon: 1 });
                } else {
                    $.layerAlert(d.Message, { icon: 2 });
                }
            }
        });
    });    
});