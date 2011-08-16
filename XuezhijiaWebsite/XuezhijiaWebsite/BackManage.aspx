<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackManage.aspx.cs" Inherits="XuezhijiaWebsite.BackManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="后台管理 ："></asp:Label>
    <p>
&nbsp;
    </p>
    <asp:LinkButton ID="LinkButton1" Text="打印管理" runat="server" OnClick="PrintClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton2" Text="汽车管理" runat="server" OnClick="CarClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton3" Text="宾馆管理" runat="server" OnClick="HotelClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton4" Text="外卖管理" runat="server" OnClick="TakeOutClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton5" Text="考研信息管理" runat="server" OnClick="GREClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton6" Text="学生商城管理" runat="server" OnClick="StudentMarketClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton7" Text="门票管理" runat="server" OnClick="TicketClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton8" Text="家教信息管理" runat="server" OnClick="TutorClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton9" CausesValidation="False" Text="房屋租赁管理" runat="server" OnClick="HourseClick"></asp:LinkButton>
    <br />
    <br />
    <asp:LinkButton ID="LinkButton10" Text="二手市场管理" runat="server" OnClick="SecondHandMarktClick"></asp:LinkButton>
    <br />

     <br />
    <asp:LinkButton ID="LinkButton11" Text="右边栏内容编辑" runat="server" OnClick="RightEditClick"></asp:LinkButton>
    <br />

    </form>
</body>
</html>
