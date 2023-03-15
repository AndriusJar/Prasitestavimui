using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prasitestavimui
{ 

    public class OtherCases
    {
        private static string driverPath = "C:\\Users\\Andrius\\Desktop\\chromdriver.exe";
        static IWebDriver driver;


        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver(driverPath);
            driver.Manage().Window.Maximize();
            driver.Url = "https://fera.lt/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//div[contains(@class,'cookie')]//a")).Click();
        }
        [TearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
        [Test]
        public static void RegistrationTest()
        {
            By myAccount = By.XPath("//div[contains(@class,'my-account-text')]");
            driver.FindElement(myAccount).Click();

            By registerButton = By.XPath("//div[contains(@class,'account-info')]//a[@class=\"account\"]");
            driver.FindElement(registerButton).Click();

            //test20230306@gmail.com

            DateTime tim = DateTime.Now;

            string email_Password = "test_" + tim.ToString("yyyy_MM_dd_HH_mm_ss") + "@gmail.com";

            driver.FindElement(By.Id("email")).SendKeys(email_Password);
            driver.FindElement(By.Id("password1")).SendKeys(email_Password);
            driver.FindElement(By.Id("password2")).SendKeys(email_Password);

            By confirmation = By.Id("confirm_1");
            driver.FindElement(confirmation).Click();

            By confirmButton = By.XPath("//div[contains(@class,'profile-field')]//button[@type='submit']");
            driver.FindElement(confirmButton).Click();

            Thread.Sleep(8000);
            driver.FindElement(myAccount).Click();

            By myAccountMail = By.XPath("//li[contains(@class,'account-info__name')]");
            string myAccountMailText = driver.FindElement(myAccountMail).Text;

            Assert.AreEqual(myAccountMailText, email_Password);
        }



    }
}



