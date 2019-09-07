using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace SmartHotel360.Specflow.Steps
{
    [Binding]
    public class SuccessSignInTestSteps
    {
        protected IApp app;
        protected Platform platform;

        readonly Query emailField;
        readonly Query passwordField;
        readonly Query signInButton;

        public SuccessSignInTestSteps()
        {
            this.platform = Platform.Android;

            emailField = x => x.Marked("username");
            passwordField = x => x.Marked("password");
            signInButton = x => x.Marked("signin");
        }

        [BeforeScenario()]
        public void Initialize()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Given(@"I check the SmatHotel(.*) app is installed in my device")]
        public void GivenICheckTheSmatHotelAppIsInstalledInMyDevice(int p0)
        {
            app.Screenshot("App Initialized");
        }
        
        [Given(@"I entered with ""(.*)""")]
        public void GivenIEnteredWith(string field)
        {
            if (field == "username")
            {
                app.WaitForElement(emailField);
                app.Tap(emailField);
                app.EnterText(TestSettings.TestUsername);
                app.DismissKeyboard();
            }
            else
            {
                app.Tap(passwordField);
                app.EnterText(TestSettings.TestPassword);
                app.DismissKeyboard();
            }
            
            app.Screenshot("Credentials Entered");
        }
        
        [When(@"I click in ""(.*)"" button")]
        public void WhenIClickInButton(string signIn)
        {
            app.Tap(signInButton);
        }
        
        [Then(@"the result should be the screen ""(.*)""")]
        public void ThenTheResultShouldBeTheScreen(string p0)
        {
            app.WaitForElement(x => x.Text("Welcome To SmartHotels 360"));
        }
    }
}
