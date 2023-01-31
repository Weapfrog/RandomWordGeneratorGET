using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomWordGeneratorGET.Core
{
    class ConnectionHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=ANOOBREKHAN;Initial Catalog=RandomWordGeneratorDb;Integrated Security=True";
            }
        }
    }
}
