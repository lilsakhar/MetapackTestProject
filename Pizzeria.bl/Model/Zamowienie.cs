using System;

namespace Pizzeria.bl.Model
{
    public class Zamowienie
    {
        public int ID_zamowienia { get; set; }
        public DateTime Data { get; set; }
        public double Cena_zam { get; set; }
        public string Klient { get; set; }
        public string Email { get; set; }
        public string Uwagi { get; set; }
        
    }
}
