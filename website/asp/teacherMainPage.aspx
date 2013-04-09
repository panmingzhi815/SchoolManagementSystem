<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherMainPage.aspx.cs"
    Inherits="WebSite.asp.teacherManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/icon.css" />

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>

    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/Jinjuan.index.js'> </script>

    <link rel="stylesheet" href="'/Jscript/kindeditor-4.1.6/themes/default/default.css" />

    <script charset="utf-8" src="/Jscript/kindeditor-4.1.6/kindeditor-min.js"></script>

    <script charset="utf-8" src="/Jscript/kindeditor-4.1.6/lang/zh_CN.js"></script>

    <style type="text/css">
        form
        {
            margin: 0;
        }
        textarea
        {
            display: block;
        }
    </style>
</head>
<body class="easyui-layout">
    <div region="west" title="院系专业列表" style="width: 200px">
        <ul id="tt">
        </ul>
    </div>
    <div region="center" title="详情" border="false">
        <form id="form">
            <div style="width: 100%">
                名称<input type="text" /></div>
            <div style="width: 100%">
                编码<input type="text" /></div>
            <div style="width: 100%">
                图片<input type="file" /></div>
            <div style="width: 100%">
                <textarea name="SimpleDescript" style="width: 100%; height: 100px; visibility: hidden;">KindEditor</textarea>
            </div>
            <div style="width: 100%">
               <textarea name="DetailDescript" style="width: 100%; height: 100%; visibility: hidden;">KindEditor</textarea>
            </div>
        </form>
    </div>
</body>
</html>

<script type="text/javascript">
    $(function(){
        $('#tt').tree({  
           url:'tree_data.json'  
        });
    })
    
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
	    
	    DetailEditor = K.create('textarea[name="content"]', {
					allowFileManager : true
		});
    });
    
    
</script>

