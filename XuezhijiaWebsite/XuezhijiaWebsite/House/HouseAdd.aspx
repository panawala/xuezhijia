<%@ Page Title="" Language="C#" MasterPageFile="~/Uploadfile.Master" AutoEventWireup="true" CodeBehind="HouseAdd.aspx.cs" Inherits="XuezhijiaWebsite.House.HouseAdd" %>
<%@ MasterType VirtualPath="~/Uploadfile.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/houseadd.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.livequery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        var formcheck = false;
        var checkcount1 = true;
        function CheckForm1() {
            $("table input:not(:file)").each(function () {
                if ($(this).val() == undefined || $(this).val() == "") {
                    $(this).removeClass("infoinput");
                    $(this).addClass("errinfoput");
                    checkcount1 = false;
                    return false;
                }
                else {
                    $(this).removeClass("errinfoput");
                    $(this).addClass("infoinput");
                    checkcount1 = true;
                    return true;
                }

            });
            return checkcount1;
        }



//        function CheckImgCss(o, img) {
//            if (!/\.((jpg)|(bmp)|(gif)|(png))$/ig.test(o.value)) {
//                alert('只能上传jpg,bmp,gif,png格式图片!');
//                o.outerHTML = o.outerHTML;
//            }
//            else {
//                $(img).filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = o.value;
//                //$('Image1').src = o.value;//这里IE7已经不支持了。所以才有上面的方法。
//            }
//        }



        function addFile() {
            var str = $('<div class="fileframe"><input type="file" class="filediv" name="File" /><a class="aclose" href="javascript:void(0);" /></div>');
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


            $("table input:not(:file)").blur(function () {
                if ($(this).val() == undefined || $(this).val() == "") {
                    $(this).removeClass("infoinput");
                    $(this).addClass("errinfoput");
                    formcheck = false;
                }
                else {
                    $(this).removeClass("errinfoput");
                    $(this).addClass("infoinput");
                    formcheck = true;
                }
            });

            $("table input:not(:file)").change(function () {
                if ($(this).val() == undefined || $(this).val() == "") {
                    $(this).removeClass("infoinput");
                    $(this).addClass("errinfoput");
                    formcheck = false;
                }
                else {
                    $(this).removeClass("errinfoput");
                    $(this).addClass("infoinput");
                    formcheck = true;
                }
            });

            addFile();

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
                    <asp:DropDownList ID="DropDownList_Catalog" runat="server" CssClass="infoinput" Width="202px">
                    </asp:DropDownList>
                </td>
                <td>
                    <label>
                        联系方式：</label>
                    <asp:TextBox ID="TextBox_Contact" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        价格：</label>
                    <asp:TextBox ID="TextBox_Price" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
                <td>
                    <label>
                        具体地点：</label>
                    <asp:TextBox ID="TextBox_Address" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        品牌：</label>
                    <asp:TextBox ID="TextBox_Brand" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
                <td>
                    <label>
                        醒目标题：</label>
                    <asp:TextBox ID="TextBox_Title" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>
                        描述：</label>
                    <asp:TextBox ID="TextBox_Des" runat="server" TextMode="MultiLine" Height="100px"
                        Width="100%" CssClass="des"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>
                        文件上传:</label>
                    <div id="MyFile">
                        
                    </div>
                </td>
            </tr>
        </table>
        <div style="clear: both;">
        </div>
        <input type="button" value="增加文件" onclick="javascript:addFile();" />
        <input onclick="this.form.reset()" type="button" value="重置(ReSet)" />
        <asp:Button runat="server" Text="开始上传" ID="Btn_Submit" OnClientClick="javascript:return CheckForm1();"
            OnClick="Btn_Submit_Click"></asp:Button>
    </div>
    <div id="right_nav" class="right_nav">
    </div>
    <div style="clear: both;">
    </div>
</asp:Content>
