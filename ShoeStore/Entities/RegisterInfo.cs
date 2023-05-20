
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ShoeStore.Entities
{
    public class RegisterInfo
    {
        [Required(ErrorMessage = "Please enter username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).{8,64})",ErrorMessage ="Password must have at least 1 number, 1 lower - upper case and a special character!")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter phone")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }

    }
}