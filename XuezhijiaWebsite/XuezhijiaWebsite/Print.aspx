<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="XuezhijiaWebsite.Print" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<link type="text/css" rel="stylesheet" href="css/globalStyles.css" />
<link type="text/css" rel="stylesheet" href="css/printStyles.css" />
<script src="js/user_log.js" language="javascript"></script>
<script src="js/print.js" language="javascript"></script>
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../Scripts/jtemplates.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="pageframe">

	<div class="pagebody">
		<!-- 功能主体 -->
		
		<!-- if has session -->
		<%
			if (Session["Username"] != null && Session["Username"] != "") {
		%>
			<div class="print-control">
				<a href="javascript:pop_print_loader()">我要打印</a>
				<!-- 打印数据 -->
				<asp:GridView ID="History" runat="server" AutoGenerateColumns="False" DataKeyNames="RecordID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate" >
					<Columns>
						<%--<asp:TemplateField ItemStyle-Width="60" ItemStyle-HorizontalAlign="Center">
            				<HeaderTemplate>
                				<input id="checkAll" type="checkbox" onclick="SelectAll();" />
								<asp:LinkButton ID="Hello" runat="server" Text="确认已打印" />
            				</HeaderTemplate>
							<ItemTemplate>
                				<asp:CheckBox ID="CheckRecord" runat="server" />
            				</ItemTemplate>
       					</asp:TemplateField>--%>
						<asp:TemplateField HeaderText="取消打印" ShowHeader="False">
							<ItemTemplate>   
               					<asp:LinkButton ID="DeleteRecord" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("FileName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>
							</ItemTemplate>   
						</asp:TemplateField>
                		<asp:BoundField DataField="FileName" HeaderText="文件名" SortExpression="FileName" />
                		<asp:BoundField DataField="DateTime" HeaderText="提交时间" SortExpression="DateTimee" />
                		<asp:BoundField DataField="State" HeaderText="打印状态" SortExpression="State" />
                		<asp:BoundField DataField="Comment" HeaderText="打印备注" SortExpression="Comment" />
            		</Columns>
				</asp:GridView>
				
			</div>
			<div id="print-loader" class="print-loader">
				<asp:FileUpload ID="LoadFile" runat="server" Text="请选择要打印的文件" />
				<br/>
				<asp:TextBox ID="PrintComment" TextMode="MultiLine" Rows="3" CssClass="print-comment" runat="server" />
                <br />
                如果首次打印请写上学号
          
				<br/>
                <br/>
				<asp:LinkButton ID="PrintFile" runat="server" Text="确定打印" OnClick="CommitPrint" />
				<a href="javascript:cancel_print()">取消打印</a>
			</div>
			<div class="print-list">
			</div>
		<!-- else -->
		<% 
			}else{
		%>
			<div>如需打印，请先登陆。</div>
		<!-- end -->
		<%
			}
		%>
			<div class="print-intro" id="prtinfo">
				

			</div>
		
		<!-- 功能主体 -->
	</div>
	
    <script type="text/javascript">

        $.ajax({
            type: "POST",
            url: "/WS/CommonService.asmx/getArticleByID",
            data: "{id:'2'}",
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
            $('#prtinfo').html('<img src="/Image/loader.gif"/>');
        }
        //加载成功
        function Successnav(data, status) {
            //在0s内将透明度设为0
            //$("#prtinfo").fadeTo(0.001, 0);
            $("#prtinfo").setTemplateURL('../Car/rightnav.htm', null, { filter_data: false });

            $("#prtinfo").processTemplate(data.d);
            //在1s内将透明度设为1
            //$("#prtinfo").fadeTo(1000, 1);

        }
    </script>

    </asp:Content>