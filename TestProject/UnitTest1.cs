using Xunit;
using FlightCodingTest;
using System.Collections.Generic;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetDepartureTimeBeforeNow_Test()
        {
            FlightBuilder flightBuilder = new FlightBuilder();

            FlightFilter flightFilter = new FlightFilter();
            List<Flight> flightsTest = flightFilter.GetDepartureTimeBeforeNow(flightBuilder.GetFlights());

            Assert.Equal(5, flightsTest.Count);
        }

        [Fact]
        public void GetArrivalDateLessDepartureDate_Test()
        {
            FlightBuilder flightBuilder = new FlightBuilder();

            FlightFilter flightFilter = new FlightFilter();
            List<Flight> flightsTest = flightFilter.GetArrivalDateLessDepartureDate(flightBuilder.GetFlights());

            Assert.Equal(5, flightsTest.Count);
        }

        [Fact]
        public void GetFlightWithTransferMoreThanTwoHours()
        {
            FlightBuilder flightBuilder = new FlightBuilder();

            FlightFilter flightFilter = new FlightFilter();
            List<Flight> flightsTest = flightFilter.GetFlightWithTransferMoreThanTwoHours(flightBuilder.GetFlights());

            Assert.Equal(4, flightsTest.Count);
        }
    }
}
