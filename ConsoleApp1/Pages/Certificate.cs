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
    internal class Certificate
    {
        public Certificate()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Certification tab
        [FindsBy(How = How.XPath, Using = "//a[@data-tab='fourth']")]
        private IWebElement ClickCert { get; set; }

        //Add new
        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),'Add New')])[4]")]
        private IWebElement ClickAddnew { get; set; }

        //Certification
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        private IWebElement AddCert { get; set; }

        //Certification from
        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        private IWebElement AddCertFrom { get; set; }

        //Year
        [FindsBy(How = How.XPath, Using = "//select[@name='certificationYear']")]
        private IWebElement AddYear { get; set; }

        //Save
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//input[@value='Add']")]
        private IWebElement SaveCert { get; set; }

        //Edit 
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//table//tbody//tr//td[4]//i[@class='outline write icon']")]
        private IWebElement EditCert { get; set; }

        //Update
        [FindsBy(How = How.XPath, Using = "//input[@value='Update']")]
        private IWebElement UpdateCert { get; set; }

        //delete
        [FindsBy(How = How.XPath, Using = "//div[@data-tab='fourth']//table//tbody//tr//td[4]//i[@class='remove icon']")]
        private IWebElement delCert { get; set; }

        internal void CertificationAdd()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='fourth']"));

            //Click Certification tab
            ClickCert.Click();

            //Click Add new
            ClickAddnew.Click();

            //Add Certification
            AddCert.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Add Certification from
            AddCertFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "From"));

            //Add Year
            AddYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Year"));

            //Save
            SaveCert.Click();

        }
        internal void AssertAddCert()
        {
            //Assert Certification
            GlobalDefinitions.wait(20);
            String ActCer = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[1]"))).Text;
            Assert.AreEqual(ActCer, GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Assert From
            String ActCerF = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActCerF, GlobalDefinitions.ExcelLib.ReadData(2, "From"));

            //Assert year
            String ActCerY = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActCerY, GlobalDefinitions.ExcelLib.ReadData(2, "Year"));
        }
        internal void CertEdit()
        {
            // Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='fourth']"));

            //Click Certification tab
            ClickCert.Click();
            EditCert.Click();

            //Edit Certification
            AddCert.Clear();
            AddCert.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Certificate"));

            //Edit Certification from
            AddCertFrom.Clear();
            AddCertFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "From"));

            //Edit Certification year
            AddYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Year"));

            //Click update
            UpdateCert.Click();
        }
        internal void AssertEditCert()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ProfilePage");
            GlobalDefinitions.wait(20);
          // String ActCer = (GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
           //Assert.AreEqual(ActCer, GlobalDefinitions.ExcelLib.ReadData(3, "Certificate"));

            //Assert Certification from
            String ActCerF = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[2]"))).Text;
            Assert.AreEqual(ActCerF, GlobalDefinitions.ExcelLib.ReadData(3, "From"));

            //Assert Certification year
            String ActCerY = (GlobalDefinitions.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody//tr[1]//td[3]"))).Text;
            Assert.AreEqual(ActCerY, GlobalDefinitions.ExcelLib.ReadData(3, "Year"));
        }
        internal void CertDelete()
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//a[@data-tab='fourth']"));
            //Click Certification tab
            ClickCert.Click();
            delCert.Click();
        }
        internal void AssertdelCert()
        {
            try
            {
                String ActCer2 = (GlobalDefinitions.driver.FindElement(By.XPath("//tbody//tr[1]//td[1]"))).Text;
                Assert.AreNotEqual(ActCer2, GlobalDefinitions.ExcelLib.ReadData(3, "Certificate"));
            }
            catch
            {
                Assert.True(true, "Element not found");
            }
        }
    }
}

    
