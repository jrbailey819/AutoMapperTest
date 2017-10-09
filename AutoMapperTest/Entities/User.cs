using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Entities
{
    public class User : Entity
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
