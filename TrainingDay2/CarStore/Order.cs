using System;
using System.Collections.Generic;
using System.Text;
using TrainingDay2.HotelApp;

namespace TrainingDay2.CarStore
{
    class Order
    {
        private int _id;

        private string _customer;

        private Car _car;

        private int _deliveryWeeks;

        private decimal _price;

        private Currency _currency;

        private bool delivered = false;




        public int DeliveryWeeks { get => _deliveryWeeks; set => _deliveryWeeks = value; }
        public decimal Price { get => _price; set => _price = value; }
        public Currency Currency { get => _currency; set => _currency = value; }
        public int Id { get => _id; set => _id = value; }
        public string Customer { get => _customer; set => _customer = value; }
        public bool Delivered { get => delivered; set => delivered = value; }
        internal Car Car { get => _car; set => _car = value; }
    }
}
