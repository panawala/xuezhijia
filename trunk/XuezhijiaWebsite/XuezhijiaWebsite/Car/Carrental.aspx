<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Carrental.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/car.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div id="carcontent" class="car">

<%--<ul>
<li>
<div class="carimage"><img src="../Image/test.jpg" /></div>
<div class="cardes">sdfasfasfdasf</div>
</li>
<li>
<div class="carimage"><img src="../Image/test.jpg" /></div>
<div class="cardes">sdfasfasfdasf</div>
</li>
<li>
<div class="carimage"><img src="../Image/test.jpg" /></div>
<div class="cardes">sdfasfasfdasf</div>
</li>
<li>
<div class="carimage"><img src="../Image/test.jpg" /></div>
<div class="cardes">sdfasfasfdasf</div>
</li>
<li>
<div class="carimage"><img src="../Image/test.jpg" /></div>
<div class="cardes">sdfasfasfdasf</div>
</li>
</ul>--%>
</div>

<script type="text/javascript">
    
    var profile = { name: "小白", age: "24" };
    $("#carcontent").setTemplateURL('../Car/cartemplate.htm');
    $("#carcontent").processTemplate(profile); 
    </script>
</asp:Content>

