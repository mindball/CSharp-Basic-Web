namespace SIS.WebServer.DiffApproach.Result
{
    using System.Text;

    using SIS.HTTP.DiffApproach.Enums;
    using SIS.HTTP.DiffApproach.Headers;
    using SIS.HTTP.DiffApproach.Responses;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8") 
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8") 
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = content;
        }
    }
}
