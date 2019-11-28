using System;
using System.Collections.Generic;
using TrainingDay2.HotelApp;


namespace TrainingDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hotel App Start");

            try
            {
                Rate rate1 = new Rate(123.333m, Currency.EUR);
                Room room1 = new Room("Standard Room", 2, 2, rate1);
                
                Rate rate2 = new Rate(570.5m, Currency.EUR);
                Room room2 = new Room("Superior Room", 4, 3, rate2);

                List<Room> hotel1_rooms = new List<Room>();
                hotel1_rooms.Add(room1);
                hotel1_rooms.Add(room2);

                Hotel hotel1 = new Hotel("Hotel Ramada", "Iasi", hotel1_rooms);
                hotel1.Print();


                var priceTotal = hotel1.GetPriceForNumberOfRooms(3, 3, 2, Currency.EUR);
                Console.WriteLine($"Minimum price for criteria: {priceTotal}");


                HotelApplication hotelApp = new HotelApplication();
                hotelApp.AddHotel(hotel1);


                Rate rate3 = new Rate(75m, Currency.EUR);
                Room room3 = new Room("Standard Room", 2, 2, rate3);

                Rate rate4 = new Rate(300m, Currency.EUR);
                Room room4 = new Room("Junior Suite", 2, 0, rate4);

                List<Room> hotel2_rooms = new List<Room>();
                hotel2_rooms.Add(room3);
                hotel2_rooms.Add(room4);

                Hotel hotel2 = new Hotel("Hotel International", "Iasi", hotel2_rooms);
                hotelApp.AddHotel(hotel2);


                Rate searchPrice = new Rate(320, Currency.EUR);
                string searchCriteria = $" Price {searchPrice.Amount} {searchPrice.Currency}";
                Room roomFound = hotelApp.FindRoomCheaperThan(searchPrice, 2, 1);
                if(roomFound == null)
                {
                    Console.WriteLine($"No room found for criteria: {searchCriteria}");
                }
                else
                {
                    Console.WriteLine($"Room {roomFound.Name} found for criteria: sa{searchCriteria}");
                }

                hotelApp.RemoveHotel("Hotel Ramada");

            }
            catch (ArgumentOutOfRangeException outOfRange)
            {

                Console.WriteLine("Error: {0}", outOfRange.Message);
            }




        }
    }
}
