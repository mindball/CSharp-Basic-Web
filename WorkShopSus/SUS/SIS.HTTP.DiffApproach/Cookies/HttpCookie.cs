using SIS.HTTP.DiffApproach.Common;
using System;
using System.Text;

namespace SIS.HTTP.DiffApproach.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationDays = 3;
        private const string HttpCookieDefaultPath = "/";
        private bool v;
        private int expires;

        public HttpCookie(string key, string value,
            int expires = HttpCookieDefaultExpirationDays, string path = HttpCookieDefaultPath)
            
        {
            CoreValidator.ThrowIfNull(key, nameof(key));
            CoreValidator.ThrowIfNull(value, nameof(value));

            this.Key = key;
            this.Value = value;

            this.IsNew = true;
            this.Expires = DateTime.UtcNow.AddDays(expires);
            this.Path = path;
        }

        public HttpCookie(string key, string value, bool isNew, int expires, string path)
            : this(key, value, expires, path)
        {            
            this.IsNew = isNew;           
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime  Expires { get; private set; }

        public string Path { get; set; }

        public bool IsNew { get;  set; }

        public bool HttpOnly { get; set; } = true;

        public void Delete()
        {
            this.Expires = DateTime.UtcNow.AddDays(-1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Key}={this.Value}; Expires={this.Expires.ToString("R")}");

            if(this.HttpOnly)
            {
                sb.Append($"; HttpOnly");
            }

            sb.Append($"; Path={this.Path}");

            return sb.ToString();
        }
    }
}
