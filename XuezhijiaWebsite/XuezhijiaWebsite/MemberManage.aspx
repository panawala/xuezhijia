<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberManage.aspx.cs" Inherits="XuezhijiaWebsite.MemberManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="学员管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
   
<asp:GridView ID="Member" runat="server" AutoGenerateColumns="False"  DataKeyNames="MemberId" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("MemberId") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("Name").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="名字" SortExpression="Name" />
                <asp:BoundField DataField="IsNative" HeaderText="是否本地户口" SortExpression="IsNative" />
                <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                <asp:BoundField DataField="ContactInformation" HeaderText="联系方式" SortExpression="ContactInformation" />
                <asp:BoundField DataField="Type" HeaderText="类型" SortExpression="Type" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
     </Columns>
    </asp:GridView>
    <br />
    </form>
</body>
</html>
