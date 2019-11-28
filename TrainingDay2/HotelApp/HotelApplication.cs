using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.HotelApp
{
    class HotelApplication
    {
        Dictionary<string, Hotel> _hotels;


        public HotelApplication()
        {
            this._hotels = new Dictionary<string, Hotel>();
        }


        /// <summary>
        /// Add a new hotel to the app
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public bool AddHotel(Hotel hotel)
        {
            if(this._hotels.ContainsKey(hotel.Name))
            {
                return false;
            }

            this._hotels.Add(hotel.Name, hotel);

            Console.WriteLine($"Hotel {hotel.Name} was added to the application.");
            return true;

        }



        /// <summary>
        /// Remove a hotel from the application
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public bool RemoveHotel(string hotelName)
        {
            if(!this._hotels.ContainsKey(hotelName))
            {
                return false;
            }

            this._hotels.Remove(hotelName);
            Console.WriteLine($"Hotel {hotelName} was removed from the application.");

            return true;

        }



        /// <summary>
        /// Find a room cheaper than one value for a given occupancy
        /// </summary>
        /// <param name="price"></param>
        /// <param name="adults"></param>
        /// <param name="chidlren"></param>
        /// <returns></returns>
        public Room FindRoomCheaperThan(Rate price, int adults, int chidlren)
        {
            foreach(KeyValuePair<string, Hotel> entry in this._hotels)
            {
                Room roomFound = entry.Value.FindRoomCheaperThan(price, adults, chidlren);
                if (roomFound != null)
                {
                    return roomFound;
                }
            }

            return null;
        }
 


    }
}
