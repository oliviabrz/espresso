using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EspressoJournal.Models;

namespace EspressoJournal.Data
{
    public class JournalEntryDataAccess
    {
        private readonly HttpClient _httpClient;

        public JournalEntryDataAccess(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EspressoDataServiceApiClient");
        }

        public async Task<IEnumerable<JournalEntryModel>> GetJournalEntriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<JournalEntryModel>>("journalentry");
        }

        public async Task AddJournalEntryAsync(JournalEntryModel journalEntry)
        {
            var response = await _httpClient.PostAsJsonAsync("journalentry", journalEntry);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateJournalEntryAsync(JournalEntryModel journalEntry)
        {
            var response = await _httpClient.PutAsJsonAsync($"journalentry/{journalEntry.Id}", journalEntry);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteJournalEntryAsync(JournalEntryModel journalEntry)
        {
            var response = await _httpClient.DeleteAsync($"journalentry/{journalEntry.Id}");
            response.EnsureSuccessStatusCode();
        }
    }
}