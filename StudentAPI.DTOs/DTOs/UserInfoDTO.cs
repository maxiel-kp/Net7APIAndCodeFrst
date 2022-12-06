using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.DTOs.DTOs
{
    public class UserInfoDTO
    {
        public int Id { get; set; } //Auto increatment
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
}
