namespace BasicAuthApp.Presentation.Pages;

using Microsoft.AspNetCore.Components;

public partial class ForgotPasswordForm : ComponentBase
{
    private string Email { get; set; }
    private string Message { get; set; }
        
    [Inject]
    private HttpClient HttpClient { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    private async Task SubmitForm()
    {
        try
        {
            var payload = new { Email };

            var response = await HttpClient.PostAsJsonAsync("https://localhost:7196/forgotPassword", payload);
            if (response.IsSuccessStatusCode)
            {
                Message = await response.Content.ReadAsStringAsync();
                NavigationManager.NavigateTo("/resetPassword");
            }
            else
            {
                Message = response.ToString();
            }
        }
        catch (Exception ex)
        {
            Message = $"Exception: {ex.Message}";
        }
    }
}