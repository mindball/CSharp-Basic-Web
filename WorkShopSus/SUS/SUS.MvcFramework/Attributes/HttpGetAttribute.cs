using SUS.HTTP;

namespace SUS.MvcFramework.Attributes
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        //public override HttpMethod Method { get; set; } = HttpMethod.Get;

        public HttpGetAttribute()
        {
        }

        public HttpGetAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.Get;
    }
}
