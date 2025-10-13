using OpenQA.Selenium;
using LMWSelenium.PageModels.StandardPage;

namespace LMWSelenium.PageModels.PageModels
{
	class SearchPage : PageModelBase
	{
		public IWebElement SearchBox { get; private set; }
		public IWebElement SearchButton { get; private set; }
		public IWebElement ProgrammingTickBox { get; private set; }
		public IWebElement TestingTickBox { get; private  set; }
		public IWebElement GamesTickBox { get; private set; }
		public IWebElement ThreeDAssetsTickBox { get; private set; }
		public IWebElement TwoDAssetsTickBox { get; private set; }
		public IWebElement BlogTickBox { get; private set; }
		public IWebElement LMWLogo { get; private set; }
		public IWebElement Linkedin { get; private set; }
		public IWebElement HomeNavBarButton { get; private set; }
		public IWebElement SearchNavBarButton { get; private set; }

		public SearchPage(IWebDriver driver)
		{
			Driver = driver;


		}

		public void SetUpPage()
		{
            SearchBox = FindElementById("Search");
            SearchButton = FindElementById("SearchButton");
            ProgrammingTickBox = FindElementById("ProgrammingCategory");
            TwoDAssetsTickBox = FindElementById("TwoDAssetCategory");
            ThreeDAssetsTickBox = FindElementById("ThreeDAssetsCategory");
            TestingTickBox = FindElementById("TestingCategory");
            GamesTickBox = FindElementById("GamesCategory");
            BlogTickBox = FindElementById("BlogCategory");
            LMWLogo = FindElementById("LogoLink");
            Linkedin = FindElementById("Linkedin");
			HomeNavBarButton = FindElementById("HomeNavBarButton");
			SearchNavBarButton = FindElementById("SearchNavBarButton");
		}

		public void CheckSearchButtonPost()
		{
			CheckTickBoxValueIsTrue(ProgrammingTickBox);
			CheckTickBoxValueIsTrue(TestingTickBox);
			CheckTickBoxValueIsTrue(GamesTickBox);
			CheckTickBoxValueIsTrue(ThreeDAssetsTickBox);
			CheckTickBoxValueIsTrue(TwoDAssetsTickBox);
			CheckTickBoxValueIsTrue(BlogTickBox);
		}

