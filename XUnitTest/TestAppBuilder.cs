using Avalonia.Headless;
using Avalonia;
using AvaloniaMultiplatform;



[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]
public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}