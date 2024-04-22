using Newtonsoft.Json;
using System.Text;
using DEMO.Client.Services.Interfaces;

namespace DEMO.Client.Services;

public class HTTPClientService : IHttpClientService
{
    protected HttpClient HttpClient;

    public HTTPClientService(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory.CreateClient();
        HttpClient.BaseAddress = new Uri("https://localhost:7238/");
    }

    public async Task<IEnumerable<Type>> GetEnumerable<Type>(string uri)
    {
        HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(uri);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var response = await httpResponseMessage.Content.ReadAsAsync<IEnumerable<Type>>();

            return response;
        }

        return Enumerable.Empty<Type>();
    }

    public async Task<Type> Post<Type>(string uri, Type data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var result = HttpClient.PostAsync(uri, content).Result;

        if (!result.IsSuccessStatusCode)
            return default!;

        var responseData = await result.Content.ReadAsStringAsync();
        var deserializedResponse = JsonConvert.DeserializeObject<Type>(responseData);

        return deserializedResponse!;
    }

    public async Task<Type> Patch<Type>(string uri, Type data)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

        var result = HttpClient.PatchAsync(uri, content).Result;

        if (!result.IsSuccessStatusCode)
            return default!;
   
        var responseData = await result.Content.ReadAsStringAsync();
        var deserializedResponse = JsonConvert.DeserializeObject<Type>(responseData);

        return deserializedResponse!;
    }

    public async Task<bool> Delete(string uri)
    {
        var response = await HttpClient.DeleteAsync(uri);
        return response.IsSuccessStatusCode;
    }
}