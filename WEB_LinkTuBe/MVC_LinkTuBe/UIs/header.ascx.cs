using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using Controller;
using System.Data;

namespace MVC_LinkTuBe.UIs
{
    public partial class header : System.Web.UI.UserControl
    {
        #region Decclare
        Propertity per = new Propertity();
        Function fun = new Function();
        Config cf = new Config();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_logo();
                Show_File_HTML();
            }
        }
        #region ShowHTML
        private void Show_File_HTML()
        {
            ltl_script.Text = cf.Show_File_HTML("footer-vi.htm", "/Data/footer/");
        }
        #endregion
        #region Load_logo
        protected void load_logo()
        {
            var _logoBanner = per.LoadLogoBanner("1", 1);
            if (_logoBanner.ToList().Count > 0)
            {
                Re_logo.DataSource = _logoBanner;
                Re_logo.DataBind();
            }
        }
        #endregion
        #region funtion
        public string Getbanner(object Banner_type, object banner_field, object Banner_ID, object Banner_Image, object BANNER_DESC)
        {
            return fun.Getbanner(Banner_type, banner_field, Banner_ID, Banner_Image,1, BANNER_DESC);
        }
        #endregion
    }
}