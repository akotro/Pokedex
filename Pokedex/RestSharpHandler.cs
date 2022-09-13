using RestSharp;

namespace Pokedex
{
    internal class RestSharpHandler
    {
        internal string Url { get; set; }

        public RestSharpHandler(string url)
        {
            Url = url;
        }

        internal RestResponse RequestRestSharp(string endpoint, string body, Method method)
        {
            RestClient restClient = new();
            RestRequest request = new(Url + endpoint, method);
            request.AddJsonBody(body);

            RestResponse? response = null;

            try
            {
                response = restClient.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception {ex} in executing request: {request}");
            }

            return response;
        }

        internal RestResponse RequestRestSharp(string endpoint, Dictionary<string, object> headers, string body, Method method)
        {
            RestClient restClient = new();
            RestRequest request = new(Url + endpoint, method);

            if (headers != null)
            {
                foreach (var item in headers)
                {
                    if (item.Value != null)
                    {
                        request.AddHeader(item.Key, item.Value.ToString()!);
                    }
                }
            }

            request.AddJsonBody(body);

            RestResponse? response = null;

            try
            {
                response = restClient.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception {ex} in executing request: {request}");
            }

            return response;
        }
    }
}
