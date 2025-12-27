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
    public class PillarPageSoftwareDevelopmentStepDefinitions
    {
        private PillarPageSoftwareDevelopment _PillarPageSoftwareDevelopment;


        [Given("PillarSoftwareDevelopment: I use Browser {string}")]
        public void GivenPillarSoftwareDevelopmentIUseBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    _PillarPageSoftwareDevelopment = new PillarPageSoftwareDevelopment(new ChromeDriver());
                    break;
                case "firefox":
                    _PillarPageSoftwareDevelopment = new PillarPageSoftwareDevelopment(new FirefoxDriver());
                    break;
                case "edge":
                    _PillarPageSoftwareDevelopment = new PillarPageSoftwareDevelopment(new EdgeDriver());
                    break;
                case "safari":
                    _PillarPageSoftwareDevelopment = new PillarPageSoftwareDevelopment(new SafariDriver());
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }
        }

        [When("PillarSoftwareDevelopment: I go to {string}")]
        public void WhenPillarSoftwareDevelopmentIGoTo(string url)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(url);
        }

        [Then("PillarSoftwareDevelopment: the page title is {string}")]
        public void ThenPillarSoftwareDevelopmentPageTitleIs(string expectedTitle)
        {
            _PillarPageSoftwareDevelopment.AssertAreEqual(expectedTitle, _PillarPageSoftwareDevelopment.Driver.Title);
            _PillarPageSoftwareDevelopment.Driver.Quit();
        }

        [When("PillarSoftwareDevelopment: I go to {string} and use the search button")]
        public void WhenPillarSoftwareDevelopmentUseSearchButton(string url)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(url);
            _PillarPageSoftwareDevelopment.SetUpPage();
            _PillarPageSoftwareDevelopment.CLickSearchNavBarButton();
        }

        [When("PillarSoftwareDevelopment: I go to {string} and use the home button")]
        public void WhenPillarSoftwareDevelopmentUseHomeButton(string url)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(url);
            _PillarPageSoftwareDevelopment.SetUpPage();
            _PillarPageSoftwareDevelopment.ClickHomeNavBarButton();
        }

        [When("PillarSoftwareDevelopment: I go to {string} and use the Linkedin button")]
        public void WhenPillarSoftwareDevelopmentpageUseLinkedinButton(string url)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(url);
            _PillarPageSoftwareDevelopment.SetUpPage();
            _PillarPageSoftwareDevelopment.ClickLinkedinButton();
        }

        [Then("PillarSoftwareDevelopment: I have arrived at linkedin")]
        public void ThenPillarSoftwareDevelopmentArrivedAtLinkedin()
        {
            _PillarPageSoftwareDevelopment.WaitUntilURLContainsValue("https://www.linkedin.com/");
            _PillarPageSoftwareDevelopment.AssertAreEqual(_PillarPageSoftwareDevelopment.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
            _PillarPageSoftwareDevelopment.Driver.Quit();
        }

        [When("PillarSoftwareDevelopment: I go to {string} and use the logo button")]
        public void WhenPillarSoftwareDevelopmentUseLogoButton(string url)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(url);
            _PillarPageSoftwareDevelopment.SetUpPage();
            _PillarPageSoftwareDevelopment.ClickLogoButton();
        }

        [When("PillarSoftwareDevelopment: I go to {string} and use the Github button")]
        public void WhenPillarSoftwareDevelopmentIGoToAndUseTheGithubButton(string p0)
        {
            _PillarPageSoftwareDevelopment.NavigateToPage(p0);
            _PillarPageSoftwareDevelopment.SetUpPage();
            _PillarPageSoftwareDevelopment.ClickGithubButton();
        }

        [Then("PillarSoftwareDevelopment: I have arrived at Github")]
        public void ThenPillarSoftwareDevelopmentIHaveArrivedAtGithub()
        {
            _PillarPageSoftwareDevelopment.WaitUntilURLContainsValue("https://github.com/");
            _PillarPageSoftwareDevelopment.AssertAreEqual(_PillarPageSoftwareDevelopment.Driver.Url, "https://github.com/LewisWhittard");
            _PillarPageSoftwareDevelopment.Driver.Quit();
        }
    }
}
