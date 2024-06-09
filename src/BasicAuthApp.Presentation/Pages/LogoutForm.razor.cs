namespace BasicAuthApp.Presentation.Pages;

using Microsoft.AspNetCore.Components;

public partial class LogoutForm : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        
        var content = new StringContent("application/json");

        await HttpClient.PostAsync("https://localhost:7196/account/logout", content);
    }
}