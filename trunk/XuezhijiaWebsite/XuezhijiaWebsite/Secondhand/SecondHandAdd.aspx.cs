using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XuezhijiaWebsite.Secondhand
{
    public partial class SecondHandAdd : System.Web.UI.Page
    {
        //该变量用来修改的的时候的默认值。例如上传自己的头像，如果用户修改头像，这里可以显示他原来的头像。
        public string pic = "/Common/ShowPhoto.ashx?id=2";
        protected void Page_Load(object sender, EventArgs e)
        {
            /// 在此处放置用户代码以初始化页面
            if (this.IsPostBack) this.SaveImages();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            pic = "/Common/ShowPhoto.ashx?id=3";
            Random r = new Random();
            //这样循环，可以同时上传多个文件。前台已经有文件格式的判断，有错误提示了。这里只要过滤掉非法文件即可，无需提示了。
            for (int i = 0; i < Request.Files.Count; i++)
            {
                if (Request.Files[i].ContentLength > 0)
                {
                    string ex = System.IO.Path.GetExtension(Request.Files[i].FileName).ToLower();
                    if (".jpg.gif.png.bmp".Contains(ex))
                    {
                        string newFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + r.Next(100, 999).ToString() + ex;
                        //保存文件名到数据库
                        //xxxxxxxxxxxxxxxx
                        //xxxxxxxxxxxxxxxx

                        Request.Files[i].SaveAs(Server.MapPath(newFileName));
                        pic = newFileName;
                    }
                }
            }
        }






        private Boolean SaveImages()
        {
            ///’遍历File表单元素
            HttpFileCollection files = HttpContext.Current.Request.Files;

            /// ’状态信息
            System.Text.StringBuilder strMsg = new System.Text.StringBuilder();
            strMsg.Append("上传的文件分别是：<hr color=red>");
            try
            {
                for (int iFile = 0; iFile < files.Count; iFile++)
                {
                    ///’检查文件扩展名字
                    HttpPostedFile postedFile = files[iFile];
                    string fileName, fileExtension;
                    fileName = System.IO.Path.GetFileName(postedFile.FileName);
                    if (fileName != "")
                    {
                        fileExtension = System.IO.Path.GetExtension(fileName);
                        strMsg.Append("上传的文件类型：" + postedFile.ContentType.ToString() + "<br>");
                        strMsg.Append("客户端文件地址：" + postedFile.FileName + "<br>");
                        strMsg.Append("上传文件的文件名：" + fileName + "<br>");
                        strMsg.Append("上传文件的扩展名：" + fileExtension + "<br><hr>");
                        ///’可根据扩展名字的不同保存到不同的文件夹
                        ///注意：可能要修改你的文件夹的匿名写入权限。
                        postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("images/") + fileName);
                    }
                }
 
                return true;
            }
            catch (System.Exception Ex)
            {
                return false;
            }
        }


    }
}