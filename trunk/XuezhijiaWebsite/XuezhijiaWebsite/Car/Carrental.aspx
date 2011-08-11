﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrental.aspx.cs" Inherits="XuezhijiaWebsite.Car.Carrental" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/car.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
    <script type="text/javascript">
        /*--获取网页传递的参数--*/
        function request(paras) {
            var url = location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            var paraObj = {}
            for (i = 0; j = paraString[i]; i++) {
                paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
            }
            var returnValue = paraObj[paras.toLowerCase()];
            if (typeof (returnValue) == "undefined") {
                return "";
            } else {
                return returnValue;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="carnav">汽车租赁</div>
<div id="carcontent" class="car">

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


    <script type="text/javascript">
 
        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getArticleByID",
            data: "{id:'"+request("id")+"'}",
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
            $("#right_nav").setTemplateURL('../Car/rightnav.htm');
            
            $("#right_nav").processTemplate(data.d);
            //在1s内将透明度设为1
            $("#right_nav").fadeTo(1000, 1);

        }
    </script>


</asp:Content>
