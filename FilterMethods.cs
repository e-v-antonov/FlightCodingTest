using System.Collections.Generic;

namespace FlightCodingTest
{
    public interface FilterMethods
    {
        void GetAllFlights(List<Flight> flights);
        List<Flight> GetDepartureTimeBeforeNow(IList<Flight> flights);
        List<Flight> GetArrivalDateLessDepartureDate(IList<Flight> flights);
        List<Flight> GetFlightWithTransferMoreThanTwoHours(IList<Flight> flights);
    }
}
