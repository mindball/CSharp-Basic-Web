﻿using System.Collections.Generic;

namespace SIS.HTTP.DiffApproach.Cookies
{
    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void AddCookie(HttpCookie cookie);

        bool ContainCookie(string key);

        HttpCookie Cookie(string key);

        bool HasCookies();
    }
}
