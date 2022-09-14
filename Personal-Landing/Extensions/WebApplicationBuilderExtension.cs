

namespace Personal_Landing.Extensions;

public static class WebApplicationBuilderExtension
{
    /// <summary>
    /// Add dependency injections
    /// </summary>
    /// <param name="builder"></param>
    public static void InjectCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<HttpCallService, HttpCallService>();
    }
    
    /// <summary>
    /// Minify html and compress response
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinificationAndCompression(this WebApplicationBuilder builder)
    {
        builder.Services.AddWebMarkupMin(
                options =>
                {
                    options.AllowMinificationInDevelopmentEnvironment = true;
                    options.AllowCompressionInDevelopmentEnvironment = true;
                })
            .AddHtmlMinification(
                options =>
                {
                    options.MinificationSettings.RemoveRedundantAttributes = true;
                    options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                    options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                })
            .AddHttpCompression();
    }

    /// <summary>
    /// Add hangfire configuration to service
    /// </summary>
    /// <param name="builder"></param>
    public static void AddHangfireConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseInMemoryStorage());

        builder.Services.AddHangfireServer();

    }
}