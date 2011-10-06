<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Hotelcommodity.aspx.cs" Inherits="XuezhijiaWebsite.Hotel.Hotelcommodity" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../css/hotel.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
    <!-- required plugins -->
    <script src="../Scripts/date.js" type="text/javascript"></script>
<!--[if IE]><script type="text/javascript" src="scripts/jquery.bgiframe.js"></script><![endif]-->
<!-- jquery.datePicker.js -->
    <script src="../Scripts/jquery.datePicker.js" type="text/javascript"></script>
    <link href="../css/datePicker.css" rel="stylesheet" type="text/css" />
    <link href="../css/calender.css" rel="stylesheet" type="text/css" />
      <!-- page specific scripts -->

		<script type="text/javascript" charset="utf-8">
		    Date.format = 'yyyy-mm-dd';
		    $(function () {
		        $('.date-pick').datePicker({ autoFocusNextInput: true });
		        
		    });

		</script>
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
          var sumPrice = 0;
          var sumDays = 0;
          var checkCountValue =0;
          var checkTypeValue = 0;
          var typeText = "";
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
                  location.href = "/Hotel/InsertOrder.aspx?HotelId=" + request("id") + "&RoomType=" +
                $("#ContentPlaceHolder1_DropDownList_RoomTypes").find("option:selected").text() + "&RoomCount=" + $("#RoomCount").val() + "&StartDate=" +
                $("#startdate").attr("value") + "&EndDate=" + $("#enddate").attr("value") + "&SumPrice=" + sumPrice+ "&CusName=" +
                 $("#name").attr("value") + "&Gender=" + $("input[type=radio]:checked").attr("value") + "&Conact=" + $("#contact").attr("value")
                  + "&Remark=" + $("#remark").attr("value");
              }
              else {
                  //alert($("input[type=radio]:checked").attr("value"));
                  return false;
              }
          }


          function compareDate(first, second, sign) {
              fArray = first.split(sign);
              sArray = second.split(sign);
              var fDate = new Date(fArray[0], fArray[1], fArray[2]);
              var sDate = new Date(sArray[0], sArray[1], sArray[2]);

              var t = Math.abs(fDate.getTime() - sDate.getTime());
              var days = t / (1000 * 60 * 60 * 24);
              return days;
          }

          function calSumFee() {
              typeText = $("#ContentPlaceHolder1_DropDownList_RoomTypes").find("option:selected").text();
              checkCountValue = $("#RoomCount").val();
              checkTypeValue = $("#ContentPlaceHolder1_DropDownList_RoomTypes").val();
              sumDays = compareDate($("#startdate").attr("value"), $("#enddate").attr("value"), "-");
              sumPrice = checkCountValue * checkTypeValue * sumDays;
              $("#SumPriceCal").html("您的房间总价为：<br/>" + typeText + "*" + checkCountValue + "间*" + sumDays + "天；<br />共" + sumPrice + "元");
          }

    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            //初始化日期
            $("#startdate").val((new Date()).asString("yyyy-mm-dd"));
            $("#enddate").val((new Date()).addDays(1).asString("yyyy-mm-dd"));
            //计算初始化总价
            calSumFee();

           
            $("#RoomCount").change(function () {
                calSumFee();
            });

            $("#ContentPlaceHolder1_DropDownList_RoomTypes").change(function () {
                calSumFee();
            });
        })
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="hotelnav">宾馆预订</div>
<div id="hotelcontent" class="hotel">
</div>


<div class="hotel_right_nav" id="right_nav">


</div>


<div class="second_right_nav">

<div class="block">
<div class="title">我要预定：
</div>
<div class="b">
<%--<p style="text-align:right;margin-right:2px;"></p>--%>
房间类型：
    <asp:DropDownList ID="DropDownList_RoomTypes" runat="server">
        <asp:ListItem Value="100">单人间</asp:ListItem>
        <asp:ListItem Value="200">双人间</asp:ListItem>
    </asp:DropDownList>
    <br />
    房间数量：
    <select id="RoomCount" name="RoomCount">
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
        <option value="5">5</option>
        <option value="6">6</option>
        <option value="7">7</option>
        <option value="8">8</option>
        <option value="9">9</option>
        <option value="10">10</option>
    </select>
    间
    <br />
    <label for="startdate">入住日期：</label>
<input type="text" name="startdate" id="startdate"  class="must date-pick rightinfoinput" onchange="calSumFee()"/>
<div style="clear:both;"></div>
<label for="enddate">结束日期：</label>
<input type="text" name="enddate" id="enddate"  class="must date-pick rightinfoinput" onchange="calSumFee()"/>
<div style="clear:both;"></div>
    <div id="SumPriceCal"></div>
    
    性别：
<input type="radio"  name="gender" value = "male" checked="checked"/>男
<input type="radio"  name="gender" value = "female" />女<br />
<p style="text-align:right;margin:5px;"></p>
姓名：
<input type="text" name="name" id="name" class="must rightinfoinput"/>
<br />
<p style="text-align:right;margin:5px;"></p>

联系方式：
<input type="text" name="contact" id="contact"  class="must rightinfoinput"/>
<br />
<p style="text-align:right;margin:5px;"></p>


<br />
<p style="text-align:right;margin:5px;"></p>

备注：
<textarea id="remark" name="remark" rows="3" class="rightinfoinput"></textarea>
<p style="text-align:right;margin:5px;"></p>
<p style="text-align:right;margin:5px;"></p>
<a target="_blank" class="m2-btn" href="javascript:void(0);" onclick="MyFormSubmit();return false;"><span class="">现在预订</span></a>
</div>
</div>

<div class="blank10"></div>
<div class="blank10"></div>


</div>


<div style="clear:both;"></div>

<script type="text/javascript">

    $.ajax({
        type: "POST",
        url: "/WS/CommonService.asmx/getFormatedHotelById",
        data: "{id:" + request("id") + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: Loading, //执行ajax前执行loading函数.直到success 
        success: Success,
        error: Error
    });

    //加载中的状态
    function Loading() {
        $('#hotelcontent').html('<img src="/Image/loader.gif"/>');
    }
    //加载成功
    function Success(data, status) {
        //在0s内将透明度设为0
        //$("#hotelcontent").fadeTo(0.001, 0);
        $("#hotelcontent").setTemplateURL('../hotel/hotelcommoditytemplate.htm' ,null, { filter_data: false });
        $('#hotelcontent').processTemplate(data.d);
        //在1s内将透明度设为1
        //$("#hotelcontent").fadeTo(1000, 1);

    }
    </script>

     <script type="text/javascript">

         $.ajax({
             type: "POST",
             url: "/WS/CommonService.asmx/getArticleByID",
             data: "{id:'12'}",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             beforeSend: Loadingnav, //执行ajax前执行loading函数.直到success 
             success: Successnav,
             error: Error
         });

         function Error() {
             alert("error");
         }
         //加载中的状态
         function Loadingnav() {
             $('#right_nav').html('<img src="/Image/loader.gif"/>');
         }
         //加载成功
         function Successnav(data, status) {
             //在0s内将透明度设为0
             //$("#right_nav").fadeTo(0.001, 0);
             $("#right_nav").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

             $("#right_nav").processTemplate(data.d);
             //在1s内将透明度设为1
             //$("#right_nav").fadeTo(1000, 1);

         }
    </script>


</asp:Content>

