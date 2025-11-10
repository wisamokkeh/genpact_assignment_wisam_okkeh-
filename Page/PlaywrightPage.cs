using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutomationWiki.Page
{
    public class PlaywrightPage
    {
        private readonly IWebDriver _driver;
        public PlaywrightPage(IWebDriver driver) {
            _driver = driver;
        }

        public string GetSectionWebText() {
          var heading = _driver.FindElement(By.Id("Debugging_features"));
          var paragraph = _driver.FindElement(By.XPath("//h3[@id='Debugging_features']//parent::div//following-sibling::p[1]"));
          var listItems = _driver.FindElement(By.XPath("//h3[@id='Debugging_features']//parent::div//following-sibling::ul[1]"));

          var li = listItems.FindElements(By.TagName("li"));
          
          var allTexts = new List<string>
          {
            heading.Text,
            paragraph.Text
          };
          allTexts.AddRange(li.Select(item => item.Text));

          return string.Join(" ", allTexts);
        }

        public void clickOnShowMicrosoftDevelopmentToolsLinks() {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            var showBtn = _driver.FindElement(By.XPath("//*[contains(@id, 'Microsoft') and contains(@id, 'development') and contains(@id, 'tools')]//parent::th//button"));
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            showBtn.Click();
        }

        public bool checkTechnologyNamesLinks(ExtentTest test) {
            var techNames = _driver.FindElements(By.XPath("//*[contains(@id, 'Microsoft') and contains(@id, 'development') and contains(@id, 'tools')]//ancestor::tbody//td//li"));
            bool allAreLinks = true;

            foreach ( var techName in techNames)
            {
                var link = techName.FindElements(By.TagName("a")).FirstOrDefault();

                if (link == null || string.IsNullOrEmpty(link.GetAttribute("href")))
                {
                    test.Fail($"The technology name: '{techName.Text}' is not a link");
                    allAreLinks = false;
                }
                else
                {
                    string name = link.Text;
                    test.Pass($"The technology name :'{name}' is a link");
                }
            }
            return allAreLinks;
        }

        public void clickOnDarkMode() {
            Actions actions = new Actions(_driver);
            var darkBtn = _driver.FindElement(By.XPath("//input[@value = 'night']"));
            actions.MoveToElement(darkBtn);
            darkBtn.Click();
        }

        public bool isDark() {
            var html = _driver.FindElement(By.TagName("html")).GetAttribute("class");
            return html.Contains("skin-theme-clientpref-night");
        }

    }
}
