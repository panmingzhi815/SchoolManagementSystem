//小潘编写
jQuery.fn.extend({
    serializeFormToJson:function () {
        var json = {};
        var input_arr = $(this).find("input");
        if (input_arr.length > 0) {
            $.each(input_arr, function (i, n) {
                var property = $(n).attr("name");
                if (json.hasOwnProperty(property)) {
//                    json[property].push($(n).val());
                    json[property] = $(n).val();
                } else {
                    json[property] = $(n).val();
                }
            });
        }
        var textarea_arr = $(this).find("textarea");
        if (textarea_arr.length > 0) {
            $.each(textarea_arr, function (i, n) {
                var property = $(n).attr("name");
                if (json.hasOwnProperty(property)) {
//                    json[property].push($(n).val());
                    json[property] =$(n).val() == '' ? "":$(n).html();
                } else {
                    json[property] =$(n).val() == '' ? "":$(n).html();
                }
            });
        }
        var select_arr = $(this).find("select");
        if (select_arr.length > 0) {
            $.each(select_arr, function (i, n) {
                var property = $(n).attr('id');
                var value = "";
                if($(n).hasClass("easyui-combobox")){
                    value = $(n).combobox('getValue');
                }else{
                    value = $("select[name='"+property+"'] options:selected").attr("value");
                }
                if (!json.hasOwnProperty(property)) {
//                    json[property].push(value);
                    json[property] = value;
                }else{
                    json[property] = value;
                }
            });
        }
        return json;
    },
    serializeSelectformToJson:function () {
        var json = {};
        var input_arr = $(this).find("input");
        if (input_arr.length > 0) {
            $.each(input_arr, function (i, n) {
                var property = ($(n).attr("name")+"").replace("_sel","");
                if (json.hasOwnProperty(property)) {
//                    json[property].push($(n).val());
                    json[property] = $(n).val();
                } else {
                    json[property] = $(n).val();
                }
            });
        }
        var textarea_arr = $(this).find("textarea");
        if (textarea_arr.length > 0) {
            $.each(textarea_arr, function (i, n) {
                var property = ($(n).attr("name")+"").replace("_sel","");
                if (json.hasOwnProperty(property)) {
//                    json[property].push($(n).text());
                    json[property] =$(n).text();
                } else {
                    json[property] =$(n).text();
                }
            });
        }
        var select_arr = $(this).find("select");
        if (select_arr.length > 0) {
            $.each(select_arr, function (i, n) {
                var property = ($(n).attr("id")+"").replace("_sel","");
                var value = "";
                if($(n).hasClass("easyui-combobox")){
                    value = $(n).combobox('getValue')+"";
                }else{
                    value = $("select[name='"+property+"'] options:selected").attr("value")+"";
                }
                if (!json.hasOwnProperty(property)) {
                    json[property] = value;
//                    json[property].push(value);
                }else{
                    json[property] = value;
                }
            });
        }
        return json;
    },
    serializeJsonToForm:function(jsonStr){
        var json = jQuery.parseJSON(jsonStr);
        $.each(json,function(name,value){
            var input = $("#"+name);
            if($(input).hasClass("easyui-combobox")){
                $(input).combobox('select',value+"");
            }if($(input).hasClass("easyui-datebox")){
                $(input).datebox('setValue', value.substr(0,10));
            }else if($(input).is("select")){
               $(input).val(value);
            }else if($(input).is("textarea")){
                $(input).val(value);
            }else if($(input).is(":text") || $(input).is(":hidden")){
                $(input).val(value);
            }
        })
    },
    pushToDatagrid:function(datagridId){
        var json = $(this).serializeSelectformToJson();
        $(datagridId).datagrid({
            queryParams:json
        })
        $(datagridId).datagrid('reload');
    },
    valid:function() { //表单输入框 编写人：chenbin
        var flag = true;
        var elem = $(this);
        var inputs = elem.find(":input[name]");

        $.each(inputs, function() {
            var name = $(this).attr("name");
            var objClass = $('#' + name).attr("class");
            if( $('#' + name).attr("type")=='hidden'){
                //return false;
            }else if (objClass == undefined) {
                //return false;
            }else if ( objClass.indexOf('easyui-validatebox')>=0 && !$('#' + name).validatebox('isValid') ){
                $(this).focus();
                flag = false;
                return false;
            }else if ( objClass.indexOf('easyui-combobox')>=0 && !$('#' + name).combobox('isValid') ){
                $(this).focus();
                flag = false;
                return false;
            }else if ( objClass.indexOf('easyui-combotree')>=0 && !$('#' + name).combotree('isValid') ){
                $(this).focus();
                flag = false;
                return false;
            }else if ( objClass.indexOf('easyui-combogrid')>=0 && !$('#' + name).combogrid('isValid') ){
                $(this).focus();
                flag = false;
                return false;
            }
        });

        if (flag == false) return false;
        var inputs3 = $(this).find(".easyui-combotree");
        $.each(inputs3, function() {
            if (!$(this).combotree('isValid')) {
                $(this).focus();
                flag = false;
                return false
            };
        });
        return flag;
    }
});
