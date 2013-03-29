<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentMainPage.aspx.cs"
    Inherits="WebSite.asp.studentManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/icon.css" />

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>

    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/Jinjuan.index.js'> </script>

    <style type="text/css">
        legend
        {
            font-size: 12px;
            color: Blue;
        }
        fieldset
        {
            margin: 3px;
        }
    </style>
</head>
<body class="easyui-layout">
    <div region="north" style="overflow: hidden;">
        <fieldset>
            <legend>查询</legend>
            <table>
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        <input type="text" style="width: 100px" />
                    </td>
                    <td>
                        性别
                    </td>
                    <td>
                        <select style="width: 50px">
                            <option>男</option>
                            <option>女</option>
                        </select>
                    </td>
                    <td>
                        身份证
                    </td>
                    <td>
                        <input type="text" style="width: 150px" />
                    </td>
                    <td>
                        院系
                    </td>
                    <td>
                        <select style="width: 120px">
                            <option>电子系</option>
                            <option>计算机系</option>
                        </select>
                    </td>
                    <td>
                        专业
                    </td>
                    <td>
                        <select style="width: 120px">
                            <option>教育学</option>
                            <option>小学教育</option>
                            <option>软件开发</option>
                        </select>
                    </td>
                    <td>
                    <a class="easyui-linkbutton" iconCls="icon-search" href="###">搜索</a>
                    <a class="easyui-linkbutton" iconCls="icon-reload" href="###">刷新</a>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
        <div id="toolbar">  
        <a id="newUserBtn" href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-add" plain="true"">添加</a>  
        <a id="editUserBtn" href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true")">修改</a>  
        <a id="destroyUserBtn" href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-remove" plain="true"">删除</a>  
    </div>  
    <div region="center" title="学生管理" border="false">
        <table class="easyui-datagrid" url="datagrid_data2.json" border="false" fit="true" toolbar="#toolbar" pagination="true" rownumbers="true" fitColumns="true" singleSelect="true">
            <thead>
                <tr>
                    <th field="sn" width="60">
                        学号
                    </th>
                    <th field="name" width="40">
                        姓名
                    </th>
                    <th field="sex" width="40">
                        性别
                    </th>
                    <th field="birth" width="60">
                        出生日期
                    </th>
                    <th field="nation" width="40">
                        民族
                    </th>
                    <th field="telphone" width="60">
                        联系电话
                    </th>
                    <th field="address" width="100">
                        联系地址
                    </th>
                </tr>
            </thead>
        </table>
    </div>
    
    <div id="w" class="easyui-window" title="添加-修改" data-options="iconCls:'icon-edit',modal:true,closed:true" style="width:500px;height:200px;padding:10px;">  
        <div style="border:solid 1 #ffffff; height:100%; width:100%">
            
        </div> 
    </div>  
</body>
</html>

<script type="text/javascript">
    $(function(){
        $("#newUserBtn").click(function(){
            $('#w').window('open')
        });
        $("#editUserBtn").click(function(){
            $('#w').window('open')
        });
        $("#destroyUserBtn").click(function(){
            
        });
    })
</script>