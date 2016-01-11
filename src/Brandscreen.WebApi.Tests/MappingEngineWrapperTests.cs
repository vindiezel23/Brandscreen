using Autofac.Extras.Moq;
using AutoMapper;
using Brandscreen.WebApi.Mappings;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests
{
    [TestFixture]
    public class MappingEngineWrapperTests : MockingTests
    {
        public override void MockingSetUp()
        {
            // note: override to not register autofac components
            Mock = AutoMock.GetLoose();
        }

        [Test]
        public void Map_ShouldBeAbleToResolveDependencyViaContext()
        {
            // Arrange
            var fromObj = new FromObj {Field1 = "Field1"};
            var dependencyObj = new DependencyObj {Field2 = 2};

            Mock.Provide(dependencyObj);
            Mock.Provide((MappingEngine) Mapper.Engine);
            Mapper.AddProfile(new FromToProfile());

            // Act
            var toObj = Mock.Create<MappingEngineWrapper>().Map<ToObj>(fromObj);

            // Assert
            Assert.That(toObj, Is.Not.Null);
            Assert.That(toObj.Field1, Is.EqualTo(fromObj.Field1));
            Assert.That(toObj.Field2, Is.EqualTo(dependencyObj.Field2));
        }

        private class FromObj
        {
            public string Field1 { get; set; }
        }

        private class ToObj
        {
            public string Field1 { get; set; }
            public int Field2 { get; set; }
        }

        private class DependencyObj
        {
            public int Field2 { get; set; }
        }

        private class FromToProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<FromObj, ToObj>()
                    .ForMember(dst => dst.Field2, opt => opt.ResolveUsing(result => result.Context.Resolve<DependencyObj>().Field2));
            }
        }
    }
}