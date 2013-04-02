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

    <script type="text/javascript" src="/Jscript/locale/easyui-lang-zh_CN.js"></script>

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
        table input
        {
            width: 120px;
        }
        .table
        {
            border-collapse: collapse;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
            color: #000000;
            text-align: center;
        }
        .table tr th
        {
            background: #000;
            color: #FFF;
            font-size: 13px;
            height: 24px;
            line-height: 24px;
        }
        .table tr th.th_border
        {
            border-right: solid 1px #FFF;
            border-left: solid 1px #aabbcc;
        }
        .table tr td
        {
            border: solid 1px #aabbcc;
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
                        <a class="easyui-linkbutton" iconcls="icon-search" href="###">搜索</a> <a class="easyui-linkbutton"
                            iconcls="icon-reload" href="###">刷新</a>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="toolbar">
        <a id="newUserBtn" href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add"
            plain="true"">添加</a> <a id="editUserBtn" href="javascript:void(0)" class="easyui-linkbutton"
                iconcls="icon-edit" plain="true")">修改</a> <a id="destroyUserBtn" href="javascript:void(0)"
                    class="easyui-linkbutton" iconcls="icon-remove" plain="true"">删除</a>
    </div>
    <div region="center" title="学生管理" border="false">
        <table class="easyui-datagrid" url="datagrid_data2.json" border="false" fit="true"
            toolbar="#toolbar" pagination="true" rownumbers="true" singleselect="true">
            <thead>
                <tr>
                    <th field="sn" width="120">
                        学号
                    </th>
                    <th field="name" width="100">
                        姓名
                    </th>
                    <th field="sex" width="120">
                        性别
                    </th>
                    <th field="birth" width="100">
                        身份证
                    </th>
                    <th field="birth" width="80">
                        出生日期
                    </th>
                    <th field="nation" width="70">
                        民族
                    </th>
                    <th field="telphone" width="100">
                        联系电话
                    </th>
                    <th field="telphone" width="100">
                        院系
                    </th>
                </tr>
            </thead>
        </table>
    </div>
    <div id="w" class="easyui-window" closed="true" style="padding: 5px;">
        <form id="editForm" style="margin: 0 0 0 0;" method="post" enctype="multipart/form-data">
        <table class="table" style="width: 100%; height: 100%">
            <tr>
                <td>
                    学 号
                </td>
                <td>
                    <input name='Sn' type="text" />
                </td>
                <td colspan="2" rowspan="4" align="center">
                    <img alt='' id="headImg" width="100" height="100" style="border: solid 1px #aabbcc"
                        src="/images/default_head.gif" />
                </td>
            </tr>
            <tr>
                <td>
                    姓 名
                </td>
                <td>
                    <input name='Name' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    身 份 证
                </td>
                <td>
                    <input name='IDcode' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    性 别
                </td>
                <td>
                    <input name='Sex' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    民 族
                </td>
                <td>
                    <input name='Nation' type="text" />
                </td>
                <td>
                    头像上传
                </td>
                <td>
                    <input id="headImgFile" runat="server" name="headImgFile" type="file" style="max-width: 70px;"
                        size="2" onchange="changeHead()" />
                </td>
            </tr>
            <tr>
                <td>
                    院 系
                </td>
                <td>
                    <input name='Department' type="text" />
                </td>
                <td>
                    入校时间
                </td>
                <td>
                    <input name='EntryTime' class="easyui-datebox" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    专业
                </td>
                <td>
                    <input name="Profession" class="easyui-combobox" />
                </td>
                <td>
                    班级
                </td>
                <td>
                    <input name="ClassGrade" class="easyui-combobox" />
                </td>
            </tr>
            <tr>
                <td>
                    移动电话
                </td>
                <td>
                    <input name='Telphone' type="text" />
                </td>
                <td>
                    家庭固话
                </td>
                <td>
                    <input name='MobilePhone' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    家庭地址
                </td>
                <td colspan="3">
                    <input name='Address' type="text" style="width: 98%" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" style="padding: 10 10 10 10">
                    <a id="dialogSaveBtn" href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-save"
                        plain="true"">保存</a> <a id="dialogCancelBtn" href="javascript:void(0)" class="easyui-linkbutton"
                            iconcls="icon-cancel" plain="true"">取消</a>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>

<script type="text/javascript">
    $(function(){
        $("#newUserBtn").click(function(){
           $('#w').window({  
            title:'添加',  
            modal:true  
           }); 
            $('#w').window('open');

        });
        $("#editUserBtn").click(function(){
            $('#w').window({  
                title:'修改',  
                modal:true  
            }); 
            $('#w').window('open');
        });
        $("#destroyUserBtn").click(function(){
            
        });
        $("#headImgFile").change(function(){
            $("#headImg").attr("src",$(this).val());
        });
        $("#dialogSaveBtn").click(function(){
            $("#method").val("addStudent");
            $('#editForm').submit();
        });
        $("#dialogCancelBtn").click(function(){
            $('#w').window('close');
        });
        
        $('#editForm').form({  
                url:'/control/StudentControl.ashx?method=addStudent',
                onSubmit: function(){ 
                    return $('#editForm').form('validate');
                },  
                success:function(data){ 
                    if(data == "1"){
                      alert("修改成功");
                    }else if(data =="0"){
                      alert("修改失败");
                    }
                }  
            });
    })
    
    function changeHead(){
        $("#headImg").attr("src",$("#headImgFile").val());
    }
    
</script>

