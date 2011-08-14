<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondHandMarketManage.aspx.cs" Inherits="XuezhijiaWebsite.SecondHandMarketManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="二手市场管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:GridView ID="SecondHandMarkets" runat="server" AutoGenerateColumns="False" DataKeyNames="SID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" OnClick="DeleteClick" CommandName="del" runat="server" CausesValidation="False" CommandArgument='<%# Eval("SID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("Type").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("SID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="Tipical" HeaderText="标题" SortExpression="Tipical" />
                <asp:BoundField DataField="Type" HeaderText="类型" SortExpression="Type" />
                <asp:BoundField DataField="LookCount" HeaderText="点击量" SortExpression="LookCount" />
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
                <asp:BoundField DataField="PublishDate" HeaderText="发布时间" SortExpression="PublishDate" />
                <asp:BoundField DataField="Location" HeaderText="交易地点" SortExpression="Location" />
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
               <asp:BoundField DataField="PhotoList" HeaderText="图片列表" SortExpression="PIDList" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="标题"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="类型"></asp:Label>
    &nbsp;&nbsp; &nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" Visible="false" runat="server" Text="点击量"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" Visible="false" runat="server" Text="价格"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" Visible="false" runat="server" Text="发布时间"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label9" Visible="false" runat="server" Text="交易地点"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox8" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label10" Visible="false" runat="server" Text="联系信息"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox9" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
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
