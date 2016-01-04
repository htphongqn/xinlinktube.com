using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;

namespace MVC_LinkTuBe.UIs
{
    public partial class BoDem_TruyCap : System.Web.UI.UserControl
    {
        Config cf = new Config();
        Function fun = new Function();
        protected void Page_Load(object sender, EventArgs e)
        {
            Loadcounter();
            Loadonlineday();
        }
        #region Counter
        public void Loadcounter()
        {
            lbl_tngotruycap.Text = FormatView(cf.Tong_Truy_Cap());
            ltl_day.Text = FormatView(Utils.CStrDef(cf.counter(1)));
            ltl_week.Text = FormatView(Utils.CStrDef(cf.counter(7)));
            ltl_month.Text = FormatView(Utils.CStrDef(cf.counter(31)));

        }
        public void Loadonlineday()
        {
            try
            {

                lbl_online.Text = FormatView(Application["Online"].ToString());

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #region function
        public string FormatView(object _cat_count)
        {
            return fun.FormatView(_cat_count);
        }
        #endregion
    }
}