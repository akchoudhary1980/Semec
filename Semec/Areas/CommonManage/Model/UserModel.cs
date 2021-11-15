using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Semec.Areas.CommonManage.Model
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Name")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "User Name should be 10 digit")]
        public string UserName { get; set; } // mobile 

        [Required(ErrorMessage = "Please Enter User Mobile")]
        [Display(Name = "Password")]
        public string Password { get; set; } // Temp by Default 

        [Display(Name = "Display Name")]
        public string DisplayName { get; set; } // Name from Employe 

        [Display(Name = "Email")]
        public string Email { get; set; } // Email from Employee 

        [Required(ErrorMessage = "Please Enter User Mobile")]
        [Display(Name = "Mobile")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number should be 10 digit")]
        public string Mobile { get; set; } // Primary key usename or mobile should be same 

        [Display(Name = "User Type")]
        public string UserType { get; set; } // Client or Admin

        [Display(Name = "Read Rights")]
        public bool ReadRights { get; set; } // yes only own Data

        [Display(Name = "Wright Rights")]
        public bool WrightRights { get; set; } // yes only own Data

        [Display(Name = "User Create Rights")]
        public bool UserCreateRights { get; set; } // No 

        [Display(Name = "Setting Rights")]
        public bool SettingRights { get; set; } // yes only own Data

        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; } // Active / Deactive    

        [Display(Name = "User Picture")]
        public string UserPicture { get; set; } // to connect it   
        
    }
}
