using AutomationWiki.Core;
using AutomationWiki.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWiki.Tests
{
    [TestFixture]
    public class ColorThemeTests : BaseTest
    {
        [Test]
        public void changetToDarkMode() {
            var pom = new PlaywrightPage(Driver);
            pom.clickOnDarkMode();
            Assert.IsTrue(pom.isDark());
        }
    }
}
