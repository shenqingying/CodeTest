using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class UserModel
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
