using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace vezba29
{
    class SeleniumTest
    {
        IWebDriver driver;
        WebDriverWait wait;

        [Test]
        public void TestKreirajNovogKorisnika()
        {
            Navigate("http://test.qa.rs");
            IWebElement linkCreate = wait.Until(EC.ElementIsVisible(By.LinkText("Kreiraj novog korisnika")));
            if (linkCreate.Displayed && linkCreate.Enabled)
            {
                linkCreate.Click();
            }
            IWebElement inputName = wait.Until(EC.ElementIsVisible(By.Name("ime")));
            if (inputName.Displayed && inputName.Enabled)
            {
                inputName.SendKeys("Lenka");

            }
            IWebElement inputLastName = driver.FindElement(By.Name("prezime"));
            if (inputLastName.Displayed && inputLastName.Enabled)
            {
                inputLastName.SendKeys("Markov");
            }
            IWebElement inputUserName = driver.FindElement(By.Name("korisnicko"));
            if (inputUserName.Displayed && inputUserName.Enabled)
            {
                inputUserName.SendKeys("lela");
            }
            IWebElement inputEmail = driver.FindElement(By.Name("email"));
            if (inputEmail.Displayed && inputEmail.Enabled)
            {
                inputEmail.SendKeys("lelo@gmail.com");
            }
            IWebElement inputPhone = driver.FindElement(By.Name("telefon"));
            if (inputPhone.Displayed && inputPhone.Enabled)
            {
                inputPhone.SendKeys("066666666");

            }
            IWebElement inputCountry = driver.FindElement(By.Name("zemlja"));
            if (inputCountry.Displayed && inputCountry.Enabled)
            {
                SelectElement selectCountry = new SelectElement(inputCountry);
                selectCountry.SelectByText("Serbia");
            }
            IWebElement inputCity = wait.Until(EC.ElementIsVisible(By.Name("grad")));
            if (inputCity.Displayed && inputCity.Enabled)
            {
                SelectElement selectCity = new SelectElement(inputCity);
                selectCity.SelectByIndex(10);

            }

            IWebElement inputStreet = driver.FindElement(By.XPath("//div[@id='address']//input"));
            if (inputStreet.Displayed && inputStreet.Enabled)
            {
                inputStreet.SendKeys("Lukina 32");
            }
            IWebElement inputGender = driver.FindElement(By.Id("pol_z"));
            if (inputGender.Displayed && inputGender.Enabled)
            {
                inputGender.Click();
            }
            IWebElement buttonRegistar = driver.FindElement(By.Name("register"));
            if (buttonRegistar.Displayed && buttonRegistar.Enabled)
            {
                buttonRegistar.Click();
            }

        }
        [Test]
        public void Veriffy()
        {

            Navigate("http://test.qa.rs");
            IWebElement linkList = driver.FindElement(By.LinkText("Izlistaj sve korisnike"));
            if (linkList.Displayed && linkList.Enabled)
            {
                linkList.Click();
            }
           
        }
        private void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
