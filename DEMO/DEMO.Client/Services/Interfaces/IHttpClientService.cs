namespace DEMO.Client.Services.Interfaces;

public interface IHttpClientService
{
    Task<IEnumerable<Type>> GetEnumerable<Type>(string uri);
    Task<Type> Post<Type>(string uri, Type data);
    Task<Type> Patch<Type>(string uri, Type data);
    Task<bool> Delete(string uri);
}