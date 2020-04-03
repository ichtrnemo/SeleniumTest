using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace seleniumTest.pages
{
    class PageYandex
    {
        private IWebDriver browser;

        public PageYandex(IWebDriver browser) {
            this.browser = browser;
        }

        //Переход на страницу Yandex музыка
        public void goToMusic() {
            IWebElement element = browser.FindElement(By.LinkText("Музыка"));
            element.Click();
        }
    }
}
