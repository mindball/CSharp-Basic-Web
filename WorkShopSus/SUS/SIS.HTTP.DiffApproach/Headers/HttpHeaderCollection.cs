using SIS.HTTP.DiffApproach.Common;
using SIS.HTTP.DiffApproach.Headers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
           
            if(!this.headers.TryGetValue(key, out getHeader))
            {
                CoreValidator.ThrowIfNull(key, nameof(key));                
            }

            return getHeader;
        }

        public override string ToString()
        {
            //StringBuilder str = new StringBuilder();
            //foreach (var header in this.headers)
            //{
            //    str.Append(header.Key);
            //    str.Append(GlobalConstants.HttpNewLine);
            //    //TODO: add last new line
            //}

            //return str.ToString().TrimEnd();

            /*
             * Separator note. Join() places the separator between every 
             * element of the collection in the returned string. The separator
             * is not added to the start or end of the result.
             * We can use string.Join to generate HTML. Often with HTML we need a 
             * separating tag or element. Join helps because it does not insert the 
             * separating tag at the end.
             */
            var result = string.Join("\r\n",
                   this.headers.Values.Select(header => header.ToString()));

            return result;
        }
    }
}
