using OpenQA.Selenium;
using LMWSelenium.PageModels.StandardPage;
using OpenQA.Selenium.Support.UI;


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
		public IWebElement Github { get; private set; }
        public IWebElement SoftwareDevelopmentNavBarButton { get; private set; }
        public IWebElement CreativeWorksNavBarButton { get; private set; }
		public IWebElement SearchDropDown { get; private set; }

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
			Github = FindElementById("Github");
            SoftwareDevelopmentNavBarButton = FindElementById("SoftwareDevelopmentNavBarButton");
            CreativeWorksNavBarButton = FindElementById("CreativeWorksNavBarButton");
			SearchDropDown = FindElementById("Category");
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

        public void ClickGithubButton()
        {
            ClickButton(Github);
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

        public void ClickSoftwareDevelopmentNavBarButton()
        {
            ClickButton(SoftwareDevelopmentNavBarButton);
            WaitUntilURLContainsValue("software-development");
            WaitUntilTitleContainsValue("Software Development");
        }

        public void ClickCreativeWorksNavBarButton()
        {
            ClickButton(CreativeWorksNavBarButton);
            WaitUntilURLContainsValue("creative-works");
            WaitUntilTitleContainsValue("Creative Works");
        }

		public void PopluateSearchDropDown(string value)
		{
			this.SelectDropdownOption(SearchDropDown,value);
		}

    }
}
