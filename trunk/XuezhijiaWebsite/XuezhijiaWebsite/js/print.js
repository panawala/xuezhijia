// JavaScript Document
//点击“打印”，弹出任务窗口
function pop_print_loader() {
	document.getElementById("shade").style.display="block";
	document.getElementById("print-loader").style.display="block";
}

//取消打印
function cancel_print () {
	document.getElementById("shade").style.display="none";
	document.getElementById("print-loader").style.display="none";
}