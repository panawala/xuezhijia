<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="XuezhijiaWebsite.index" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jtemplates.js" type="text/javascript"></script>
    <script type="text/javascript">
        var t = n = 0, count;
        $(document).ready(function () {

            count = $("#banner_list a").length;
            $("#banner_list a:not(:first-child)").hide();
            $("#banner_info").html($("#banner_list a:first-child").find("img").attr('alt'));
            $("#banner_info").click(function () { window.open($("#banner_list a:first-child").attr('href'), "_blank") });
            $("#banner li").click(function () {
                var i = $(this).text() - 1; //获取Li元素内的值，即1，2，3，4
                n = i;
                if (i >= count) return;
                $("#banner_info").html($("#banner_list a").eq(i).find("img").attr('alt'));
                $("#banner_info").unbind().click(function () { window.open($("#banner_list a").eq(i).attr('href'), "_blank") })
                $("#banner_list a").filter(":visible").fadeOut(500).parent().children().eq(i).fadeIn(1000);
                document.getElementById("banner").style.background = "";
                $(this).toggleClass("on");
                $(this).siblings().removeAttr("class");
            });
            t = setInterval("showAuto()", 4000);
            $("#banner").hover(function () { clearInterval(t) }, function () { t = setInterval("showAuto()", 4000); });
        })

        function showAuto() {
            n = n >= (count - 1) ? 0 : ++n;
            $("#banner li").eq(n).trigger('click');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="index_content">
        <div class="index_center">
            <div class="img_space">
                <div id="banner">
                    <div id="banner_bg">
                    </div>
                    <!--标题背景-->
                    <div id="banner_info">
                    </div>
                    <!--标题-->
                    <ul>
                        <li class="on">1</li>
                        <%for (int i = 2; i < imgList.Count + 1; i++)
                          {%>
                        <li>
                            <%=i%></li>
                        <%} %>
                    </ul>
                    <div id="banner_list">
                        <%for (int i = 0; i < imgList.Count; i++)
                          {
                              DAL.INDEXIMAGE img = imgList[i];
                        %>
                        <a href="<%=img.ImageHref %>" target="_self">
                            <img src="../IndexImage/<%=img.ImageSrc %>" title="<%=img.ImageTitle %>" alt="<%=img.ImageAlt %>" /></a>
                        <% }%>
                    </div>
                </div>
                <div class="img_space_mark">
                    同济大学创建于1907年，是教育部直属全国重点大学，国家211工程和“985工程”重点建设高校，也是首批经国务院批准成立研究生院的 高校。在百余年的办学历程中，同济大学始终注重“人才培养、科学研究、社会服务、国际交往”四大功能均衡发展，综合实力位居国内高校前列。
                </div>
            </div>
            <div class="tab_space" id="newscontent">
                <div class="tab_space_title">
                    新闻列表
                    <div class="more">
                        <a href="/News/NewsList.aspx?type=1">更多...</a></div>
                </div>
                <div id="webcontent">
                </div>
                <div class="tab_space_title">
                    新闻列表
                    <div class="more">
                        <a href="/News/NewsList.aspx?type=2">更多...</a></div>
                </div>
                <div id="schoolcontent">
                </div>
            </div>
            <div class="channel_space">
                <ul class="linklist">
                    <li><a href="http://news.tongji.edu.cn/newscenter/" target="_blank">信息报送</a></li>
                    <li><a href="http://mail.tongji.edu.cn/" target="_blank">同济邮局</a></li>
                    <li><a href="mailto:xzxx@mail.tongji.edu.cn">校长信箱</a></li>
                    <li><a href="http://urp.tongji.edu.cn" target="_blank">信息门户</a></li>
                    <li><a href="./other/public.html" target="_blank">校务公开</a></li>
                    <li><a href="http://xxgk.tongji.edu.cn/" target="_blank">信息公开</a></li>
                    <li><a href="./other/index.html" target="_blank">站点链接</a></li>
                    <li><a href="./other/index.html" target="_blank">常用服务</a></li>
                    <li><a href="http://www.tongjiren.org/" target="_blank">校友会</a></li>
                    <li><a href="http://fund.tongji.edu.cn/" target="_blank">基金会</a></li>
                    <li><a href="http://xxgk.tongji.edu.cn/" target="_blank">信息公开</a></li>
                    <li><a href="./other/index.html" target="_blank">站点链接</a></li>
                    <li><a href="./other/index.html" target="_blank">常用服务</a></li>
                    <li><a href="http://www.tongjiren.org/" target="_blank">校友会</a></li>
                    <li><a href="http://fund.tongji.edu.cn/" target="_blank">基金会</a></li>
                </ul>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getTopSixNewsByType",
            data: "{id:'2'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: Loading, //执行ajax前执行loading函数.直到success 
            success: Success,
            error: Error
        });

        //加载中的状态
        function Loading() {
            $('#webcontent').html('<img src="/Image/loader.gif"/>');
        }
        //加载成功
        function Success(data, status) {
            //在0s内将透明度设为0
            $("#webcontent").fadeTo(0.001, 0);
            $("#webcontent").setTemplateURL('../Index/webtemplate.htm');
            $('#webcontent').processTemplate(data.d);
            //在1s内将透明度设为1
            $("#webcontent").fadeTo(1000, 1);

        }
    </script>
    <script type="text/javascript">

        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getTopSixNewsByType",
            data: "{id:'1'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: Loading, //执行ajax前执行loading函数.直到success 
            success: Success,
            error: Error
        });

        //加载中的状态
        function Loading() {
            $('#schoolcontent').html('<img src="/Image/loader.gif"/>');
        }
        //加载成功
        function Success(data, status) {
            //在0s内将透明度设为0
            $("#schoolcontent").fadeTo(0.001, 0);
            $("#schoolcontent").setTemplateURL('../Index/schooltemplate.htm');
            $('#schoolcontent').processTemplate(data.d);
            //在1s内将透明度设为1
            $("#schoolcontent").fadeTo(1000, 1);

        }
    </script>
</asp:Content>
