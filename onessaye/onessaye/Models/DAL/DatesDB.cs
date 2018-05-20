using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.DAL
{
    public class DatesDB
    {
        public int Id { get; set; }
        public int QuantityLeft { get; set; }
        public DateTime DateAvailable { get; set; }
        public int Schedule_Id { get; set; }
    }
}