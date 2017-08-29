using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public struct StructCustomer : IEquatable<StructCustomer>, IComparable<StructCustomer>, IComparable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }

        public StructCustomer(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }

        public bool Equals(StructCustomer other)
        {
            return int.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            else return Equals((StructCustomer)obj);
        }

        public bool Equals(StructCustomer other, IEqualityComparer<StructCustomer> eq)
        {
            if (ReferenceEquals(eq, null))
                return Equals(other);

            return eq.Equals(this, other);
        }


        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + Id.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(StructCustomer other)
        {
            if (Equals(other)) return 0;
            
            return Id.CompareTo(other.Id);
        }

        int IComparable.CompareTo(object obj)
        {
            if(!(obj is StructCustomer))
            {
                throw new InvalidOperationException($"Object is not a {typeof(StructCustomer)}");
            }
            return CompareTo((StructCustomer)obj);
        }

        public int CompareTo(StructCustomer other, IComparer<StructCustomer> comparer)
        {
            if (ReferenceEquals(comparer, null))
                return CompareTo(other);

            return comparer.Compare(this, other);
        }

        public int CompareTo(StructCustomer other, Comparison<StructCustomer> comparer)
        {
            if (ReferenceEquals(comparer, null))
                return CompareTo(other);

            return comparer(this, other);
        }

        public override string ToString() => $"Customer name: {Name}, Last name: {LastName}";

        public static bool less(StructCustomer lhs, StructCustomer rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) != 1)
            {
                return true;
            }

            return false;
        }


        public static bool more(StructCustomer lhs, StructCustomer rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) == 1)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(StructCustomer lhs, StructCustomer rhs) => less(lhs, rhs);


        public static bool operator >(StructCustomer lhs, StructCustomer rhs) => more(lhs, rhs);

        public static bool operator ==(StructCustomer c1, StructCustomer c2) => c1.Equals(c2);

        public static bool operator !=(StructCustomer c1, StructCustomer c2) => !(c1 == c2); 

    }
}
