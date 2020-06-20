using AventStack.ExtentReports;
using ConsoleApp1.Pages;
using NUnit.Framework;


namespace ConsoleApp1
{
    public class Program 
    {

        [TestFixture]
        [Category("ProfilePage")]
        class UserProfilePage : Global.Base
        {
            [Test, Description("Validate Adding Profile Details")]
            public void Profile()
            {
                ProfilePage proobj = new ProfilePage();
                proobj.ProfileAdd();
            }
            [Test, Description("Validate Availability")]
            public void Availabe()
            {
                //extent = getExtent();

                ProfilePage probj = new ProfilePage();
                probj.Availability();
               
            }
            [Test, Description("Validate hours")]
            public void Hourwork()
            {
                ProfilePage probj = new ProfilePage();
                probj.hoursuser();
            }
            [Test, Description("Validate earntarget")]
            public void Earn()
            {
                ProfilePage probj = new ProfilePage();
                probj.earntarget();
            }
            [Test, Description("Validate hours")]
            public void Descriptions()
            {
                ProfilePage probj = new ProfilePage();
                probj.description();
            }
            [Test, Description("Validate Add Language")]
            public void AddLanguage()
            {
                Language lanobj = new Language();
                lanobj.LanguageAdd();
                lanobj.AssertAddLang();
            }

            [Test, Description("Validate Edit Language")]
            public void EditLanguage()
            {
                Language lanobj = new Language();
                lanobj.LanguageEdit();
                lanobj.AssertEditLang();
            }

            [Test, Description("Validate Edit Language")]
            public void DeleteLanguage()
            {
                Language lanobj = new Language();
                lanobj.LangDelete();
                lanobj.AssertdelLang();
            }

            [Test, Description("Validate Add Skill")]
            public void AddSkill()
            {
                Skill skillobj = new Skill();
                skillobj.SkillAdd();
                skillobj.AssertAddSkill();

            }

            [Test, Description("Validate Edit Skill")]
            public void EditSkill()
            {
                Skill skillobj = new Skill();
                skillobj.SkillEdit();
                skillobj.AssertEditSkill();
            }

            [Test, Description("Validate Delete Skill")]
            public void DeleteSkill()
            {
                Skill skillobj = new Skill();
                skillobj.SkillDelete();
                skillobj.AssertdelSkill();
            }

            [Test, Description("Validate Add Education")]
            public void AddEducation()
            {
                Education eduobj = new Education();
                eduobj.EducationAdd();
                eduobj.AssertAddEdu();
            }

            [Test, Description("Validate Edit Education")]
            public void EditEducation()
            {
                Education eduobj = new Education();
                eduobj.EduEdit();
                eduobj.AssertEditEdu();
            }

            [Test, Description("Validate Delete Education")]
            public void DeleteEducation()
            {
                Education eduobj = new Education();
                eduobj.EduDelete();
                eduobj.AssertdelEdu();
            }

            [Test, Description("Validate Add Certification")]
            public void AddCertification()
            {
                Certificate certobj = new Certificate();
                certobj.CertificationAdd();
                certobj.AssertAddCert();
            }

            [Test, Description("Validate Edit Certification")]
            public void EditCertification()
            {
                Certificate certobj = new Certificate();
                certobj.CertEdit();
                certobj.AssertEditCert();
            }

            [Test, Description("Validate Delete Certification")]
            public void DeleteCertification()
            {
                Certificate certobj = new Certificate();
                certobj.CertDelete();
                certobj.AssertdelCert();
            }
        }

        [TestFixture]
        [Category("ShareSkillPage")]
        class ShareSkillPage : Global.Base
        {
          
            [Test, Description("Validate the user can enter shareskill page")]
            public void ShareSkill()
            {
                //extent = getExtent();
                
                //Adding service Listing details in share skill page
                ShareSkill shareobj = new ShareSkill();
                shareobj.EnterShareSkill();
                shareobj.validate();
            }
            [Test, Description("validate the user can delete details in Managelisting page")]
            public void DeleteManageListings()
            {
               
                //Delete service Listing in Manage Listing page
                ManageListings manobj = new ManageListings();
                manobj.Listings();
                manobj.deleteAssert();
            }

            [Test, Description("Validate the user can edit the servicelisting")]
            public void EditManageListings()
            {
               
                //Edit ServiceListing
                ManageListings manobj = new ManageListings();
                manobj.ShareskillEdit();
            }
            [Test, Description("Validate the user can Search the Skill in Search skill page")]
            public void SearchSkill()
            {
                //extent = getExtent();

                SearchSkill searchobj = new SearchSkill();
                searchobj.SearchSkills();
            }
            [Test, Description("Validate the user can Search the Skill in Search skill page")]
            public void SearchbyFilter()
            {
                SearchSkill searchobj = new SearchSkill();
                searchobj.Filter();
            }

        }
    }
}
