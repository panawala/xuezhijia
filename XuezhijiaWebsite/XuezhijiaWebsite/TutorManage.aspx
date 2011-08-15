<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorManage.aspx.cs" Inherits="XuezhijiaWebsite.TutorManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="家教信息管理"></asp:Label>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <asp:LinkButton ID="LinkButton1" OnClick="GotoStudent" runat="server">学生信息管理</asp:LinkButton>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:LinkButton ID="LinkButton2" OnClick="GotoTeacher" runat="server">老师信息管理</asp:LinkButton>
    </form>
</body>
</html>
