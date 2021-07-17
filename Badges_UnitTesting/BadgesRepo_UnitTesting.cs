using Microsoft.VisualStudio.TestTools.UnitTesting;
using Badges;
using System;

namespace Badges_UnitTesting
{
    [TestClass]
    public class BadgesRepo_UnitTesting
    {
        private BadgeRepo _repo;
        private Badge _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            _content = new Badge(1,, "Gold Badge");

            _repo.AddBadgeInfo(_content);
        }

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            Badge info = new Badge();
            info.BadgeName = "Gold";
            BadgeRepo repo = new BadgeRepo();

            repo.AddBadgeInfo(info);
            Badge infoFromDirectory = repo.GetInfoByName("Gold");

            Assert.IsNotNull(infoFromDirectory);
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            Badge newInfo = new Badge();
            bool updateResult = _repo.UpdateExistingInfo("Blue", newInfo);

            Assert.IsTrue(updateResult);

        }

        [DataTestMethod]
        [DataRow("Gold", true)]
        [DataRow("Blue", false)]
        public void UpdateDoors_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            Badge newInfo = new Badge();

            // Act
            bool updateResult = _repo.GetInfoByName(originalName, newInfo);
            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteInfo_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveAllDoorInfoFromList(_content.BadgeName);
            Assert.IsTrue(deleteResult);
        }
    
    }
}
