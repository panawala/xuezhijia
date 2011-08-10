<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoReview.aspx.cs" Inherits="XuezhijiaWebsite.PhotoReview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
   
    <br />
    <br />
    <br />
    <asp:FileUpload ID="Upload" runat="server" />
&nbsp;
    <asp:Button ID="Commit" runat="server" Text="上传" OnClick="UploadClicked" />
    <br />
    <asp:Label ID="LabelComment" runat="server" Text="备注"></asp:Label>
    <br />
    <br />
&nbsp;<asp:TextBox ID="Comment" runat="server" Height="100px" Width="315px"></asp:TextBox>
    <br />
    </form>
</body>
</html>
