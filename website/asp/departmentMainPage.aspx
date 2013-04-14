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
    
    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/locale/easyui-lang-zh_CN.js"></script>

    <link rel="stylesheet" href="/Jscript/kindeditor-4.1.6/themes/default/default.css" />

    <script type="text/javascript" charset="utf-8" src="/Jscript/kindeditor-4.1.6/kindeditor-min.js"></script>

    <script type="text/javascript" charset="utf-8" src="/Jscript/kindeditor-4.1.6/lang/zh_CN.js"></script>
    
    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/form.js'></script>

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
        <form id="form" enctype="multipart/form-data" method="post" style="margin: 0; padding: 5px; line-height: 30px;">
        <input type=hidden id="Id" name="Id" />
        <input type=hidden id="pId" name="pId" />
        <input type=hidden id="method" name="method" />
        <div style="width: 100%">
            类型 <input type="text" value="院系" id="type" name="type" readonly/>
            </div>
        <div style="width: 100%">
            隶属
            <input type="text" id="parentDepartment" name="parentDepartment" readonly/></div>
        <div style="width: 100%">
            名称
            <input type="text" id="Name" name="Name" />
        </div>
        <div style="width: 100%">
            编码
            <input type="text" id="Sn" name="Sn" />
        </div>
        <div style="width: 100%">
            图片
            <input type="file" id="DescriptImage" name="DescriptImage" />
            <a id="linkDescriptImage" href="" target="_blank" style="display:none">点击下载</a>    
        </div>
        <div style="width: 100%">
            简介
            <textarea id="SimpleDescript" runat="server" name="SimpleDescript" style="width: 80%; height: 100px;"></textarea>
        </div>
        <div style="width: 100%">
            详情
            <textarea id="DetailDescript" runat="server" name="DetailDescript" style="width: 80%; height: 200px;"></textarea>
        </div>
        </form>
        <div id="demo" class="demo">
           <a id="addFaculty" href="#" class="easyui-linkbutton" plain="true" iconCls="icon-add" style="display:none">添加院系</a>
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

    var SimpleEditor;
    var DetailEditor;
    KindEditor.ready(function(K) {
	    SimpleEditor = K.create('textarea[name="SimpleDescript"]', {
		    resizeType : 1,
		    allowImageUpload : false,
		    items : [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
			    'insertunorderedlist']
	    });
		DetailEditor = K.create('textarea[name="DetailDescript"]', {
		    uploadJson : '/control/upload_json.ashx',
			fileManagerJson : '/control/file_manager_json.ashx',
			allowFileManager : true
		});
    });
    
    $(function(){  
    $("#delBtn").click(function(){
        $("#method").val("deleteDepartment");
        $('#form').submit();
    });
    $("#saveBtn").click(function(){
        $("#method").val("saveDepartment");
        $('#form').submit();
    });
    $("#addFaculty").click(function(){
       beforeClickPrepare("院系");
    });
    $("#addProfession").click(function(){
        beforeClickPrepare("专业");
    });
    $("#addClassGrade").click(function(){
       beforeClickPrepare("班级");
    });
    $('#form').form({  
        url:'/control/DepartmentControl.ashx',
        onSubmit: function(){ 
            SimpleEditor.sync();
            DetailEditor.sync();
            return $('#form').form('validate');
        },  
        success:function(data){ 
            if(data == "1"){
              msgShow('提示','操作成功');
            }else if(data =="0"){
              msgAlert('提示','操作失败','error');
            }
        }  
    }); 
    $('#tt').tree({  
        url:'/control/DepartmentControl.ashx?method=getDepartmentTree',
        onLoadSuccess:function(node, data){
           if(data == ""){
               $("#type").val("学校");
           }
        },
        onClick: function(node){
           var type = node.attributes.type;
           var parentType = $('#tt').tree("getParent",node.target);
           setEnableBtn(type);
		    $.ajax({
                url: "/control/DepartmentControl.ashx?method=getDepartment&type="+type,
                data: {
                   Id: node.id,
                   type:type
                },
                type:'post', 
                success: function( data ) {
                    if (data.length > 0) {
                      $("#form").serializeJsonToForm(data);
                      $("#type").val(type);
                      var json = jQuery.parseJSON(data);
                      SimpleEditor.html(json.SimpleDescript);
                      DetailEditor.html(json.DetailDescript);
                      if(json.DescriptImage == undefined || json.DescriptImage == ""){
                          $("#linkDescriptImage").hide();
                      }else{
                          $("#linkDescriptImage").show();
                          $("#linkDescriptImage").attr("href",json.DescriptImage);
                      }
                      
                      if(parentType != undefined && parentType != null){
                          $("#pId").val(parentType.id);
                          $("#parentDepartment").val(parentType.text);
                      }
                    } else {
                      msgAlert('提示','加载用户详细信息失败!','error');
                    }
                },
                error : function() {      
                   alert("异常！");    
                } 
            });
	    }
	   });
    })
    
    function beforeClickPrepare(type){
       var Name = $("#Name").val();
       var Id = $("#Id").val();
       $("form").form('clear');
       $("#type").val(type);
       $("#pId").val(Id);
       $("#parentDepartment").val(Name);
       setEnableBtn("");
    }
    
    function setEnableBtn(position){
    
        $("#addFaculty").hide();
        $("#addProfession").hide();
        $("#addClassGrade").hide();
        
        if(position != "1" &&position != "2" &&position != "3" ){
           if(position == "学校"){
               position = "1";
           }
           else if(position == "院系"){
               position = "2";
           }
           else if(position == "专业"){
               position = "3";
           }
        }

        switch(position){
           case "1" :
               $("#addFaculty").show();
               $("#type").val("院系");
               break;
           case "2" :
               $("#addProfession").show();
               $("#type").val("专业");
               break;
           case "3" :
               $("#addClassGrade").show();
               $("#type").val("班级");
               break;
           default :
               break;
        }
    }
</script>

