using System;

namespace Task6._9
{
    public class Ticket
    {
        public double ID { get; set; }
        public double Row { get; set; }
        public double Place { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public string Yarus { get; set; }
        public string Status { get; set; }

    public Ticket(double id,double row,double place, string name, DateTime time, double price,string yarus,string status )
        {
            ID = id;
            Row = row;
            Place = place;
            Name = name;
            Time = time;
            Price = price;
            Yarus = yarus;
            Status = status;
        }
    }
}
