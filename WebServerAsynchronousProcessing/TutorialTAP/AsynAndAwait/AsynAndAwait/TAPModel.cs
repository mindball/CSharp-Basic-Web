using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynAndAwait
{
    public class TAPModel
    {
        public async Task<int> GetUrlContentLengthAsync(string url)
        {
            var client = new HttpClient();

            Task<string> getStringTask =
                client.GetStringAsync(url);

            DoIndependentWork();

            string contents = await getStringTask;            

            return contents.Length;
        }

        private void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }


    }
}
