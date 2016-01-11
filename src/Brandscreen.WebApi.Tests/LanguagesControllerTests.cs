using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services;
using Brandscreen.Entities;
using Brandscreen.WebApi.Controllers;
using Brandscreen.WebApi.Models;
using Brandscreen.WebApi.Paginations;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class LanguagesControllerTests : ApiControllerMockingTests<LanguagesController>
    {
        [Test]
        public async Task Get_ShouldReturnLanguageList()
        {
            // Arrange
            var language = new Language {LanguageId = 1};
            var languages = new List<Language> {language};

            Mock.Mock<ILanguageService>().Setup(x => x.GetLanguages()).Returns(languages.ToAsyncEnumerable());

            // Act
            var retVal = await Controller.Get(null);

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal, Is.TypeOf<OkNegotiatedContentResult<PagedListViewModel<LanguageListViewModel>>>());
            var content = ((OkNegotiatedContentResult<PagedListViewModel<LanguageListViewModel>>) retVal).Content;
            Assert.That(content.TotalItemCount, Is.EqualTo(1));
            Assert.That(content.Data.ElementAt(0).LanguageId, Is.EqualTo(language.LanguageId));
        }
    }
}