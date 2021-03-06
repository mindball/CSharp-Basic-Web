﻿namespace SIS.HTTP.DiffApproach.Responses
{
    using SIS.HTTP.DiffApproach.Common;
    using SIS.HTTP.DiffApproach.Cookies;
    using SIS.HTTP.DiffApproach.Enums;
    using SIS.HTTP.DiffApproach.Extensions;
    using SIS.HTTP.DiffApproach.Headers;
    using SIS.HTTP.DiffApproach.Headers.Contracts;
    using SIS.HTTP.DiffApproach.Responses.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.XPath;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();

            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
            : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }
        public IHttpCookieCollection Cookies { get; }

        public void AddCookie(HttpCookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public void AddHeader(HttpHeader header)
        {
            //CoreValidator.ThrowIfNull(header, nameof(header));
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] httpResponseBytesWithoutBody = Encoding.UTF8.GetBytes(this.ToString());

            byte[] httpResponseBytesWithBody = new byte[httpResponseBytesWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i] = httpResponseBytesWithoutBody[i];
            }

            for (int i = 0; i < httpResponseBytesWithBody.Length - httpResponseBytesWithoutBody.Length; i++)
            {
                httpResponseBytesWithBody[i + httpResponseBytesWithoutBody.Length] = this.Content[i];
            }

            return httpResponseBytesWithBody;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append($"{this.Headers}")
                .Append(GlobalConstants.HttpNewLine);

            if (this.Cookies.HasCookies())
            {
                result.Append($"{this.Cookies}").Append(GlobalConstants.HttpNewLine);
            }

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
