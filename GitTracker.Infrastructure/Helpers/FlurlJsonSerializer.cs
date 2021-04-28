using Flurl.Http.Configuration;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitTracker.Infrastructure.Helpers
{
    public class FlurlJsonSerializer : ISerializer
    {
        public T Deserialize<T>(string s)
        {
            return JsonSerializer.Deserialize<T>(s);
        }

        public T Deserialize<T>(Stream stream)
        {
            return Task.Run(async () => await DeserializeAsync<T>(stream)).Result;
        }

        public static async Task<T> DeserializeAsync<T>(Stream stream)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}