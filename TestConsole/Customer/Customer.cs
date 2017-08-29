using System;
using System.Collections.Generic;

namespace TestConsole
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>, IComparable
    {
        #region Public Properties 
        public int Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        #endregion

        public Customer(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return int.Equals(Id, other.Id) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            else return Equals((Customer)obj);
        }

        public bool Equals(Customer other, IEqualityComparer<Customer> eq)
        {
            if (ReferenceEquals(other, null))
                return false;

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

        public int CompareTo(Customer other)
        {
            if (Equals(other)) return 0;
            if (ReferenceEquals(other, null)) return 1;
            return Id.CompareTo(other.Id);
        }

        int IComparable.CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
                return 1;

            Customer otherCustomer = obj as Customer;
            if (!ReferenceEquals(otherCustomer, null))
                return CompareTo(otherCustomer);

            throw new ArgumentNullException($"Object is not a {typeof(Customer)}");
        }

        public int CompareTo(Customer other, IComparer<Customer> comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (ReferenceEquals(comparer, null))
                return CompareTo(other);

            return comparer.Compare(this, other);
        }

        public int CompareTo(Customer other, Comparison<Customer> comparer)
        {
            if (ReferenceEquals(other, null))
                return 1;

            if (ReferenceEquals(comparer, null))
                return CompareTo(other);

            return comparer(this, other);
        }

        public override string ToString() => $"Customer name: {Name}, Last name: {LastName}";

        public static bool Less (Customer lhs, Customer rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) < 0)
            {
                return true;
            }

            return false;
        }


        public static bool More (Customer lhs, Customer rhs)
        {
            if (lhs.Name.CompareTo(rhs.Name) > 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator == (Customer c1, Customer c2) => c1.Equals(c2);

        public static bool operator != (Customer c1, Customer c2) => !(c1==c2);

        public static bool operator < (Customer lhs, Customer rhs) => Less(lhs, rhs);

        public static bool operator > (Customer lhs, Customer rhs) => More (lhs, rhs);
        
    }
}
