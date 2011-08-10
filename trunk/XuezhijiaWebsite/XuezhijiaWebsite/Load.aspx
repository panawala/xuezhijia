<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Load.aspx.cs" Inherits="XuezhijiaWebsite.Load" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="欢迎登陆"></asp:Label>
        <br />
        <br />
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确认" OnClick="CommitClick" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="清空" OnClick="ClearClick"/>
    </form>
</body>
</html>