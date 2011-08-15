<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherInformation.aspx.cs" Inherits="XuezhijiaWebsite.TeacherInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="老师信息管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
&nbsp;<asp:GridView ID="Teachers" runat="server" AutoGenerateColumns="False" DataKeyNames="TID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("TName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("TID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="TName" HeaderText="姓名" SortExpression="TName" />
                <asp:BoundField DataField="ConnectionInformation" HeaderText="联系方式" SortExpression="ConnectionInformation" />
                <asp:BoundField DataField="AdvantageSubjects" HeaderText="擅长科目" SortExpression="AdvantageSubjects" />
                <asp:BoundField DataField="Comment" HeaderText="包车价格" SortExpression="Comment" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="名字"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="联系方式"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label4" Visible="false" runat="server" Text="擅长科目"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label8" Visible="false" runat="server" Text="备注"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox7" Visible="false" runat="server" TextMode="MultiLine" 
        Height="423px" Width="477px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="Button1" runat="server" Visible="false" Text="提交" OnClick="CommitClick" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    </form>
</body>
</html>
