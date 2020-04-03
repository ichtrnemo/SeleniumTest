using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using seleniumTest.pages;

namespace seleniumTest
{
    public partial class Form1 : Form
    {
        IWebDriver browser;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://www.yandex.ru");

            //Yandex страница поиска
            PageYandex yandexPage = new PageYandex(browser);
            //запоминаем вкладку
            List<String> beforeTabs = browser.WindowHandles.ToList();
            //переход к музыке yandex
            yandexPage.goToMusic();
            //переключаемся на вкладку с музыкой
            List<String> afterTabs = browser.WindowHandles.ToList();
            List<String> newTab = afterTabs.Except(beforeTabs).ToList();
            browser.SwitchTo().Window(newTab[0]);

            //проверка
            if (!browser.Url.Equals("https://music.yandex.ru/home")) {
                System.Windows.Forms.MessageBox.Show(browser.Url + " instead of https://music.yandex.ru/home");
            }
            
            //страница яндекс музыка
            PageMusic musicPage = new PageMusic(browser);
            musicPage.goToRadio();

            //проверка
            if (!browser.Url.Equals("https://music.yandex.ru/radio"))
            {
                System.Windows.Forms.MessageBox.Show(browser.Url + " instead of https://music.yandex.ru/radio");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (browser != null) {
                browser.Quit();
            }
        }
    }
}
