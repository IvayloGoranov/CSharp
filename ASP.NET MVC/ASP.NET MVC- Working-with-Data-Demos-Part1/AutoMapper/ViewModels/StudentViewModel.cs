using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoMapper.ViewModels
{
    public class StudentViewModel
    {
        public string FullName { get; set; }

        public decimal AverageGrade { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}