namespace SIS.WebServer.DiffApproach.Result
{
    using SIS.HTTP.DiffApproach.Enums;
    using SIS.HTTP.DiffApproach.Headers;
    using SIS.HTTP.DiffApproach.Responses;

    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) 
            : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
