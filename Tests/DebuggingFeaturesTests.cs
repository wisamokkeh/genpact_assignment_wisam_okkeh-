using AutomationWiki.Api;
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
    public class DebuggingFeaturesTests : BaseTest
    {
        [Test]
        public async Task CheckApiAndWebTheSame() {
            var pom = new PlaywrightPage(Driver);
            var api = new MediaWikiApi();

            //web elements
            var webText = pom.GetSectionWebText();
            var normalizedWeb = NormalizerText.Normalize(webText);
            var webUniqueCount = NormalizerText.CountUniqeWords(normalizedWeb);

            //api elements
            var apiText = await api.GetSectionApi();
            var normalizedApi = NormalizerText.Normalize(apiText);
            var apiUniqueCount = NormalizerText.CountUniqeWords(normalizedApi);

            TestContext.WriteLine($"Web Unique words: {webUniqueCount}");
            TestContext.WriteLine($"Api Unique words: {apiUniqueCount}");

            Assert.That(apiUniqueCount, Is.EqualTo(webUniqueCount));

        }

    }
}
