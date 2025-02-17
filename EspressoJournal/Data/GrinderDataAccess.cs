using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EspressoJournal.Models;

namespace EspressoJournal.Data
{
    public class GrinderDataAccess
    {
        private readonly HttpClient _httpClient;

        public GrinderDataAccess(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EspressoDataServiceApiClient");
        }

        public async Task<IEnumerable<GrinderModel>> GetGrindersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GrinderModel>>("grinder");
        }

        public async Task AddGrinderAsync(GrinderModel grinder)
        {
            var response = await _httpClient.PostAsJsonAsync("grinder", grinder);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGrinderAsync(GrinderModel grinder)
        {
            var response = await _httpClient.PutAsJsonAsync($"grinder/{grinder.ID}", grinder);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGrinderAsync(GrinderModel grinder)
        {
            var response = await _httpClient.DeleteAsync($"grinder/{grinder.ID}");
            response.EnsureSuccessStatusCode();
        }
    }
}