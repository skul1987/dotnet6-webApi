using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        public int id { get; set; }

        public string userName { get; set; } = string.Empty;

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        public List<Employee>? Employees { get;  set;}
    }
}