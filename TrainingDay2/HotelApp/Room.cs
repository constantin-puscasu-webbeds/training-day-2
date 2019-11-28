using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.HotelApp
{
    class Room : IPrinter
    {
        public const int RoomNameMinChars = 3;
        public const int RoomNameMaxChars = 250;

        public const int MinAdults = 1;
        public const int MaxAdults = 20;

        public const int MinChildren = 0;
        public const int MaxChildren = 20;
        



        private string _name;
        private int _adults;

        private int _children;

        internal Rate Rate { get; set; }

        /// <summary>
        /// The class must be instanciated with all properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="adults"></param>
        /// <param name="chidlren"></param>
        /// <param name="rate"></param>
        public Room(string name, int adults, int chidlren, Rate rate)
        {
            this.Name = name;
            this.Adults = adults;
            this.Children = chidlren;
            this.Rate = rate;
        }



        /// <summary>
        /// Name is free text, minimum with a minimum lenght of 3 chars
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set
            {
                if (value.Length < RoomNameMinChars || value.Length > RoomNameMaxChars)
                {
                    throw new ArgumentOutOfRangeException("Name", $"Room name lenght must be between {RoomNameMinChars} and {RoomNameMaxChars}.");
                }
                this._name = value;
            }
        }
        


        /// <summary>
        /// Manage number of adults
        /// </summary>
        public int Adults
        {
            get { return this._adults; }
            set
            {
                if (value < MinAdults || value > MaxAdults)
                {
                    throw new ArgumentOutOfRangeException("value", $"Number of adults must be within {MinAdults} and {MaxAdults}.");
                }
                this._adults = value;
            }
        }



        /// <summary>
        /// Manage number of children
        /// </summary>
        public int Children
        {
            get { return this._children; }
            set
            {
                if (value < MinChildren || value > MaxChildren)
                {
                    throw new ArgumentOutOfRangeException("Children", $"Number of children must be within {MinChildren} and {MaxChildren}.");
                }
                this._children = value;
            }
        }




  





        /// <summary>
        /// Return the price for a given number of days
        /// </summary>
        /// <param name="numberOfDays"></param>
        /// <returns></returns>
        public decimal GetPriceForDays(int numberOfDays)
        {
            return this.Rate.Amount * numberOfDays;
        }



        /// <summary>
        /// Prints to console all class properties
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Print Room instance: {0}", this.GetHashCode());
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Adults: {this.Adults}");
            Console.WriteLine($"Children: {String.Join(',', this.Children)}");
            Console.WriteLine($"Rate:");
            
            this.Rate.Print();
        }
    }
}
