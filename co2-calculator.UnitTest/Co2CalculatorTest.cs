using Xunit;
using Calculator.Methods;
using Xunit.Sdk;

//Installed xunit.runner.console v2.4.1

namespace Co2calculator.UnitTest
{
    public class Co2CalculatorTest
    {
        //Testing structure
        //-Arrange
        //-Act
        //-Arsert

        [Theory]
        [InlineData(-2, false)]
        [InlineData(-10000, false)]
        [InlineData(-5.09, false)]
        [InlineData(double.MinValue, false)]
        public void GetValidity_DistanceEnteredLessThanZero_False(double x, bool expected)
        {
            //-Act
            Methods.GetDistanceValidity(x, out bool actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, false)]
        public void GetValidity_DistanceEnteredIsZero_False(double x, bool expected)
        {
            //-Act
            Methods.GetDistanceValidity(x, out bool actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(234.6, true)]
        [InlineData(double.MaxValue, true)]
        public void GetValidity_DistanceEnteredGreaterThanZero_True(double x, bool expected)
        {
            //-Act
            Methods.GetDistanceValidity(x, out bool actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("kg", 0.001)]
        public void GetMassMultiplicationFactor_MassEnteredInKg(string x, double expected)
        {
            //-Act
            Methods.GetMassMultiplicationFactor(x, out double actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("g", 1)]
        public void GetMassMultiplicationFactor_MassEnteredInG(string x, double expected)
        {
            //-Act
            Methods.GetMassMultiplicationFactor(x, out double actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("small-diesel-car", 142)]
        [InlineData("small-petrol-car", 154)]
        [InlineData("small-plugin-hybrid-car", 73)]
        [InlineData("small-electric-car", 50)]
        [InlineData("medium-diesel-car", 171)]
        [InlineData("medium-petrol-car", 192)]
        [InlineData("medium-plugin-hybrid-car", 110)]
        [InlineData("medium-electric-car", 58)]
        [InlineData("large-diesel-car", 209)]
        [InlineData("large-petrol-car", 282)]
        [InlineData("large-plugin-hybrid-car", 126)]
        [InlineData("large-electric-car", 73)]
        [InlineData("bus", 27)]
        [InlineData("train", 6)]
        public void GetEmissionValue_CheckAllValues(string x, int expected)
        {
            //-Act
            Methods.GetEmissionValue(x, out int actual);
            //-Arsert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("km", true, 1)]
        public void GetDistanceMultiplicationFactor_DistanceEnteredInKm(string x, bool expectedBool, double expected)
        {
            //-Act
            Methods.GetDistanceMultiplicationFactor(x, out bool actualBool, out double actual);
            //-Arsert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);

        }

        [Theory]
        [InlineData("m", true, 0.001)]
        public void GetDistanceMultiplicationFactor_DistanceEnteredInM(string x, bool expectedBool, double expected)
        {
            //-Act
            Methods.GetDistanceMultiplicationFactor(x, out bool actualBool, out double actual);
            //-Arsert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedBool, actualBool);
        }

        [Theory]
        [InlineData("sharp", false)]
        [InlineData("", false)]
        [InlineData("Rambo",false)]
        public void GetDistanceMultiplicationFactor_DistanceEnteredInOtherUnits(string x, bool expectedBool)
        {
            //-Act
            Methods.GetDistanceMultiplicationFactor(x, out bool actualBool, out double actual);
            //-Arsert
            Assert.Equal(expectedBool, actualBool);

        }

        [Theory]
        [InlineData("small-diesel-car", "kg", true, "kg")]
        [InlineData("small-petrol-car", "kg", true, "kg")]
        [InlineData("small-plugin-hybrid-car", "kg", true, "kg")]
        [InlineData("small-electric-car", "kg", true, "kg")]
        [InlineData("medium-diesel-car", "kg", true, "kg")]
        [InlineData("medium-petrol-car", "kg", true, "kg")]
        [InlineData("medium-plugin-hybrid-car", "kg", true, "kg")]
        [InlineData("medium-electric-car", "kg", true, "kg")]
        [InlineData("large-diesel-car", "kg", true, "kg")]
        [InlineData("large-petrol-car", "kg", true, "kg")]
        [InlineData("large-plugin-hybrid-car", "kg", true, "kg")]
        [InlineData("large-electric-car", "kg", true, "kg")]
        [InlineData("bus", "kg", true, "kg")]
        [InlineData("train", "kg", true, "kg")]
        [InlineData("small-diesel-car", "", true, "kg")]
        [InlineData("small-petrol-car", "", true, "kg")]
        [InlineData("small-plugin-hybrid-car", "", true, "kg")]
        [InlineData("small-electric-car", "", true, "kg")]
        [InlineData("medium-diesel-car", "", true, "kg")]
        [InlineData("medium-petrol-car", "", true, "kg")]
        [InlineData("medium-plugin-hybrid-car", "", true, "kg")]
        [InlineData("medium-electric-car", "", true, "kg")]
        [InlineData("large-diesel-car", "", true, "kg")]
        [InlineData("large-petrol-car", "", true, "kg")]
        [InlineData("large-plugin-hybrid-car", "", true, "kg")]
        [InlineData("large-electric-car", "", true, "kg")]
        [InlineData("bus", "", true, "kg")]
        [InlineData("train", "", true, "g")]
        public void GetMassOutputUnit_CheckAllVales(string transportationMethod, string output, bool exepectedUnitOfMassValidTrip, string exepectedMassOutputUnits)
        {
            //-Act
            Methods.GetMassOutputUnit(transportationMethod, output, out bool actualUnitOfMassValidTrip, out string actualMassOutputUnits);
            //-Arsert
            Assert.Equal(exepectedUnitOfMassValidTrip, actualUnitOfMassValidTrip);
            Assert.Equal(exepectedMassOutputUnits, actualMassOutputUnits);
        }

        [Theory]
        [InlineData("small-diesel-car", "jah", false)]
        [InlineData("small-petrol-car", "jah", false)]
        [InlineData("small-plugin-hybrid-car", "jah", false)]
        [InlineData("small-electric-car", "jah", false)]
        [InlineData("medium-diesel-car", "jah", false)]
        [InlineData("medium-petrol-car", "jah", false)]
        [InlineData("medium-plugin-hybrid-car", "jah", false)]
        [InlineData("medium-electric-car", "jah", false)]
        [InlineData("large-diesel-car", "jah", false)]
        [InlineData("large-petrol-car", "jah", false)]
        [InlineData("large-plugin-hybrid-car", "jah", false)]
        [InlineData("large-electric-car", "jah", false)]
        [InlineData("bus", "jah", false)]
        [InlineData("train", "jah", false)]
        public void GetMassOutputUnit_InValidVales(string transportationMethod, string output, bool exepectedUnitOfMassValidTrip)
        {
            //-Act
            Methods.GetMassOutputUnit(transportationMethod, output, out bool actualUnitOfMassValidTrip, out string actualMassOutputUnits);
            //-Arsert
            Assert.Equal(exepectedUnitOfMassValidTrip, actualUnitOfMassValidTrip);
   
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, true, true, false)]
        [InlineData(true, false, true, false)]
        [InlineData(true, true, false, false)]
        public void CheckTripValidity_CheckValidEntries(bool distaceValidTrip, bool unitOfDistanceValidTrip, bool unitOfMassValidTrip, bool expectedValidTrip)
        {
            //-Act
            Methods.CheckTripValidity(distaceValidTrip, unitOfDistanceValidTrip, unitOfMassValidTrip, out bool actualValidTrip);
            //-Arsert
            Assert.Equal(expectedValidTrip, actualValidTrip);
        }

        [Theory]
        [InlineData(171, 1, 0.001, double.MaxValue, "kg", 3.07405526061456E+307, true)]
        [InlineData(171, 1, 0.001, 15, "kg",2.6 ,true)]
        [InlineData(282, 1, 0.001, 1800.5, "kg", 507.7, true)]
        [InlineData(6, 0.001, 1, 14500, "g", 87, true)]
        [InlineData(6, 0.001, 0.001, 14500, "kg", 0.1, true)]        
        [InlineData(142, 1, 0.001, 34, "kg", 4.8, true)]
        [InlineData(154, 1, 0.001, 76, "kg", 11.7, true)]
        [InlineData(173, 1, 0.001, 32, "kg", 5.5, true)]
        [InlineData(50, 0.001, 1, 100, "kg", 5, true)]
        [InlineData(192, 1, 0.001, 23, "kg", 4.4, true)]
        [InlineData(110, 1, 0.001, 17, "kg", 1.9, true)]
        [InlineData(58, 1, 0.001, 35, "kg", 2, true)]
        [InlineData(209, 1, 0.001, 68, "kg", 14.2, true)]
        [InlineData(282, 1, 0.001, 53, "kg", 14.9, true)]
        [InlineData(126, 1, 0.001, 22, "kg", 2.8, true)]
        [InlineData(73, 1, 0.001, 67, "kg", 4.9, true)]
        [InlineData(27, 1, 0.001, 9, "kg", 0.2, true)]
        [InlineData(6, 1, 0.001, 1225, "g", 7.4, true)]
        public void CalculateEmission_ValidEntries(double emissionValue, double distanceMultiplicationFactor, double massMultiplicationFactor, double distance, string massOutputUnits, double massEmissionExpected, bool validTrip)
        {
            //-Act
            Methods.CalculateEmission(emissionValue, distanceMultiplicationFactor, massMultiplicationFactor, distance, massOutputUnits, out double massEmissionActual, validTrip);
            //-Arsert
            Assert.Equal(massEmissionExpected, massEmissionActual);
        }        

    }
}
