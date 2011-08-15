<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="XuezhijiaWebsite.Print" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<link type="text/css" rel="stylesheet" href="css/globalStyles.css" />
<link type="text/css" rel="stylesheet" href="css/printStyles.css" />
<script src="js/user_log.js" language="javascript"></script>
<script src="js/print.js" language="javascript"></script>
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
			<div class="print-intro">
				print introduction
			</div>
		
		<!-- 功能主体 -->
	</div>
	

    </asp:Content>