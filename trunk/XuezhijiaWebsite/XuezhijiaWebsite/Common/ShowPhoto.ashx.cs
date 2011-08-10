using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace XuezhijiaWebsite.Common
{
    /// <summary>
    /// Summary description for ShowPhoto
    /// </summary>
    public class ShowPhoto : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            PhotoWrapper photoWrapper=new PhotoWrapper();
            int id = Convert.ToInt32(context.Request.QueryString["id"]);
            context.Response.BinaryWrite(photoWrapper.getDataByID(id));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}