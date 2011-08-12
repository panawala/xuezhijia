<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="SecondHandAdd.aspx.cs" Inherits="XuezhijiaWebsite.Secondhand.SecondHandAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/secondhandadd.css" rel="stylesheet" type="text/css" />
    <link href="../css/car.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function $(o) { return document.getElementById(o); }
        function CheckImgCss(o, img) {
            if (!/\.((jpg)|(bmp)|(gif)|(png))$/ig.test(o.value)) {
                alert('只能上传jpg,bmp,gif,png格式图片!');
                o.outerHTML = o.outerHTML;
            }
            else {
                $(img).filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = o.value;
                //$('Image1').src = o.value;//这里IE7已经不支持了。所以才有上面的方法。
            }
        }


        function addFile() {
            var str = '<input type="file" size="50" name="File">';
            document.getElementById("MyFile").insertAdjacentHTML("beforeEnd", str);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="carnav">
        <h1 id="H1">
            <span class="freeT">免费</span>发布信息</h1>
    </div>
    <div id="shcontent" class="shadd">
        <table>
            <tr>
                <td>
                    <label>
                        类目：</label>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <label>
                        联系方式：</label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        价格：</label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    <label>
                        具体地点：</label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        品牌：</label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        描述：</label>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Width="500px" Height="100px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <h3>
            多文件上传</h3>
        <div id="Div1">
            <input type="file" size="50" name="File" />
        </div>
        <input type="button" value="增加(Add)" onclick="addFile()" />
        <input onclick="this.form.reset()" type="button" value="重置(ReSet)" />
        <asp:Button runat="server" Text="开始上传" ID="Button1"></asp:Button>
    </div>
    <div id="right_nav" class="right_nav">
    </div>
    <div style="clear: both;">
    </div>
</asp:Content>
