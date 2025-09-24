using LMWSelenium.PageModels.PageModels;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace LWMDev_UI_Tests.StepDefinitions
{
    [Binding]
    public class BrowserNavigationAndPageTitleVerificationStepDefinitions
    {
        private HomePage _homePage;

        [Given("I use Browser {string}")]
        public void GivenIUseBrowser(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    _homePage = new HomePage(new ChromeDriver());
                    break;
                case "firefox":
                    _homePage = new HomePage(new FirefoxDriver());
                    break;
                case "edge":
                    _homePage = new HomePage(new EdgeDriver());
                    break;
                case "safari":
                    _homePage = new HomePage(new SafariDriver());
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

        }

        [When("I go to {string}")]
        public void WhenIGoTo(string p0)
        {
            _homePage.NavigateToHomepage(p0);
        }


        [Then("the page title is {string}")]
        public void ThenThePageTitleIs(string p0)
        {
            _homePage.AssertAreEqual(p0,_homePage.Driver.Title);
            _homePage.Driver.Quit();
        }
    }
}
