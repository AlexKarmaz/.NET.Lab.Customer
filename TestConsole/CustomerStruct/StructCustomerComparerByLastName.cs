using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.CustomerStruct
{
    public class StructCustomerComparerByLastName : Comparer<StructCustomer>
    {
        public override int Compare(StructCustomer x, StructCustomer y)
        {
            if (object.Equals(x, y)) { return 0; }
            return string.Compare(x.LastName, y.LastName);
        }
    }
}
