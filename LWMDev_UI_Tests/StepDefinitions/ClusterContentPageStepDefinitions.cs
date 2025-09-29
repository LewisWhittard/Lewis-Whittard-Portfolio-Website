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
    public class ClusterContentPageStepDefinitions
    {
		private ClusterContentPageModel _clusterContentPageModel;
		private SearchPage _searchPage;

		[Given("ClusterContent: I use Browser {string}")]
		public void GivenIUseBrowser(string browser)
		{
			switch (browser)
			{
				case "chrome":
					_clusterContentPageModel = new ClusterContentPageModel(new ChromeDriver());
					break;
				case "firefox":
					_clusterContentPageModel = new ClusterContentPageModel(new FirefoxDriver());
					break;
				case "edge":
					_clusterContentPageModel = new ClusterContentPageModel(new EdgeDriver());
					break;
				case "safari":
					_clusterContentPageModel = new ClusterContentPageModel(new SafariDriver());
					break;
				default:
					throw new ArgumentException($"Unsupported browser: {browser}");
			}

		}

		[When("ClusterContent: I go to {string}")]
		public void WhenIGoTo(string p0)
		{
			_clusterContentPageModel.NavigateToPage(p0);
		}


		[Then("ClusterContent: the page title is {string}")]
		public void ThenThePageTitleIs(string p0)
		{
			_clusterContentPageModel.AssertAreEqual(p0, _clusterContentPageModel.Driver.Title);
			_clusterContentPageModel.Driver.Quit();
		}

		[When("ClusterContent: I go to {string} and use the search button")]
		public void WhenIGoToAndUseTheSearchButton(string p0)
		{
			_clusterContentPageModel.NavigateToPage(p0);
			_clusterContentPageModel.SetUpPage();
			_clusterContentPageModel.CLickSearchNavBarButton();
		}

		[When("ClusterContent: I go to {string} and use the home button")]
		public void WhenIGoToAndUseTheHomeButton(string p0)
		{
			_clusterContentPageModel.NavigateToPage(p0);
			_clusterContentPageModel.SetUpPage();
			_clusterContentPageModel.ClickHomeNavBarButton();

		}

		[When("ClusterContent: I go to {string} and use the Linkedin button")]
		public void WhenIGoToAndUseTheLinkedinButton(string p0)
		{
			_clusterContentPageModel.NavigateToPage(p0);
			_clusterContentPageModel.SetUpPage();
			_clusterContentPageModel.ClickLinkedinButton();
		}

		[Then("ClusterContent: I have arrived at linkedin")]
		public void ThenIHaveArrivedAtLinkedin()
		{
			_clusterContentPageModel.WaitUntilURLContainsValue("https://www.linkedin.com/");
			_clusterContentPageModel.AssertAreEqual(_clusterContentPageModel.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
			_clusterContentPageModel.Driver.Quit();

		}

		[When("ClusterContent: I go to {string} and use the logo button")]
		public void WhenIGoToAndUseTheLogoButton(string p0)
		{
			_clusterContentPageModel.NavigateToPage(p0);
			_clusterContentPageModel.SetUpPage();
			_clusterContentPageModel.ClickLogoButton();
		}

	}
}
