<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Train.aspx.cs" Inherits="XuezhijiaWebsite.Train.Train" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/train.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="trainnav">考研培训</div>
<div id="traincontent" class="train">

</div>
<div id="right_nav" class="right_nav"></div>
<div style="clear:both;"></div>
<script type="text/javascript">

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
        $('#traincontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        $("#traincontent").fadeTo(0.001, 0);
        $("#traincontent").setTemplateURL('../Train/traintemplate.htm');
        $('#traincontent').processTemplate(data.d);
        //在1s内将透明度设为1
        $("#traincontent").fadeTo(1000, 1);

    }
    </script>


    <script type="text/javascript">

        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getArticleByID",
            data: "{id:'6'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: Loadingnav, //执行ajax前执行loading函数.直到success 
            success: Successnav,
            error: Error
        });

        function Error() {
            alert("error");
        }
        //加载中的状态
        function Loadingnav() {
            $('#right_nav').html('<img src="/Image/loader.gif"/>');
        }
        //加载成功
        function Successnav(data, status) {
            //在0s内将透明度设为0
            $("#right_nav").fadeTo(0.001, 0);
            $("#right_nav").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

            $("#right_nav").processTemplate(data.d);
            //在1s内将透明度设为1
            $("#right_nav").fadeTo(1000, 1);

        }
    </script>


</asp:Content>
