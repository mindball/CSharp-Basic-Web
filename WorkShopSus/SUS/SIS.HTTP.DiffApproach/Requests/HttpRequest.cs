using SIS.HTTP.DiffApproach.Common;
using SIS.HTTP.DiffApproach.Cookies;
using SIS.HTTP.DiffApproach.Enums;
using SIS.HTTP.DiffApproach.Exceptions;
using SIS.HTTP.DiffApproach.Headers;
using SIS.HTTP.DiffApproach.Headers.Contracts;
using SIS.HTTP.DiffApproach.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.DiffApproach.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();

            this.Headers = new HttpHeaderCollection();

            this.Cookies = new HttpCookieCollection();

            this.ParseRequest(requestString);
        }


        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; private set; }
        public Dictionary<string, object> QueryData { get; private set; }
        public IHttpHeaderCollection Headers { get; private set; }
        public HttpRequestMethod RequestMethod { get; private set; }
        public IHttpCookieCollection Cookies { get; }

        //Request line
        private bool IsValidateRequestLine(string[] requestLineParams)
        {
            if (requestLineParams.Length != 3 ||
                 GlobalConstants.HttpOneProtocolFragment != requestLineParams[2])
            {
                return false;
            }

            return true;
        }

        private void ParseRequestMethod(string[] requestLineParams)
        {
            HttpRequestMethod requestMethod;
            bool isParsed =
                Enum.TryParse<HttpRequestMethod>(requestLineParams[0], true, out requestMethod);

            if (!isParsed)
            {
                throw new BadRequestException(
                    string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage,
                        requestLineParams[0]));
            }

            this.RequestMethod = requestMethod;
        }

        private void ParseRequestUrl(string[] requestLineParams)
        {
            this.Url = requestLineParams[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url
                .Split('?')[0];
        }

        //Headers
        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders.Select(plainHeader => plainHeader.Split(new[] { ':', ' ' }
                , StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKeyValuePair =>
                    this.Headers.AddHeader(new HttpHeader(headerKeyValuePair[0], headerKeyValuePair[1])));
        }

        private void ParseRequestQueryParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split('?', '#')[1]
                .Split('&')
                //name="pesho"&id="2"
                .Select(plainQueryParameter => plainQueryParameter.Split('='))
                .ToList()
                .ForEach(queryParameterKeyValuePair =>
                    this.QueryData.Add(queryParameterKeyValuePair[0], queryParameterKeyValuePair[1]));
            }

        }

        private bool HasQueryString() => this.Url.Split('?').Length > 1;

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseRequestParameters(string requestBody)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(requestBody); //TODO: Split
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.HttpHeaderCookie))
            {
                string value = this.Headers.GetHeader(HttpHeader.HttpHeaderCookie).Value;
                string[] unparsedCookies = value.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var unParseCookie in unparsedCookies)
                {
                    string[] cookieKeyValuePair = unParseCookie.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                    HttpCookie httpCookie = new HttpCookie(cookieKeyValuePair[0], cookieKeyValuePair[1], false);

                    this.Cookies.AddCookie(httpCookie);
                }
            }
        }

        //Body
        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (!string.IsNullOrEmpty(requestBody))
            {
                requestBody
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList()
                    .ForEach(queryParameterKeyValuePair =>
                        this.FormData.Add(queryParameterKeyValuePair[0], queryParameterKeyValuePair[1]));
            }
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new string[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidateRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            //RequestLine
            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseCookies();

            //Headers
            this.ParseRequestHeaders(this.ParsePlainRequestHeaders(splitRequestContent).ToArray());

            //Request Body
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
