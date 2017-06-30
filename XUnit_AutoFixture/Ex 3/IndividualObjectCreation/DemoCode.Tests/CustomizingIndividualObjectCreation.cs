using System;
using System.Runtime.InteropServices;
using Ploeh.AutoFixture;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomizingIndividualObjectCreation
    {
        [Fact]
        public void Error()
        {
            var fixture = new Fixture();

            var flight = fixture.Create<FlightDetails>();
        }

        [Fact]
        public void OmitSettingSpecificProperties()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .Without(x => x.ArrivalAirportCode)
                                .Without(x => x.DepartureAirportCode)
                                .Create();
        }


        [Fact]
        public void OmitSettingAllProperties()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .OmitAutoProperties()
                                .Create();
        }

        [Fact]
        public void CustomizedBuilding()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .With(x => x.ArrivalAirportCode, "LAX")
                                .With(x => x.DepartureAirportCode, "LHR")
                                .Create();
        }

        [Fact]
        public void CustomizedBuildingWithActions()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.DepartureAirportCode, "LHR")
                .With(x => x.ArrivalAirportCode, "LAX")
                .Without(x => x.MealOptions)
                .Do(x => x.MealOptions.Add("Chicken"))
                .Do(x => x.MealOptions.Add("Fish"))
                .Create();


        }


        [Fact]
        public void CustomizedBuildingForAllTypesInFixture()
        {
            var fixture = new Fixture();

            fixture.Customize<FlightDetails>(fd =>
                fd.With(x => x.DepartureAirportCode, "LHR")
                  .With(x => x.ArrivalAirportCode, "LAX")
                  .With(x => x.AirlineName, "Fly Fly Premium Air")
                  .Without(x => x.MealOptions)
                  .Do(x => x.MealOptions.Add("Chicken"))
                  .Do(x => x.MealOptions.Add("Fish"))); // notice no .Create() is required here


            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();
        }

    }
}
