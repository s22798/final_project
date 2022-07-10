using final_project.Shared.Models.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace final_project.Client.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private string apiKey = "WNux2CEcikhLeVRxJ0m4_K5tvBvvmBVF";
        private readonly HttpClient _client;
        public CompanyService(HttpClient client)
        {
            _client = client;
        }

        public async Task AddCompanyToDb(string ticker)
        {
            var model = await GetCompanyByTicker(ticker);
            var serialized = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/companies", stringContent);
        }

        public async Task<HttpResponseMessage> AddToCompanyUsers(string idUser, int idCompany)
        {
            var model = new WatchlistDTO() { IdUser = idUser, IdCompany = idCompany };
            var seralized = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(seralized, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/watchlists", stringContent);
            return response;
        }

        public async Task DeleteFromCompanyUsers(string idUser, int idCompany)
        {
            await _client.DeleteAsync($"api/watchlists?idCompany={idCompany}&idUser={idUser}");
        }

        public async Task<CompanyDTO> GetCompanyByTicker(string ticker)
        {
            CompanyDTO company = null;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"https://api.polygon.io/v3/reference/tickers/{ticker}?apiKey={apiKey}");
                var jObject = JObject.Parse(json);

                company = jObject.SelectToken("results").ToObject<CompanyDTO>();
            }
            RegionInfo cultureInfo = new RegionInfo($"{company.Locale}-{company.Locale}");
            company.Locale = cultureInfo.EnglishName;
            company.Branding.Logo_url += "?apiKey=WNux2CEcikhLeVRxJ0m4_K5tvBvvmBVF";
            return company;
        }

        public async Task<IEnumerable<CompanySearchDTO>> GetSearchedCompany(string text)
        {
            IEnumerable <CompanySearchDTO> companies= null;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"https://api.polygon.io/v3/reference/tickers?search={text}&active=true&sort=ticker&order=asc&limit=10&apiKey={apiKey}");
                var jObject = JObject.Parse(json);

                companies = jObject.SelectToken("results").ToObject<IEnumerable<CompanySearchDTO>>();
            }
            return companies;
        }

        public async Task<CompanyDTODB> GetCompanyFromDb(string ticker)
        {
            var res = await _client.GetStringAsync($"api/companies/{ticker}");
            return JObject.Parse(res).SelectToken("").ToObject<CompanyDTODB>();
        }

        public async Task<IEnumerable<CompanyDTODB>> GetCompaniesFromDb()
        {
            var res = await _client.GetStringAsync($"api/companies");
            return JArray.Parse(res).SelectToken("").ToObject<IEnumerable<CompanyDTODB>>();
        }

        public async Task<IEnumerable<CompanyDTODB>> GetWatchlist(string idUser)
        {
            var res = await _client.GetStringAsync($"api/watchlists/{idUser}");
            return JArray.Parse(res).SelectToken("").ToObject<IEnumerable<CompanyDTODB>>();
        }

        
    }
}