		public void CheckAllTickboxValuesAreFalse()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);
		}

		public void CheckProgrammingButtonPost()
		{
			CheckTickBoxValueIsTrue(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);

		}

		public void CheckTestingButtonPost()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsTrue(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);
		}

		public void CheckGamesButtonPost()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsTrue(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);
		}

		public void CheckThreeDButtonPost()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsTrue(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);
		}

		public void CheckTwoDButtonPost()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsTrue(TwoDAssetsTickBox);
			CheckTickBoxValueIsFalse(BlogTickBox);
		}

		public void BlogButtonPost()
		{
			CheckTickBoxValueIsFalse(ProgrammingTickBox);
			CheckTickBoxValueIsFalse(TestingTickBox);
			CheckTickBoxValueIsFalse(GamesTickBox);
			CheckTickBoxValueIsFalse(ThreeDAssetsTickBox);
			CheckTickBoxValueIsFalse(TwoDAssetsTickBox);
			CheckTickBoxValueIsTrue(BlogTickBox);
		}

		public void SearchTestAllTickBoxesTrueResult(IWebDriver driver)
		{
			SendTextToInput(SearchBox, "Part 1 of My Portfolio Completed!");
			CheckSearchButtonPost();
			ClickButton(SearchButton);
			WaitUntilURLContainsValue("Modified");
			WaitUntilTitleContainsValue( "Modified");
			AssertAreEqual("Search Modified - Lewis Whittard Software Development", driver.Title);
		}

		public void SearchTestAllTickBoxesTrueResultPost(IWebDriver driver)
		{
			CheckSearchButtonPost();
			IWebElement ResultButton = FindElementById( "0Button");
			ClickButton(ResultButton);
			WaitUntilURLContainsValue("PortfolioPiece");
			WaitUntilTitleContainsValue( "Portfolio Piece");
			AssertAreEqual(driver.Title, "Portfolio Piece - Lewis Whittard Software Development");

		}



		public void SearchTestAllTickBoxesTrueNoResult(IWebDriver driver)
		{
			CheckSearchButtonPost();
			SendTextToInput(SearchBox, "no result");
			ClickButton(SearchButton);
			WaitUntilURLContainsValue( "Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");



		}

		public void SearchTestAllTicketBoxesTrueNoResultPost(IWebDriver driver)
		{
			CheckSearchButtonPost();
			AssertAreEqual(SearchBox.GetAttribute("value"), "no result");
			DontFindElementById("0Button");
		}

		public void SearchTestAllTickBoxesFalse()
		{
			ClickButton(ProgrammingTickBox);
			ClickButton(TestingTickBox);
			ClickButton(GamesTickBox);
			ClickButton(ThreeDAssetsTickBox);
			ClickButton(TwoDAssetsTickBox);
			ClickButton(BlogTickBox);
		}

		public void SearchTestAllTickBoxesTrue(IWebDriver driver)
		{
			SendTextToInput(SearchBox, "Part 1 of My Portfolio Completed!");
			ClickButton(ProgrammingTickBox);
			ClickButton(TestingTickBox);
			ClickButton(GamesTickBox);
			ClickButton(ThreeDAssetsTickBox);
			ClickButton(TwoDAssetsTickBox);
			ClickButton(BlogTickBox);
			ClickButton(SearchButton);
			WaitUntilURLContainsValue( "Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");
		}

		public void SearchTestAllTickBoxesFalsePost(IWebDriver driver)
		{
			CheckAllTickboxValuesAreFalse();
			AssertAreEqual(SearchBox.GetAttribute("value"), "Part 1 of My Portfolio Completed!");
			DontFindElementById("0Button");
		}

		public void CheckAllTickBoxesAreStale(IWebDriver driver)
		{
			WaitUntilElementIsStale(ProgrammingTickBox);
			WaitUntilElementIsStale(TestingTickBox);
			WaitUntilElementIsStale(GamesTickBox);
			WaitUntilElementIsStale(ThreeDAssetsTickBox);
			WaitUntilElementIsStale(TwoDAssetsTickBox);
			WaitUntilElementIsStale(BlogTickBox);
		}

		public void ClickHomeNavBarButton()
		{
			ClickButton(HomeNavBarButton);
			WaitUntilTitleContainsValue("Home Page - Lewis Whittard Software Development");
		}

		public void CLickSearchNavBarButton()
		{
			ClickButton(SearchNavBarButton);
			WaitUntilURLContainsValue("search");
			WaitUntilTitleContainsValue("Search");
		}

		public void ClickLogoButton()
		{
			ClickButton(LMWLogo);
		}

		public void ClickLinkedinButton()
		{
			ClickButton(Linkedin);
			CloseDriver();
			SwitchTab(Driver, 0);
		}

		public void ClickProgrammingTickBox()
		{
			ClickButton(ProgrammingTickBox);
		}

		public void ClickTestingTickBox()
		{
			ClickButton(TestingTickBox);
		}

		public void ClickGamesTickBox()
		{
			ClickButton(GamesTickBox);
		}

		public void ClickThreeDAssetsTickBox()
		{
			ClickButton(ThreeDAssetsTickBox);
		}

		public void ClickTwoDAssetsTickBox()
		{
			ClickButton(TwoDAssetsTickBox);
		}

		public void ClickBlogTickBox()
		{
			ClickButton(BlogTickBox);
		}

		public void ClickSearchButton()
		{
			ClickButton(SearchButton);
		}

		public void Search(string searchTerm)
		{
			SendTextToInput(SearchBox, searchTerm);
		}
	}
}
