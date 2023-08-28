using Microsoft.AspNetCore.Mvc;

namespace SpotiClone_Bolivar_Back.Controllers
{
    [Route("[controller]")]
    public class PlaylistController : Controller
    {
        [HttpGet]
        public async Task<string> GetAsync()
        {
            var token = "BQBuBBoRdjcDWONuTuBZNJ8ea6xEUIxjukoAnveThpyVIfvf-mhY6ADR9PBTZFnbw63eNJHzAd03VOU4viZ8FBJ54PtpvPGxXyG8oADeMVet088UAfc";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n"),
                Headers =
                {
                    { "Authorization", $"Bearer {token}" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync()!;
                return body;
            }
        }
    }
}

