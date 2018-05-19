using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Schedule
    {
        public int Id { get; set; }
        public List<Date> ListDate { get; set; }
        public Schedule()
        {
            ListDate = new List<Date>();
        }
        public void AddDate(Date date)=> ListDate.Add(date);
        public override string ToString()
        {
            string toString="";
            foreach (Date date in ListDate)
            {
                toString += date.ToString();
            }
            return toString;
        }
    }
}