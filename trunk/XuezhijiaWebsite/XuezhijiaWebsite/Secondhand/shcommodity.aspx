<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="shcommodity.aspx.cs" Inherits="XuezhijiaWebsite.Secondhand.shcommodity" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../css/sencondhand.css" rel="stylesheet" type="text/css" />
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

<div class="secondhandnav">二手市场</div>
<div id="secondhandcontent" class="secondhand">
</div>


<div class="second_right_nav">
<div class="block">
<div class="title">学之家友情提醒：
</div>
<div class="b">
不要提前转账或汇款！
<p style="text-align:right;margin-right:2px;"></p>
</div>
</div>

<div class="blank10"></div>
<div class="blank10"></div>




</div>
<div style="clear:both;"></div>

<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getSecondHandMarketByID",
        data: "{id:"+request("id")+"}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#secondhandcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        //$("#secondhandcontent").fadeTo(0.001, 0);
        $("#secondhandcontent").setTemplateURL('../secondhand/shcommoditytemlate.htm', null, { filter_data: false });
        $('#secondhandcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        //$("#secondhandcontent").fadeTo(1000, 1);

    }
    </script>

</asp:Content>
