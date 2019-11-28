using System;
using System.Collections.Generic;
using System.Text;
using TrainingDay2.HotelApp;

namespace TrainingDay2.CarStore
{
    static class CarStoreApplication
    {

        public static void Run()
        {
            Customer alex = new Customer
            {
                Name = "Alex"
            };


            Producer ford = new Producer
            {
                Name = "Skoda"
            };


            Store fordStore = new Store
            {
                Name = "Ford Store",
                City = "Bucuresti"
            };

            Car focus2015FromFordStore = new Car
            {
                Producer = ford,
                Model = "Focus",
                Year = 2015
            };


            Order alexFordStoreOrder = new Order
            {
                Id = 10,
                Car = focus2015FromFordStore,
                Customer = alex.Name,
                Price = 15000m,
                Currency = Currency.EUR,
                DeliveryWeeks = 4
            };


            fordStore.AddOrder(alexFordStoreOrder);



            Store skodaStore = new Store
            {
                Name = "Skoda Store",
                City = ""
            };

            Car focus2015FromSkodaStore = new Car
            {
                Producer = ford,
                Model = "Focus",
                Year = 2015
            };

            Order alexSkodaStoreOrder = new Order
            {
                Id = 23,
                Car = focus2015FromSkodaStore,
                Customer = alex.Name,
                Price = 14000m,
                Currency = Currency.EUR,
                DeliveryWeeks = 3
            };

            skodaStore.AddOrder(alexSkodaStoreOrder);


            fordStore.CencelOrder(alexFordStoreOrder.Id);

            skodaStore.DeliverOrder(alexSkodaStoreOrder.Id, 3);



        }

    }
}
