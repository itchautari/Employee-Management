using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Helpers
{
    public class CurrentUser
    {
        public static int userId {
            get {
                return 1;
            }
        }

        public string userName
        {
            get
            {
                return "";
            }
        }

        public int usersGroup
        {
            get
            {
                return 1;
            }
        }
    }
}
