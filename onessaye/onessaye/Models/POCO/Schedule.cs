using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Schedule
    {
        public virtual List<DateTime> ListDate { get; set; }
        public virtual int QuantityLeft { get; set; }
    }
}