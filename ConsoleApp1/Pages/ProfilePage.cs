using ConsoleApp1.Global;
using HtmlAgilityPack;
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
    internal class ProfilePage
    {
        public ProfilePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Assert title validation for profile page
        [FindsBy(How = How.XPath, Using = "//div[@class='title' and contains(text(),'Lavanya Rajendran')]")]
        private IWebElement ProfileTitle { get; set; }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Share Skill')]")]
        private IWebElement ShareSkillButton { get; set; }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//section//a[contains(.,'Manage Listings')]")]
        private IWebElement manageListingsLink { get; set; }

        //IWebElement ShareSkillButton => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(.,'Share Skill')]"));

        //validate I'm in profile page
        internal void AssertProfilePAge()
        {
            GlobalDefinitions.wait(20);
            Assert.AreEqual(ProfileTitle.Text,"Lavanya Rajendran");
        }
        internal void Navigate_ShareSkill_Page()
        {
            //Explicit wait
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[contains(.,'Share Skill')]"));

            //click shareskill
            ShareSkillButton.Click();
        }
        internal void AssertShareSkillPage()
        { 
            //Validate I'm at shareskill page
            String URL = GlobalDefinitions.driver.Url;
            Assert.AreEqual(URL, "http://192.168.99.100:5000/Home/ServiceListing");
                       
        }
        internal void Navigate_Manage_Listing()
        {
            //Explicit wait to find element
             GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//section//a[contains(.,'Manage Listings')]"));
           
            //click managelisting
            manageListingsLink.Click();
        }
    }
}




