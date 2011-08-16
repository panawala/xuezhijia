<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintManage.aspx.cs" Inherits="XuezhijiaWebsite.PrintManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="打印管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:GridView ID="File" runat="server" AutoGenerateColumns="False" DataKeyNames="RecordID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("RecordID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("FileName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("RecordID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="Size" HeaderText="大小" SortExpression="Size" />
                <asp:BoundField DataField="FileName" HeaderText="文件名" SortExpression="FileName" />
                <asp:BoundField DataField="PageCount" HeaderText="页数" SortExpression="PageCount" />
                <asp:BoundField DataField="DateTime" HeaderText="上传时间" SortExpression="DateTime" />
                <asp:BoundField DataField="UserName" HeaderText="用户" SortExpression="UserName" />
                <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="状态"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
    &nbsp;&nbsp;<br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Visible="false" Text="提交" OnClick="CommitClick" />
    &nbsp;</form>
</body>
</html>
