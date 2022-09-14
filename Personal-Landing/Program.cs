var builder = WebApplication.CreateBuilder(args);

builder.AddHangfireConfiguration();

builder.Services.AddHttpClient();

builder.InjectCustomServices();

builder.Services.AddControllersWithViews();

builder.AddMinificationAndCompression();

var application = builder.Build();

application.UseHangfireDashboard();

application.MapGet("/health", () => true);

application.UseHttpsRedirection();

application.UseStaticFiles();

application.UseRouting();

application.UseWebMarkupMin();

application.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

application.AddRecurringJob();

application.Run();