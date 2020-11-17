﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestAsString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            this.FormData = new Dictionary<string, string>();

            //Parse requestAsString
            var lines = requestAsString.Split(new string[] { HttpConstants.NewLine },
                StringSplitOptions.None);

            var headerLine = lines[0];
            var headerLineParts = headerLine.Split(' ');
            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);
            this.Path = headerLineParts[1];

            int lineIndex = 1;
            bool isInHeaders = true;
            StringBuilder bodyBuilder = new StringBuilder();

            while (lineIndex < lines.Length)
            {
                var line = lines[lineIndex];
                lineIndex++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;
                    continue;
                }

                if (isInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }

            if (this.Headers.Any(x => x.Name == HttpConstants.RequestCookieHeader))
            {
                var cookiesAsString = this.Headers.FirstOrDefault(x =>
                        x.Name == HttpConstants.RequestCookieHeader).Value;

                var cookies = cookiesAsString.Split(new string[] { "; " },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookieAsString in cookies)
                {
                    this.Cookies.Add(new Cookie(cookieAsString));
                }
            }

            this.Body = bodyBuilder.ToString().TrimEnd('\n', '\r'); 
            SplitParameters(this.Body, this.FormData);
            //var bodyParameters = this.Body.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            //foreach (var bodyParameter in bodyParameters)
            //{
            //    var keyValueData = bodyParameter.Split('=');

            //    var keyFormData = keyValueData[0];
            //    var valuFormData = WebUtility.UrlDecode(keyValueData[1]);

            //    if (!this.FormData.ContainsKey(keyFormData))
            //    {
            //        this.FormData.Add(keyFormData, valuFormData);
            //    }

            //}
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public Dictionary<string, string> FormData { get; set; }

        public string Body 
        { 
            get; 
            set; 
        }

        private static void SplitParameters(string parametersAsString, IDictionary<string, string> output)
        {

            var parameters = parametersAsString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var parameter in parameters)
            {
                var parameterParts = parameter.Split(new[] { '=' }, 2);
                var name = parameterParts[0];
                var value = WebUtility.UrlDecode(parameterParts[1]);
                if (!output.ContainsKey(name))
                {
                    output.Add(name, value);
                }
            }
        }
    }
}