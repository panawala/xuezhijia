<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="News.aspx.cs" Inherits="XuezhijiaWebsite.News.News" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/news.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="newsnav">新闻</div>
<div id="newscontent" class="news">

</div>
<div id="right_nav" class="right_nav"></div>
<div style="clear:both;"></div>
</asp:Content>
