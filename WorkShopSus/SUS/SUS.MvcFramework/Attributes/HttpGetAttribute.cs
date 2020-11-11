using SUS.HTTP;

namespace SUS.MvcFramework.Attributes
{
    public class HttpGetAttribute : BaseHttpAttribute
    {
        public override HttpMethod Method { get; set; } = HttpMethod.Get;
    }
}
