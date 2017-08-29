using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class CustomerEqualityByLastName : EqualityComparer<Customer>
    {
        public override bool Equals(Customer x, Customer y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.LastName == y.LastName;
        }

        public override int GetHashCode(Customer obj)
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
