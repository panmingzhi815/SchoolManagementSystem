<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Domain.index" %>

<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>湖北工程学院主页</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <!-- Le styles -->
    <link href="/Jscript/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
    <style type="text/css">
      body {
        padding-top: 20px;
        padding-bottom: 40px;
      }

      /* Custom container */
      .container-narrow {
        margin: 0 auto;
        max-width: 700px;
      }
      .container-narrow > hr {
        margin: 30px 0;
      }

      /* Main marketing message and sign up button */
      .jumbotron {
        margin: 60px 0;
        text-align: center;
      }
      .jumbotron h1 {
        font-size: 72px;
        line-height: 1;
      }
      .jumbotron .btn {
        font-size: 21px;
        padding: 14px 24px;
      }

      /* Supporting marketing content */
      .marketing {
        margin: 60px 0;
      }
      .marketing p + h4 {
        margin-top: 28px;
      }
    </style>
    <link href="/Jscript/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet">
  </head>

  <body>

    <div class="container-narrow">

      <div class="masthead">
        <ul class="nav nav-pills pull-right">
          <li class="active"><a href="#">主页</a></li>
          <li><a href="login.aspx">成绩查询</a></li>
        </ul>
        <h3 class="muted">湖北工程学院</h3>
      </div>

      <hr>

      <div class="jumbotron" runat="server" id="SchoolContent">
        <%--<h1>湖北工程学院欢迎您!</h1>
        <p class="lead">湖北工程学院是人杰地灵之地，学子一片欣欣向荣，就业率稳步提升。</p>--%>
      </div>

      <hr>

      <div class="row-fluid marketing">
        <div class="span6" runat="server" id="FacultyColumn1">
          <%--<h4>计算机学院</h4>
          <p>计算机学院总共有7个科目，教授19人，博士4人，师资力量雄厚</p>

          <h4>生命科学学院</h4>
          <p>Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Cras mattis consectetur purus sit amet fermentum.</p>

          <h4>政法学院</h4>
          <p>Maecenas sed diam eget risus varius blandit sit amet non magna.</p>--%>
        </div>

        <div class="span6" runat="server" id="FacultyColumn2">
          <%--<h4>化学院</h4>
          <p>Donec id elit non mi porta gravida at eget metus. Maecenas faucibus mollis interdum.</p>

          <h4>外语系</h4>
          <p>Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Cras mattis consectetur purus sit amet fermentum.</p>

          <h4>艺术系</h4>
          <p>Maecenas sed diam eget risus varius blandit sit amet non magna.</p>--%>
        </div>
      </div>

      <hr>

      <div class="footer">
        <p>&copy; Company 2013</p>
      </div>

    </div> <!-- /container -->

    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="/Jscript/bootstrap/js/jquery-1.9.1.min.js"></script>
    <script src="/Jscript/bootstrap/js/bootstrap.min.js"></script>

  </body>
</html>

