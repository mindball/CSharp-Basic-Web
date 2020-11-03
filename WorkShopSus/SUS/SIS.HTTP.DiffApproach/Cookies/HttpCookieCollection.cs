using SIS.HTTP.DiffApproach.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.DiffApproach.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private Dictionary<string, HttpCookie> cookies ;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.cookies.Add(cookie.Key, cookie);
        }

        public bool ContainCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie Cookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.cookies[key];
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return this.cookies.Values.GetEnumerator();
        }

        public bool HasCookies()
        {
            return this.cookies.Count > 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {

            var sb = new StringBuilder();

            foreach (var cookie in this.cookies.Values)
            {
                sb.Append($"Set-cookie: {cookie}").Append(GlobalConstants.HttpNewLine);
            }

            return sb.ToString();
        }
    }
}
