using SIS.HTTP.DiffApproach.Common;
using SIS.HTTP.DiffApproach.Headers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.DiffApproach.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key) => this.headers.ContainsKey(key);

        public HttpHeader GetHeader(string key)
        {
            HttpHeader getHeader;
           if(this.headers.TryGetValue(key, out getHeader))
            {
                return getHeader;
            }
           else
            {
                return CoreValidator.ThrowIfNull(key, nameof(key));
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var header in this.headers)
            {
                str.Append(header.Key);
                str.Append(GlobalConstants.HttpNewLine);
                //TODO: add last new line
            }

            return str.ToString();
        }
    }
}
