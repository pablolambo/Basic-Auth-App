using Microsoft.AspNetCore.Components;

namespace blazor_app.Pages;

using System.Text;
using System.Text.Json;

public partial class ResetPassword : ComponentBase
{
    private string ResetCode { get; set; }
    private string Email { get; set; }
    private string NewPassword { get; set; }
    private string Result { get; set; }
    
    [Inject]
    private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var response = await HttpClient.GetAsync("https://localhost:7196/account/email");
        Email = await response.Content.ReadAsStringAsync();
    }

    private async Task SubmitForm()
    {
        var data = new Dictionary<string, string>
        {
            { "email", Email },
            { "resetCode", ResetCode },
            { "newPassword", NewPassword }
        };

        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync("https://localhost:7196/resetPassword", content);

        Console.WriteLine(response.IsSuccessStatusCode ? "Reset successful!" : "Reset failed!");
        
        Result = response.ToString();
    }
}