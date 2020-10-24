namespace SIS.WebServer.DiffApproach.Result
{
    using System.Text;

    using SIS.HTTP.DiffApproach.Enums;
    using SIS.HTTP.DiffApproach.Headers;
    using SIS.HTTP.DiffApproach.Responses;

    public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode) 
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}