<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HourseManage.aspx.cs" Inherits="XuezhijiaWebsite.HourseManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="房屋管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
&nbsp;<asp:GridView ID="RentHourses" runat="server" AutoGenerateColumns="False" DataKeyNames="HourseID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" OnClick="DeleteClick" CommandName="del" runat="server" CausesValidation="False" CommandArgument='<%# Eval("HourseID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("HourseName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("HourseID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
                <asp:BoundField DataField="RentType" HeaderText="租赁方式" SortExpression="RentType" />
                <asp:BoundField DataField="HourseType" HeaderText="房屋类型" SortExpression="HourseType" />
                <asp:BoundField DataField="HourseName" HeaderText="房屋名称" SortExpression="HourseName" />
                <asp:BoundField DataField="Area" HeaderText="面积/平米" SortExpression="Area" />
                <asp:BoundField DataField="Configuration" HeaderText="房屋配置" SortExpression="Configuration" />
                <asp:BoundField DataField="ClickCount" HeaderText="点击量" SortExpression="ClickCount" />
                <asp:BoundField DataField="DistributeTime" HeaderText="发布时间" SortExpression="DistributeTime" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="价格"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="租赁类型"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" Visible="false" runat="server" Text="房屋类型"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" Visible="false" runat="server" Text="房屋名称"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" Visible="false" runat="server" Text="面积"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label9" Visible="false" runat="server" Text="发布时间"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox8" Visible="false" runat="server"></asp:TextBox>
    &nbsp;<br />
    <br />
    <asp:Label ID="Label7" Visible="false" runat="server" Text="房屋配置"></asp:Label>
    &nbsp;
    <asp:TextBox ID="TextBox6" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label8" Visible="false" runat="server" Text="点击量"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox7" Visible="false" runat="server" 
        Height="30px" Width="242px"></asp:TextBox>
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
