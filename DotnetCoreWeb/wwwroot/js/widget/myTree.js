// 递归出深度
function sonsTree(arr, id) {
    var temp = [], lev = 0;
    var forFn = function (arr, id, lev) {
        for (var i = 0; i < arr.length; i++) {
            var item = arr[i];
            if (item.ParentId === id) {
                item.Lev = lev;
                temp.push(item);
                forFn(arr, item.Id, lev + 1);
            }
        }
    };
    forFn(arr, id, lev);
    return temp;
}

// 递归树对象
function tree(data, lev) {
    this.tree = data || [];
    this.groups = {};
    this.Lev = lev || 4;
};

// 递归树
tree.prototype = {
    init: function (pid) {
        this.group();
        return this.getDom(this.groups[pid]);
    },
    group: function () {
        for (var i = 0; i < this.tree.length; i++) {
            if (this.groups[this.tree[i].ParentId]) {
                this.groups[this.tree[i].ParentId].push(this.tree[i]);
            } else {
                this.groups[this.tree[i].ParentId] = [];
                this.groups[this.tree[i].ParentId].push(this.tree[i]);
            }
        }
    },
    getDom: function (arry) {
        if (!arry) { return "" }
        var html = "";
        for (var i = 0; i < arry.length; i++) {
            var item = arry[i];
            html += this.getDom(this.groups[arry[i].Id]);
        };
        html += "";
        return html;
    }
};