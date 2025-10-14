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
			_searchPage.FindElementById("SearchResult 0");
			_searchPage.FindElementById("SearchResult 1");
			_searchPage.FindElementById("SearchResult 2");
			_searchPage.FindElementById("SearchResult 3");
			_searchPage.FindElementById("SearchResult 4");
			_searchPage.QuitDriver();
		}

		[When("SearchPage: I untick all the search boxes and search")]
		public void WhenSearchPageIUntickAllTheSearchBoxesAndSearch()
		{
			_searchPage.SetUpPage();
			_searchPage.ClickProgrammingTickBox();
			_searchPage.ClickTwoDAssetsTickBox();
			_searchPage.ClickBlogTickBox();
			_searchPage.ClickGamesTickBox();
			_searchPage.ClickThreeDAssetsTickBox();
			_searchPage.ClickTestingTickBox();
			_searchPage.ClickSearchButton();

		}

		[When("SearchPage: and search")]
		public void WhenSearchPageAndSearch()
		{
			_searchPage.SetUpPage();
			_searchPage.ClickSearchButton();
		}


		[Then("SearchPage: No search items should be visible")]
		public void ThenSearchPageNoSearchItemsShouldBeVisible()
		{
			_searchPage.DontFindElementById("SearchResult 0");
			_searchPage.DontFindElementById("SearchResult 1");
			_searchPage.DontFindElementById("SearchResult 2");
			_searchPage.DontFindElementById("SearchResult 3");
			_searchPage.DontFindElementById("SearchResult 4");
			_searchPage.QuitDriver();
		}


		[Then("SearchPage: search items should be filtered by tick box")]
		public void ThenResultsAreFilteredByTheTickBox()
		{
			_searchPage.DontFindElementById("SearchResult 0");
			_searchPage.DontFindElementById("SearchResult 1");
			_searchPage.FindElementById("SearchResult 2");
			_searchPage.DontFindElementById("SearchResult 3");
			_searchPage.FindElementById("SearchResult 4");
			_searchPage.QuitDriver();
		}

		[Then("SearchPage: search items should be filtered by search box")]
		public void ThenResultsAreFilteredByTheSearchBox()
		{
			_searchPage.DontFindElementById("SearchResult 0");
			_searchPage.DontFindElementById("SearchResult 1");
			_searchPage.DontFindElementById("SearchResult 2");
			_searchPage.DontFindElementById("SearchResult 3");
			_searchPage.FindElementById("SearchResult 4");
			_searchPage.QuitDriver();
		}

        [Then("SearchPage: I click a {string} result and go through to the page {string}")]
        public void ThenSearchPageIClickAResultAndGoThroughToThePage(string p0, string p1)
        {
			_searchPage.SetUpPage();
            var searchItem = _searchPage.FindElementById(p0);
            _searchPage.ClickButton(searchItem);
            _searchPage.WaitUntilURLContainsValue(p1);
            _searchPage.QuitDriver();
        }

        [When("SearchPage: I untick all the search boxes")]
        public void WhenSearchPageIUntickAllTheSearchBoxes()
        {
			_searchPage.SetUpPage();
            _searchPage.ClickProgrammingTickBox();
            _searchPage.ClickTwoDAssetsTickBox();
            _searchPage.ClickBlogTickBox();
            _searchPage.ClickGamesTickBox();
            _searchPage.ClickThreeDAssetsTickBox();
            _searchPage.ClickTestingTickBox();
        }

		[When("SearchPage: I click programming And Search")]
		public void WhenSearchPageIClickProgrammingAndSearch()
		{
			_searchPage.ClickProgrammingTickBox();
			_searchPage.ClickSearchButton();
		}

        [When("SearchPage: Search by the term Cogetta")]
        public void WhenSearchPageSearchByTheTermCogetta()
        {
            _searchPage.SetUpPage();
            _searchPage.Search("Cogetta");
            _searchPage.ClickSearchButton();
        }
    }
}
