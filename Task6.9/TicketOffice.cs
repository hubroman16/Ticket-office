using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6._9
{
    public class TicketOffice
    {
        List<Ticket> tickets;

        public TicketOffice()
        {
            tickets = new List<Ticket>();
        }

        public delegate void ActionHandler(string message);//Делегат
        public event ActionHandler Ticketsold;
        public void soldcompleted()
        {
            if (Ticketsold != null)
                Ticketsold("Билет был продан!");
        }
        // метод добавления 
        public bool Add(Ticket ticket)
        {
            tickets.Add(ticket);
            return true;
        }
        //поиск по цене
        public List<Ticket> Find_Price(double min, double max)
        {
            tickets = tickets.Where(x => x.Price>min & x.Price < max).ToList();
            return tickets;
        }
        //поиск по времени
        public List<Ticket> Find_Time(DateTime time)
        {
            tickets = tickets.Where(x => x.Time.Equals(time)).ToList();
            return tickets;
        }
        //поиск по месту
        public List<Ticket> Find_Place(double row,double place)
        {
            tickets = tickets.Where(x => x.Row.Equals(row)& x.Place.Equals(place)).ToList();
            return tickets;
        }
        //поиск по ярусу
        public List<Ticket> Find(string yarus)
        {
            tickets = tickets.Where(x => x.Yarus.Equals(yarus)).ToList();
            return tickets;
        }
        //обновление базы
        public List<Ticket> upd()
        {
            List<Ticket> results = new List<Ticket>();
            foreach (var item in tickets)
            {
                Ticket ticket = (Ticket)item;
                results.Add(ticket);
            }
            return results;
        }
        //очистка базы
        public void Clear()
        {
            tickets.Clear();
        }
    }
}
