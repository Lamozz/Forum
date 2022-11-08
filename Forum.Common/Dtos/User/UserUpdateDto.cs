using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Common.Dtos.User
{
    public class UserUpdateDto
    {
        [MaxLength(60, ErrorMessage = "So much symbols")]
        public string Status { get; set; }

        [MinLength(1, ErrorMessage = "Need more symbols")]
        [MaxLength(20, ErrorMessage = "So much symbols")]
        public string UserName { get; set; }

    }
}
