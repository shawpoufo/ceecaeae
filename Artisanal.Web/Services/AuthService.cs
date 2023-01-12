

using System.Text;
using System.Text.Json;
using Artisanal.Web.Models;
using Artisanal.Web.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Artisanal.Web.Services;
public class AuthService
{
    private readonly HttpClient _httpClient;
    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.BaseAddress = new Uri("http://localhost:5126");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<ResponseDto> Login(string userName, string passWord)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(new { userName, passWord }),
            Encoding.UTF8,
            Application.Json);
        var response = await _httpClient.PostAsync("/auth/login",content);
        var responseDto = new ResponseDto{
            IsSuccess = response.IsSuccessStatusCode,
            Result = response.Headers.FirstOrDefault(h => h.Key == "Set-Cookie").Value?.FirstOrDefault()
        };
        
        return responseDto;

        
    }


}