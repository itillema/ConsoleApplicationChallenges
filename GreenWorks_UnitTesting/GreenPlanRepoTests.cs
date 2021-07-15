using Green_Plan;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreenWorks_UnitTesting
{
    [TestClass]
    public class GreenPlanRepoTests
    {
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            CarInformation info = new CarInformation();
            info.CarName = "Ford";
            GreenPlanRepo repo = new GreenPlanRepo();

            repo.AddCarInfoToList(info);
            CarInformation infoFromDirectory = repo.GetInfoByName("Ford");

            Assert.IsNotNull(infoFromDirectory);
        }
    }
}
