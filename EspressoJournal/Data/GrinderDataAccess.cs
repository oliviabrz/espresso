using System;
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
            _httpClient = httpClientFactory.CreateClient("GrinderApiClient");
        }

        public async Task<IEnumerable<GrinderModel>> GetGrindersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<GrinderModel>>("grinders");
        }

        public async Task AddGrinderAsync(GrinderModel grinder)
        {
            await _httpClient.PostAsJsonAsync("grinders", grinder);
        }
    }
}