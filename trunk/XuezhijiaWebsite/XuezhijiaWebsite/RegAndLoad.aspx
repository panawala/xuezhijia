<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegAndLoad.aspx.cs" Inherits="RegAndLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        <asp:Label ID="Label1" runat="server" Text="填写登陆信息"></asp:Label>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="用户名"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="电话号码"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="密码"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="密码确认"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
    <p>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="邮箱"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Height="24px" Width="443px"></asp:TextBox>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="提交"  OnClick="CommitClick"/>
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="清空"  OnClick="ClearClick"/>
    </p>
    </form>
</body>
</html>
