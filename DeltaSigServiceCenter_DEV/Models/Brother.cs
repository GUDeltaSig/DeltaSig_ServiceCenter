using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeltaSigServiceCenter_DEV.Models
{

    public class Brother
    {
        public int BrotherID { get; set; }
        
        [Required]
        public string FullName { get; set; }

        public int NumOfHours { get; set; }
        
        [Required]
        public string ClassStanding { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNum { get; set; }

    }


}