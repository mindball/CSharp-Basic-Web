using SUS.HTTP;

namespace SUS.MvcFramework.Attributes
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        public override HttpMethod Method { get; set; } = HttpMethod.Post;
    }
}
