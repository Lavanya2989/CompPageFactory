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
    internal class Education
    {
        public Education()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Education tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='third']")]
        private IWebElement ClickEdu { get; set; }

        //Add new Education
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[3]")]
        private IWebElement ClickAddnewE { get; set; }

        //University
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='College/University Name']")]
        private IWebElement University { get; set; }

        //Country
        [FindsBy(How = How.XPath, Using = "//select[@name='country']")]
        private IWebElement Country { get; set; }

        //Title
        [FindsBy(How = How.XPath, Using = "//select[@name='title']")]
        private IWebElement Title { get; set; }

        //Degree
        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        private IWebElement Degree { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "//select[@name='yearOfGraduation']")]
        private IWebElement Year { get; set; }

        //Save
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//input[@value='Add']")]
        private IWebElement SaveEdu { get; set; }

        //Edit 
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//table//tbody//tr//td[6]//i[@class='outline write icon']")]
        private IWebElement EditEdu { get; set; }

        //Update
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateEdu { get; set; }

        //Delete
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='third']//table//tbody//tr//td[6]//i[@class='remove icon']")]
        private IWebElement delEdu { get; set; }
        internal void EducationAdd()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='third']"));

            //Click Skill tab
            ClickEdu.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//div[contains(text(),'Add New')])[3]"));

            //Click Add new
            ClickAddnewE.Click();

            //Add University
            University.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            //Add Country
            Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));

            //Add Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Add Degree
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            //Add Year
            Year.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation"));

            //Save Education
            SaveEdu.Click();

        }
        internal void AssertAddEdu()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            GlobalDefinitions.wait(40);

            //Assert Country 
            String ActEdu = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[1]"))).Text;
            Assert.AreEqual(ActEdu, GlobalDefinitions.ExcelLib.ReadData(2, "Country"));

            //Assert University
            String ActEdu1 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActEdu1, GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            //Assert Title
            String ActEdu2 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActEdu2, GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Assert Degree
            String ActEdu3 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[4]"))).Text;
            Assert.AreEqual(ActEdu3, GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            //Assert year of graduation
            String ActEdu4 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[5]"))).Text;
            Assert.AreEqual(ActEdu4, GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation"));
        }
        internal void EduEdit()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='third']"));
            //Click Education tab
            ClickEdu.Click();
            EditEdu.Click();

            //Edit University
            University.Clear();
            University.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "University"));

            //Edit Country
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//select[@name='country'])"));
            SelectElement Edit = new SelectElement(Country);
            Edit.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Country"));
           // Country.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Country"));

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//select[@name='title'])"));
            //Edit Title
           // EditTitle.Click();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Edit Degree
            Degree.Clear();
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Degree"));

            //Edit year
            //EditYear.Click();
            Year.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "YearOfGraduation"));

            //Click update
            UpdateEdu.Click();
        }
        internal void AssertEditEdu()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            GlobalDefinitions.wait(40);
            //String ActEdu = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[1]"))).Text;
            //Assert.IsTrue(ActEdu.Contains(GlobalDefinitions.ExcelLib.ReadData(3, "Country")));

            //Assert University
            String ActEdu1 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActEdu1, GlobalDefinitions.ExcelLib.ReadData(3, "University"));

            //Assert Title
            String ActEdu2 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActEdu2, GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Assert Degree
            String ActEdu3 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[4]"))).Text;
            Assert.AreEqual(ActEdu3, GlobalDefinitions.ExcelLib.ReadData(3, "Degree"));

            //Assert year
            String ActEdu4 = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='third']//tbody//tr[1]//td[5]"))).Text;
            Assert.AreEqual(ActEdu4, GlobalDefinitions.ExcelLib.ReadData(3, "YearOfGraduation"));
        }
        internal void EduDelete()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='third']"));
            //Click Education tab
            ClickEdu.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[@data-tab='third']//table//tbody//tr//td[6]//i[@class='remove icon']"));
           //Delete
            delEdu.Click();
        }
        internal void AssertdelEdu()
        {
            try
            {
                String ActEdu2 = (GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActEdu2, GlobalDefinitions.ExcelLib.ReadData(3, "Country"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }
    }
}
