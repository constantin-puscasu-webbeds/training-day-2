using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.HotelApp
{
    /// <summary>
    /// Stores information for a hotel room rate
    /// </summary>
    class Rate : IPrinter
    {

        public const decimal RateMinValue = 0m;
        public const decimal RateMaxValue = 100000000;

        private decimal _amount;

        private Currency _currency;



        /// <summary>
        /// Constructor to guarantee all instances have valid price and currency
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        public Rate(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }



        /// <summary>
        /// Amount must with max 3 decimals, greater than 0
        /// </summary>
        public decimal Amount
        {
            get { return this._amount; }
            set
            {
                if(value < RateMinValue || value > RateMaxValue)
                {
                    throw new ArgumentOutOfRangeException("Amount", $"The price must be a between {RateMinValue} and {RateMaxValue}.");
                }
                if(Decimal.Round(value, 3) != value)
                {
                    throw new ArgumentOutOfRangeException("amount", "The price must have maximum 3 decimals.");
                }

                this._amount = value;
            }
        }




        /// <summary>
        /// Currency integrity is guaranteed by the struct Currency
        /// </summary>
        public Currency Currency
        {
            get { return this._currency; }
            set
            {
                this._currency = value;
            }
        }


        /// <summary>
        /// Prints to console all class properties
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Print Rate instance: {0}", this.GetHashCode());
            Console.WriteLine($"amount: {this.Amount} in currency: {this.Currency}");
        }
    }
}
