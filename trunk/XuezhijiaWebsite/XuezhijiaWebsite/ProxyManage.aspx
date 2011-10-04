<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyManage.aspx.cs" Inherits="XuezhijiaWebsite.ProxyManage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="代理机构管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
<asp:GridView ID="Proxy" runat="server" AutoGenerateColumns="False"  DataKeyNames="ProId" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ProId") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("Name").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("ProId") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="代理商名称" SortExpression="Name" />
                <asp:BoundField DataField="Type" HeaderText="类型" SortExpression="Type" />
                <asp:BoundField DataField="PName" HeaderText="图片名" SortExpression="PName" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
     </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="代理机构名称"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="类型"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
    &nbsp;<br />
    <br />
    <asp:Label ID="Label8" Visible="false" runat="server" Text="备注"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    
        <CKEditor:CKEditorControl ID="TextBox7" runat="server" Height="300" Width="770">
</CKEditor:CKEditorControl>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Visible="false" Text="店铺图片"></asp:Label>
    <asp:Image ID="Image1" Visible="false" runat="server" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
&nbsp;<asp:Label ID="Label10" Visible="false" runat="server"  Text="上传新图片"></asp:Label>
    &nbsp;<br />
    <asp:FileUpload ID="Upload" Visible="false" runat="server" />
&nbsp;
    <br />
    <asp:Label ID="LabelComment" runat="server" Visible="false" Text="图片备注"></asp:Label>
    <br />
    <br />
&nbsp;<asp:TextBox ID="Comment" runat="server" Visible="false" Height="100px" Width="315px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Visible="false" Text="提交" OnClick="CommitClick" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    </form>
</body>
</html>
