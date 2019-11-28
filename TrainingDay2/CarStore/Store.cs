using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.CarStore
{
    class Store
    {
        private string _name;
        private string _city;

        private Dictionary<int, Order> _orders;





        public string Name { get => _name; set => _name = value; }
        public string City { get => _city; set => _city = value; }
        internal Dictionary<int, Order> Orders { get => _orders; set => _orders = value; }


        public Store()
        {
            this._orders = new Dictionary<int, Order>();
        }


        /// <summary>
        /// Get human readable text from order
        /// </summary>
        /// <param name="newOrder"></param>
        /// <param name="prefixAction"></param>
        /// <returns></returns>
        private StringBuilder OrderDetailsToString(Order newOrder, string prefixAction)
        {
            StringBuilder shelper = new StringBuilder();

            shelper.Append($"{prefixAction} by store name '{this.Name}' ");
            shelper.Append($"from the customer '{newOrder.Customer}' ");
            shelper.Append($"for the car '{newOrder.Car.Producer.Name} {newOrder.Car.Model} {newOrder.Car.Year}' ");
            shelper.Append($"with price '{newOrder.Price} {newOrder.Currency}' ");
            shelper.Append($"and delivery of '{newOrder.DeliveryWeeks} weeks'.");

            return shelper;
        }




        /// <summary>
        /// Register a new order for a customer and a car
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public bool AddOrder(Order newOrder)
        {
            if(this.Orders.ContainsKey(newOrder.Id))
            {
                Console.WriteLine($"order id {newOrder.Id} of store {this.Name} already exists.");
                return false;
            }

            this.Orders.Add(newOrder.Id, newOrder);

            Console.WriteLine("--------------------------------------------------------------------------------------------");
            StringBuilder shelper = this.OrderDetailsToString(newOrder, "New order received");

            Console.WriteLine(shelper);

            return true;
        }   



        /// <summary>
        /// Cancel an existing order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool CencelOrder(int orderId)
        {
            if (!this.Orders.ContainsKey(orderId))
            {
                Console.WriteLine($"Could not find order id {orderId} of store {this.Name}.");
                return false;
            }

            StringBuilder orderDetails = this.OrderDetailsToString(this.Orders[orderId], "Order cancelled");

            this.Orders.Remove(orderId);

            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine(orderDetails);

            return true;

        }



        /// <summary>
        /// Mark order as delivered
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="weeksDelivered"></param>
        /// <returns></returns>
        public bool DeliverOrder(int orderId, int weeksDelivered)
        {
            if (!this.Orders.ContainsKey(orderId))
            {
                Console.WriteLine($"Could not find order id {orderId} of store {this.Name}.");
                return false;
            }


            StringBuilder orderDetails = this.OrderDetailsToString(this.Orders[orderId], $"Order delivered after {weeksDelivered} weeks ");

            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine(orderDetails);

            this.Orders[orderId].Delivered = true;
            this.Orders[orderId].DeliveryWeeks = weeksDelivered;


            return true;

        }

    }
}
