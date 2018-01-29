
namespace EmployeeChallenge.Xam.Utils.Factories.Abstractions
{
    using System.Net.Http;

    public interface IHttpClientFactory
    {
        void DisposeAllClients();
        void DisposeClient(string baseAddress);
        HttpClient GetOrCreateHttpClient(string baseAddress);
    }
}