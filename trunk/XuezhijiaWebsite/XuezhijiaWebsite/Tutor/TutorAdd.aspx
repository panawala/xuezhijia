<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TutorAdd.aspx.cs" Inherits="XuezhijiaWebsite.Tutor.TutorAdd" %>
 <%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/tutoradd.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.livequery.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

        var formcheck = false;
        var checkcount = true;
        function CheckForm() {
            $("table input:not(:file)").each(function () {
                if ($(this).val() == undefined || $(this).val() == "") {
                    $(this).removeClass("infoinput");
                    $(this).addClass("errinfoput");
                    checkcount = false;
                    return false;
                }
                else {
                    $(this).removeClass("errinfoput");
                    $(this).addClass("infoinput");
                    checkcount = true;
                    return true;
                }

            });
            return checkcount;
        }



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


        })
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tutornav">
        <h2 id="H1">
            提交家教信息</h2>
    </div>
    <div id="shcontent" class="shadd">
        <table>
            <tr>
            <td>
                    <label>
                        姓名：</label>
                    <asp:TextBox ID="TextBox_Name" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
                <td>
                    <label>
                        擅长科目：</label>
                    <asp:TextBox ID="TextBox_Subject" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    <label>
                        年级：</label>
                    <asp:TextBox ID="TextBox_Grade" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
                <td>
                    <label>
                        联系方式：</label>
                    <asp:TextBox ID="TextBox_Contact" runat="server" CssClass="infoinput"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="clear: both;">
        </div>
        <input onclick="this.form.reset()" type="button" value="重置" />
        <asp:Button runat="server" Text="提交" ID="Btn_Submit" OnClientClick="javascript:return CheckForm();"
            OnClick="Btn_Submit_Click"></asp:Button>
    </div>
    <div id="right_nav" class="right_nav">
    </div>
    <div style="clear: both;">
    </div>
</asp:Content>
