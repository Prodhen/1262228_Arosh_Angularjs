﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1262228_Arosh_NGJs.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public string Transaction { get; set; }
        //public int StudentID { get; set; }
        //public virtual Student Student { get; set; }

    }
}
