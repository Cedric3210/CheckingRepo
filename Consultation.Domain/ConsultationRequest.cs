using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Domain.Enum;

namespace Consultation.Domain
{
    public class ConsultationRequest
    {
        [Key]
        public int ConsultationID { get; set; }

        public DateTime DateSchedule { get; set; }

        public string Concern { get; set; }

        public DateTime DateRequested { get; set; }
        
        //Added nako ni kay needed ug data type kung kanusa mag start ug end ang session
        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndedTime { get; set; }

        public Status Status { get; set; }

        public string? DisapprovedReason { get; set; }

        public string SubjectCode { get; set; } 

        public Notification Notification { get; set; } 

        //Change nako ni from int to string
        [ForeignKey(nameof(StudentID))]
        public string StudentID { get; set; }

        [ForeignKey(nameof(FacultyID))]
        public string FacultyID { get; set; }

        //Added kay needed if pag one-to-one relationship ta
        public virtual Student Student { get; set; }

        public virtual Faculty Faculty { get; set; }


    }
}