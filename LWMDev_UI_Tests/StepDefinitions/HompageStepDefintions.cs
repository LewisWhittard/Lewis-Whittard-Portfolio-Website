using LMWSelenium.PageModels.PageModels;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace LWMDev_UI_Tests.StepDefinitions
{
    [Binding]
    public class HompageStepDefintions
    {
        private HomePage _homePage;
        private SearchPage _searchPage;

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

        [When("I go to {string} and use the search button")]
        public void WhenIGoToAndUseTheSearchButton(string p0)
        {
            _homePage.NavigateToHomepage(p0);
            _homePage.SetUpPage();
            _homePage.CLickSearchNavBarButton();
        }

        [When("I go to {string} and use the home button")]
        public void WhenIGoToAndUseTheHomeButton(string p0)
        {
            _homePage.NavigateToHomepage(p0);
            _homePage.SetUpPage();

        }

        [When("I go to {string} and use the Linkedin button")]
        public void WhenIGoToAndUseTheLinkedinButton(string p0)
        {
            _homePage.NavigateToHomepage(p0);
            _homePage.SetUpPage();
            _homePage.ClickLinkedinButton();
        }

        [Then("I have arrived at linkedin")]
        public void ThenIHaveArrivedAtLinkedin()
        {
            _homePage.WaitUntilURLContainsValue("https://www.linkedin.com/");
            _homePage.AssertAreEqual(_homePage.Driver.Url, "https://www.linkedin.com/in/lewis-whittard-092167157/");
        }

        [When("I go to {string} and use the programming button")]
        public void WhenIGoToAndUseTheProgrammingButton(string p0)
        {
            _homePage.NavigateToHomepage(p0);
            _homePage.SetUpPage();
            _homePage.ClickProgrammingButton();
            _searchPage = new SearchPage(_homePage.Driver);
        }

        [Then("I have arrived at the search page with the programming tickbox ticked")]
        public void ThenIHaveArrivedAtTheSearchPageWithTheProgrammingTickboxTicked()
        {
            _searchPage.SetUpPage();
            _searchPage.CheckProgrammingButtonPost();
        }


        [When("I go to {string} and use the testing button")]
        public void WhenIGoToAndUseTheTestingButton(string p0)
        {
			_homePage.NavigateToHomepage(p0);
			_homePage.SetUpPage();
			_homePage.ClickTestButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

        [Then("I have arrived at the search page with the testing tickbox ticked")]
        public void ThenIHaveArrivedAtTheSearchPageWithTheTestingTickboxTicked()
        {
			_searchPage.SetUpPage();
			_searchPage.CheckTestingButtonPost();
		}

        [When("I go to {string} and use the games button")]
        public void WhenIGoToAndUseTheGamesButton(string p0)
        {
			_homePage.NavigateToHomepage(p0);
			_homePage.SetUpPage();
			_homePage.ClickGamesButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

        [Then("I have arrived at the search page with the games tickbox ticked")]
        public void ThenIHaveArrivedAtTheSearchPageWithTheGamesTickboxTicked()
        {
			_searchPage.SetUpPage();
			_searchPage.CheckGamesButtonPost();
		}

        [When("I go to {string} and use the {int}D Assets button")]
        public void WhenIGoToAndUseTheDAssetsButton(string p0, int p1)
        {
			_homePage.NavigateToHomepage(p0);
			_homePage.SetUpPage();
			_homePage.ClickGamesButton();
			_searchPage = new SearchPage(_homePage.Driver);
		}

        [Then("I have arrived at the search page with the {int}D Assets tickbox ticked")]
        public void ThenIHaveArrivedAtTheSearchPageWithTheDAssetsTickboxTicked(int p0)
        {
			_searchPage.SetUpPage();
			_searchPage.CheckThreeDButtonPost();
		}

        [When("I go to {string} and use the Blog button")]
        public void WhenIGoToAndUseTheBlogButton(string p0)
        {
            throw new PendingStepException();
        }

        [Then("I have arrived at the search page with the Blog tickbox ticked")]
        public void ThenIHaveArrivedAtTheSearchPageWithTheBlogTickboxTicked()
        {
			_searchPage.SetUpPage();
			_searchPage.BlogButtonPost();
		}


    }
}
