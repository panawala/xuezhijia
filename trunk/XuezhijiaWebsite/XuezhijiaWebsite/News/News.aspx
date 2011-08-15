<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="XuezhijiaWebsite.News.News" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/news.css" rel="stylesheet" type="text/css" />
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
     <div class="newsnav">新闻</div>
<div id="newscontent" class="news">

</div>
<div id="right_nav" class="right_nav"></div>
<div style="clear:both;"></div>


<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getResultByID",
        data: "{id:" + request("id") + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#newscontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        $("#newscontent").fadeTo(0.001, 0);
        $("#newscontent").setTemplateURL('../News/newstemplate.htm');
        $('#newscontent').processTemplate(data.d);
        //在1s内将透明度设为1
        $("#newscontent").fadeTo(1000, 1);

    }
    </script>


</asp:Content>
