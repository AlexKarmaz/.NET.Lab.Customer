using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class CustomerComparerByLastName : Comparer<Customer>
    {
        public override int Compare(Customer x, Customer y)
        {
            if(object.Equals(x,y)) { return 0; }

            if (ReferenceEquals(x, y))
                return 0;

            return string.Compare(x.LastName, y.LastName);
        }
    }
}
