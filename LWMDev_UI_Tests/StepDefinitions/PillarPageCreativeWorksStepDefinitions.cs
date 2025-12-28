using LMWSelenium.PageModels.PageModels;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Reqnroll;
using System;

namespace LWMDev_UI_Tests.StepDefinitions
{
    [Binding]
    public class PillarCreativeWorksSoftwareDevelopmentStepDefinitions
    {
        private PillarPageCreativeWorks _PillarPageCreativeWorks;


        [Given("PillarCreativeWorks: I use Browser {string}")]
        public void GivenPillarCreativeWorksIUseBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    _PillarPageCreativeWorks = new PillarPageCreativeWorks(new ChromeDriver());
                    break;
                case "firefox":
                    _PillarPageCreativeWorks = new PillarPageCreativeWorks(new FirefoxDriver());
                    break;
                case "edge":
                    _PillarPageCreativeWorks = new PillarPageCreativeWorks(new EdgeDriver());
                    break;
                case "safari":
                    _PillarPageCreativeWorks = new PillarPageCreativeWorks(new SafariDriver());
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }

        [When("PillarCreativeWorks: I go to {string}")]
        public void WhenPillarCreativeWorksIGoTo(string url)
        {
            _PillarPageCreativeWorks.NavigateToPage(url);
        }

        [Then("PillarCreativeWorks: the page title is {string}")]
        public void ThenPillarCreativeWorksPageTitleIs(string expectedTitle)
        {
            _PillarPageCreativeWorks.AssertAreEqual(expectedTitle, _PillarPageCreativeWorks.Driver.Title);
            _PillarPageCreativeWorks.Driver.Quit();
        }

        [When("PillarCreativeWorks: I go to {string} and use the search button")]
        public void WhenPillarCreativeWorksUseSearchButton(string url)
        {
            _PillarPageCreativeWorks.NavigateToPage(url);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.CLickSearchNavBarButton();
        }

        [When("PillarCreativeWorks: I go to {string} and use the home button")]
        public void WhenPillarCreativeWorksUseHomeButton(string url)
        {
            _PillarPageCreativeWorks.NavigateToPage(url);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.ClickHomeNavBarButton();
        }

        [When("PillarCreativeWorks: I go to {string} and use the Linkedin button")]
        public void WhenPillarCreativeWorkspageUseLinkedinButton(string url)
        {
            _PillarPageCreativeWorks.NavigateToPage(url);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.ClickLinkedinButton();
        }

        [Then("PillarCreativeWorks: I have arrived at linkedin")]
        public void ThenPillarCreativeWorksArrivedAtLinkedin()
        {
            _PillarPageCreativeWorks.WaitUntilURLContainsValue("https://www.linkedin.com/");
            _PillarPageCreativeWorks.AssertAreEqual(_PillarPageCreativeWorks.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
            _PillarPageCreativeWorks.Driver.Quit();
        }

        [When("PillarCreativeWorks: I go to {string} and use the logo button")]
        public void WhenPillarCreativeWorksUseLogoButton(string url)
        {
            _PillarPageCreativeWorks.NavigateToPage(url);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.ClickLogoButton();
        }

        [When("PillarCreativeWorks: I go to {string} and use the Github button")]
        public void WhenPillarCreativeWorksIGoToAndUseTheGithubButton(string p0)
        {
            _PillarPageCreativeWorks.NavigateToPage(p0);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.ClickGithubButton();
        }

        [Then("PillarCreativeWorks: I have arrived at Github")]
        public void ThenPillarCreativeWorksIHaveArrivedAtGithub()
        {
            _PillarPageCreativeWorks.WaitUntilURLContainsValue("https://github.com/");
            _PillarPageCreativeWorks.AssertAreEqual(_PillarPageCreativeWorks.Driver.Url, "https://github.com/LewisWhittard");
            _PillarPageCreativeWorks.Driver.Quit();
        }

        [When("Homepage: I go to {string} and use the Software Development button")]
        public void WhenHomepageIGoToAndUseTheSoftwareDevelopmentButton(string p0)
        {
            _PillarPageCreativeWorks.NavigateToPage(p0);
            _PillarPageCreativeWorks.SetUpPage();
            _PillarPageCreativeWorks.ClickSoftwareDevelopmentNavBarButton();
        }

        [When("Homepage: I go to {string} and use the Creative Works button")]
        public void WhenHomepageIGoToAndUseTheCreativeWorksButton(string p0)
        {
            throw new PendingStepException();
        }

    }
}
