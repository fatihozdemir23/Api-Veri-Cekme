using System.Net;

namespace WebApi.Helpers
{
    public class HttpHelper
    {
        string url;
        public HttpHelper(string url)
        {
            this.url = url; 
        }
        public  async Task<T> GetDataFromApi<T>()
        {
            using ( var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                string resultContentString = await result.Content.ReadAsStringAsync();
                T resultContent = System.Text.Json.JsonSerializer.Deserialize<T>(resultContentString);
                return resultContent;
            }
        }

        public async Task<HttpStatusCode> StatusCode()
        {
            using ( var client = new HttpClient() )
            {
                var result = await client.GetAsync(url);
                return result.StatusCode;
            }

                
        }
    }
}
