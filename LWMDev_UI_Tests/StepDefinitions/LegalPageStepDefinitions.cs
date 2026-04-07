using System;
using LMWSelenium.PageModels.PageModels;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Reqnroll;

namespace LWMDev_UI_Tests.StepDefinitions
{
    [Binding]
    public class LegalPageStepDefinitions
    {
        private LegalPageModel _LegalPageModel;


        [Given("LegalPage: I use Browser {string}")]
        public void GivenLegalPageIUseBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    _LegalPageModel = new LegalPageModel(new ChromeDriver());
                    break;
                case "firefox":
                    _LegalPageModel = new LegalPageModel(new FirefoxDriver());
                    break;
                case "edge":
                    _LegalPageModel = new LegalPageModel(new EdgeDriver());
                    break;
                case "safari":
                    _LegalPageModel = new LegalPageModel(new SafariDriver());
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }

        [When("LegalPage: I go to {string}")]
        public void WhenLegalPageIGoTo(string url)
        {
            _LegalPageModel.NavigateToPage(url);
            _LegalPageModel.SetUpPage();
        }

        [Then("LegalPage: the page title is {string}")]
        public void ThenLegalPagePageTitleIs(string expectedTitle)
        {
            _LegalPageModel.AssertAreEqual(expectedTitle, _LegalPageModel.Driver.Title);
            _LegalPageModel.Driver.Quit();
        }

        [When("LegalPage: I go to {string} and use the search button")]
        public void WhenLegalPageUseSearchButton(string url)
        {
            _LegalPageModel.NavigateToPage(url);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.CLickSearchNavBarButton();
        }

        [When("LegalPage: I go to {string} and use the home button")]
        public void WhenLegalPageUseHomeButton(string url)
        {
            _LegalPageModel.NavigateToPage(url);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickHomeNavBarButton();
        }

        [When("LegalPage: I go to {string} and use the Linkedin button")]
        public void WhenLegalPageUseLinkedinButton(string url)
        {
            _LegalPageModel.NavigateToPage(url);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickLinkedinButton();
        }

        [Then("LegalPage: I have arrived at linkedin")]
        public void ThenLegalPageArrivedAtLinkedin()
        {
            _LegalPageModel.WaitUntilURLContainsValue("https://www.linkedin.com/");
            _LegalPageModel.AssertAreEqual(_LegalPageModel.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
            _LegalPageModel.Driver.Quit();
        }

        [When("LegalPage: I go to {string} and use the logo button")]
        public void WhenLegalPageUseLogoButton(string url)
        {
            _LegalPageModel.NavigateToPage(url);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickLogoButton();
        }

        [When("LegalPage: I go to {string} and use the Github button")]
        public void WhenLegalPageIGoToAndUseTheGithubButton(string p0)
        {
            _LegalPageModel.NavigateToPage(p0);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickGithubButton();
        }

        [Then("LegalPage: I have arrived at Github")]
        public void ThenLegalPageIHaveArrivedAtGithub()
        {
            _LegalPageModel.WaitUntilURLContainsValue("https://github.com/");
            _LegalPageModel.AssertAreEqual(_LegalPageModel.Driver.Url, "https://github.com/LewisWhittard");
            _LegalPageModel.Driver.Quit();
        }

        [When("LegalPage: I go to {string} and use the Software Development button")]
        public void WhenLegalPageIGoToAndUseTheSoftwareDevelopmentButton(string p0)
        {
            _LegalPageModel.NavigateToPage(p0);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickSoftwareDevelopmentNavBarButton();
        }

        [When("LegalPage: I go to {string} and use the Creative Works button")]
        public void WhenLegalPageIGoToAndUseTheCreativeWorksButton(string p0)
        {
            _LegalPageModel.NavigateToPage(p0);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickCreativeWorksNavBarButton();
        }

        [When("LegalPage: I go to {string} and use the legal button")]
        public void WhenLegalPageIGoToAndUseTheLegalButton(string p0)
        {
            _LegalPageModel.NavigateToPage(p0);
            _LegalPageModel.SetUpPage();
            _LegalPageModel.ClickLegalButton();
        }

    }
}
