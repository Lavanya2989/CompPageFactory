using ConsoleApp1.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Pages
{
    class SignIn
    {

        public SignIn()
        {

            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the SignIn Link
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button']")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            //Get url
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            //Maximize screen
            GlobalDefinitions.driver.Manage().Window.Maximize();


            //Click on SignIntab button
             SignIntab.Click();

            //Enter FirstName
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            //Enter LastName
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on Join button
            LoginBtn.Click();


        }
    }
}