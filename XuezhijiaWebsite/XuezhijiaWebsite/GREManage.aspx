<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GREManage.aspx.cs" Inherits="XuezhijiaWebsite.GREManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="课程管理"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="AddClick">增加新纪录</asp:LinkButton>
&nbsp;<asp:GridView ID="Courses" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate">
      <Columns>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">   
            <ItemTemplate>   
                <asp:LinkButton ID="LinkButton1" OnClick="DeleteClick" CommandName="del" runat="server" CausesValidation="False" CommandArgument='<%# Eval("CourseID") %>'
                    Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("CourseName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>   
            </ItemTemplate>   
          </asp:TemplateField>
           <asp:TemplateField HeaderText="修改" ShowHeader="False">   
            <ItemTemplate>   
               <asp:LinkButton ID="linkbtnName" runat="server" CommandName="Show" CommandArgument='<%# Eval("CourseID") %>' Text="修改记录"></asp:LinkButton>
            </ItemTemplate>   
          </asp:TemplateField>
                <asp:BoundField DataField="CourseName" HeaderText="课程名" SortExpression="CourseName" />
                <asp:BoundField DataField="Lessons" HeaderText="课时" SortExpression="Lessons" />
                <asp:BoundField DataField="Location" HeaderText="上课地点" SortExpression="Location" />
                <asp:BoundField DataField="Time" HeaderText="上课时间" SortExpression="Time" />
                <asp:BoundField DataField="MaxNumber" HeaderText="最大上课人数" SortExpression="MaxNumber" />
                <asp:BoundField DataField="Comment" HeaderText="备注" SortExpression="Comment" />
                <asp:BoundField DataField="TName" HeaderText="上课老师" SortExpression="TName" />
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="Label2" Visible="false" runat="server" Text="课程名"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" Visible="false" runat="server" Text="课时"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Label ID="Label4" Visible="false" runat="server" Text="上课地点"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" Visible="false" runat="server" Text="上课时间"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" Visible="false" runat="server" Text="最大上课人数"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" Visible="false" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label7" Visible="false" runat="server" Text="老师"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="TextBox6" Visible="false" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label8" Visible="false" runat="server" Text="备注"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox7" Visible="false" runat="server" TextMode="MultiLine" 
        Height="423px" Width="477px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Visible="false" Text="课程图片"></asp:Label>
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
