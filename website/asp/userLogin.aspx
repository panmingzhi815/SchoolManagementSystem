<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="WebSite.asp.userLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>欢迎登录</title>
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/icon.css" />
    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>
	<script type="text/javascript" src='/Jscript/easyui1.2.6/js/Jinjuan.index.js'> </script>
</head>

<body>
<div id="loginWin" class="easyui-window" title="登录" style="width:400px;height:260px;" closable="false"
   minimizable="false" maximizable="false" resizable="false" collapsible="false">
    <div class="easyui-layout" fit="true">
        <div region="north" style="height:60px; padding:0" border="false">
           <img  src="../images/loginback.png" width="100%" height="60px"/>
        </div>
        <div region="center" border="false">
             <div class="easyui-tabs" fit="true" border="false">
                <div title="普通用户">
                    <table style=" padding-top:15px;padding-left:70px; font-size:15px; line-height:30px">
                        <tr>
                            <td width="60px">用户名</td>
                            <td><input class="easyui-validatebox" required="true" validType="length[1,20]"></td>
                        </tr>
                         <tr>
                            <td>密　码</td>
                            <td><input class="easyui-validatebox" required="true" validType="length[1,16]"></td>
                        </tr>
                         <tr>
                            <td colspan="2" align="center">
                                <a class="easyui-linkbutton" iconCls="icon-ok" href="main.aspx">登陆</a><b style=" width:40px">　</b><a class="easyui-linkbutton" iconCls="icon-cancel" href="###">重置</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div title="管理员">
                    <table style=" padding-top:15px;padding-left:70px; font-size:15px; line-height:30px">
                        <tr>
                            <td width="60px">用户名</td>
                            <td><input class="easyui-validatebox" required="true" validType="length[1,20]"></td>
                        </tr>
                         <tr>
                            <td>密　码</td>
                            <td><input class="easyui-validatebox" required="true" validType="length[1,16]"></td>
                        </tr>
                         <tr>
                            <td colspan="2" align="center">
                                <a class="easyui-linkbutton" iconCls="icon-ok" href="###">登陆</a><b style=" width:40px">　</b><a class="easyui-linkbutton" iconCls="icon-cancel" href="###">重置</a>
                            </td>
                        </tr>
                    </table>
                </div>
             </div>
        </div>
    </div>
</div>
</body>
</script>
</html>