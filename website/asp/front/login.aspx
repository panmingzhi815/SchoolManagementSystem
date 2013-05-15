<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Domain.asp.front.login" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>学生登陆</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Le styles -->
    <link href="../../Jscript/bootstrap/css/bootstrap.css" rel="stylesheet">
    <style type="text/css">
      body {
        padding-top: 40px;
        padding-bottom: 40px;
        background-color: #f5f5f5;
      }

      .form-signin {
        max-width: 300px;
        padding: 19px 29px 29px;
        margin: 0 auto 20px;
        background-color: #fff;
        border: 1px solid #e5e5e5;
      }
      .form-signin .form-signin-heading,
      {
        margin-bottom: 10px;
      }
      .form-signin input[type="text"],
      .form-signin input[type="password"] {
        font-size: 16px;
        height: auto;
        margin-bottom: 15px;
        padding: 7px 9px;
      }

    </style>
    <link href="../../Jscript/bootstrap/css/bootstrap-responsive.css" rel="stylesheet">
  </head>

  <body>
    <div class="span4"></div>
    <div class="container span4">
        <form id="form1" runat="server">
        <h2 class="form-signin-heading">请先登陆</h2>
        <input name="method" value="login" type="hidden" />
        <input id="Sn" runat="server" type="text" class="input-block-level" placeholder="用户名">
        <input  id="Password"  runat="server" type="password" class="input-block-level" placeholder="密码">
        <p id="ErrorInfos" runat="server" class="help-block"></p>
        <asp:Button ID="LoginBtn" runat="server" Text="登陆" 
            class="btn btn-large btn-primary" onclick="LoginBtn_Click"/>
        </form>
    </div>
    <div class="span4"></div>
  </body>
</html>

