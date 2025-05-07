using Consultation.Domain.Enum;

namespace FlutterAPI.ViewModel
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public string UserID { get; set; }

        public UserType UserType { get; set; }
    }
}
