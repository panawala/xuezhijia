<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Secondhand.aspx.cs" Inherits="XuezhijiaWebsite.Secondhand.Secondhand" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/sencondhand.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="secondhandnav">二手市场</div>
<div id="secondhandcontent" class="secondhand">

</div>
<div class="second_right_nav">
<div class="block">
<div class="title">商家推广</div>
<div class="b">
选择百姓网付费推广，投入少
效果好。超过50万商家已使用
付费推广。
<p style="text-align:right;margin-right:2px;"><a href="/Secondhand/SecondHandAdd.aspx">我要发布</a></p>
</div>
</div>

<div class="blank10"></div>
<div class="blank10"></div>

<div class="block">
<div class="b">
<a href="http://www.baixing.com/mkt/spread/intro/?src=listing" target="_blank">百姓联盟，实实在在赚点钱</a>

<a href="http://www.baixing.com/pay/?city=xuchang&amp;serviceType=53&amp;src=listSide" target="_blank" style="color:red">开通车商店铺，免费刷新！</a>
<p><a href="http://bbs.baixing.com/viewthread.php?tid=967171&amp;extra=page%3D1&amp;frombbs=1" target="_blank"><span style="color:red;">"二手车团购"活动招商啦</span></a></p>
<p><a href="http://shanghai.baixing.com/ershouqiche/?query=%E4%B8%8B%E7%BA%BF%E8%BD%A6" target="_blank"><span style="color:red;">上海低价下线车</span></a></p>
<p>提醒：不要提前转账或汇款！ </p>
</div>
</div>


</div>
<div style="clear:both;"></div>
<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getAllSecondHandMarketList",
        data: "{}",
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
        $("#secondhandcontent").fadeTo(0.001, 0);
        $("#secondhandcontent").setTemplateURL('../secondhand/secondhandtemplate.htm');
        $('#secondhandcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        $("#secondhandcontent").fadeTo(1000, 1);

    }
    </script>


</asp:Content>
