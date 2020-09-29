function initSelectTree(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: false,
            chkboxType: { "Y": "ps", "N": "s" }
        },
        callback: {
            onClick: onClick,
            onCheck: onCheck
        }

    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    var html = '<div class = "layui-select-title" >' +
        '<input id="' + id + 'Show"' + 'type = "text" placeholder = "请选择" value = "" class = "layui-input" readonly>' +
        '<i class= "layui-edge" ></i>' +
        '</div>';
    $("#" + id).append(html);
    $("#" + id).parent().append('<div class="tree-content scrollbar">' +
        '<input hidden id="' + id + 'Hide" ' +
        'name="' + $(".select-tree").attr("id") + '">' +
        '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
        '</div>');
    $("#" + id).bind("click", function () {
        if ($(this).parent().find(".tree-content").css("display") !== "none") {
            hideMenu()
        } else {
            $(this).addClass("layui-form-selected");
            var Offset = $(this).offset();
            var width = $(this).width() - 2;
            $(this).parent().find(".tree-content").css({
                left: Offset.left + "px",
                top: Offset.top + $(this).height() + "px"
            }).slideDown("fast");
            $(this).parent().find(".tree-content").css({
                width: 300
            });
            $("body").bind("mousedown", onBodyDown);
        }
    });
    $.fn.zTree.init($("#" + id + "Tree"), setting, datanode);
}

function initSelectTree2(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: true,
            chkStyle: "radio",
            radioType: "all"
        },
        callback: {
            onClick: onClick2,
            onCheck: onCheck
        }

    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    var html = '<div class = "layui-select-title" >' +
        '<input id="' + id + 'Show"' + 'type = "text" placeholder = "请选择" value = "" class = "layui-input" readonly>' +
        '<i class= "layui-edge" ></i>' +
        '</div>';
    $("#" + id).append(html);
    $("#" + id).parent().append('<div class="tree-content scrollbar" id="bmscrollbar">' +
        '<input hidden id="' + id + 'Hide" ' +
        'name="' + $(".select-tree").attr("id") + '">' +
        '<ul id="' + id + 'Tree" class="ztree scrollbar" style="margin-top:0;"></ul>' +
        '</div>');
    $("#" + id).bind("click", function () {
        if ($(this).parent().find(".tree-content").css("display") !== "none") {
            hideMenu()
        } else {
            $(this).addClass("layui-form-selected");
            var Offset = $(this).offset();
            var width = $(this).width() - 2;
            $(this).parent().find(".tree-content").css({
                left: Offset.left + "px",
                top: Offset.top + $(this).height() + "px"
            }).slideDown("fast");
            $(this).parent().find(".tree-content").css({
                width: 300
            });
            $("body").bind("mousedown", onBodyDown);
        }
    });
    $.fn.zTree.init($("#" + id + "Tree"), setting, datanode);
}
function initSelectTree3(id, isMultiple, chkboxType, idKey, pIdKey, name, datanode) {
    var setting = {
        view: {
            dblClickExpand: false,
            showLine: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: idKey,
                pIdKey: pIdKey
            },
            key: {
                name: name
            }
        },
        check: {
            enable: false,
            chkboxType: { "Y": "ps", "N": "s" }
        },
        callback: {
            onClick: onClick,
            onCheck: onCheck
        }
    };
    if (isMultiple) {
        setting.check.enable = isMultiple;
    }
    if (chkboxType !== undefined && chkboxType != null) {
        setting.check.chkboxType = chkboxType;
    }
    $.fn.zTree.init($("#" + id), setting, datanode);
}
function beforeClick(treeId, treeNode) {
    var check = (treeNode && !treeNode.isParent);
    if (!check) alert("只能选择城市...");
    return check;
}

function onClick(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    if (zTree.setting.check.enable == true) {
        zTree.checkNode(treeNode, !treeNode.checked, true);
        //var nodes = zTree.getSelectedNodes();
        //for (var i = 0, l = nodes.length; i < l; i++) {
        //    zTree.checkNode(nodes[i], true, true);
        //}
        assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
    } else {
        assignment(treeId, zTree.getSelectedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    }
}

function onClick2(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    if (zTree.setting.check.enable == true) {
        zTree.checkNode(treeNode, !treeNode.checked, true);
        //var nodes = zTree.getSelectedNodes();
        //for (var i = 0, l = nodes.length; i < l; i++) {
        //    zTree.checkNode(nodes[i], true, true);
        //}
        assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    } else {
        assignment(treeId, zTree.getSelectedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
        hideMenu();
    }
}

function onCheck(event, treeId, treeNode) {
    var zTree = $.fn.zTree.getZTreeObj(treeId);
    assignment(treeId, zTree.getCheckedNodes(), zTree.setting.data.key.name, zTree.setting.data.simpleData.idKey);
}

function hideMenu() {
    $(".select-tree").removeClass("layui-form-selected");
    $(".tree-content").fadeOut("fast");
    $("body").unbind("mousedown", onBodyDown);
}

function assignment(treeId, nodes, name, id) {
    var names = "";
    var ids = "";
    for (var i = 0, l = nodes.length; i < l; i++) {
        names += nodes[i][name] + ",";
        ids += nodes[i][id] + ",";
    }
    if (names.length > 0) {
        names = names.substring(0, names.length - 1);
        ids = ids.substring(0, ids.length - 1);
    }
    treeId = treeId.substring(0, treeId.length - 4);
    $("#" + treeId + "Show").attr("value", names);
    $("#" + treeId + "Show").attr("title", names);
    $("#" + treeId + "Hide").attr("value", ids);
}

function onBodyDown(event) {
    if ($(event.target).parents(".tree-content").html() == null) {
        if ($(event.target).closest(".tree-content").html() == null) {
            hideMenu();
        }
        //hideMenu();
    }
}