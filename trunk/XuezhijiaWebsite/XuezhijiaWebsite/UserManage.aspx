<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="XuezhijiaWebsite.UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView_Users" runat="server" AutoGenerateColumns="False" >
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="会员姓名" />
                <asp:BoundField DataField="Tel_NO" HeaderText="电话号码" />
                <asp:BoundField DataField="Comment" HeaderText="邮箱" />
                <asp:BoundField DataField="Grade" HeaderText="年级" />
                 <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
            </Columns>
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
