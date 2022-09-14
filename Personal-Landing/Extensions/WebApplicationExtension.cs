namespace Personal_Landing.Extensions;

public static class WebApplicationExtension
{
    /// <summary>
    /// Add recurring job
    /// </summary>
    /// <param name="application"></param>
    public static void AddRecurringJob(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
        var httpCallService = scope.ServiceProvider.GetRequiredService<HttpCallService>();
        recurringJobManager.AddOrUpdate("Dont-Close", () => httpCallService.CallHealthCheck(), Cron.MinuteInterval(10));
        Console.WriteLine("called");
    }
}