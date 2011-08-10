<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="XuezhijiaWebsite.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>学之家 - 免费打印</title>

<link type="text/css" rel="stylesheet" href="css/globalStyles.css" />
<link type="text/css" rel="stylesheet" href="css/printStyles.css" />
<script src="js/user_log.js" language="javascript"></script>
<script src="js/print.js" language="javascript"></script>

</head>

<body>

<div class="pageframe">
<form id="formall" runat="server">
	<div class="pagehead">
		<div class="headbox">
			<div class="logo">
				logo
			</div>
			<div class="logon-area">
			<!-- if has session -->
			<%
				if(Session["Username"] != null && Session["Username"] != ""){
			%>
			<%="用户【"+Session["Username"]+"】"
			%>
				<a href="javascript:logout()">注销</a>
			<!-- else -->
			<%
				}else{
			%>
				用户名：
				<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
				密码：
				<asp:TextBox ID="Password" runat="server"></asp:TextBox>
				<asp:LinkButton ID="Log" runat="server" Text="登陆" OnClick="CommitLoad" />
                
				<a href="javascript:pop_register()">注册</a>
			<!-- end -->
			<%
				}
			%>
			</div>
			<div id="register-area" class="register-area">
				<ul class="register-info">
					<li>
						<label>用户名：</label>
						<asp:TextBox ID="NewName" runat="server"></asp:TextBox>
						<span></span>
					</li>
					<li>
						<label>年级：</label>
						<asp:DropDownList ID="NewGrade" runat="server" >
							<asp:ListItem>大一</asp:ListItem>
							<asp:ListItem>大二</asp:ListItem>
							<asp:ListItem>大三</asp:ListItem>
							<asp:ListItem>大四</asp:ListItem>
							<asp:ListItem>研一</asp:ListItem>
							<asp:ListItem>研二</asp:ListItem>
							<asp:ListItem>研三</asp:ListItem>
							<asp:ListItem>博一</asp:ListItem>
							<asp:ListItem>博二</asp:ListItem>
							<asp:ListItem>博三</asp:ListItem>
						</asp:DropDownList>
					</li>
					<li>
						<label>邮箱：</label>
						<asp:TextBox ID="NewEmail" runat="server"></asp:TextBox>
						<span></span>
					</li>
					<li>
						<label>手机：</label>
						<asp:TextBox ID="NewTel" runat="server"></asp:TextBox>
						<span></span>
					</li>
					<li>
						<label>密码：</label>
						<asp:TextBox ID="NewPassword" TextMode="Password" runat="server"></asp:TextBox>
						<span></span>
					</li>
					<li>
						<label>密码确认：</label>
						<asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
						<span></span>
					</li>
					<li>
						<asp:LinkButton ID="ConfirmRegister" runat="server" Text="确认" OnClick="CommitRegister" />
						<a href="javascript:cancel_register()">取消</a>
					</li>
				</ul>
			</div>
		</div>
	</div>
	
	<div class="pageneck">
		<div id="menubar" name="menubar">
			<ul class="menu-list">
				<li class="menu-item"><a href="">首页</a></li>|
				<li class="menu-item"><a>免费打印</a></li>|
				<li class="menu-item"><a href="">汽车租赁</a></li>|
				<li class="menu-item"><a href="">宾馆预定</a></li>|
				<li class="menu-item"><a href="">外卖信息</a></li>|
				<li class="menu-item"><a href="">考研培训</a></li>|
				<li class="menu-item"><a href="">学生商城</a></li>|
				<li class="menu-item"><a href="">门票服务</a></li>|
				<li class="menu-item"><a href="">家教服务</a></li>|
				<li class="menu-item"><a href="">房屋租赁</a></li>|
				<li class="menu-item"><a href="">二手市场</a></li>
			</ul>
		</div>
	</div>
	
	<div class="pagebody">
		<!-- 功能主体 -->
		<div class="bodycontent">
		<!-- if has session -->
		<%
			if (Session["Username"] != null && Session["Username"] != "") {
		%>
			<div class="print-control">
				<a href="javascript:pop_print_loader()">我要打印</a>
				<!-- 打印数据 -->
				<asp:GridView ID="History" runat="server" AutoGenerateColumns="False" DataKeyNames="RecordID" OnRowDeleting="RowDeleting" OnRowCommand="RowUpdate" >
					<Columns>
						<asp:TemplateField ItemStyle-Width="60" ItemStyle-HorizontalAlign="Center">
            				<HeaderTemplate>
                				<input id="checkAll" type="checkbox" onclick="SelectAll();" />
								<asp:LinkButton ID="Hello" runat="server" Text="确认已打印" />
            				</HeaderTemplate>
							<ItemTemplate>
                				<asp:CheckBox ID="CheckRecord" runat="server" />
            				</ItemTemplate>
       					</asp:TemplateField>
						<asp:TemplateField HeaderText="取消打印" ShowHeader="False">
							<ItemTemplate>   
               					<asp:LinkButton ID="DeleteRecord" CausesValidation="False" CommandName="Delete"Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("FileName").ToString() + "吗?\")) return false;"%>'></asp:LinkButton>
							</ItemTemplate>   
						</asp:TemplateField>
                		<asp:BoundField DataField="FileName" HeaderText="文件名" SortExpression="FileName" />
                		<asp:BoundField DataField="DateTimee" HeaderText="提交时间" SortExpression="DateTimee" />
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
		</div>
		<!-- 功能主体 -->
	</div>
	
	<div class="pagefeet">
		页脚
	</div>
</form>	

</div>

<div id="shade" name="shade" class="shade" style="height: 100%" ></div>

</body>
</html>