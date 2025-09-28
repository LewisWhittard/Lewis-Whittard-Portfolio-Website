using OpenQA.Selenium;
using LMWSelenium.PageModels.StandardPage;

namespace LMWSelenium.PageModels.PageModels
{
	class HomePage : PageModelBase
	{
		public IWebElement HomeNavBarButton { get; private set; }
		public IWebElement SearchNavBarButton { get; private set; }
		public IWebElement ProgrammingButton { get; private set; }
		public IWebElement TestingButton { get; private set; }
		public IWebElement GamesButton { get; private set; }
		public IWebElement ThreeDAssetsButton { get; private set; }
		public IWebElement TwoDBAssetsButton { get; private set; }
		public IWebElement BlogButton { get; private set; }
		public IWebElement LMWLogo { get; private set; }
		public IWebElement Linkedin { get; private set; }
		

		public HomePage(IWebDriver driver)
		{
            Driver = driver;
		}

		public void SetUpPage()
		{
            HomeNavBarButton = FindElementById("HomeNavBarButton");
            SearchNavBarButton = FindElementById("SearchNavBarButton");
            ProgrammingButton = FindElementById("ProgrammingButton");
            TestingButton = FindElementById("TestingButton");
            GamesButton = FindElementById("GamesButton");
            ThreeDAssetsButton = FindElementById("ThreeDAssetsButton");
            TwoDBAssetsButton = FindElementById("TwoDAssetsButton");
            BlogButton = FindElementById("BlogButton");
            LMWLogo = FindElementById("LogoLink");
            Linkedin = FindElementById("Linkedin");
        }

        public void NavigateToHomepage(string url)
        {
			NavigateToPage(url);
        }

        public void ClickHomeNavBarButton()
		{
			ClickButton(HomeNavBarButton);
		}

		public void CLickSearchNavBarButton()
		{
			ClickButton(SearchNavBarButton);
			WaitUntilURLContainsValue("search");
			WaitUntilTitleContainsValue("Search");
		}

		public void ClickProgrammingButton()
		{
			ClickButton(ProgrammingButton);
			WaitUntilURLContainsValue("Search?GamesCategory=False&ProgrammingCategory=True&TestingCategory=False&ThreeDAssetsCategory=False&TwoDAssetCategory=False&BlogCategory=False&Meta=False");
		}

		public void ClickTestButton()
		{
			ClickButton(TestingButton);
			WaitUntilURLContainsValue("Search?GamesCategory=False&ProgrammingCategory=False&TestingCategory=True&ThreeDAssetsCategory=False&TwoDAssetCategory=False&BlogCategory=False&Meta=False");
		}

		public void TestGamesButton(IWebDriver driver)
		{
			ClickButton(GamesButton);
			WaitUntilURLContainsValue("Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");
		}

		public void TestTwoDAssetsButton(IWebDriver driver)
		{
			ClickButton(TwoDBAssetsButton);
			WaitUntilURLContainsValue("Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");
		}

		public void TestThreeDAssetsButton(IWebDriver driver)
		{
			ClickButton(ThreeDAssetsButton);
			WaitUntilURLContainsValue("Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");
		}

		public void TestBlogButton(IWebDriver driver)
		{
			ClickButton(BlogButton);
			WaitUntilURLContainsValue("Modified");
			WaitUntilTitleContainsValue("Modified");
			AssertAreEqual(driver.Title, "Search Modified - Lewis Whittard Software Development");
		}

		public void TestLogoButton(IWebDriver driver)
		{
			ClickButton(LMWLogo);
			AssertAreEqual(driver.Title, "Home Page - Lewis Whittard Software Development");
		}

		public void ClickLinkedinButton()
		{
			ClickButton(Linkedin);
			CloseDriver();
			SwitchTab(Driver, 0);
		}

	}
}
