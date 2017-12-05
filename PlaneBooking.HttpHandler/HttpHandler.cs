using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlaneBooking.Http
{
    public class HttpHandler : IHttpHandler
    {
        private readonly IHttpClientWrapper _client;

        public string GatewayHost { get; private set; }
        public int GatewayPort { get; private set; }
        public string GatewayApiPath { get; private set; }

        public HttpHandler(IHttpClientWrapper client)
        {
            _client = client;
        }

        public TResponse PostJson<TRequest, TResponse>(TRequest request, string path)
        {
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
            var uri = BuildHttpClientUri(
                GatewayHost,
                $"{GatewayApiPath}/{path}",
                GatewayPort);
            var response =
                Send<TResponse>(async () => await _client
                    .PostAsync(uri, stringContent)
                    .ConfigureAwait(false));

            return response;
        }

        public TResponse PostJson<TRequest, TResponse>(TRequest request)
        {
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
            var uri = BuildHttpClientUri(
                GatewayHost,
                GatewayApiPath,
                GatewayPort);
            var response =
                Send<TResponse>(async () => await _client
                    .PostAsync(uri, stringContent)
                    .ConfigureAwait(false));

            return response;
        }

        public TResponse PutJson<TRequest, TResponse>(TRequest request, string path)
        {
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
            var uri = BuildHttpClientUri(
                GatewayHost,
                $"{GatewayApiPath}/{path}",
                GatewayPort);
            var response =
                Send<TResponse>(async () => await _client
                    .PutAsync(uri, stringContent)
                    .ConfigureAwait(false));

            return response;
        }

        public TResponse PutJson<TRequest, TResponse>(TRequest request)
        {
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");
            var uri = BuildHttpClientUri(
                GatewayHost,
                GatewayApiPath,
                GatewayPort);
            var response =
                Send<TResponse>(async () => await _client
                    .PutAsync(uri, stringContent)
                    .ConfigureAwait(false));

            return response;
        }

        public TResponse GetJson<TResponse>(
            IEnumerable<KeyValuePair<string, string>> args = null)
        {
            return GetResponse<TResponse>(GetQueryString(args));
        }

        public TResponse GetJson<TResponse>(string queryString)
        {
            return GetResponse<TResponse>(queryString);
        }

        public TResponse DeleteJson<TResponse>(string queryString)
        {
            var url = BuildHttpClientUrl(
                GatewayHost,
                GatewayApiPath,
                GatewayPort,
                queryString);

            var response =
                Send<TResponse>(async () => await _client
                    .DeleteAsync(url)
                    .ConfigureAwait(false));

            return response;
        }

        public void InitHttpUrl(
            string host,
            int port,
            string rootPath)
        {
            GatewayHost = host;
            GatewayPort = port;
            GatewayApiPath = rootPath;
        }

        private TResponse GetResponse<TResponse>(string queryString)
        {
            var url = BuildHttpClientUrl(
                GatewayHost,
                GatewayApiPath,
                GatewayPort,
                queryString);

            return Send<TResponse>(async () => await _client
                .GetAsync(url));
        }

        private static TResponse Send<TResponse>(Func<Task<HttpResponseMessage>> operation)
        {
            var responseTask = Task.Run(operation);
            var response = responseTask.Result.EnsureSuccessStatusCode();

            var readContentTask =
                Task.Run(async () => await response
                    .Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false));
            Task.WaitAll(readContentTask);
            return JsonConvert.DeserializeObject<TResponse>(readContentTask.Result);
        }

        private static Uri BuildHttpClientUri(
            string host,
            string path,
            int port)
        {
            var uriBuilder = new UriBuilder(Uri.UriSchemeHttp, host, port, path);
            return uriBuilder.Uri;
        }

        private static string BuildHttpClientUrl(
            string host,
            string path,
            int port,
            string queryString = "")
        {
            return $"{Uri.UriSchemeHttp}://{host}:{port}/{path}{queryString}";
        }

        private static string GetQueryString(IEnumerable<KeyValuePair<string, string>> args)
        {
            var argsArray = args as KeyValuePair<string, string>[] ?? args.ToArray();
            if (!argsArray.Any())
            {
                return string.Empty;
            }

            var queryString = string.Join(
                "&",
                argsArray.Select(_ => $"{_.Key}={_.Value}"));

            return $"?{queryString}";
        }
    }
}
