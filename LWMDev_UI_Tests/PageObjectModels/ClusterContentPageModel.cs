using OpenQA.Selenium;
using LMWSelenium.PageModels.StandardPage;

namespace LMWSelenium.PageModels.PageModels
{
	class ClusterContentPageModel : PageModelBase
	{
		public IWebElement HomeNavBarButton { get; private set; }
		public IWebElement SearchNavBarButton { get; private set; }
		public IWebElement LMWLogo { get; private set; }
		public IWebElement Linkedin { get; private set; }
		

		public ClusterContentPageModel(IWebDriver driver)
		{
            Driver = driver;
		}

		public void SetUpPage()
		{
            HomeNavBarButton = FindElementById("HomeNavBarButton");
            SearchNavBarButton = FindElementById("SearchNavBarButton");
            LMWLogo = FindElementById("LogoLink");
            Linkedin = FindElementById("Linkedin");
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

	}
}
