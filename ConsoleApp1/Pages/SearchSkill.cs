using ConsoleApp1.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Pages
{
   internal class SearchSkill
    {
        public SearchSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Assert title validation for profile page
        [FindsBy(How = How.XPath, Using = "//i[@class='search link icon']")]
        private IWebElement Searchlink { get; set; }

        // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//a[@role='listitem'])[9]")]
        private IWebElement catg1 { get; set; }

        // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//a[@class='item subcategory'])[1]")]
        private IWebElement subcatg1 { get; set; }

              //Edit Firstname
        [FindsBy(How = How.XPath, Using = "(//a[@class='seller-info'])[3]")]
        private IWebElement SkillClick { get; set; }

        // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//button[@class='ui button'])[1]")]
        private IWebElement Online { get; set; }

        // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//button[@class='ui button otherPage'])[last()-1]")]
        private IWebElement Navigatelast { get; set; }

        // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//a[@class='seller-info'])[1]")]
        private IWebElement ClickonlineSkill { get; set; }

      
        internal void SearchSkills()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//i[@class='search link icon']"));
            Searchlink.Click();
            catg1.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//a[@class='item subcategory'])[1]"));
            subcatg1.Click();
            // Navigatelast.Click();
             GlobalDefinitions.wait(40);
             SkillClick.Click();
            GlobalDefinitions.wait(40);
            //Validate Page Url
            String URL = GlobalDefinitions.driver.Url;
            Assert.AreEqual(URL, "http://192.168.99.100:5000/Account/Profile?id=5eb0901d4d2814000663501a");
        }
        internal void Filter()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//i[@class='search link icon']"));
            Searchlink.Click();
           
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//button[@class='ui button'])[1]"));
                Online.Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//button[@class='ui button otherPage'])[last()-1]"));
                Navigatelast.Click();
                GlobalDefinitions.wait(40);
                ClickonlineSkill.Click();
                GlobalDefinitions.wait(60);
            String URL = GlobalDefinitions.driver.Url;
            Assert.AreEqual(URL, "http://192.168.99.100:5000/Account/Profile?id=5c621663bea4490005ebe9d2");
        }
   }
}
