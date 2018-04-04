using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LivestockBrandIdentifier.Services
{
    public class RestClient
    {
        private readonly string _url;
        private ContentType _contentType;

        public RestClient(string url)
        {
            _url = url;
        }

        public RestClient WithContentType(ContentType contentType)
        {
            _contentType = contentType;

            return this;
        }

        public async Task<TResult> PostAsync<TResult, T>(T @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(nameof(@object), "Argument cannot be null.");
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var serializedObject = JsonConvert.SerializeObject(@object);
                    var content = new StringContent(serializedObject, Encoding.UTF8, _contentType.GetDescription());
                    var httpResponse = await httpClient.PostAsync(_url, content);

                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error while calling POST method at {_url}");
                    }

                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TResult>(responseContent);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public enum ContentType
    {
        [Description("application/json")]
        Json,
        [Description("application/xml")]
        Xml
    }
}
