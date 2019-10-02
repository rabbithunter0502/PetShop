using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Utinity
{
    class MemRegister
    {
        public long id { get; set; }
        public String Username { get; set; }
        public String passWord { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String avatar { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
        public String introduction { get; set; }
        public String gender { get; set; }
        public String birthday { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String salt { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public int status { get; set; }
    }
}
