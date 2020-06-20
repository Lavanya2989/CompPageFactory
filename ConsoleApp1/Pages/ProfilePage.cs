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
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Mars Logo')]")]
        private IWebElement ProfileTitle { get; set; }

         // Profile name dropdown 
        [FindsBy(How = How.XPath, Using = "(//i[@class='dropdown icon'])[2]")]
        private IWebElement ProfileName { get; set; }

        //Edit Firstname
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement Firstname { get; set; }

        //Edit lastname
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement Lastname { get; set; }

        //Assert title
        [FindsBy(How = How.XPath, Using = "//div[@class='title' and contains(text(),'Lavanya Rajendran')]")]
        private IWebElement Titlename { get; set; }

        //Save profile name
        [FindsBy(How = How.XPath, Using = "//button[@class='ui teal button']")]
        private IWebElement SaveProfileName { get; set; }

        //Select available time
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[1]")]
        private IWebElement Availabletime { get; set; }

        //Select time
        [FindsBy(How = How.XPath, Using = "//select")]
        private IWebElement Selecttime { get; set; }

        //Select hours
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[2]")]
        private IWebElement hours { get; set; }

        //Select time
        [FindsBy(How = How.XPath, Using = "(//select)")]
        private IWebElement Selecthours { get; set; }

        //EarnTarget
        [FindsBy(How = How.XPath, Using = "(//i[@class='right floated outline small write icon'])[3]")]
        private IWebElement EarnTarget { get; set; }

        //Select EarnTarget
        [FindsBy(How = How.XPath, Using = "(//select)")]
        private IWebElement SelectEarntarget { get; set; }

        //Select Description
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Description { get; set; }

        //Edit Description
        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement Descriptiontext { get; set; }

        //Save Description
        [FindsBy(How = How.XPath, Using = "//button[@type='button']")]
        private IWebElement DescriptionSave { get; set; }

        //Assert time
        [FindsBy(How = How.XPath, Using = "((//span)[5]//option)[3]")]
        private IWebElement Time { get; set; }

        //Assert hour
        [FindsBy(How = How.XPath, Using = "(//span)[7]")]
        private IWebElement Hour { get; set; }

        //Assert EarnTarget
        [FindsBy(How = How.XPath, Using = "(//span)[9]")]
        private IWebElement EarnT { get; set; }

        //Assert Description
        [FindsBy(How = How.XPath, Using = "(//span)[11]")]
        private IWebElement Desc { get; set; }

        //IWebElement ShareSkillButton => GlobalDefinitions.driver.FindElement(By.XPath("//a[contains(.,'Share Skill')]"));

        //validate I'm in profile page
        internal void AssertProfilePAge()
        {
            GlobalDefinitions.wait(20);
            Assert.AreEqual(ProfileTitle.Text, "Mars Logo");
        }
     
        internal void ProfileAdd()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='dropdown icon'])[2]"));
            //Click Profilename
            ProfileName.Click();

            //Enter Firstname
            Firstname.Clear();
            Firstname.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Firstname"));

            //Enter Lastname
            Lastname.Clear();
            Lastname.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Lastname"));

            //Save profilename
            SaveProfileName.Click();
            var fname = GlobalDefinitions.ExcelLib.ReadData(2, "Firstname");
            var Lname = GlobalDefinitions.ExcelLib.ReadData(2, "Lastname");
            var title = fname+" "+Lname;
            GlobalDefinitions.wait(40);
            Assert.AreEqual(Titlename.Text, title);
        }
        internal void Availability()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='right floated outline small write icon'])[1]"));
            
            //Click Available time
            GlobalDefinitions.wait(50);
            Availabletime.Click();
           
            // Select on Category Dropdown Time
            GlobalDefinitions.wait(10);
            SelectElement time = new SelectElement(Selecttime);
            time.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Availability"));
            
            GlobalDefinitions.wait(40); 
            Assert.AreEqual(Time.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Availability"));
        }
        internal void hoursuser()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            
            //Click hours
            GlobalDefinitions.wait(50);
            hours.Click();
            
            // Select on Category Dropdown Hours
            SelectElement hour = new SelectElement(Selecthours);
            hour.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
            GlobalDefinitions.wait(40);
            
            //Assert Hour
            Assert.AreEqual(Hour.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
        }
        internal void earntarget()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
           
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='right floated outline small write icon'])[3]"));
            //Click EarnTarget
            EarnTarget.Click();
            
            // Select on Category Dropdown EarnTarget
            GlobalDefinitions.wait(50);
            SelectElement Earn = new SelectElement(SelectEarntarget);
            Earn.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
            
            //Assert EarnTarget
            GlobalDefinitions.wait(40);
            Assert.AreEqual(EarnT.Text, GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
        }
        internal void description()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"));
            //Click Description
            Description.Click();

            GlobalDefinitions.wait(40);
            Descriptiontext.Clear();
            //Enter Description
            Descriptiontext.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            DescriptionSave.Click();
            //Assert
            GlobalDefinitions.wait(40);
            //String des = Desc.Text;
            //Assert.IsTrue(des.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
            String addMessage =GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']//div")).Text;
            String expectedAddMessage = "Description has been saved successfully";
            Assert.AreEqual(addMessage, expectedAddMessage);
        }
    }


}

