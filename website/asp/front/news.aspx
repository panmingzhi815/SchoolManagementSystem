<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Domain.asp.front.news" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>院系信息</title>
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
    </style>
    <link href="../../Jscript/bootstrap/css/bootstrap-responsive.css" rel="stylesheet">
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
    
<div class="span3"></div>
    <div class="span6" runat="server" id="TableContent">
    </div>
<div class="span3"></div>     
  </body>

