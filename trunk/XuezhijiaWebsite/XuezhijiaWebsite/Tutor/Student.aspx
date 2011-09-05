<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="XuezhijiaWebsite.Tutor.Student" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/student.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="studentnav">家教信息</div>
<div id="studentcontent" class="student">

</div>
<div class="second_right_nav">
<div class="block">
<div class="title">友情提醒</div>
<div class="b">
本板块完全免费，有需要的同学请在网上在线登记信息，我们一旦有适合您的的学生信息我们将第一时间与您联系！
<p style="text-align:right;margin-right:2px;"><a href="/Tutor/TutorAdd.aspx">我要当老师</a></p>


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
        url: "/WS/CommonService.asmx/getFormatedStudent",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#studentcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        //$("#studentcontent").fadeTo(0.001, 0);
        $("#studentcontent").setTemplateURL('../Tutor/studenttemplate.htm');
        $('#studentcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        //$("#studentcontent").fadeTo(1000, 1);

    }
    </script>

     <script type="text/javascript">

         $.ajax({
             type: "POST",
             url: "/WS/CommonService.asmx/getArticleByID",
             data: "{id:'9'}",
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
             //$("#rightblock").fadeTo(0.001, 0);
             $("#rightblock").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

             $("#rightblock").processTemplate(data.d);
             //在1s内将透明度设为1
             //$("#rightblock").fadeTo(1000, 1);

         }
    </script>

</asp:Content>


