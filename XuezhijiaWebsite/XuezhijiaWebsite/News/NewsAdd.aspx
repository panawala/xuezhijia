<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="XuezhijiaWebsite.News.NewsAdd" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/sample.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:DropDownList ID="DropDownList_Area" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList_Area_SelectedIndexChanged">
        </asp:DropDownList>
		<CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="400">
</CKEditor:CKEditorControl>
        <asp:Button ID="Btn_Submit" runat="server" Text="提交" 
            onclick="Btn_Submit_Click" />
            <div>
		<pre runat="server" id="preCKEditorData" class="samples"></pre>
	</div>
    </div>
    </form>
</body>
</html>
