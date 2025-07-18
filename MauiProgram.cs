namespace memorygame;
public static class MauiProgram
{
    #if DEBUG
    const string AndroidOpenAdUnitId = ""; // AdmobOpenAdServiceOptions.AndroidTestUnitId;
    const string IosOpenAdUnitId = ""; // AdmobOpenAdServiceOptions.IosTestUnitId;
#else
    // Put your real unit id here
    const string AndroidOpenAdUnitId = ""; // <YOUR AD UNIT ID>
    const string IosOpenAdUnitId = ""; // <YOUR AD UNIT ID>
#endif
    
    public static MauiApp CreateMauiApp() =>
        MauiMaterialUtils.CreateMauiApp<App>(
            #if DEBUG
            addDebug: true,
#endif
            
            configureSetup: config =>
            {
                config.AddRating();

                config.AddOnboardingScreen(onb =>
                {
#warning Change icons for OnboardingScreen with icons from https://fonts.google.com/icons
                    onb.SetItems("my_icon1", "my_icon2");

                    onb.ConfigureForDesktopEnv("https://www.example.com");
                });

                /* For ServiceSharp Attribute injection:
                config.AddServices();
                */

                /* Uncomment for file picker (still need LukeMauiFilePicker package installed): 
                config.AddFilePicker();
                */

                /* Ad setup, uncomment to add open ads
                config.AddAdmob(new()
                {
                    OpenAd = ads =>
                    {
                        ads.AndroidUnitId = AndroidOpenAdUnitId;
                        ads.IosUnitId = IosOpenAdUnitId;

                        ads.RequestTrackingAuth = true;
                    }
                });
                */
            });

}
