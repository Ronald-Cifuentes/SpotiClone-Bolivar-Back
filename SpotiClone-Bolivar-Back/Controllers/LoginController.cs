using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


namespace SpotiClone_Bolivar_Back.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        //private static readonly Guid state = Guid.NewGuid();
        private static readonly string clientId = ConfigManager.AppSetting["Data:Client_Id"]!;
        private static readonly string clientSecret = ConfigManager.AppSetting["Data:Client_Secret"]!;
        //private static readonly string urlAuth = ConfigManager.AppSetting["Data:Url_Authorization"]!;
        //private static readonly string cb = ConfigManager.AppSetting["Data:Url_Callback"]!;
        //private static readonly string uri = $"{urlAuth}?response_type=code&client_id={clientId}&redirect_uri={cb}&state={state}";


        [HttpGet]
        public async Task<DTOAccessData> Get()
        {
            var clientHandler = new HttpClientHandler
            {
                UseCookies = false,
            };
            var client = new HttpClient(clientHandler);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://accounts.spotify.com/api/token"),
                Headers =
                    {},
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" },
                        { "client_id", clientId },
                        { "client_secret", clientSecret },
                    }),
            };
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {

                string body = await response.Content.ReadAsStringAsync();
                DTOAccessData dataRes = JsonSerializer.Deserialize<DTOAccessData>(body)!;
                return dataRes;
            }
            return new DTOAccessData { access_token="", token_type="", expires_in=0 };
        }
    }
}

