﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onessaye.Models.POCO
{
    public class Schedule
    {
        public List<DateTime> ListDate { get; set; }
        public int QuantityLeft { get; set; }
    }
}