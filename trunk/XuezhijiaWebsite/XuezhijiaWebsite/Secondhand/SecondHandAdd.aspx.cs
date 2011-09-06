using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using DAL;
using System.IO;

namespace XuezhijiaWebsite.Secondhand
{
    public partial class SecondHandAdd : System.Web.UI.Page
    {
        //该变量用来修改的的时候的默认值。例如上传自己的头像，如果用户修改头像，这里可以显示他原来的头像。
        //public string pic = "/Common/ShowPhoto.ashx?id=2";
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Uploadfile)Master).CurrentMenu = "market";
            if (!IsPostBack)
            {
                ((Uploadfile)Master).CurrentMenu = "market";
                
                //DropDownList_Catalog.DataSource = (new SecondHMWrapper()).getAllType();
                //DropDownList_Catalog.DataTextField = "Type";
                //DropDownList_Catalog.DataValueField = "Type";
                //DropDownList_Catalog.DataBind();
            }

            /// 在此处放置用户代码以初始化页面
           
        }



        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            SecondHMWrapper wrapper = new SecondHMWrapper();
            SECONDHANDMARKET secondhandmarket = new SECONDHANDMARKET();
            secondhandmarket.Type = DropDownList_Catalog.SelectedValue;
            secondhandmarket.ContactInformation = TextBox_Contact.Text;
            secondhandmarket.Price = TextBox_Price.Text;
            //secondhandmarket.Location = TextBox_Address.Text;
            //secondhandmarket.Brand = TextBox_Brand.Text;
            secondhandmarket.Comment = TextBox_Des.Text;
            secondhandmarket.LookCount = 0;
            secondhandmarket.Tipical = TextBox_Title.Text;
            secondhandmarket.PublishDate = DateTime.Now.ToString();
            secondhandmarket.HasImage = false;
            HttpFileCollection files = Request.Files;
            int count = files.Count;
            List<int> pidlist = new List<int>();
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].FileName.Length > 0)
                {
                    CommenHelper helper = CommenHelper.GetInstance();
                    PHOTO photo = new PHOTO();
                    PhotoWrapper photowrapper = new PhotoWrapper();
                    Stream input = files[i].InputStream;
                    int len = files[i].ContentLength;
                    byte[] buf = new byte[len];
                    input.Read(buf, 0, buf.Length);
                    photo.Data = buf;
                    photowrapper.addAClassRecord(photo);
                    int pid = helper.getIdent("Photo");
                    pidlist.Add(pid);
                    secondhandmarket.HasImage = true;
                }
            }
            secondhandmarket.PIDList = pidlist;
            wrapper.addAClassRecord(secondhandmarket);

            Response.Write("<script>alert('发布成功！');window.location='/Secondhand/Secondhand.aspx';</script>");
        }
    }
}