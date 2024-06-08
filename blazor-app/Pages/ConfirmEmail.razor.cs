using Microsoft.AspNetCore.Components;

namespace blazor_app.Pages;

public partial class ConfirmEmail : ComponentBase
{
    private string message = "Welcome user!";

    [Inject]
    private HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var response = await HttpClient.GetAsync("https://localhost:7196/confirmEmail");
            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsStringAsync();
            }
            else
            {
                message = response.ToString();
            }
        }
        catch (Exception ex)
        {
            message = $"Exception: {ex.Message}";
        }
    }
}