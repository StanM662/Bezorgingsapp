using Google.Apis.Auth.OAuth2;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public static class FcmSender
{
    private const string ProjectId = "maui-applicatie";
    private static readonly string FcmEndpoint = $"https://fcm.googleapis.com/v1/projects/{ProjectId}/messages:send";

    public static async Task SendPushAsync(string deviceToken)
    {
        try
        {
            // Adjust the file loading path as needed in your app
            using var stream = await FileSystem.OpenAppPackageFileAsync("service-account.json");

            var credential = GoogleCredential
                .FromStream(stream)
                .CreateScoped("https://www.googleapis.com/auth/firebase.messaging");

            var accessToken = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var message = new
            {
                message = new
                {
                    token = deviceToken,
                    notification = new
                    {
                        title = "Test",
                        body = "Hello from .NET MAUI"
                    }
                }
            };

            var json = JsonSerializer.Serialize(message);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(FcmEndpoint, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Push notification sent successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to send push. Status: {response.StatusCode}");
                Console.WriteLine($"Response: {responseContent}");
                throw new Exception($"FCM push failed: {responseContent}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending FCM push: {ex}");
            throw;
        }
    }
}
