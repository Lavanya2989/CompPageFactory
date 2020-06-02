using ConsoleApp1.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='title']")]
        private IWebElement Title { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//i[@class='checkmark icon']")]
        private IWebElement clickActionsButton { get; set; }

        //Delete icon
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']//div")]
        private IWebElement deleteicon { get; set; }
        internal void Listings()
        {
            GlobalDefinitions.wait(30);

            //click delete icon
            delete.Click();

            //deleteaction
            clickActionsButton.Click();
        }

        internal void deleteAssert()
        {

            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            //Get popup text
            string addMessage = deleteicon.Text;
            //get deleted string
            string title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string expectedAddMessage =title+ " has been deleted";
            Assert.AreEqual(addMessage, expectedAddMessage);
        }
    }
    
}
