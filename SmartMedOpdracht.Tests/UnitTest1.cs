using System;
using Xunit;
using SmartMedOpdracht.Models;
using SmartMedOpdracht.Services;
using Moq;

namespace SmartMedOpdracht.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsQuantityBiggerThanOne()
        {
            var medicineServiceMock = new Mock<IMedicineService>();

            Medicine medicine1 = new Medicine("iddWRFV", "parecitmol", 2, DateTime.Now);
            Medicine medicine2 = new Medicine("iddWRFV", "parecitmol", -1, DateTime.Now);

            medicineServiceMock.Setup(p => p.QuantityGreaterThanOne(medicine1.quantity)).Returns(true);
            medicineServiceMock.Setup(p => p.QuantityGreaterThanOne(medicine2.quantity)).Returns(false);

        }
    }
}
