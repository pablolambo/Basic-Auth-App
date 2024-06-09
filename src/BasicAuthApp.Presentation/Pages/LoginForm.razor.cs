namespace BasicAuthApp.Presentation.Pages;

using System.Text;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.Components;

public partial class LoginForm : ComponentBase
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
        
        var uriBuilder = new UriBuilder("https://localhost:7196/login");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["useSessionCookies"] = "true"; // Add useSessionCookies parameter
        query["useCookies"] = "true"; // Add useCookies parameter
        uriBuilder.Query = query.ToString();
        

        var response = await HttpClient.PostAsync("https://localhost:7196/login?useCookies=true&useSessionCookies=true", content);

        Console.WriteLine(response.IsSuccessStatusCode ? "Login successful!" : "Login failed!");

        Result = response.ToString();
        Content = await response.Content.ReadAsStringAsync();
    }
}
