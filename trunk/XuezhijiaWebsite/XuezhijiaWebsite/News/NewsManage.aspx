<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="XuezhijiaWebsite.News.NewsManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView_News" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView_News_RowDeleting">
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField DataField="NewsType" HeaderText="新闻类型" />
                <asp:BoundField DataField="NewsTitle" HeaderText="新闻标题" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="check" CommandName="Check" Text="查看" CommandArgument='<%#Eval("NewsID") %>'
                            OnCommand="Check_Command" CausesValidation="false"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="edit" CommandName="Check" Text="编辑" CommandArgument='<%#Eval("NewsID") %>'
                            OnCommand="Edit_Command" CausesValidation="false"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
