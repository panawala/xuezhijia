<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="SecondHandAdd.aspx.cs" Inherits="XuezhijiaWebsite.Secondhand.SecondHandAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/secondhandadd.css" rel="stylesheet" type="text/css" />
    <link href="../css/car.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.livequery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        
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
            var str = $('<div><input type="file" name="File"><a class="aclose">x</a></div>');
            $("#MyFile").append(str);
        }

        $(document).ready(function () {

            //绑定事件
            /*$(".aclose").click(function () {
                $(this).parent().remove();
            });*/

            $('.aclose').livequery('click', function () {
                $(this).parent().remove();
            });

        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="carnav">
        <h2 id="H1">
            免费发布信息</h2>
    </div>
    <div id="shcontent" class="shadd">
        <table>
            <tr>
                <td>
                    <label>
                        类目：</label>
                    <asp:DropDownList ID="DropDownList_Catalog" runat="server">
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
            <tr>
                <td>
                    <label>
                        文件上传:</label>
                    <div id="MyFile">
                        <div><input type="file" name="File" /><a class="aclose">x</a></div>
                    </div>
                </td>
            </tr>
        </table>
        <div style="clear: both;">
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
