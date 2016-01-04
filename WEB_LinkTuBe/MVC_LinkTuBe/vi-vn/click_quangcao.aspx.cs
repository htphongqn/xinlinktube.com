using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;

namespace MVC_LinkTuBe.vi_vn
{
    public partial class click_quangcao : System.Web.UI.Page
    {
        int aditem_id = 0;
        Function fun = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                aditem_id = Utils.CIntDef(Request.QueryString["aditem_id"]);
                string strScript = "<script>";
                //strScript += "window.location='" + (!String.IsNullOrEmpty(url1) ? url1 : "/") + "';";
                strScript += "window.location='" + fun.Click_quangcao(aditem_id) + "'";
                strScript += "</script>";
                Page.RegisterClientScriptBlock("strScript", strScript);
            }
        }
    }
}