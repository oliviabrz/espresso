using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EspressoJournal.Models;

namespace EspressoJournal.Data
{
    public class EspressoBeanDataAccess
    {
        private readonly HttpClient _httpClient;

        public EspressoBeanDataAccess(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EspressoDataServiceApiClient");
        }

        public async Task<IEnumerable<EspressoBeanModel>> GetEspressoBeansAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<EspressoBeanModel>>("espressobean");
            return response;
        }

        public async Task AddEspressoBeanAsync(EspressoBeanModel espressoBean)
        {
            var response = await _httpClient.PostAsJsonAsync("espressobean", espressoBean);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEspressoBeanAsync(EspressoBeanModel espressoBean)
        {
            var response = await _httpClient.PutAsJsonAsync($"espressobean/{espressoBean.Id}", espressoBean);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEspressoBeanAsync(EspressoBeanModel espressoBean)
        {
            var response = await _httpClient.DeleteAsync($"espressobean/{espressoBean.Id}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<IEnumerable<RoastTypeLookupModel>> GetRoastTypeLookupAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<RoastTypeLookupModel>>("roastType");
            return response;
        }
    }
}