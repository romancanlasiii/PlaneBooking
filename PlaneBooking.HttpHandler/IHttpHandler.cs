using System.Collections.Generic;

namespace PlaneBooking.Http
{
    public interface IHttpHandler
    {
        TResponse PostJson<TRequest, TResponse>(TRequest request);
        TResponse PostJson<TRequest, TResponse>(TRequest request, string path);

        TResponse PutJson<TRequest, TResponse>(TRequest request);
        TResponse PutJson<TRequest, TResponse>(TRequest request, string path);

        TResponse GetJson<TResponse>(
            IEnumerable<KeyValuePair<string, string>> args = null);

        TResponse GetJson<TResponse>(string queryString);

        void InitHttpUrl(
            string host,
            int port,
            string rootPath);

        TResponse DeleteJson<TResponse>(string queryString);
    }
}
