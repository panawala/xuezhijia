// JavaScript Document
// 点击“登陆”
//function logon() {
	//alert("function called.");
	//form.submit();
//}
//点击“注册”,弹出窗口
function pop_register() {
	document.getElementById("shade").style.display="block";
	document.getElementById("register-area").style.display="block";
}
//更新注册信息提示
function register_state() {
}
//检查校验信息
function register_check() {
}
//确认
//function confirm_register() {
	//form.submit();
//}
//取消
function cancel_register () {
	document.getElementById("shade").style.display="none";
	document.getElementById("register-area").style.display="none";
}