using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace seleniumTest.pages
{
    class PageMusic
    {
        private IWebDriver browser;

        public PageMusic(IWebDriver browser) {
            this.browser = browser;
        }

        public void goToRadio() {
            IWebElement element = browser.FindElement(By.LinkText("Радио"));
            element.Click();
        }

    }
}
