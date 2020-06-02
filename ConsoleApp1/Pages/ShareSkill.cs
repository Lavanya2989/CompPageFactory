using ConsoleApp1.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.XPath, Using = "//textarea")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.XPath, Using = "//select")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder='Add new tag'])[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[2]")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "(//input[@name='locationType'])[1]")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='startDate']")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='endDate']")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "(//input[@index='1'])[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//input[@name='StartTime' and @index='1' and @value]")]
        private IWebElement StartTime { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//input[@name='EndTime' and @index='1' and @value]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='true']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "(//input[@placeholder='Add new tag'])[2]")]
        private IWebElement SkillExchange { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Manage listing title value
        [FindsBy(How = How.XPath, Using = "(//tr[1]//td[@class='four wide'])[1]")]
        private IWebElement MTitle { get; set; }

        //Manage listing Category
        [FindsBy(How = How.XPath, Using = "(//tr[1]//td[@class='one wide'])[2]")]
        private IWebElement MCategory { get; set; }

        //Manage listing Description
        [FindsBy(How = How.XPath, Using = "(//tr[1]//td[@class='four wide'])[2]")]
        private IWebElement MDescription { get; set; }

        //Manage listing Service type
        [FindsBy(How = How.XPath, Using = "(//tr[1]//td[@class='one wide'])[3]")]
        private IWebElement MServiceType { get; set; }

        //Manage listing Skill trade
        [FindsBy(How = How.XPath, Using = "//i[@class='blue check circle outline large icon']")]
        private IWebElement blueicon { get; set; }

        internal void EnterShareSkill()
        {

            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Enter title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            // Select on Category Dropdown
            GlobalDefinitions.wait(10);
            SelectElement catg = new SelectElement(CategoryDropDown);
            catg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select on SubCategory Dropdown
            GlobalDefinitions.wait(10);
            SelectElement subcatg = new SelectElement (SubCategoryDropDown);
            subcatg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter Tag names in textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select the Service type
            ServiceTypeOptions.Click();

            //Select the Location type
            LocationTypeOption.Click();

            //Click on Start Date dropdown
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            //Click on End Date dropdown
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Select available days
            Days.Click();

            //Select startTime
            StartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            //select endtime
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            //select SkillTradeOption
            SkillTradeOption.Click();

            //Enter SkillExchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Return);

            //Click on Active/Hidden option
            ActiveOption.Click();

            //click save
            Save.Click();
        }

            internal void validate()
            {
                GlobalDefinitions.wait(40);
                //Validate the service details saved by title
                Assert.AreEqual(MTitle.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

                //validate Category
                Assert.AreEqual(MCategory.Text,GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

                //validate Description
                Assert.AreEqual(MDescription.Text,GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

                //validate Servicetype
                Assert.AreEqual(MServiceType.Text,GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType"));

                //validate image of blue icon in skill trade
                var img = blueicon.Displayed;
                Assert.IsTrue(img);
                
            }
        }
    }

