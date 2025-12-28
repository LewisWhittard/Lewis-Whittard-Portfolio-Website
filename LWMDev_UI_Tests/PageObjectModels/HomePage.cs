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

		public void ClickGamesButton()
		{
			ClickButton(GamesButton);
			WaitUntilURLContainsValue("Search?GamesCategory=True&ProgrammingCategory=False&TestingCategory=False&ThreeDAssetsCategory=False&TwoDAssetCategory=False&BlogCategory=False&Meta=False");
		}

		public void ClickTwoDAssetsButton()
		{
			ClickButton(TwoDBAssetsButton);
			WaitUntilURLContainsValue("Search?GamesCategory=False&ProgrammingCategory=False&TestingCategory=False&ThreeDAssetsCategory=False&TwoDAssetCategory=True&BlogCategory=False&Meta=False");
		}

		public void ClickThreeDAssetsButton()
		{
			{
				ClickButton(ThreeDAssetsButton);
				WaitUntilURLContainsValue("Search?GamesCategory=False&ProgrammingCategory=False&TestingCategory=False&ThreeDAssetsCategory=True&TwoDAssetCategory=False&BlogCategory=False&Meta=False");
			}
		}

		public void ClickBlogButton()
		{
			{
				ClickButton(BlogButton);
				WaitUntilURLContainsValue("Search?GamesCategory=False&ProgrammingCategory=False&TestingCategory=False&ThreeDAssetsCategory=False&TwoDAssetCategory=False&BlogCategory=True&Meta=False");
			}
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

	}
}
