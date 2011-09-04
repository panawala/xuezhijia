<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="XuezhijiaWebsite.index" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/index.css" rel="stylesheet" type="text/css" />

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
                       学之家网站是一个专门为学生提供服务与产品的新型创业型网站，网站始终以学生的需求为核心。我们希望能够通过去壮大自己来获得与社会上一些资源谈判的筹码。我们希望能通过这种方式能让学生在踏上社会之前尽量保护自己的权利，避免因为信息不对称而遭受不必要的损失，如果同学们对某一项资源需求很大欢迎拨打60486650，我们力争将该项资源价格水平推向最低！
                </div>
            </div>
            <div class="tab_space" id="newscontent">
                <div class="tab_space_title">
                    同济NEWS
                    <div class="more">
                        <a href="/News/NewsList.aspx?type=1">更多...</a></div>
                </div>
                <div id="webcontent">
                </div>
                <div class="tab_space_title">
                    学之家NEWS
                    <div class="more">
                        <a href="/News/NewsList.aspx?type=2">更多...</a></div>
                </div>
                <div id="schoolcontent">
                </div>
            </div>
            <div class="channel_space">
                <ul class="linklist">


                    <li><a href="http://xuanke.tongji.edu.cn/" target="_blank">本科生选课</a></li>
                    <li><a href="http://gsinfo.tongji.edu.cn/"target="_blank">研究生信息</a></li>
                    <li><a href="http://news.tongji.edu.cn/classid-1.html/"target="_blank"/>同济新闻网</a></li>
                    <li><a href="http://bbs.tongji.edu.cn/" target="_blank">同舟共济站</a></li>
                    <li><a href="http://bbs.tongji.net/" target="_blank">同济网bbs</a></li>
                    <li><a href="http://vpn.tongji.cn/" target="_blank">同济VPN</a></li>
                    <li><a href="http://www.tongji.edu.cn/" target="_blank">同济大学</a></li>
                    <li><a href="http://jiading.tongji.edu.cn/" target="_blank">嘉定校区</a></li>
                    <li><a href="http://urp.tongji.edu.cn" target="_blank">信息门户</a></li>
                    <li><a href="http://nyglzx.tongji.edu.cn/web/datastat.aspx" target="_blank">电量查询</a></li>
                    <li><a href="http://mail.tongji.edu.cn/" target="_blank">同济邮局</a></li>
                    <li><a href="mailto://xzxx@mail.tongji.edu.cn/" target="_blank">校长信箱</a></li>
                    <li><a href="http://lib.tongji.edu.cn/" target="_blank">图书馆</a></li>
                    <li><a href="http://hq.tongji.edu.cn/" target="_blank">后勤网</a></li>
                    <li><a href="http://yz.tongji.edu.cn/" target="_blank">研招网</a></li>
                    <li><a href="http://cwc.tongji.edu.cn/" target="_blank">财务处</a></li>                    
                    <li><a href="http://www.tongjiren.org/" target="_blank">校友会</a></li>
                    
                </ul>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getTopSixNewsByType",
            data: "{type:'2'}",
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
            data: "{type:'1'}",
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
