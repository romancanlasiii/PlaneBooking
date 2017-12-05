using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlaneBooking.Http
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> PutAsync(Uri uri, HttpContent content);
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
        Task<HttpResponseMessage> GetAsync(Uri uri);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> DeleteAsync(string uri);
    }
}
