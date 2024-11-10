using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.ModelView
{
    public class LoginViewModel
    {
        [Required]
        public string TaiKhoan { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        public bool RememberMe { get; set; }
    }
}
