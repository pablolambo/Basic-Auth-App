namespace blazor_app.Pages;

using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public partial class RegisterForm : ComponentBase
{
    private string Email { get; set; }
    private string Password { get; set; }
    private string Result { get; set; }
    private string Content { get; set; }

    [Inject]
    private HttpClient HttpClient { get; set; }

    private async Task SubmitForm()
    {
        var loginData = new Dictionary<string, string>
        {
            { "email", Email },
            { "password", Password }
        };

        var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync("https://localhost:7196/register", content);

        Console.WriteLine(response.IsSuccessStatusCode ? "Register successful!" : "Register failed!");
        Result = response.ToString();
        Content = await response.Content.ReadAsStringAsync();
    }
}