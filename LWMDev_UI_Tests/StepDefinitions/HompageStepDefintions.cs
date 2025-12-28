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
		private SearchPage _searchPage;


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

		[When("Homepage: I go to {string} and use the programming button")]
		public void WhenHomepageUseProgrammingButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickProgrammingButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the programming tickbox ticked")]
		public void ThenHomepageProgrammingTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.CheckProgrammingButtonPost();
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the testing button")]
		public void WhenHomepageUseTestingButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickTestButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the testing tickbox ticked")]
		public void ThenHomepageTestingTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.CheckTestingButtonPost();
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the games button")]
		public void WhenHomepageUseGamesButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickGamesButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the games tickbox ticked")]
		public void ThenHomepageGamesTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.CheckGamesButtonPost();
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the Blog button")]
		public void WhenHomepageUseBlogButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickBlogButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the Blog tickbox ticked")]
		public void ThenHomepageBlogTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.BlogButtonPost();
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the TwoD Assets button")]
		public void WhenHomepageUseTwoDAssetsButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickTwoDAssetsButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the TwoD Assets tickbox ticked")]
		public void ThenHomepageTwoDAssetsTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.CheckTwoDButtonPost();
			_homePage.Driver.Quit();
		}

		[When("Homepage: I go to {string} and use the ThreeD Assets button")]
		public void WhenHomepageUseThreeDAssetsButton(string url)
		{
			_homePage.NavigateToPage(url);
			_homePage.SetUpPage();
			_homePage.ClickThreeDAssetsButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

		[Then("Homepage: I have arrived at the search page with the ThreeD Assets tickbox ticked")]
		public void ThenHomepageThreeDAssetsTickboxChecked()
		{
			_searchPage.SetUpPage();
			_searchPage.CheckThreeDButtonPost();
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
