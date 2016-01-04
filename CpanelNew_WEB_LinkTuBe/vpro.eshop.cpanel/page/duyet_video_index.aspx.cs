using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using vpro.eshop.cpanel.Components;
using vpro.functions;
namespace vpro.eshop.cpanel.page
{
    public partial class duyet_video_index : System.Web.UI.Page
    {
        #region Declare

        int _count = 0;
        int _News_period = 0;
        int _page = 0;
        int _gtype, _gid;
        eshopdbDataContext DB = new eshopdbDataContext();

        #endregion

        #region properties

        public SortDirection sortProperty
        {
            get
            {
                if (ViewState["SortingState"] == null)
                {
                    ViewState["SortingState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["SortingState"];
            }
            set
            {
                ViewState["SortingState"] = value;
            }
        }

        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            _News_period = Utils.CIntDef(Request.QueryString["news_period"]);
            _gid = Utils.CIntDef(Session["GROUP_ID"]);
            _gtype = Utils.CIntDef(Session["GROUP_TYPE"]);
            _page = Utils.CIntDef(Request["page"]);   
            if (!IsPostBack)
            {          
                SearchResult();
            }

        }

        #endregion

        #region My Functions

        public string getOrder()
        {
            _count = _count + 1;
            return _count.ToString();
        }
        private void SearchResult()
        {
            try
            {
                int _limit = 40;
                int _skip = 0;
                string keyword = CpanelUtils.ClearUnicode(txtKeyword.Value);
                if (_page != 0)
                    _skip = _page * _limit - _limit;
                var AllList = (from g in DB.ESHOP_NEWs
                               where (g.NEWS_TYPE == 1 && ("" == keyword || (DB.fClearUnicode(g.NEWS_TITLE)).Contains(keyword)))
                               select new
                               {
                                   g.NEWS_ID,
                                   g.NEWS_TITLE,
                                   g.NEWS_PERIOD,
                                   g.NEWS_COUNT,
                                   g.NEWS_ORDER,
                                   g.NEWS_ORDER_PERIOD,
                                   g.NEWS_PUBLISHDATE,
                               }).ToList();
                if (_News_period == 1)
                {
                    AllList = AllList.OrderByDescending(n => n.NEWS_ID).ToList();
                }
                else
                {
                    AllList = AllList.OrderByDescending(n => n.NEWS_COUNT).ToList();
                }
                Rplist_news.DataSource = AllList.Skip(_skip).Take(_limit);
                Rplist_news.DataBind();
                LitPage.Text = changePageNews(AllList.Count, _limit, "duyet_video_index.aspx", _page, 10);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
        }
        public string changePageNews(int tongsotin, int sotin, string cat_seo_url, int _page, int maxpageshow)
        {
            string _re = string.Empty;
            int kiemtradu = tongsotin % sotin;
            int _sotrang;
            if (_page == 0)
            {
                _page = 1;
            }
            if (kiemtradu != 0)
            {
                _sotrang = (tongsotin / sotin) + 1;
            }
            else
            {
                _sotrang = (tongsotin / sotin);
            }
            int _sotrangtmp = _sotrang;
            if (_sotrang == 1)
            {
                _re = "";
            }
            else
            {
                int s = 1;
                if (_sotrang > maxpageshow)
                {
                    if (_page >= maxpageshow && _page < _sotrang)
                    {
                        _sotrang = _page + 1;
                        s = _page - maxpageshow + 2;
                    }
                    else if (_page == _sotrang)
                    {
                        _sotrang = _page;
                        s = _page - maxpageshow + 1;
                    }
                    else _sotrang = maxpageshow;
                }
                _re += _re += "<li><a href='/" + cat_seo_url + ".html?page=1'><|</a>";
                for (int i = s; i <= _sotrang; i++)
                {
                    if (_page == i)
                    {
                        _re += "<li><a><b>" + i + "</b></a></li></li>";
                    }
                    else
                    {
                        if (i == _sotrang && _page >= maxpageshow)
                        {
                            _re += "<li><a href='/" + cat_seo_url + ".html?page=" + (_page + 1) + "'>" + i + "</a></li>";
                        }
                        else if (i == s && _page >= maxpageshow)
                        {
                            _re += "<li><a href='/" + cat_seo_url + ".html?page=" + s + "'>" + s + "</a></li>";
                        }
                        else
                            _re += "<li><a href='/" + cat_seo_url + ".html?page=" + i + "'>" + i + "</a></li>";

                    }

                    _re += "<li><a href='/" + cat_seo_url + ".html?page=" + _sotrangtmp + "'>|></a></li>";
                }
            }
            return _re;
        }
        public string getDate(object News_PublishDate)
        {
            return string.Format("{0:dd/MM/yyyy}", News_PublishDate);
        }
        public string FormatView(object Expression)
        {
            try
            {
                string View = String.Format("{0:#,#}", Expression);
                return View.Replace(",", ".");
            }
            catch
            {
                return "1";
            }
        }
        public string get_trangthai(object news_per)
        {      
            if (Utils.CIntDef(news_per) == _News_period)
                return "Đã kích hoạt";
            return "Chưa kích hoạt";
        }
        #endregion
        #region Button Envents
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
        protected void lbtSave_Click(object sender, EventArgs e)
        {
            try
            {
                _News_period = Utils.CIntDef(Request.QueryString["news_period"]);
                int j = 0;
                int[] items = new int[Rplist_news.Items.Count];
                for (int i = 0; i < Rplist_news.Items.Count; i++)
                {
                    HtmlInputCheckBox check = (HtmlInputCheckBox)Rplist_news.Items[i].FindControl("chkSelect");
                    if (check.Checked)
                    {
                        HtmlInputText txtOrder = (HtmlInputText)Rplist_news.Items[i].FindControl("txtOrder");
                        HtmlInputText txtOrderPeriod = (HtmlInputText)Rplist_news.Items[i].FindControl("txtOrderPeriod");
                        HiddenField Hdid = Rplist_news.Items[i].FindControl("Hdnewsid") as HiddenField;
                        int _news_id = Utils.CIntDef(Hdid.Value);
                        var list = DB.ESHOP_NEWs.Where(n => n.NEWS_ID == _news_id).ToList();
                        if (list.Count > 0)
                        {
                            list[0].NEWS_PERIOD = _News_period;
                            list[0].NEWS_ORDER = Utils.CIntDef(txtOrder.Value);
                            list[0].NEWS_ORDER_PERIOD = Utils.CIntDef(txtOrderPeriod.Value);
                            DB.SubmitChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
            }
            finally
            { SearchResult(); }
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult();
        }
    }
}