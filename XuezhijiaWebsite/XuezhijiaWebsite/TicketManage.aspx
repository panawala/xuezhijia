<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketManage.aspx.cs" Inherits="XuezhijiaWebsite.TicketManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="门票管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
&nbsp;<asp:GridView ID="Tickets" runat="server" AutoGenerateColumns="False" DataKeyNames="TicketID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" OnClick="DeleteClick" CommandName="del" runat="server" CausesValidation="False" CommandArgument='<%# Eval("TicketID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("TicketName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("TicketID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="TicketName" HeaderText="门票名称" SortExpression="TicketName" />
                <asp:BoundField DataField="DurationOfService" HeaderText="有效期" SortExpression="DurationOfService" />
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
                <asp:BoundField DataField="WayToPay" HeaderText="付款方式" SortExpression="WayToPay" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="名票名"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="有效期"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" Visible="false" runat="server" Text="价格"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" Visible="false" runat="server" Text="付款方式"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" Visible="false" runat="server" Text="链接地址"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <br />
    <br />
    <asp:Label ID="Label8" Visible="false" runat="server" Text="备注"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox7" Visible="false" runat="server" TextMode="MultiLine" 
        Height="423px" Width="477px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Visible="false" Text="门票图片"></asp:Label>
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
