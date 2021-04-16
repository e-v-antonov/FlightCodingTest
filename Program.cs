using System;
using System.Collections.Generic;

namespace FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();

            IList<Flight> flights = new List<Flight>();
            flights = flightBuilder.GetFlights();

            FilterMethods flightFilter = new FlightFilter();

            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("Фильтр №1");
            Console.ResetColor();
            flightFilter.GetAllFlights(flightFilter.GetDepartureTimeBeforeNow(flights));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Фильтр №2");
            Console.ResetColor();
            flightFilter.GetAllFlights(flightFilter.GetArrivalDateLessDepartureDate(flights));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Фильтр №3");
            Console.ResetColor();
            flightFilter.GetAllFlights(flightFilter.GetFlightWithTransferMoreThanTwoHours(flights));

            Console.ReadKey();
        }
    }
}
