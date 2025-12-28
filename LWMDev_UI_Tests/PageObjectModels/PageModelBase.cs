using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LMWSelenium.PageModels.StandardPage
{
	abstract class PageModelBase
	{
        public IWebDriver Driver { get; private protected set; }

        public void NavigateToPage(String url)
		{
			Driver.Navigate().GoToUrl(url);
		}

		public void WaitUntilURLContainsValue(string value)
		{
			var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
						.Until(drv => drv.Url.Contains(value));

		}

		public void WaitUntilTitleContainsValue(string value)
		{
			var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
						.Until(drv => drv.Title.Contains(value));

		}

		public IWebElement FindElementById(string id)
		{
			IWebElement ReturnElement;

			
			
			try
			{
				var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
						.Until(drv => drv.FindElement(By.Id(id)));

				ReturnElement = Driver.FindElement(By.Id(id));
			}
			catch (Exception)
			{

				throw;
			}
			

			return ReturnElement;
		}

        public void DontFindElementById(string id)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

            bool elementNotFound = wait.Until(driver =>
            {
                try
                {
                    driver.FindElement(By.Id(id));
                    return false; // Element is still present
                }
                catch (NoSuchElementException)
                {
                    return true; // Element is not found
                }
            });

            if (!elementNotFound)
            {
                throw new InvalidOperationException("Failed to not find element");
            }
        }

        public void CloseDriver()
		{
			Driver.Close();
		}

		public void QuitDriver()
		{
			Driver.Quit();
		}
		
		public void AssertAreEqual(string valueOne, string valueTwo)
		{
			if (valueOne != valueTwo)
            { 
				throw new InvalidOperationException("Values are not equal");
            }


        }

		public void ClickButton(IWebElement button)
		{
			button.Click();
		}

		public string CheckTickBoxValueIsTrue(IWebElement tickbox)
		{
			string TickboxValue = tickbox.GetAttribute("checked");

			AssertAreEqual(TickboxValue, "true");

			return TickboxValue;
		}

		public string CheckTickBoxValueIsFalse(IWebElement tickbox)
		{
			string TickboxValue = tickbox.GetAttribute("checked");

			AssertAreEqual(TickboxValue, null);

			return TickboxValue;
		}

		public void SendTextToInput(IWebElement Target, string String)
		{
			Target.SendKeys(String);
		}

		public void SwitchTab(IWebDriver driver, int Tab)
		{
			driver.SwitchTo().Window(driver.WindowHandles[Tab]);
		}

		

		public void AssertContains(string Value1,string Value2)
		{
			bool CheckValue = Value1.Contains(Value2);

			if (CheckValue == false)
			{
				throw new InvalidOperationException("Does not Contain");
			}
			
		}

        public void WaitUntilElementIsStale(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                try
                {
                    // Accessing any property will throw if the element is stale
                    var displayed = element.Displayed;
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }

        public void SelectDropdownOption(IWebElement dropdownElement, string visibleText)
        {
            var select = new SelectElement(dropdownElement);
            select.SelectByText(visibleText);
        }
    }
}
