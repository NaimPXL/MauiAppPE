using IWantPicturesOfSpidermanMauiApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantPicturesOfSpidermanMauiApp.Services
{
    public class RestService
    {
        private const string REST_URL = "https://kw938rwh-7006.euw.devtunnels.ms";

        private readonly HttpClient _httpClient;

        public RestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<PictureDTO>> GetAllPicturesAsync()
        {
            var response = await _httpClient.GetAsync($"{REST_URL}/api/Picture");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<PictureDTO>>(content, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            }
            else
            {
                throw new Exception("Failed to fetch Pictures.");
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{REST_URL}/api/categories");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<CategoryDTO>>(content);
            }
            else
            {
                throw new Exception("Failed to fetch Categories.");
            }
        }


    }
}
