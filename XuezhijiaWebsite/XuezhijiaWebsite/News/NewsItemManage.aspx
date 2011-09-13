<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsItemManage.aspx.cs" Inherits="XuezhijiaWebsite.News.NewsItemManage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <br />
        新闻标题：
        <br />
        <asp:TextBox ID="TextBox_Title" runat="server" Width="800px"></asp:TextBox>
        <br />
         新闻正文：
    <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="400" Width="810"></CKEditor:CKEditorControl>
        <asp:Button ID="Btn_Submit" runat="server" Text="提交" 
            onclick="Btn_Submit_Click" />
    </div>
    </form>
</body>
</html>
