using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.HotelApp
{
    class Hotel : IPrinter
    {
        public const int NameMinChars = 3;
        public const int NameMaxChars = 250;


        private string _name;
        private string _city;

        private List<Room> _rooms;



        /// <summary>
        /// all parameters required
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="rooms"></param>
        public Hotel(string name, string city, List<Room> rooms)
        {
            this.Name = name;
            this.City = city;
            this.Rooms = rooms;
        }


        /// <summary>
        /// Name is free text, minimum with a minimum lenght of 3 chars
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set
            {
                if (value.Length < NameMinChars || value.Length > NameMaxChars)
                {
                    throw new ArgumentOutOfRangeException("Name", $"Hotel name lenght must be between {NameMinChars} and {NameMaxChars}.");
                }
                this._name = value;
            }
        }


        /// <summary>
        /// Name is free text, minimum with a minimum lenght of 3 chars
        /// </summary>
        public string City
        {
            get { return this._city; }
            set
            {
                if (value.Length < NameMinChars || value.Length > NameMaxChars)
                {
                    throw new ArgumentOutOfRangeException("City", $"Hotel city lenght must be between {NameMinChars} and {NameMaxChars}.");
                }
                this._city = value;
            }
        }


        /// <summary>
        /// Manage the rooms list
        /// </summary>
        public List<Room> Rooms
        {
            get { return this._rooms; }
            set
            {
                if (value.Count < 1)
                {
                    throw new ArgumentOutOfRangeException("Rooms", "At least one room must be defined.");
                }
                this._rooms = value;
            }
        }




        /// <summary>
        /// Prints to console all class properties
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Print Hotel instance: {0}", this.GetHashCode());
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"City: {this.City}");

            foreach (Room tmp in this.Rooms)
            {
                tmp.Print();
            }
        }



        /// <summary>
        /// Get cheapest price for a number of rooms and a given occupancy
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <param name="adults"></param>
        /// <param name="chidlren"></param>
        /// <returns></returns>
        public decimal GetPriceForNumberOfRooms(int numberOfRooms, int adults, int chidlren, Currency currency)
        {
            decimal miniumTotalPrice = -1m;
            

            foreach(Room tmpRoom in this.Rooms)
            {
                if (tmpRoom.Adults >= adults && tmpRoom.Children >= chidlren && tmpRoom.Rate.Currency == currency && (tmpRoom.Rate.Amount < miniumTotalPrice || miniumTotalPrice == -1))
                {
                    miniumTotalPrice = tmpRoom.Rate.Amount;
                }
            }

            if(miniumTotalPrice > -1)
            {
                return numberOfRooms * miniumTotalPrice;
            }

            return miniumTotalPrice;

        }




        /// <summary>
        /// Find the Hotel room cheaper than one given price for a given occupancy and price
        /// </summary>
        /// <param name="price"></param>
        /// <param name="adults"></param>
        /// <param name="chidlren"></param>
        /// <returns></returns>
        public Room FindRoomCheaperThan(Rate price, int adults, int chidlren)
        {
            foreach(Room room in this.Rooms)
            {
                if(room.Rate.Currency == price.Currency && room.Rate.Amount < price.Amount && room.Adults >= adults && room.Children >= chidlren)
                {
                    return room;
                }
            }

            return null;
        }


    }
}
