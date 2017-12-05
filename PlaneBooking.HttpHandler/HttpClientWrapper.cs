using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PlaneBooking.Http
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return _client.PostAsync(uri, content);
        }

        public Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content)
        {
            return _client.PutAsync(uri, content);
        }

        public Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return _client.GetAsync(uri);
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            return _client.DeleteAsync(uri);
        }
    }
}