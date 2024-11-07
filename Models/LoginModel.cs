using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}