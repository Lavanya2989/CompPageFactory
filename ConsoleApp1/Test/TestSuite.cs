using ConsoleApp1.Pages;
using NUnit.Framework;

namespace ConsoleApp1
{
    public class Program
    {

        [TestFixture]
        [Category("ShareSkillPage")]
        class ShareSkillPage : Global.Base
        {

            [Test, Description("Validate the user can enter shareskill page")]
            public void ShareSkill()
            {
                // Navigate to shareskill page from profile page
                ProfilePage profobj = new ProfilePage();
                profobj.AssertProfilePAge();
                profobj.Navigate_ShareSkill_Page();
                profobj.AssertShareSkillPage();

                //Adding service Listing details in share skill page
                ShareSkill shareobj = new ShareSkill();
                shareobj.EnterShareSkill();
                shareobj.validate();
            }
            [Test, Description("validate the user can delete details in Managelisting page")]
            public void ManageListings()
            {
                //Navigate to Managelisting page from profile page
                ProfilePage profobj = new ProfilePage();
                profobj.Navigate_Manage_Listing();

                //Delete service Listing in Manage Listing page
                ManageListings manobj = new ManageListings();
                manobj.Listings();
                manobj.deleteAssert();
            }

            [Test, Description("Validate the user can edit the servicelisting")]
            public void ManageListingsEdit()
            {
                //Navigate to Managelisting page from profile page
                ProfilePage profobj = new ProfilePage();
                profobj.Navigate_Manage_Listing();

                //Edit ServiceListing
                ManageListings manobj = new ManageListings();
                manobj.ShareskillEdit();
            }
        }
    }
}
