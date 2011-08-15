<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DishManage.aspx.cs" Inherits="XuezhijiaWebsite.DishManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
    <asp:Label ID="Label8" runat="server" Text="店铺"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="饭菜管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
&nbsp;<asp:GridView ID="Dishs" runat="server" AutoGenerateColumns="False" DataKeyNames="DishId" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete"  runat="server" CausesValidation="False" CommandArgument='<%# Eval("DishId") %>'
                    Text="删除" OnClientClick='<%# "if (!confirm(\"你确定要删除" + Eval("DishName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server"  CommandName="Edit" CommandArgument='<%# Eval("DishId") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="DishName" HeaderText="菜名" SortExpression="DishName" />
                <asp:BoundField DataField="DishScore" HeaderText="评分" SortExpression="DishScore" />
                <asp:BoundField DataField="DishUpCount" HeaderText="顶" SortExpression="DishUpCount" />
                <asp:BoundField DataField="DishDownCount" HeaderText="踩" SortExpression="DishDownCount" />
                <asp:BoundField DataField="DishCatalog" HeaderText="分类" SortExpression="DishCatalog" />
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="菜名"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="评分"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" Visible="false" runat="server" Text="价格"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" Visible="false" runat="server" Text="分类"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" Visible="false" runat="server" Text="踩次数"></asp:Label>
    &nbsp;
    <asp:TextBox ID="TextBox5" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label7" Visible="false" runat="server" Text="顶次数"></asp:Label>
    &nbsp;
    <asp:TextBox ID="TextBox6" Visible="false" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    &nbsp;<br />
    <asp:Button ID="Button1" runat="server" Visible="false" Text="提交" OnClick="CommitClick" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    </form>
</body>
</html>
