<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="departmentMainPage.aspx.cs"
    Inherits="WebSite.asp.departmentMainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/icon.css" />

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>

    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/Jinjuan.index.js'> </script>

    <link rel="stylesheet" href="/Jscript/kindeditor-4.1.6/themes/default/default.css" />

    <script charset="utf-8" src="/Jscript/kindeditor-4.1.6/kindeditor-min.js"></script>

    <script charset="utf-8" src="/Jscript/kindeditor-4.1.6/lang/zh_CN.js"></script>

    <style type="text/css">
        textarea
        {
            display: block;
        }
        .demo
        {
            position:absolute;
            text-align:right;
            top:30px;
            width:78%;
        }
    </style>
</head>
<body class="easyui-layout">
    <div id="cc" region="west" title="院系专业列表" style="width: 200px; padding:5px">
        <ul id="tt">
        </ul>
    </div>
    <div region="center" title="详情" border="true" fit="true">
        <form id="form" style="margin: 0; padding: 5px; line-height: 30px;">
        <div style="width: 100%">
            类型 <input type="text" value="院系" readonly/>
            </div>
        <div style="width: 100%">
            隶属
            <input type="text" readonly/></div>
        <div style="width: 100%">
            名称
            <input type="text" /></div>
        <div style="width: 100%">
            编码
            <input type="text" /></div>
        <div style="width: 100%">
            图片
            <input type="file" /></div>
        <div style="width: 100%">
            简介
            <textarea name="SimpleDescript" style="width: 80%; height: 100px; visible: false;">KindEditor</textarea>
        </div>
        <div style="width: 100%">
            详情
            <textarea name="DetailDescript" style="width: 80%; height: 200px; visible: false;">KindEditor</textarea>
        </div>
        </form>
        <div id="demo" class="demo">
           <a id="addSchool" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-add" style="display:none">添加学校</a>
           <a id="addDepartment" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-add" style="display:none">添加院系</a>
           <a id="addProfession" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-add" style="display:none">添加专业</a>
           <a id="addClassGrade" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-add" style="display:none">添加班级</a>
           <a id="delBtn" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-remove">删除</a>
           <a id="saveBtn" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-ok">保存</a>
		    <a id="closeBtn" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-no">关闭</a>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
    $(function(){  
    $('#tt').tree({  
        onClick: function(node){
           var type = node.attributes.type;
           setEnableBtn(type);
		    $.ajax({
                url: "/control/StudentControl.ashx?method=getStudent&type="+type,
                data: {
                   Id: node.id
                },
                type:'post', 
                success: function( data ) {
                    if (data.length > 0) {
                      $("#form").serializeJsonToForm(data);
                    } else {
                      msgAlert('提示','加载用户详细信息失败!','error');
                    }
                },
                error : function() {      
                   alert("异常！");    
                } 
            });
	    },
        data:[{  
                "id": 1,
               "iconCls":"icon-department",
                "text": "计算机系", 
                "attributes" :{"type":"2"},
                "children":
                [{  
                    "id": 11,  
                    "iconCls":"icon-profession",
                    "text": "小学教育",
                    "attributes" :{"type":"3"},
                    "children":
                    [{  
                        "id": 11,  
                        "iconCls":"icon-class",
                        "text": "网络一班",
                        "attributes" :{"type":"4"}
                    }]
                },{  
                    "id": 12,  
                    "iconCls":"icon-profession",
                    "text": "软件开发",
                    "attributes" :{"type":"3"}
                }]  
            },{  
                "id": 2,  
                "iconCls":"icon-department",
                "text": "电子系",
                "attributes" :{"type":"2"},
                "state": "closed"  
            }]
        });
    })
    
    function setEnableBtn(position){
        $("#addSchool").hide();
        $("#addDepartment").hide();
        $("#addProfession").hide();
        $("#addClassGrade").hide();
        switch(position){
           case "1" :
               $("#addSchool").show();
               break;
           case "2" :
               $("#addDepartment").show();
               break;
           case "3" :
               $("#addProfession").show();
               break;
           case "4" :
               $("#addClassGrade").show();
               break;
           default :
               break;
        }
    }
    
    var simpleEditor;
    var DetailEditor;
    KindEditor.ready(function(K) {
	    simpleEditor = K.create('textarea[name="SimpleDescript"]', {
		    resizeType : 1,
		    allowPreviewEmoticons : false,
		    allowImageUpload : false,
		    items : [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
			    'insertunorderedlist']
	    });
		DetailEditor = K.create('textarea[name="DetailDescript"]', {
			allowFileManager : true
		});
    });
    
    
</script>

