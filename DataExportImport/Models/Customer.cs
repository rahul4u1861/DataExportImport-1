using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataExportImport.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "SSN")]
        public string SSN { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Display(Name = "Address Line 1")]

        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}