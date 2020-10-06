using System;
using System.Collections.Generic;
using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Badges_Repository_Tests
{
    [TestClass]
    public class BadgeItemsRepositoryTests
    {
        private BadgeItems _content;
        private BadgeItemsRepository _repo;
        [TestMethod]
        public void AddBadge_ShouldGetCorrectBoolean()
        {
            //ARRANGE
            BadgeItems newClaim = new BadgeItems();
            BadgeItemsRepository repo = new BadgeItemsRepository();

            //ACT
            bool addResult = repo.AddNewBadge(newClaim);

            //ASSERT
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectListOfClaims()
        {
            //ARRANGE
            BadgeItems newObject = new BadgeItems();
            BadgeItemsRepository repository = new BadgeItemsRepository();
            repository.AddNewBadge(newObject);

            //ACT
            List<BadgeItems> listOfBadgeItems = repository.GetAllBadges();

            //ASSERT
            bool claimHasItems = listOfBadgeItems.Contains(newObject);
            Assert.IsTrue(claimHasItems);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeItemsRepository();
            _content = new BadgeItems(33245, new List<string>());
            _repo.AddNewBadge(_content);
        }
        [TestMethod]
        public void GetById_ShouldReturnCorrectItem()
        {
            //ACT
            BadgeItems searchResult = _repo.GetBadgeById(33245);

            //ASSERT
            Assert.AreEqual(_content, searchResult);
        }

    }
}
