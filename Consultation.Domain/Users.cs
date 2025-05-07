using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Domain
{
    public class Users
    {
        [Key]
        //Change name from UserID to UserNumber
        public int UserNumber { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        //Added nako ni siya as every register dapat mo input ug StudentID or FacultyID ang 
        // ang nag register
        public string UserID { get; set; }


    }
}
