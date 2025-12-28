using LMWSelenium.PageModels.PageModels;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace LWMDev_UI_Tests.StepDefinitions
{
    [Binding]
    public class SearchPageStepDefinitions
    {
        private SearchPage _searchPage;

		[Given("SearchPage: I use Browser {string}")]
        public void GivenSearchPageIUseBrowser(string browser)
        {
			switch (browser.ToLower())
			{
				case "chrome":
					_searchPage = new SearchPage(new ChromeDriver());
					break;
				case "firefox":
					_searchPage = new SearchPage(new FirefoxDriver());
					break;
				case "edge":
					_searchPage = new SearchPage(new EdgeDriver());
					break;
				case "safari":
					_searchPage = new SearchPage(new SafariDriver());
					break;
				default:
					throw new ArgumentException($"Unsupported browser: {browser}");
			}
		}

		[When("SearchPage: I go to {string}")]
		public void WhenIGoTo(string p0)
		{
			_searchPage.NavigateToPage(p0);
		}


		[Then("SearchPage: the page title is {string}")]
		public void ThenThePageTitleIs(string p0)
		{
			_searchPage.AssertAreEqual(p0, _searchPage.Driver.Title);
			_searchPage.Driver.Quit();
		}

		[When("SearchPage: I go to {string} and use the search button")]
		public void WhenIGoToAndUseTheSearchButton(string p0)
		{
			_searchPage.NavigateToPage(p0);
			_searchPage.SetUpPage();
			_searchPage.CLickSearchNavBarButton();
		}

		[When("SearchPage: I go to {string} and use the home button")]
		public void WhenIGoToAndUseTheHomeButton(string p0)
		{
			_searchPage.NavigateToPage(p0);
			_searchPage.SetUpPage();
			_searchPage.ClickHomeNavBarButton();

		}

		[When("SearchPage: I go to {string} and use the Linkedin button")]
		public void WhenIGoToAndUseTheLinkedinButton(string p0)
		{
			_searchPage.NavigateToPage(p0);
			_searchPage.SetUpPage();
			_searchPage.ClickLinkedinButton();
		}

		[Then("SearchPage: I have arrived at linkedin")]
		public void ThenIHaveArrivedAtLinkedin()
		{
			_searchPage.WaitUntilURLContainsValue("https://www.linkedin.com/");
			_searchPage.AssertAreEqual(_searchPage.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
			_searchPage.Driver.Quit();

		}

		[When("SearchPage: I go to {string} and use the logo button")]
		public void WhenIGoToAndUseTheLogoButton(string p0)
		{
			_searchPage.NavigateToPage(p0);
			_searchPage.SetUpPage();
			_searchPage.ClickLogoButton();
		}

		[Then("SearchPage: all search items should be visible")]
		public void ThenAllSearchItemsShouldBeVisible()
		{
			_searchPage.FindElementById("SearchResultButton-from-reflection-to-action-the-marginal-gains-sprint");
			_searchPage.FindElementById("SearchResultButton-cogetta");
			_searchPage.FindElementById("SearchResultButton-ui-test-automation-portfolio-piece");
			_searchPage.FindElementById("SearchResultButton-my-portfolio-website-development");
			_searchPage.FindElementById("SearchResultButton-lewis-matthew-whittard-software-development-logo");
            _searchPage.FindElementById("SearchResultButton-portfolio-website-completed");
            _searchPage.QuitDriver();
		}

        [When("SearchPage: I go to {string} and use the Github button")]
        public void WhenSearchPageIGoToAndUseTheGithubButton(string p0)
        {
            _searchPage.NavigateToPage(p0);
            _searchPage.SetUpPage();
            _searchPage.ClickGithubButton();
        }

        [Then("SearchPage: I have arrived at Github")]
        public void ThenSearchPageIHaveArrivedAtGithub()
        {
            _searchPage.WaitUntilURLContainsValue("https://github.com/");
            _searchPage.AssertAreEqual(_searchPage.Driver.Url, "https://github.com/LewisWhittard");
            _searchPage.Driver.Quit();
        }

        [When("SearchPage: I go to {string} and use the Software Development button")]
        public void WhenSearchPageIGoToAndUseTheSoftwareDevelopmentButton(string p0)
        {
            _searchPage.NavigateToPage(p0);
            _searchPage.SetUpPage();
            _searchPage.ClickSoftwareDevelopmentNavBarButton();
        }

        [When("SearchPage: I go to {string} and use the Creative Works button")]
        public void WhenSearchPageIGoToAndUseTheCreativeWorksButton(string p0)
        {
            _searchPage.NavigateToPage(p0);
            _searchPage.SetUpPage();
            _searchPage.ClickCreativeWorksNavBarButton();
        }

    }
}
