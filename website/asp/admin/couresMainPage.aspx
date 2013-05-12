<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="couresMainPage.aspx.cs"
    Inherits="WebSite.asp.studentManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/Jscript/easyui1.2.6/js/themes/icon.css" />

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/jquery.easyui.min.js"></script>

    <script type="text/javascript" src="/Jscript/easyui1.2.6/js/locale/easyui-lang-zh_CN.js"></script>

    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/Jinjuan.index.js'> </script>
    
    <script type="text/javascript" src='/Jscript/easyui1.2.6/js/form.js'> </script>

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
        .table input
        {
            width: 128px;
        }
        .table select
        {
            width: 128px;
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
                        院系
                    </td>
                    <td>
                        <input id='faculty_sel' name='faculty' type="text"/>
                    </td>
                    <td>
                        专业
                    </td>
                    <td>
                        <input id='profession_sel' name='profession' type="text" />
                    </td>
                    <td>
                        年号
                    </td>
                    <td>
                        <select id="YearNo_sel" name="YearNo"></select>
                    </td>
                    <td>
                        年级
                    </td>
                    <td>
                        <select id="LevelNo_sel" name="LevelNo">
                           <option value="大一">大一</option>
                            <option value="大二">大二</option>
                            <option value="大三">大三</option>
                            <option value="大四">大四</option>
                        </select>
                    </td>
 
                    <td>
                        <a class="easyui-linkbutton" iconcls="icon-search" href="###" id="searchBtn">搜索</a> <a class="easyui-linkbutton"
                            iconcls="icon-reload" href="###" id="refreshBtn">刷新</a>
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
    <div region="center" title="课程管理" border="false">
        <table id="datagrid" idField="Id" class="easyui-datagrid" url="/control/CouresControl.ashx?method=searchCoures" border="false" fit="true"
            toolbar="#toolbar" pagination="true" rownumbers="true" singleselect="true">
            <thead>
                <tr>
                    <th field="ProfessionName" width="100">
                        专业
                    </th>
                    <th field="Name" width="100">
                        名称
                    </th>
                    <th field="YearNo" width="100">
                        年号
                    </th>
                    <th field="LevelNo" width="100">
                        年级
                    </th>
                    <th field="totalScore" width="100">
                        总分
                    </th>
                </tr>
            </thead>
        </table>
    </div>
    <div id="w" class="easyui-window" closed="true" style="padding: 5px;">
        <form id="editForm" action="/control/CouresControl.ashx" style="margin: 0 0 0 0;" method="post" enctype="multipart/form-data">
        <input type="hidden" id="method" name="method" value="saveCoures" />
        <input type="hidden" id="Id" name="Id"/>
        <table id="table" class="table" style="width: 100%; height: 100%">
            <tr>
                <td>
                    院系
                </td>
                <td>
                    <input id='faculty' name='faculty' type="text"/>
                </td>
                <td>
                    专业
                </td>
                <td>
                    <input id='profession' name='profession' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    年号
                </td>
                <td>
                   <select id="YearNo" name="YearNo"></select>
                </td>
                <td>
                    年级
                </td>
                <td>
                    <select id="LevelNo" name="LevelNo">
                            <option value="大一">大一</option>
                            <option value="大二">大二</option>
                            <option value="大三">大三</option>
                            <option value="大四">大四</option>
                   </select>
                </td>
            </tr>
            <tr>
                <td>
                    名称
                </td>
                <td>
                    <input id='Name' name='Name' type="text" />
                </td>
                <td>
                    总分
                </td>
                <td>
                    <input id='totalScore' name='totalScore' type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    描述
                </td>
                <td colspan="3">
                  <textarea id="Descript" name="Descript" style="width:95%" cols="20" rows="3"></textarea>
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
        $('#faculty').combobox({
				url:'/control/DepartmentControl.ashx?method=getFacultyCombo',
				valueField:'Id',
				textField:'Name',
				onSelect: function(faculty){   
				      $('#profession').combobox('setValues', '');
                    var url = '/control/DepartmentControl.ashx?method=getProfessionCombo&facultyID='+faculty.Id;   
                    $('#profession').combobox('reload', url);   
               }
		});
		$('#profession').combobox({
				url:'',
				valueField:'Id',
				textField:'Name'
		});
        $('#faculty_sel').combobox({
				url:'/control/DepartmentControl.ashx?method=getFacultyCombo',
				valueField:'Id',
				textField:'Name',
				onSelect: function(faculty){   
				      $('#profession_sel').combobox('setValues', '');
                    var url = '/control/DepartmentControl.ashx?method=getProfessionCombo&facultyID='+faculty.Id;   
                    $('#profession_sel').combobox('reload', url);   
               }
		});
		$('#profession_sel').combobox({
				url:'',
				valueField:'Id',
				textField:'Name'
		});
		$("#searchBtn").click(function(){
		    var faculty_sel = $('#faculty_sel').combobox('getValue');
		    var profession_sel = $('#profession_sel').combobox('getValue')
		    var YearNo_sel = $("#YearNo_sel").val();
		    var LevelNo_sel = $("#LevelNo_sel").val();
            $('#datagrid').datagrid('reload',{
                FacultyID: faculty_sel,
                ProfessionID: profession_sel,
                YearNo: YearNo_sel,
                LevelNo: LevelNo_sel
            });
        });
	    $("#refreshBtn").click(function(){
            $('#datagrid').datagrid('reload',{});
        });
        $("#newUserBtn").click(function(){
           $('#w').window({  
            title:'添加',  
            modal:true  
           }); 
            $("#editForm").form('clear');
            $('#w').window('open');
            $("#method").val("saveCoures");

        });
        $("#editUserBtn").click(function(){
           var selected =  $('#datagrid').datagrid('getSelected');
            if(!selected){
               msgAlert('提示','请选中一行后再执行此操作','warning');
            }else{
                $('#w').window({  
                    title:'修改',  
                    modal:true  
                }); 
                $('#w').window('open');
                $("#method").val("saveCoures");
                $.ajax({
                    url: "/control/CouresControl.ashx?method=getCouresByID",
                    data: {
                       CouresID: selected.Id
                    },
                    type:'post', 
                    success: function( data ) {
                        if (data.length > 0) {
                          $("#table").serializeJsonToForm(data);
                          var json = jQuery.parseJSON(data);
                          
                          $('#faculty').combobox('select', json.FacultyID);
                          $('#profession').combobox('select', json.ProfessionID);
                          $('#profession')
                          $('#profession')
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
        $("#destroyUserBtn").click(function(){
            var selected =  $('#datagrid').datagrid('getSelected');
            if(!selected){
               msgAlert('提示','请选中一行后再执行此操作','warning');
            }else{
                $.ajax({
                    url: "/control/CouresControl.ashx?method=deleteCoures",
                    data: {
                      CouresID: selected.Id
                    },
                    type:'post', 
                    success: function( data ) {
                      if(data == "1"){
                          msgShow('提示','操作成功');
                          $('#datagrid').datagrid('reload'); 
                      }else{
                          msgAlert('提示','操作失败','error');
                      }
                    },
                    error : function() {      
                      alert("异常！");    
                    } 
                });
            }
        });
        $("#headImgFile").change(function(){
            $("#headImg").attr("src",$(this).val());
        });
        $("#dialogSaveBtn").click(function(){
            
            $('#editForm').submit();
        });
        $("#dialogCancelBtn").click(function(){
            $('#w').window('close');
        });
        
        $('#editForm').form({  
                onSubmit: function(){ 
                    return $('#editForm').form('validate');
                },  
                success:function(data){ 
                    if(data == "1"){
                      $('#w').window('close');
                      msgShow('提示','操作成功');
                      $('#datagrid').datagrid('reload'); 
                    }else if(data =="0"){
                      msgAlert('提示','操作失败','error');
                    }
                }  
            });
    })
    
    function changeHead(){
        $("#headImg").attr("src",$("#headImgFile").val());
    }
    
    var myDate  = new Date();
    for(var i = myDate.getFullYear();i > myDate.getFullYear() -100;i=i-1){  
        document.getElementById("YearNo_sel").options.add(new Option(i, i));  
        document.getElementById("YearNo").options.add(new Option(i, i));
    }
    
</script>

