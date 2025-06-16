using Shiny.Push;
using Microsoft.Extensions.Logging;

public class MyPushDelegate : IPushDelegate
{
    readonly ILogger<MyPushDelegate> logger;

    public MyPushDelegate(ILogger<MyPushDelegate> logger)
    {
        this.logger = logger;
    }

    public Task OnEntry(PushNotification notification)
    {
        logger.LogInformation("Push notification received");
        return Task.CompletedTask;
    }

    public Task OnNewToken(string token)
    {
        throw new NotImplementedException();
    }

    public Task OnReceived(PushNotification notification)
    {
        throw new NotImplementedException();
    }

    public Task OnTokenChanged(string newToken)
    {
        logger.LogInformation("New FCM token: " + newToken);
        return Task.CompletedTask;
    }

    public Task OnUnRegistered(string token)
    {
        throw new NotImplementedException();
    }
}
