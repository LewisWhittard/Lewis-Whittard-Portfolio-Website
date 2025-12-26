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
	public class HomepageStepDefinitions
	{
		private HomePage _homePage;


		[Given("Homepage: I use Browser {string}")]
		public void GivenHomepageIUseBrowser(string browser)
		{
			switch (browser.ToLower())
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

		[When("Homepage: I go to {string}")]
		public void WhenHomepageIGoTo(string url)
		{
			_homePage.NavigateToPage(url);
		}

		[Then("Homepage: the page title is {string}")]
		public void ThenHomepagePageTitleIs(string expectedTitle)
		{
			_homePage.AssertAreEqual(expectedTitle, _homePage.Driver.Title);
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the search button")]
		public void WhenHomepageUseSearchButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.CLickSearchNavBarButton();
		}

		[When("Homepage: I go to {string} and use the home button")]
		public void WhenHomepageUseHomeButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
		}

		[When("Homepage: I go to {string} and use the Linkedin button")]
		public void WhenHomepageUseLinkedinButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickLinkedinButton();
		}

		[Then("Homepage: I have arrived at linkedin")]
		public void ThenHomepageArrivedAtLinkedin()
		{
			_homePage.WaitUntilURLContainsValue("https://www.linkedin.com/");
			_homePage.AssertAreEqual(_homePage.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the logo button")]
		public void WhenHomepageUseLogoButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickLogoButton();
		}
	}
}
