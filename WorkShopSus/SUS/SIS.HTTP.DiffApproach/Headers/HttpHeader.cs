﻿using SIS.HTTP.DiffApproach.Common;

namespace SIS.HTTP.DiffApproach.Headers
{
    public class HttpHeader
    {
        public const string HttpHeaderCookie = "Cookie";
        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString() => $"{this.Key}: {this.Value}";
    }
}
