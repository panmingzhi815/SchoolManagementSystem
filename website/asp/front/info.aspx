<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Domain.asp.front.info" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>学生资料查询</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <link href="../../Jscript/bootstrap/css/bootstrap.css"rel="stylesheet">
    <style>
      body {
        padding-top: 60px;
      }
    </style>
    <link href="../../Jscript/bootstrap/css/bootstrap-responsive.css" rel="stylesheet">
    <script type="text/javascript" src="../../Jscript/bootstrap/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../Jscript/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function(){
           $("#updatePassword").click(function(){
               var Sn = $("#Sn").val();
               var Password = $("#Password").val();
               $.ajax({
                    url: "../../control/StudentControl.ashx?method=updatePassword",
                    data: {
                      Sn:Sn,
                      Password:Password
                    },
                    type:'post', 
                    success: function( data ) {
                      if(data == "1"){
                          $("#helpInfo").html("修改成功");
                      }else{
                          $("#helpInfo").html("修改失败");
                      }
                    }
                });
              });
        })
    </script>
  </head>

  <body>

    <div class="navbar navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container">
          <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </a>
          <a class="brand" href="#" id="welcomeInfo" runat="server">游客你好</a>
          <div class="nav-collapse pull-right">
            <ul class="nav">
              <li class="active"><a href="index.aspx">首页</a></li>
              <li><a href="score.aspx">考试成绩</a></li>
              <li><a href="info.aspx">基础资料</a></li>
              <li><a href="login.aspx">登陆</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>

    <div class="container">
        <form class="form-horizontal">
          <fieldset>
            <legend>基本资料</legend>
            <div class="control-group">
              <label class="control-label" for="input01">学号</label>
              <div class="controls">
                <input id="Sn" runat="server" type="text" class="input-xlarge" >
              </div>
            </div>
            <div class="control-group">
              <label class="control-label" for="input01">姓名</label>
              <div class="controls">
                <input id="Name" runat="server" type="text" class="input-xlarge" >
              </div>
            </div>
            <div class="control-group">
              <label class="control-label" for="input01">身份证</label>
              <div class="controls">
                <input id="IDCode" runat="server" type="text" class="input-xlarge">
              </div>
            </div>
            <div class="control-group">
              <label class="control-label" for="input01">民族</label>
              <div class="controls">
                <input id="Nation" runat="server" type="text" class="input-xlarge">
              </div>
            </div>
            <div class="control-group">
              <label class="control-label" for="input01">联系地址</label>
              <div class="controls">
                <input id="Address" runat="server" type="text" class="input-xlarge">
              </div>
            </div>
             <div class="control-group">
              <label class="control-label" for="input01">联系电话</label>
              <div class="controls">
                <input id="MobilePhone" runat="server" type="text" class="input-xlarge">
              </div>
            </div>
             <div class="control-group">
              <label class="control-label" for="input01">家庭电话</label>
              <div class="controls">
                <input id="Telphone" runat="server" type="text" class="input-xlarge">
              </div>
            </div>
            <div class="control-group">
              <label class="control-label" for="input01">登陆密码</label>
              <div class="controls">
                <input id="Password" runat="server" type="text" class="input-xlarge">
                <input id="updatePassword" class="btn btn-primary" type="button" value="保存更新" class="input-xlarge">
                <p class="help-block" id="helpInfo"></p>
              </div>
            </div>
          </fieldset>
        </form>
    </div>
  </body>
</html>