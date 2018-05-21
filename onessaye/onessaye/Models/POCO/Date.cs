using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Date
    {
        public int Id { get; set; }
        public int QuantityLeft { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime DateAvailable { get; set; }
        public Date(DateTime AvailableDate, int quantity)
        {
            DateAvailable = AvailableDate;
            QuantityLeft = quantity;
            QuantityAvailable = quantity;
        }
        public Date(){}
        public override string ToString()
        {
            return string.Concat("quantity available: " + QuantityLeft + " Date: " + DateAvailable+ "\br");
        }
    }
}