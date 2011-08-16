<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="House.aspx.cs" Inherits="XuezhijiaWebsite.House.House" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/house.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="housenav">二手市场</div>
<div id="housecontent" class="house">

</div>
<div class="second_right_nav">
<div class="block">
<div class="title">商家推广</div>
<div class="b">
选择百姓网付费推广，投入少
效果好。超过50万商家已使用
付费推广。
<p style="text-align:right;margin-right:2px;"><a href="/House/HouseAdd.aspx">我要发布</a></p>
</div>
</div>

<div class="blank10"></div>
<div class="blank10"></div>

<div class="block" id="rightblock">

</div>


</div>
<div style="clear:both;"></div>
<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getALLFormatedHourse",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#housecontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        $("#housecontent").fadeTo(0.001, 0);
        $("#housecontent").setTemplateURL('../house/housetemplate.htm');
        $('#housecontent').processTemplate(data.d);
        //在1s内将透明度设为1
        $("#housecontent").fadeTo(1000, 1);

    }
    </script>

     <script type="text/javascript">
         $.ajax({
             type: "POST",
             url: "/WS/CommonService.asmx/getArticleByID",
             data: "{id:'10'}",
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
             $('#rightblock').html('<img src="/Image/loader.gif"/>');
         }
         //加载成功
         function Successnav(data, status) {
             //在0s内将透明度设为0
             $("#rightblock").fadeTo(0.001, 0);
             $("#rightblock").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

             $("#rightblock").processTemplate(data.d);
             //在1s内将透明度设为1
             $("#rightblock").fadeTo(1000, 1);

         }
    </script>

</asp:Content>

