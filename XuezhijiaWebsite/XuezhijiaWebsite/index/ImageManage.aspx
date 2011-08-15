<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageManage.aspx.cs" Inherits="XuezhijiaWebsite.Index.ImageManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView_Image" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView_Image_RowCancelingEdit"
            OnRowDeleting="GridView_Image_RowDeleting" OnRowEditing="GridView_Image_RowEditing"
            OnRowUpdating="GridView_Image_RowUpdating">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="ImageHref" HeaderText="图片链接" />
                <asp:BoundField DataField="ImageSrc" HeaderText="图片地址" />
                <asp:BoundField DataField="ImageTitle" HeaderText="图片标题" />
                <asp:BoundField DataField="ImageAlt" HeaderText="图片显示" />
                 <asp:CommandField HeaderText="选择" ShowSelectButton="True" />
                <asp:CommandField HeaderText="操作" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>
    <p>
    <asp:Label ID="Label2" runat="server" Text="图片连接"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="图片地址"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="标题"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3"  runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5"  runat="server" Text="替换文字"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    <asp:Button ID="Button1" runat="server" Text="提交" OnClick="CommitClick" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    </form>
</body>
</html>
