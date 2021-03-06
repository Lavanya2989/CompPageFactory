﻿using AutoItX3Lib;
using ConsoleApp1.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//section//a[contains(.,'Manage Listings')]")]
        private IWebElement manageListingsLink { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//i[@class='checkmark icon']")]
        private IWebElement clickActionsButton { get; set; }

        //Delete row
        [FindsBy(How = How.XPath, Using = "(//td[@class='four wide'])[1]")]
        private IWebElement acttitle { get; set; }

        //Edit Shareskillpage
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Editbutton { get; set; }

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
        [FindsBy(How = How.XPath, Using = "(//input[@value='0'])[1]")]
        private IWebElement Hourly { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "(//input[@name='serviceType'])[2]")]
        private IWebElement Oneoff { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "(//input[@value='0'])[2]")]
        private IWebElement Onsite { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "(//input[@value='1'])[2]")]
        private IWebElement Online { get; set; }

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

        //Enter Skill Trade
        [FindsBy(How = How.XPath, Using = "(//input[@value='false'])[1]")]
        private IWebElement Credit { get; set; }

        //Enter Creditvalue
        [FindsBy(How = How.XPath, Using = "//input[@name='charge']")]
        private IWebElement Creditvalue { get; set; }

        //Click on worksample
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement Worksample { get; set; }

        //Click on Active
        [FindsBy(How = How.XPath, Using = "(//input[@value='true'])[2]")]
        private IWebElement StatusActive { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        private IWebElement StatusHidden { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Click on Cancel button
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel']")]
        private IWebElement Cancel { get; set; }

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
        [FindsBy(How = How.XPath, Using = "(//i[@class='grey remove circle large icon'])[1]")]
        private IWebElement greyicon { get; set; }


        internal void Listings()
        {
            //Explicit wait to find element
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//section//a[contains(.,'Manage Listings')]"));

            //click managelisting
            manageListingsLink.Click();

            // Explicit wait
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='remove icon'])[1]"));
            //click delete icon
            delete.Click();

            //deleteaction
            clickActionsButton.Click();
        }

        internal void deleteAssert()
        {
            try
            {
                //Get popup text
                // string addMessage = deleteicon.Text;
                //get deleted string
                //string expectedAddMessage =title+ " has been deleted";
                //Assert.AreEqual(addMessage, expectedAddMessage);
                // Populate the excel data
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
                string title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Assert.AreNotEqual(title, acttitle, "Title not deleted");
            }
            catch
            {
                Assert.True(true, "Element not found");
            }

        }
        internal void ShareskillEdit()
        {
            //Explicit wait to find element
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//section//a[contains(.,'Manage Listings')]"));

            //click managelisting
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"));
            Editbutton.Click();
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Enter title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Enter Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

            // Select on Category Dropdown
            GlobalDefinitions.wait(10);
            SelectElement catg = new SelectElement(CategoryDropDown);
            catg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Category"));

            //Select on SubCategory Dropdown
            GlobalDefinitions.wait(10);
            SelectElement subcatg = new SelectElement(SubCategoryDropDown);
            subcatg.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "SubCategory"));

            //Enter Tag names in textbox
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select the Service type
            if (GlobalDefinitions.ExcelLib.ReadData(3, "ServiceType") == "Hourly basis service")
            {
                Hourly.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "ServiceType") == "One-off service")
            {
                Oneoff.Click();
            }

            //Select the Location type
            if (GlobalDefinitions.ExcelLib.ReadData(3, "LocationType") == "On-site")
            {
                Onsite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "LocationType") == "Online")
            {
                Online.Click();
            }

            //Click on Start Date dropdown
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Startdate"));

            //Click on End Date dropdown
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Enddate"));

            //Select available days
            Days.Click();

            //Select startTime
            StartTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Starttime"));

            //select endtime
            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Endtime"));

            if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Skill-Exchange")
            {

                //select SkillTradeOption
                SkillTradeOption.Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Return);

            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "SkillTrade") == "Credit")
            {

                Credit.Click();
                Creditvalue.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
                Creditvalue.SendKeys(Keys.Enter);
            }
            //Click worksample
            Worksample.Click();
            //Worksample.SendKeys("path");

            //upload file using AutoIT
            AutoItX3 autoit = new AutoItX3();
            //Activate so that next action happens on this window
            autoit.WinActivate("Open");
            //autoit.Send(@"D:\Shareskillmars\FileUploadScript.exe");
            autoit.Send(@"D:\Shareskillmars\sample.txt");
            autoit.Send("{ENTER}");

            Thread.Sleep(20000);
            //Select user option
            if (GlobalDefinitions.ExcelLib.ReadData(3, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(3, "UserStatus") == "Hidden")
            {
                StatusHidden.Click();
            }

           //click save or cancel
            if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "SaveOrCancel") == "Save")
            {
                Save.Click();
            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(3, "SaveOrCancel") == "Cancel")
            {
                Cancel.Click();
            }
        }

        internal void validate()
        {
            GlobalDefinitions.wait(40);
            //Validate the service details saved by title
            Assert.AreEqual(MTitle.Text, GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //validate Category
            Assert.AreEqual(MCategory.Text, GlobalDefinitions.ExcelLib.ReadData(3, "Category"));

            //validate Description
            Assert.AreEqual(MDescription.Text, GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

            //validate Servicetype
            Assert.AreEqual(MServiceType.Text, GlobalDefinitions.ExcelLib.ReadData(3, "ServiceType"));

            //validate image of blue icon in skill trade
            var img = greyicon.Displayed;
            Assert.IsTrue(img);

        }
    }
    
}
