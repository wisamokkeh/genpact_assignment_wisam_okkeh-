using AutomationWiki.Core;
using AutomationWiki.Page;

namespace AutomationWiki.Tests
{
    [TestFixture]
    public class MicrosoftDevToolsTests : BaseTest
    {
        [Test]
        public void checkMicrosoftDevelopmentToolsLinks()
        {
            var pom = new PlaywrightPage(Driver);

            pom.clickOnShowMicrosoftDevelopmentToolsLinks();
            bool allLinks = pom.checkTechnologyNamesLinks(_test);
            Assert.IsTrue(allLinks,
                "One or more technology names are not links.");
        }
    }
}
