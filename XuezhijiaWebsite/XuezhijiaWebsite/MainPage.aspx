<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>学之家 - 首页</title>
    <link href="css/home.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="css/globalStyles.css" />
<script src="js/user_log.js" language="javascript"></script>

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
				if(Session["Username"] != null){
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
				<li class="menu-item"><a href="">首页</a></li>
				<li class="menu-item"><a href="">免费打印</a></li>
				<li class="menu-item"><a href="">汽车租赁</a></li>
				<li class="menu-item"><a href="">宾馆预定</a></li>
				<li class="menu-item"><a href="">外卖信息</a></li>
				<li class="menu-item"><a href="">考研培训</a></li>
				<li class="menu-item"><a href="">学生商城</a></li>
				<li class="menu-item"><a href="">门票服务</a></li>
				<li class="menu-item"><a href="">家教服务</a></li>
				<li class="menu-item"><a href="">房屋租赁</a></li>
				<li class="menu-item"><a href="">二手市场</a></li>
			</ul>
		</div>
	</div>
	
	<div class="pagebody">
		<!-- 功能主体 -->
			功能主体
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

