﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vpro.eshop.cpanel.Components
{
    public class PageIndexChange
    {
        public string changePage(string url, int tongsotin, int sotin, int _page)
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
            if (_sotrang <= 1)
            {
                _re = "";
            }
            else
            {
                int s = 1;
                if (_sotrang > 7)
                {
                    if (_page >= 7 && _page < _sotrang)
                    {
                        _sotrang = _page + 1;
                        s = _page - 7 + 2;
                    }
                    else if (_page == _sotrang)
                    {
                        _sotrang = _page;
                        s = _page - 7 + 1;
                    }
                    else _sotrang = 7;
                }
                for (int i = s; i <= _sotrang; i++)
                {
                    if (_page == i)
                    {
                        _re += "<li><a><b>" + i + "</b></a></li>";
                    }
                    else
                    {
                        if (i == _sotrang && _page >= 7)
                        {
                            _re += "<li><a href='" + url + "?page=" + (_page + 1) + "'> >> </a></li>";
                        }
                        else if (i == s && _page >= 7)
                        {
                            _re += "<li><a href='" + url + "?page=" + (_page - 1) + "'> << </a></li>";
                        }
                        else
                            _re += "<li><a href='" + url + "?page=" + i + "'>" + i + "</a></li>";

                    }
                }
            }
            return _re;
        }
        public string changePageNews(int tongsotin, int sotin, string cat_seo_url, int _page, int _type, int maxpageshow)
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
                _re += "<li><a href='/" + cat_seo_url + "?page=1" + "&type=" + _type + "'><|</a></li>";
                for (int i = s; i <= _sotrang; i++)
                {
                    if (_page == i)
                    {
                        _re += "<li><a><b>" + i + "</b></a></li>";
                    }
                    else
                    {
                        if (i == _sotrang && _page >= maxpageshow)
                        {
                            _re += "<li><a href='/" + cat_seo_url + "?page=" + (_page + 1) + "&type=" + _type + "'>" + i + "</a></li>";
                        }
                        else if (i == s && _page >= maxpageshow)
                        {
                            _re += "<li><a href='/" + cat_seo_url + "?page=" + s + "&type=" + _type + "'>" + s + "</a></li>";
                        }
                        else
                            _re += "<li><a href='/" + cat_seo_url + "?page=" + i + "&type=" + _type + "'>" + i + "</a></li>";

                    }

                    _re += "<li><a href='/" + cat_seo_url + "?page=" + _sotrangtmp + "&type=" + _type + "'>|></a></li>";
                }
            }
            return _re;
        }
    }
}