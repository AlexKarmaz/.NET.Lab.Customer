using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.CustomerStruct
{
    public class StructCustomerEqualityByLastName : EqualityComparer<StructCustomer>
    {
        public override bool Equals(StructCustomer x, StructCustomer y)
        {
            return x.LastName == y.LastName;
        }

        public override int GetHashCode(StructCustomer obj)
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + obj.LastName.GetHashCode();
                return hash;
            }
        }
    }
}
