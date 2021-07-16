using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Claims_UnitTesting
{
    [TestClass]
    public class ClaimsRepoTesting
    {
        private ClaimsRepo _repo;
        private ClaimContent _content;

        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _content = new ClaimContent();

            _repo.AddClaimContentToList(_content);
        }

        [TestMethod]
        // Add Method
        public void AddToList_ShouldGetNotNull()
        {
            ClaimContent content = new ClaimContent();
            content.ClaimID = 1;
            ClaimsRepo repo = new ClaimsRepo();

            repo.AddClaimContentToList(content);
            ClaimContent infoFromDirectory = repo.GetClaimContent(1);

            Assert.IsNotNull(infoFromDirectory);
        }
        [TestMethod]
        public void UpdateClaim_ShouldReturnTrue()
        {
            ClaimContent newContent = new ClaimContent(2, ClaimType.Car, "Tree through window", 1000, DateTime.Now, DateTime.Today, true);
            bool updateResult = _repo.UpdateClaimInfo(2, newContent);
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(3, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalID, bool shouldUpdate)
        {
            ClaimContent newContent = new ClaimContent(2, ClaimType.Car, "Tree through window", 1000, DateTime.Now, DateTime.Now, true);
            bool updateResult = _repo.UpdateClaimInfo(originalID, newContent);
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveClaimContentFromList(_content.ClaimID);
            Assert.IsTrue(deleteResult);
        }
    }
}
