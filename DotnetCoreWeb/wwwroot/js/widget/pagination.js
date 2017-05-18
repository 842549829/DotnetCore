// 分页函数
function drawPagination(container, pageIndex, pageSize, dataCount, pageChangedCallback) {
    if (dataCount > 0) {
        var pageCount = parseInt((dataCount + pageSize - 1) / pageSize);
        var contents = new Array();
        contents.push("<div class=\"dataPager clearfix\">");
        if (pageIndex > 1) {
            contents.push("<a id=\"pager_lbnFirst\" style=\"margin-left:5px;margin-right:5px;\" value=1>首页</a>");
            contents.push("<a id=\"pager_lbnPrev\" value=" + (pageIndex - 1) + ">&lt; 上一页</a>");
        }
        contents.join("<span id=\"pPages\">");
        for (var i = pageIndex - 4; i <= pageIndex + 4; i++) {
            if (i === pageIndex) {
                contents.push("<a id=\"pager_lbPage" + i + "\" disabled=\"disabled\" class=\"yemaa\" style=\"margin-left:5px;margin-right:5px;text-decoration:none;\">" + i + "</a>");
            } else if (i > 0 && i <= pageCount) {
                contents.push("<a id=\"pager_lbPage" + i + "\" value=" + i + " style=\"margin-left:5px;margin-right:5px;\">" + i + "</a>");
            }
        }
        contents.join("</span>");
        if (pageIndex < pageCount) {
            contents.push("<a id=\"pager_lbnNext\" value=" + (pageIndex + 1) + " style=\"margin-left:5px;margin-right:5px;\" >下一页 &gt;</a>");
            contents.push("<a id=\"pager_lbnLast\" value=" + pageCount + ">末页</a>");
        }
        contents.push("共 <span id=\"pager_lblTotalCount\">" + dataCount);
        contents.push("</span> 条 每页 <span id=\"pager_lblPageSize\">" + pageSize);
        contents.push("</span> 条 第 <span id=\"lblCurrentPage\">" + pageIndex + "</span> / <span id=\"pager_lblTotalPage\">" + pageCount + "</span> 页</div>");
        container.html(contents.join(""));
        if (pageChangedCallback) {
            $("a", container).on("click", function () {
                var self = $(this);
                if (!self.attr("disabled")) {
                    pageChangedCallback(self.attr("value"));
                }
            });
        }
        container.show();
    } else {
        container.html("");
        container.hide();
    }
}


//获取分页信息
function getPaging(pageindex, pagesize) {
    return { "PageSize": pagesize, "PageIndex": pageindex, "GetRowsCount": true };
}

// 分页查询
function paging(o) {
    var obj = $.extend(true, {
        tbody: "table#dataList tbody",
        temp: "#temp",
        pager: "#Pager",
        pageIndex: 1,
        pageSize: 10,
        data: null,
        methodname: null,
        url: null,
        success: null
    }, o);
    var pagingCondition = getPaging(obj.pageIndex, obj.pageSize);
    var condition = obj.data;
    condition.Paging = pagingCondition;
    var para = JSON.stringify(condition);
    var load;
    $.ajaxExtend({
        data: para,
        url: obj.url,
        beforeSend: function () {
            load = window.layer.load(1);
        },
        success: function (d) {
            $(obj.tbody).html($(obj.temp).tmpl(d.Data));
            drawPagination($(obj.pager), d.Paging.PageIndex, d.Paging.PageSize, d.Paging.RowsCount, obj.methodname);
            if (obj.success) {
                obj.success(d);
            }
        },
        complete: function () {
            if (load) {
                window.layer.close(load);
            }
        }
    });
    return false;
}