using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BureauOfMeteorology.Facade.Tests
{
    [TestClass]
    public class ObservationFacadeTest
    {
        [TestMethod]
        public void CanGetObservation()
        {
            var facade = new ObservationFacade();
            var result = facade.GetObservation("95770");
        }
    }
}
