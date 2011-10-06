<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProxyItem.aspx.cs" Inherits="XuezhijiaWebsite.Proxy.ProxyItem" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../css/proxyitem.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>

    <script type="text/javascript">
        /*--获取网页传递的参数--*/
        function request(paras) {
            var url = location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            var paraObj = {}
            for (i = 0; j = paraString[i]; i++) {
                paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
            }
            var returnValue = paraObj[paras.toLowerCase()];
            if (typeof (returnValue) == "undefined") {
                return "";
            } else {
                return returnValue;
            }
        }
    </script>
    <script type="text/javascript">
        var check = false;
        function CheckMyForm() {
                $(".must").each(function () {
                    if ($(this).val() == undefined || $(this).val() == "") {
                        $(this).removeClass("rightinfoinput");
                        $(this).addClass("righterrinfoput");
                        check = false;
                        return false;
                    }
                    else {
                        $(this).removeClass("righterrinfoput");
                        $(this).addClass("rightinfoinput");
                        check = true;
                        return true;
                    }
                });
                return check;
        }

        function MyFormSubmit() {
            if (CheckMyForm()) {
                location.href = "/Proxy/InsertMember.aspx?Name=" + $("#name").attr("value") + "&IsNative=" +
                $("input[type=radio]:checked").attr("value") + "&Address=" + $("#address").attr("value") + "&ContactInformation=" +
                $("#contact").attr("value") + "&Comment=" + $("#remark").attr("value") + "&TypeId=" + request("id");
            }
            else {
                //alert($("input[type=radio]:checked").attr("value"));
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="proxyitemnav">校园代理</div>
<div id="proxyitemcontent" class="proxyitem">
</div>


<div class="second_right_nav">

<div class="block">
<div class="title">我要报名：
</div>
<div class="b">
<%--<p style="text-align:right;margin-right:2px;"></p>--%>
姓名：
<input type="text" name="name" id="name" class="must rightinfoinput"/>
<br />
<p style="text-align:right;margin:5px;"></p>
联系方式：
<input type="text" name="contact" id="contact"  class="must rightinfoinput"/>
<br />
<p style="text-align:right;margin:5px;"></p>
上海户口：
<input type="radio"  name="hukou" value = "yes" checked="checked"/>是
<input type="radio"  name="hukou" value = "no" />否<br />
<p style="text-align:right;margin:5px;"></p>
居住地址：
<textarea id="address" name="address" rows="3" class="must rightinfoinput"></textarea>
<p style="text-align:right;margin:5px;"></p>
备注：
<textarea id="remark" name="remark" rows="3" class="must rightinfoinput"></textarea>
<p style="text-align:right;margin:5px;"></p>
<a target="_blank" class="m2-btn" href="javascript:void(0);" onclick="MyFormSubmit();return false;"><span class="">现在报名</span></a>
</div>
</div>

<div class="blank10"></div>
<div class="blank10"></div>


</div>
<div style="clear:both;"></div>

<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getProxyByID",
        data: "{id:" + request("id") + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#proxyitemcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        //$("#proxyitemcontent").fadeTo(0.001, 0);
        $("#proxyitemcontent").setTemplateURL('../Proxy/proxyitemtemplate.htm', null, { filter_data: false });
        $('#proxyitemcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        //$("#proxyitemcontent").fadeTo(1000, 1);

    }
    </script>

</asp:Content>
