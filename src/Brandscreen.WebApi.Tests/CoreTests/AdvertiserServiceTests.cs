using System;
using System.Collections.Generic;
using System.Linq;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Services.Advertisers;
using Brandscreen.Entities;
using NUnit.Framework;

namespace Brandscreen.WebApi.Tests.CoreTests
{
    [TestFixture]
    public class AdvertiserServiceTests : MockingTests
    {
        [Test]
        public void GetAdvertisers_ShouldReturnAllAdvertisers_WhenNoOptions()
        {
            // Arrange
            var emptyOptions = new AdvertiserQueryOptions();

            var buyerAccount1 = new BuyerAccount {BuyerAccountId = 1};
            var buyerAccount2 = new BuyerAccount {BuyerAccountId = 2};
            var advertisers = new List<Advertiser>
            {
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount2.BuyerAccountId, BuyerAccount = buyerAccount2}
            };
            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(advertisers.ToAsyncEnumerable());

            // Act
            var retVal = Mock.Create<AdvertiserService>().GetAdvertisers(emptyOptions).ToList();

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetAdvertisers_ShouldReturnMatchedAdvertiser_WhenWithBuyerAccountIdsOption()
        {
            // Arrange
            var queryOptions = new AdvertiserQueryOptions();
            queryOptions.BuyerAccountIds.Add(1);

            var buyerAccount1 = new BuyerAccount {BuyerAccountId = 1};
            var buyerAccount2 = new BuyerAccount {BuyerAccountId = 2};
            var advertisers = new List<Advertiser>
            {
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount1.BuyerAccountId, BuyerAccount = buyerAccount1},
                new Advertiser {BuyerAccountId = buyerAccount2.BuyerAccountId, BuyerAccount = buyerAccount2}
            };
            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(advertisers.ToAsyncEnumerable());

            // Act
            var retVal = Mock.Create<AdvertiserService>().GetAdvertisers(queryOptions).ToList();

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAdvertisers_ShouldReturnMatchedAdvertiser_WhenWithUserIdsOption()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var queryOptions = new AdvertiserQueryOptions();
            queryOptions.UserIds.Add(userId);

            var buyerAccount1 = new BuyerAccount {BuyerAccountId = 1};
            var buyerAccount2 = new BuyerAccount {BuyerAccountId = 2};
            var advertisers = new List<Advertiser>
            {
                new Advertiser
                {
                    BuyerAccountId = buyerAccount1.BuyerAccountId,
                    BuyerAccount = buyerAccount1,
                    UserAdvertiserRoles = new List<UserAdvertiserRole>
                    {
                        new UserAdvertiserRole {UserId = userId}
                    }
                },
                new Advertiser
                {
                    BuyerAccountId = buyerAccount1.BuyerAccountId,
                    BuyerAccount = buyerAccount1,
                    UserAdvertiserRoles = new List<UserAdvertiserRole>
                    {
                        new UserAdvertiserRole {UserId = userId}
                    }
                },
                new Advertiser
                {
                    BuyerAccountId = buyerAccount2.BuyerAccountId,
                    BuyerAccount = buyerAccount2,
                    UserAdvertiserRoles = new List<UserAdvertiserRole>
                    {
                        new UserAdvertiserRole {UserId = userId}
                    }
                },
            };
            MockUnitOfWorkRepository<Advertiser>().Setup(x => x.Queryable())
                .Returns(advertisers.ToAsyncEnumerable());

            // Act
            var retVal = Mock.Create<AdvertiserService>().GetAdvertisers(queryOptions).ToList();

            // Assert
            Assert.That(retVal, Is.Not.Null);
            Assert.That(retVal.Count, Is.EqualTo(3));
        }
    }
}