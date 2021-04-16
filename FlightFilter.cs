using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightCodingTest
{
    public class FlightFilter : FilterMethods
    {
        /// <summary>
        /// Вывод отфильтрованных данных в консоль
        /// </summary>
        /// <param name="flights">Отфилтрованные данные</param>
        public void GetAllFlights(List<Flight> flights)
        {
            foreach (Flight item in flights)
            {
                for (int i = 0; i < item.Segments.Count; i++)
                {
                    Console.WriteLine(item.Segments[i].DepartureDate.ToString() + " -> " + item.Segments[i].ArrivalDate.ToString());
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Исключение из данных вылетов до текущего момента времени
        /// </summary>
        /// <param name="flights">Даннные о перелетах</param>
        /// <returns></returns>
        public List<Flight> GetDepartureTimeBeforeNow(IList<Flight> flights)
        {
            return flights.Where(p => 
                                 new Flight { 
                                     Segments = p.Segments
                                     .TakeWhile(s => s.DepartureDate > DateTime.Now)
                                     .ToList() 
                                 }.Segments.Count > 0)
                           .ToList();
        }

        /// <summary>
        /// Исключения из данных перелетов с датой прилёта раньше даты вылета
        /// </summary>
        /// <param name="flights">Данные о перелетах</param>
        /// <returns></returns>
        public List<Flight> GetArrivalDateLessDepartureDate(IList<Flight> flights)
        {
            return flights.Where(p => 
                                 new Flight { 
                                     Segments = p.Segments
                                     .TakeWhile(s => s.ArrivalDate > s.DepartureDate)
                                     .ToList() 
                                 }.Segments.Count > 0)
                           .ToList();
        }        

        /// <summary>
        /// Исключение из данных перелетов, где общее время проведенное на земле
        /// превышает 2 часа
        /// </summary>
        /// <param name="flights">Данные о перелетах</param>
        /// <returns></returns>
        public List<Flight> GetFlightWithTransferMoreThanTwoHours(IList<Flight> flights)
        {
            foreach (var item in flights.ToList())
            {
                if (item.Segments.Count > 1)
                {
                    LinkedList<Segment> segments = new LinkedList<Segment>(item.Segments.Select(s => s));

                    var segmentsItem = segments.First;
                    DateTime dateTime = new DateTime();

                    while (segmentsItem.Next != null)
                    {
                        dateTime += segmentsItem.Next.Value.DepartureDate - segmentsItem.Value.ArrivalDate;
                        segmentsItem = segmentsItem.Next;
                    }

                    if (dateTime.Hour > 2)
                    {
                        flights.Remove(item);
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            return (List<Flight>)flights;
        }
    }
}
