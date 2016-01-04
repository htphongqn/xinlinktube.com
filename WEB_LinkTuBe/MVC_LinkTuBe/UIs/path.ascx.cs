using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
namespace MVC_LinkTuBe.UIs
{
    public partial class path : System.Web.UI.UserControl
    {
        #region Decclare
        Propertity per = new Propertity();
        Function fun = new Function();
        Config cf = new Config();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["purl"];
            liPath.Text = per.Getpath();
            if (liPath.Text == string.Empty)
            {
                
                if (url == "tim-kiem")
                {
                    liPath.Text = "<li><a href='/" + url + ".html'>Tìm kiếm</a></li>";
                    return;
                }
                if (url == "lien-he")
                {
                    liPath.Text = "<li><a href='/" + url + ".html'>Liên hệ</a></li>";
                    return;
                }  
                if (url == "thong-bao-loi")
                {
                    liPath.Text = "<li><a href='/" + url + ".html'>Thông báo lỗi</a></li>";
                    return;
                }
                liPath.Text = "<li><a href='/" + "tim-kiem" + ".html'>Tìm kiếm</a></li>";
                return;
            }
            if (!IsPostBack)
                Show_File_HTML();
        }
        private void Show_File_HTML()
        {
            ltl_sologan.Text = cf.Show_File_HTML("sologan-vi.htm", "/Data/footer/");
        }
    }
}