using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingDay2.CarStore
{
    class Car
    {
        private Producer _producer;
        private string _model;

        private int _year;

        public string Model { get => _model; set => _model = value; }
        public int Year { get => _year; set => _year = value; }
        internal Producer Producer { get => _producer; set => _producer = value; }
    }
}
