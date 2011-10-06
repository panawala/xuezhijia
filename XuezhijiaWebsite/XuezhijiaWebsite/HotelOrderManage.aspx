<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelOrderManage.aspx.cs" Inherits="XuezhijiaWebsite.HotelOrderManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    </div>
    <asp:Label ID="Label1" runat="server" Text="订单管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
   
<asp:GridView ID="Order" runat="server" AutoGenerateColumns="False"  DataKeyNames="OrderID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" CommandName="Delete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("OrderID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("CustomName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="CustomName" HeaderText="客户姓名" SortExpression="CustomName" />
                <asp:BoundField DataField="ConnectionMethods" HeaderText="联系方式" SortExpression="ConnectionMethods" />
                <asp:BoundField DataField="Type" HeaderText="订房类型" SortExpression="Type" />
                <asp:BoundField DataField="EnterDateTime" HeaderText="入住时间" SortExpression="EnterDateTime" />
                <asp:BoundField DataField="LeaveDateTime" HeaderText="离开时间" SortExpression="LeaveDateTime" />
                <asp:BoundField DataField="Gender" HeaderText="客户性别" SortExpression="Gender" />
                <asp:BoundField DataField="RoomCount" HeaderText="订房数量" SortExpression="RoomCount" />
                <asp:BoundField DataField="SumPrice" HeaderText="总价" SortExpression="SumPrice" />
                <asp:BoundField DataField="HotelName" HeaderText="所定宾馆名称" SortExpression="HotelName" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
     </Columns>
    </asp:GridView>
    <br />
    </form>
</body>
</html>
