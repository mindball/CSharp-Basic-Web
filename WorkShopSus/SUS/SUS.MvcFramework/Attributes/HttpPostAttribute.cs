using SUS.HTTP;

namespace SUS.MvcFramework.Attributes
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        //public override HttpMethod Method { get; set; } = HttpMethod.Post;

        public HttpPostAttribute()
        {
        }

        public HttpPostAttribute(string url)
        {
            this.Url = url;
        }

        public override HttpMethod Method => HttpMethod.Post;
    }
}
