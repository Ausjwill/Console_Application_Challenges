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
            BadgeItems newBadge = new BadgeItems();
            BadgeItemsRepository repo = new BadgeItemsRepository();

            //ACT
            bool addResult = repo.AddNewBadge(newBadge);

            //ASSERT
            Assert.IsTrue(addResult);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeItemsRepository();
            _content = new BadgeItems(33245, new List<string>() { "A1", "A2", "A3" } );
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
