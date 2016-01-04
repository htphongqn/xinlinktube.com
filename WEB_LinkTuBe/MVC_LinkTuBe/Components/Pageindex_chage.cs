using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vpro.functions;

namespace MVC_LinkTuBe.Components
{
    public class Pageindex_chage
    {
        public string result(int tongsotin, int sotin, string cat_seo_url, int _page, int type, int maxpageshow)
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
            if (_sotrang <= 1)
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
                if (type == 2)
                {
                    _re += "<a href='/tim-kiem.html?page=1&key=" + cat_seo_url + "'><|</a>";
                }
                else
                {
                    _re += _re += "<a href='/" + cat_seo_url + ".html?page=1'><|</a>";
                }
                //<li class="active"><a href="#">1</a></li>
                for (int i = s; i <= _sotrang; i++)
                {
                    if (_page == i)
                    {
                        _re += "<li class='active'><a href='#'>" + i + "</a></li>";
                    }
                    else
                    {
                        if (type == 2)
                        {
                            if (i == _sotrang && _page >= maxpageshow)
                            {
                                _re += "<li><a href='/tim-kiem.html?page=" + (_page + 1) + "&key=" + cat_seo_url + "'>" + i + "</a></li>";
                            }
                            else if (i == s && _page >= maxpageshow)
                            {
                                _re += "<li><a href='/tim-kiem.html?page=" + s + "&key=" + cat_seo_url + "'>" + s + "</a></li>";
                            }
                            else
                                _re += "<li><a href='/tim-kiem.html?page=" + i + "&key=" + cat_seo_url + "'>" + i + "</a></li>";
                        }
                        else if (type == 1)
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

                    }
                }
                if (type == 2)
                {
                    _re += "<li><a href='/tim-kiem.html?page=" + _sotrangtmp + "&key=" + cat_seo_url + "'>|></a></li>";
                }
                else
                {
                    _re += "<li><a href='/" + cat_seo_url + ".html?page=" + _sotrangtmp + "'>|></a></li>";
                }
            }
            return _re;
        }
    }
}