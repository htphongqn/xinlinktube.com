using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vpro.functions;
using Model;
using System.Web;

namespace Controller
{
    public class Function
    {
        #region Decclare
        dbVuonRauVietDataContext db = new dbVuonRauVietDataContext();
        #endregion
        public void add_like(string _sNewsSeoUrl)
        {
            try
            {
                var list = db.ESHOP_NEWs.Where(n => n.NEWS_SEO_URL == _sNewsSeoUrl).ToList();
                if (list.Count() > 0)
                {
                    list.FirstOrDefault().UNIT_ID1 += 1;
                    db.SubmitChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        public string Get_news_title(string _sNewsSeoUrl)
        {
            try
            {
                var list = db.ESHOP_NEWs.Where(n => n.NEWS_SEO_URL == _sNewsSeoUrl).ToList();
                if (list.Count() > 0)
                {
                    return list.FirstOrDefault().NEWS_TITLE;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
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
        public string GetIMG(object CAT_ID, object CAT_IMG)
        {
            try
            {
                if (CAT_IMG != null && CAT_IMG.ToString() != string.Empty)
                {
                    return "/data/categories/" + CAT_ID.ToString() + "/" + CAT_IMG.ToString();
                }
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Get_linkkenh(int _cat_id)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_ID == _cat_id).ToList();
                if (list.Count() > 0)
                {
                    return Utils.CStrDef(list[0].CAT_URL);
                }
                else
                {
                    list = db.ESHOP_CATEGORies.Where(n => n.CAT_POSITION == 2).ToList();
                    if (list.Count() > 0)
                        return Utils.CStrDef(list[0].CAT_URL);
                    else
                        return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public string Get_tenKenh(int _cat_id)
        {
            try
            {
                var list = db.ESHOP_CATEGORies.Where(n => n.CAT_ID == _cat_id).ToList();
                if (list.Count() > 0)
                {
                    return Utils.CStrDef(list[0].CAT_NAME);
                }
                else
                {
                    list = db.ESHOP_CATEGORies.Where(n => n.CAT_POSITION == 2).ToList();
                    if (list.Count() > 0)
                        return Utils.CStrDef(list[0].CAT_NAME);
                    else
                        return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public string DoiWatchSangEmbed(string _watch)
        {
            return _watch.Replace("watch?v=", "embed/");
        }
        public string GetLinkYoutube(object News_linkyoutube, object News_title)
        {
            return "<iframe width='210px' height='117.333px' src='" + DoiWatchSangEmbed(Utils.CStrDef(News_linkyoutube)) + "?showinfo=0&showsearch=0&hd=1&modestbranding=0&rel=0&iv_load_policy=3&cc_load_policy=1' frameborder='0' alt='" + Utils.CStrDef(News_title) + "' title='" + Utils.CStrDef(News_title) + "' allowfullscreen></iframe>";
        }
        public string GetLinkYoutube_detail(object News_linkyoutube, object News_title)
        {
            return "<iframe width='689px' height='388px' src='" + DoiWatchSangEmbed(Utils.CStrDef(News_linkyoutube)) + "?showinfo=0&showsearch=0&hd=1&modestbranding=0&rel=0&iv_load_policy=3&cc_load_policy=1' frameborder='0' alt='" + Utils.CStrDef(News_title) + "' title='" + Utils.CStrDef(News_title) + "' allowfullscreen></iframe>";
        }
        public string Getlink_Share(object Seo_url, object _URLWebsite)
        {
            return _URLWebsite +"/"+ Utils.CStrDef(Seo_url) + ".html";
        }
        public string Get_ShareTweet(string news_seo_url, string news_title, string _URLWebsite, string _EmailDisplayName)
        {
            return news_title + ": " + _URLWebsite + "/" + Utils.CStrDef(news_seo_url) + ".html" + " <3! --->Xem thêm tại: " + _URLWebsite + "/" + " &via=HUFI_MinhQuan";
        }
        public string Getlink_News(object News_url, object Seo_url)
        {
            return string.IsNullOrEmpty(Utils.CStrDef(News_url)) ? "/" + Utils.CStrDef(Seo_url) + ".html" : Utils.CStrDef(News_url);
        }
        public string Getlink_Cat(object Cat_Url, object Cat_Seo_Url)
        {
            return string.IsNullOrEmpty(Utils.CStrDef(Cat_Url)) ? "/" + Utils.CStrDef(Cat_Seo_Url) + ".html" : Utils.CStrDef(Cat_Url);
        }
        public string settam(string desc)
        {
            if (!String.IsNullOrEmpty(desc))
            {
                if (desc.Contains("\r\n"))
                    desc = desc.Replace("\r\n", "/");
            }
            return desc;
        }
        public string XuLyChuoiDesc(string desc)
        {
            try
            {
                string _temp = settam(desc);
                string[] _chuoicat = _temp.Split('/');
                string _return = string.Empty;
                for (int i = 0; i < _chuoicat.Count(); i++)
                {
                    if (_chuoicat[i].Trim() != string.Empty && _chuoicat[i].Trim() != null)
                    {
                        _return += ("<p>" + _chuoicat[i] + "</p>");
                    }
                }
                return _return;
            }
            catch
            {
                throw;
            }
        }
        public string setBr(string desc)
        {
            if (!String.IsNullOrEmpty(desc))
            {
                if (desc.Contains("\r\n"))
                    desc = desc.Replace("\r\n", "<br/>");
            }
            return desc;
        }
        public string getDate(object News_PublishDate)
        {
            return string.Format("{0:dd/MM/yyyy}", News_PublishDate);
        }
        public string GetImageT_News(object News_Id, object News_Image1)
        {

            try
            {
                if (Utils.CIntDef(News_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(News_Image1)))
                {
                    return PathFiles.GetPathNews(Utils.CIntDef(News_Id)) + Utils.CStrDef(News_Image1);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT_News_Cat(object News_Id, object News_Image1)
        {

            try
            {
                if (Utils.CIntDef(News_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(News_Image1)))
                {
                    return PathFiles.GetPathCategory(Utils.CIntDef(News_Id)) + Utils.CStrDef(News_Image1);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
         //<li> <a href="" title="Tòa nhà làm việc công ty Sông Thu – Tp Đà Nẵng" class="img_partner"><img src="http://www.cleverjobs.vn/cj/upload_files/images/thumbs/5/7/8/5787f9363e250a8f37bb0f0076e9bfe6.jpg" alt="Tòa nhà làm việc công ty Sông Thu – Tp Đà Nẵng" /> </a> </li>
        public string GetImageAd_new(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object AD_ITEM_DESC)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<li><a href='" + Utils.CStrDef(Ad_Url) + "' title='" + AD_ITEM_DESC + "'><img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='" + AD_ITEM_DESC + "' /></a></li>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        public string GetImageAd_NEWS(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object AD_ITEM_DESC)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<a href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "' alt='" + AD_ITEM_DESC + "'><img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='" + AD_ITEM_DESC + "' /></a>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT_Ad(object ad_Id, object ad_Image1)
        {

            try
            {
                if (Utils.CIntDef(ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(ad_Image1)))
                {
                    return PathFiles.GetPathAdItems(Utils.CIntDef(ad_Id)) + Utils.CStrDef(ad_Image1);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageAd_ads(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object AD_ITEM_DESC)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<a rel='nofollow' href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "' alt='" + AD_ITEM_DESC + "' title='" + AD_ITEM_DESC + "' ><img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='" + AD_ITEM_DESC + "' title='" + AD_ITEM_DESC + "' /></a>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        public string GetImageAd(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<a href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "'><img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "'  data-thumb='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='' /></a>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        //Get images logo - sologan
        //<a href="index.html" id="banner_head"> <img src="Images/banner_head.png" alt="CÔNG TY TNHH MTV CỬA NHỰA MIỀN TRUNG WINDOW" /></a>
        public string Getbanner(object Banner_type, object banner_field, object Banner_ID, object Banner_Image, int lang, object BANNER_DESC)
        {
            string banner = banner_field.ToString();
            return banner == "1" ? "<a href='" + "/" + "'>" + GetImage(Banner_type, Banner_ID, Banner_Image, BANNER_DESC) + "</a>" : "<a href='" + "/" + "'>" + GetImage(Banner_type, Banner_ID, Banner_Image, BANNER_DESC) + "</a>";
        }
        public string GetImage(object Banner_type, object Banner_ID, object Banner_Image, object BANNER_DESC)
        {
            try
            {
                string _sResult = string.Empty;
                if (Utils.CIntDef(Banner_type) == 0)
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                        return "<img src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' alt='" + BANNER_DESC + "' title='" + BANNER_DESC + "' />";
                    else
                        return "<img src='../vi-vn/Images/Logo.png' width='172' height='80' />"; ;
                }
                else
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                    {
                        _sResult += "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0'  height='117' id='ShockwaveFlash1' >";
                        _sResult += "<param name='movie' value='" + PathFiles.GetPathAdItems(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "'>";
                        _sResult += "<param name='Menu' value='0'>";
                        _sResult += "<param name='quality' value='high'>";
                        _sResult += "<param name='wmode' value='transparent'>";
                        _sResult += "<embed height='117' width='885' src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' wmode='transparent' ></object>";
                    }

                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        //Support
        #region Click - quảng cáo
        public string Click_quangcao(int aditem_id)
        {
            try
            {
                var list = db.ESHOP_AD_ITEMs.Where(n => n.AD_ITEM_ID == aditem_id).ToList();
                if (list.Count() > 0)
                {
                    list[0].AD_ITEM_CLICKCOUNT += 1;
                    db.SubmitChanges();
                    return list[0].AD_ITEM_URL;
                }
                return "/trang-chu.html";
            }
            catch
            {
                return "/trang-chu.html";
            }
        }
        #endregion
        #region Hàm đổi thời gian
        private bool check_phut(int _s)
        {
            try
            {
                if (_s > 59)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool check_gio(int _p)
        {
            try
            {
                if (_p > 59)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool check_ngay(int _h)
        {
            try
            {
                if (_h > 23)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool check_tuan(int _ngay)
        {
            try
            {
                if (_ngay > 6)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool check_thang(int _tuan)
        {
            try
            {
                if (_tuan > 4)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool check_nam(int _thang)
        {
            try
            {
                if (_thang > 12)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private string HAM_CHUYEN_DOI(int _s)
        {
            try
            {
                if (check_phut(_s) == true)
                {
                    int _p = _s / 60;
                    if (check_gio(_p) == true)
                    {
                        int _h = _p / 60;
                        {
                            if (check_ngay(_h) == true)
                            {
                                int _d = _h / 24;
                                if (check_tuan(_d) == true)
                                {
                                    int _w = _d / 7;
                                    if (check_thang(_w) == true)
                                    {
                                        int _m = _w / 4;
                                        if (check_nam(_m) == true)
                                        {
                                            int _y = _m / 12;
                                            return _y + " năm trước";
                                        }
                                        else
                                            return _m + " tháng trước";
                                    }
                                    else
                                    {
                                        return _w + " tuần trước";
                                    }
                                }
                                else
                                {
                                    return _d + " ngày trước";
                                }
                            }
                            else
                            {
                                return _h + " giờ trước";
                            }
                        }
                    }
                    else
                    {
                        return _p + " phút trước";
                    }
                }
                else
                {
                    return "Mới đây";
                }
            }
            catch
            {
                return "Mới đây";
            }
        }
        public string HAM_QUI_DOI(DateTime _outputTG)
        {
            try
            {
                int _s = Utils.CIntDef((DateTime.Now - _outputTG).TotalSeconds);
                return HAM_CHUYEN_DOI(_s);
            }
            catch
            {
                return "1 phút trước";
            }
        }
        #endregion
    }
}
