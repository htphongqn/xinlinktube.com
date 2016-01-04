using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using Controller;

namespace MVC_LinkTuBe.UIs
{
    public partial class support : System.Web.UI.UserControl
    {

        #region Declare
        Propertity per = new Propertity();
        Function fun = new Function();
        Config cf = new Config();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadhotline_email();
            }
        }
        #region support
        //<div class="wmn it-ht">
        //      <p class="orange"><b>Hỗ trợ và tư vấn khách hàng</b></p>
        //      <p> <span class="namehttt">Mr Long: </span> <span class="number"> 0905.355.012 </span> </p>
        //      <p> <i class="fa icohttt"><a><img src="images/yh.png" /></a></i> <span  class="emailhttt">Yahoo: long_lklaptopgiatot</span> </p>
        //    </div>
        //    <div class="wmn it-ht">
        //      <p class="orange"><b>Kinh doanh 1</b></p>
        //      <p> <span class="namehttt">Mr Long: </span> <span class="number"> 0905.355.012 </span> </p>
        //      <p> <i class="fa icohttt"><a><img src="images/yh.png" /></a></i> <span  class="emailhttt">Yahoo: long_lklaptopgiatot</span> </p>
        //    </div>
        //    <div class="wmn it-ht">
        //      <p class="orange"><b>Kinh doanh 2</b></p>
        //      <p> <span class="namehttt">Mr Long: </span> <span class="number"> 0905.355.012 </span> </p>
        //      <p> <i class="fa icohttt"><a><img src="images/yh.png" /></a></i> <span  class="emailhttt">Yahoo: long_lklaptopgiatot</span> </p>
        //    </div>
        //<p class="hotline-httt">Hotline 1: <b>0979 677 111</b></p>
        public void Loadhotline_email()
        {
            var list = per.LoadHTTT(2).Take(10).ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ltl_hotline.Text += "<p class='hotline-httt'>" + Utils.CStrDef(list[i].ONLINE_DESC) + ": <b>" + Utils.CStrDef(list[i].ONLINE_NICKNAME) + "</b></p>";
                }
            }
            list = per.LoadHTTT(11).Take(10).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                if (i == 0)
                {
                    ltl_email.Text += "<i>" + Utils.CStrDef(list[i].ONLINE_NICKNAME) + "</i>";
                }
                else
                {
                    ltl_email.Text += " - <i>" + Utils.CStrDef(list[i].ONLINE_NICKNAME) + "</i>";
                }
            }
        }
        #endregion
    }
}
