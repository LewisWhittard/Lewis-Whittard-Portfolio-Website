using OpenQA.Selenium;
using LMWSelenium.PageModels.StandardPage;

namespace LMWSelenium.PageModels.PageModels
{
	class SearchPage : PageModelBase
	{
		public IWebElement SearchBox { get; private set; }
		public IWebElement SearchButton { get; private set; }
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
            LMWLogo = FindElementById("LogoLink");
            Linkedin = FindElementById("Linkedin");
			HomeNavBarButton = FindElementById("HomeNavBarButton");
			SearchNavBarButton = FindElementById("SearchNavBarButton");
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
