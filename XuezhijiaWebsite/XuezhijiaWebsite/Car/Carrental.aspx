<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Carrental.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/car.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="carcontent" class="car">

</div>

<script type="text/javascript">
    
   /* var profile = { name: "小白", age: "24" };
    $("#carcontent").setTemplateURL('../Car/cartemplate.htm');
    $("#carcontent").processTemplate(profile);*/

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getAllCourseList",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#carcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        $("#carcontent").fadeTo(0.001, 0);
        $("#carcontent").setTemplateURL('../Car/cartemplate.htm');
        $('#carcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        $("#carcontent").fadeTo(1000, 1);

    }
    </script>
</asp:Content>

