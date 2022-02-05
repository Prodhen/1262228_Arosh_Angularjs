using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace _1262228_Arosh_NGJs.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }



        //for Future
        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        //public string BloodGroup { get; set; }     

        public string Email { get; set; }

        //public string Mobile { get; set; }

        public bool? Status { get; set; } = false;
        //public string Picture { get; set; }
        //[NotMapped]
        //public IFormFile UploadImage { get; set; }



        public int? UnitID { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
