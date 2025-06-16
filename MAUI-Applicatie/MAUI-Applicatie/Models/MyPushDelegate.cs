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
        logger.LogInformation("Push notification opened.");
        return Task.CompletedTask;
    }

    public Task OnNewToken(string token)
    {
        logger.LogInformation($"New token: {token}");
        return Task.CompletedTask;
    }

    public Task OnReceived(PushNotification notification)
    {
        logger.LogInformation($"Push received");
        return Task.CompletedTask;
    }

    public Task OnTokenChanged(string newToken)
    {
        logger.LogInformation($"Token changed: {newToken}");
        return Task.CompletedTask;
    }

    public Task OnUnRegistered(string token)
    {
        logger.LogInformation($"Token unregistered: {token}");
        return Task.CompletedTask;
    }

}
