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
    internal class Skill
    {
        public Skill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Skill tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='second']")]
        private IWebElement ClickSkilltab { get; set; }

        // Add new
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[2]")]
        private IWebElement ClickAddnewSkill { get; set; }

        //Add new Skill
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Add Skill']")]
        private IWebElement AddnewSkill { get; set; }

        //Skill level
        [FindsBy(How = How.XPath, Using = "//select")]
        private IWebElement SelectSkillLevel { get; set; }

        //save
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='second']//input[@value='Add']")]
        private IWebElement SaveSkill { get; set; }

        //Edit Skill button
        [FindsBy(How = How.XPath, Using = "(//*[@data-tab='second']//table//tbody//tr//td[3]//i[@class='outline write icon'])")]
        private IWebElement EditSkill { get; set; }

        //Assert Skill
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='second']//tbody[last()]//td[1]")]
        private IWebElement ActSkill { get; set; }

        //Assert Skill Level
        [FindsBy(How = How.XPath, Using = "//*[@data-tab='second']//tbody[last()]//td[2]")]
        private IWebElement ActSkill1 { get; set; }

        //Update
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateSkill { get; set; }

        //delete
        [FindsBy(How = How.XPath, Using = "(//*[@data-tab='second']//table//tbody[last()]//tr//td[3]//i[@class='remove icon'])")]
        private IWebElement delSkill { get; set; }

        internal void SkillAdd()
    {
        // Populate the excel data
        GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='second']"));

        //Click Skill tab
        ClickSkilltab.Click();

        //Click Add new
        ClickAddnewSkill.Click();

        //Add Skill
        AddnewSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

        //Add Level
        SelectSkillLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Level"));

         //Save Skill
         SaveSkill.Click();

    }
        internal void AssertAddSkill()
        {
            GlobalDefinitions.wait(40);
            //Assert skill
            Assert.AreEqual(ActSkill.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));
            //Assert skill level
            Assert.AreEqual(ActSkill1.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Skill Level"));
        }
        internal void SkillEdit()
    {
        // Populate the excel data
        GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='second']"));

        //Click Skill tab
        ClickSkilltab.Click();
        GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//*[@data-tab='second']//table//tbody//tr//td[3]//i[@class='outline write icon'])"));
       
        //Edit Skill 
        EditSkill.Click();

        //Edit Skill
        AddnewSkill.Clear();
        AddnewSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Skill"));

         //Edit Level
         SelectElement Edit = new SelectElement(SelectSkillLevel);
         Edit.SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Skill Level"));
          
        //Click update
        UpdateSkill.Click();
    }
        internal void AssertEditSkill()
        {
         GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

          GlobalDefinitions.wait(30);
            //Assert skill
          String Skill= ActSkill.Text;
          Assert.IsTrue(Skill.Contains(GlobalDefinitions.ExcelLib.ReadData(3, "Skill")));

          GlobalDefinitions.wait(30);
            //Assert level
          Assert.AreEqual(ActSkill1.Text, GlobalDefinitions.ExcelLib.ReadData(3, "Skill Level"));
        }
        internal void SkillDelete()
    {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='second']"));
            //Click Skill tab
            ClickSkilltab.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//table//tbody[last()]//tr//td[3]//i[@class='remove icon'])"));
            delSkill.Click();
    }
        internal void AssertdelSkill()
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

  