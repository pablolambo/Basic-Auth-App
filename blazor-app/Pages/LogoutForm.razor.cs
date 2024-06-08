using Microsoft.AspNetCore.Components;

namespace blazor_app.Pages;

public partial class LogoutForm : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        
        var content = new StringContent("application/json");

        await HttpClient.PostAsync("https://localhost:7196/logout", content);
    }
}