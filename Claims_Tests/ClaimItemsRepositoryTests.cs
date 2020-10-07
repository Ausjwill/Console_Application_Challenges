using System;
using System.Collections.Generic;
using Claim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Tests
{
    [TestClass]
    public class ClaimItemsRepositoryTests
    {
        private ClaimItems _content;
        private ClaimItemsRepository _repo;
        [TestMethod]
        public void AddClaim_ShouldGetCorrectBoolean()
        {
            //ARRANGE
            ClaimItems newClaim = new ClaimItems();
            ClaimItemsRepository repo = new ClaimItemsRepository();

            //ACT
            bool addResult = repo.AddNewClaim(newClaim);

            //ASSERT
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectListOfClaims()
        {
            //ARRANGE
            ClaimItems newObject = new ClaimItems();
            ClaimItemsRepository repository = new ClaimItemsRepository();
            repository.AddNewClaim(newObject);

            //ACT
            List<ClaimItems> listOfClaimItems = repository.GetAllClaims();

            //ASSERT
            bool claimHasItems = listOfClaimItems.Contains(newObject);
            Assert.IsTrue(claimHasItems);
        }
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimItemsRepository();
            _content = new ClaimItems(4, ClaimType.Car, "Wreck on I-70.", 2000f, new DateTime(18, 04, 27), new DateTime(18, 04, 28), true);
            _repo.AddNewClaim(_content);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectItem()
        {
            //ACT
            ClaimItems searchResult = _repo.GetItemsById(4);

            //ASSERT
            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void GetNextClaim_ShouldReturnCorrectItem()
        {
            //ACT
            ClaimItems nextClaim = _repo.GetItemsById(4);

            //ASSERT
            Assert.AreEqual(_content, nextClaim);
        }

        [TestMethod]
        public void DeleteMenuItems_ShouldReturnTrue()
        {
            //ARRANGE
            ClaimItems deleteContent = _repo.GetItemsById(4);

            //ACT
            bool removeResult = _repo.RemoveClaim(deleteContent);

            //ASSERT
            Assert.IsTrue(removeResult);
        }
    }
}
