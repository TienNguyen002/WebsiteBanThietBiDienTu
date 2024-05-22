using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.User
{
    public class UserEditModel
    {
        public string Id { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
