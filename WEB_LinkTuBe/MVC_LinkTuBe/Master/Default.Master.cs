using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC_LinkTuBe.Master
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            string strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            if (strUrl.Trim() == "http://www.xinlinktube/")
                Response.Redirect("http://xinlinktube/");
            form1.Action = Request.RawUrl;
        }
    }
}