<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="departmentMainPage.aspx.cs" Inherits="WebSite.asp.departmentMainPage" %>

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
                </tr>
            </table>
        </fieldset>
    </div>
    <div region="center" title="学生管理" border="false">
        <table class="easyui-datagrid" url="datagrid_data2.json" border="false" fit="true"
            fitcolumns="true">
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
</body>
</html>