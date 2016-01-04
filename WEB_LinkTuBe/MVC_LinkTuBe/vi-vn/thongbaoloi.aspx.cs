using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vpro.functions;

namespace MVC_LinkTuBe.vi_vn
{
    public partial class thongbaoloi : System.Web.UI.Page
    {
        #region Declare
        Config cf = new Config();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            var _configs = cf.Config_meta();

            if (_configs.ToList().Count > 0)
            {
                if (!string.IsNullOrEmpty(_configs.ToList()[0].CONFIG_FAVICON))
                    ltrFavicon.Text = "<link rel='shortcut icon' href='" + PathFiles.GetPathConfigs() + _configs.ToList()[0].CONFIG_FAVICON + "' />";
            }

            HtmlHead header = base.Header;
            HtmlMeta headerDes = new HtmlMeta();
            HtmlMeta headerKey = new HtmlMeta();
            headerDes.Name = "Description";
            headerKey.Name = "Keywords";

            header.Title = "Thông báo lỗi";
            lbl_thongbao.Text = "Bạn vui lòng nhấn vào đây để quay lại <a href='/'><b>" + Utils.CStrDef(System.Configuration.ConfigurationManager.AppSettings["EmailDisplayName"]) + "</b></a>";
        }
    }
}