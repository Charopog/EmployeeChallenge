
namespace EmployeeChallenge.Xam.Utils.Extensions
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpClientExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent httpContent)
        {
            var jsonString = await httpContent.ReadAsStringAsync();
            return await Task.Run(()=>JsonConvert.DeserializeObject<T>(jsonString));
        }

        public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient httpClient, string requestUri, object value)
        {
            var serializedObject = await Task.Run(() => JsonConvert.SerializeObject(value)).ConfigureAwait(false);
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await httpClient.PostAsync(requestUri, content).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient httpClient, string requestUri, object value)
        {
            var serializedObject = await Task.Run(() => JsonConvert.SerializeObject(value)).ConfigureAwait(false);
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return await httpClient.PutAsync(requestUri, content).ConfigureAwait(false);
        }


    }
}
