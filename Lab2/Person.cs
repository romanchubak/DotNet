using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        #region private
        private string _firstName;
        private string _secondName;
        private DateTime _birthday;
        #endregion
        
        #region Constructors
        public Person(string fName, string sName, DateTime bDay)
        {
            _firstName = fName;
            _secondName = fName;
            _birthday = bDay;
        }
        public Person()
        {
            _firstName = "";
            _secondName = "";
            _birthday = DateTime.Today;
        }
        public Person( Person person)
        {
            _firstName = person._firstName;
            _secondName = person._secondName;
            _birthday = person._birthday;
        }
        #endregion

        #region methods
        public object DeepCopy()
        {
            Person copy = new Person(_firstName, _secondName, _birthday);
            return copy;
        }
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person p = (Person)obj;
            return (_firstName.Equals(p._firstName)) && (_secondName.Equals(p._secondName)) && (_birthday.Equals(p._birthday));
        }
        public override int GetHashCode()
        {
            return _firstName.GetHashCode() ^ _secondName.GetHashCode() ^ _birthday.GetHashCode();
        }
        public static bool operator ==(Person x, Person y)
        {
            return x._firstName == y._firstName && x._secondName == y._secondName && x._birthday == y._birthday;
        }
        public static bool operator !=(Person x, Person y)
        {
            return !(x == y);
        }
        public override string ToString()
        {
            return " First Name: " + _firstName + ", Second Name: " + _secondName + ", birthday: " + _birthday;
        }
        public virtual string ToShortString() => " First Name: " + _firstName + ", Second Name: " + _secondName;
        #endregion
    }
}
