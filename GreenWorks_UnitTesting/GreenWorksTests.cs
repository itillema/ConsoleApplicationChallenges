using Green_Plan;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreenWorks_UnitTesting
{
    [TestClass]
    public class GreenWorksTests
    {
        [TestMethod]
        public void SetCarMake_ShouldSetCorrectCarMake()
        {
            CarInformation info = new CarInformation();

            info.CarMake = "Ford";

            string expected = "Ford";
            string actual = info.CarMake;

            Assert.AreEqual(expected, actual);
        }


    }
}
