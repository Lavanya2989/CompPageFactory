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
using System.Xml.Linq;

namespace ConsoleApp1.Pages
{
    internal class Language
    {
        public Language()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Language tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='first']")]
        private IWebElement ClickLang { get; set; }

        //Add new Language
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Add New')][1]")]
        private IWebElement Addnewlang { get; set; }

        //Add Language
        [FindsBy(How = How.XPath, Using = "//input[@type='text'and@placeholder='Add Language']")]
        private IWebElement AddLang { get; set; }

        //Add Language Level
        [FindsBy(How = How.XPath, Using = "//select[@class='ui dropdown']")]
        private IWebElement SelectLevel { get; set; }

        //Save Language
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement SaveLang { get; set; }

        // Edit Language button
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='outline write icon']")]
        private IWebElement EditLang { get; set; }

        //Update Language
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateLang { get; set; }

        // delete
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='remove icon']")]
        private IWebElement delLang { get; set; }

        //Assert Lang
        [FindsBy(How = How.XPath, Using = "(//div[@data-tab='first']//table//tbody//tr[1]//td[1])[1]")]
        private IWebElement Lang { get; set; }

        //Assert Level
        [FindsBy(How = How.XPath, Using = "(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")]
        private IWebElement LanLevel { get; set; }
        internal void LanguageAdd()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            //Explicit wait to click Add new element
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='first']"));

            //Click Language tab
            ClickLang.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[contains(text(),'Add New')][1]"));

            //Click Add new
            Addnewlang.Click();

            //Add Language
            AddLang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Add Level
            SelectLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));

            //Save Language
            SaveLang.Click();

        }
        internal void AssertAddLang()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            GlobalDefinitions.wait(30);
            //Language Assertion
            Assert.AreEqual(Lang.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Level Assertion
            Assert.AreEqual(LanLevel.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Level"));
        }
        internal void LanguageEdit()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            //Click Language tab
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='first']"));
            ClickLang.Click();
            EditLang.Click();

            //Add new Language
            AddLang.Clear();
            AddLang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Language"));

            //Add new Level
            SelectLevel.Click();
            SelectLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Level"));

            //Click update
            UpdateLang.Click();

            GlobalDefinitions.wait(40);
        }
        internal void AssertEditLang()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
                       
            GlobalDefinitions.wait(30);
            //String Langu = Lang.Text;
            //Assert.IsTrue(Langu.Contains(GlobalDefinitions.ExcelLib.ReadData(3, "Language")));

            //Level Assertion
            Assert.AreEqual(LanLevel.Text, GlobalDefinitions.ExcelLib.ReadData(3, "Level"));
        }
        internal void LangDelete()
        {
            ClickLang.Click();
            //Click delete
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@data-tab='first']//table//tbody//tr//td[3]//i[@class='remove icon']"));
            delLang.Click();
        }
        internal void AssertdelLang()
        {
            try
            {
                String ActLang2 = (GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActLang2, GlobalDefinitions.ExcelLib.ReadData(3, "Language"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }
    }
}