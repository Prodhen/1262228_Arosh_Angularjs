﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1262228_Arosh_NGJs.Models
{
    public class Result
    {
        [Key]
        public int ResultID { get; set; }
        public int? Bangla { get; set; }
        public int? English { get; set; }
        public int? GeneralKnowlede { get; set; }
        public int? Ict { get; set; }



        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]


        //for future


        //public int? TotalMark
        //{
        //    get { return (Bangla + English + GeneralKnowlede + Ict); }
        //    private set { }
        //}

        //public int StudentID { get; set; }
        //public virtual Student Student { get; set; }
    }
}
