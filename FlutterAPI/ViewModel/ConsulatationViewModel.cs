using Consultation.Domain;

namespace FlutterAPI.ViewModel
{
    public class ConsulatationViewModel
    {
        public string StudentName { get; set; }

        public string FacultyName { get; set; }

        public string CourseCode { get; set; }

        public TimeOnly  TimeStarted { get; set; }

        public TimeOnly TimeEnded { get; set; }

        public DateTime DateOfConsultation { get; set; }

    }
}
